using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using fad2.Backend;
using fad2.UI.Properties;
using log4net;
using MetroFramework;
using MetroFramework.Controls;

namespace fad2.UI
{
    /// <summary>
    /// Copy Files
    /// </summary>
    public partial class FileCopy : MetroUserControl
    {
        private readonly bool _autoMode;
        private readonly Connection _connection;
        private readonly string[] _imageFileTypes = Properties.Settings.Default.ImageFileTypes.Split(',');
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly long _maxThumbnailSize = Properties.Settings.Default.MaxImageThumbSize;
        private readonly int _metroTileMargin = Properties.Settings.Default.MetroTileMargin;
        private readonly int _metroTileSize = Properties.Settings.Default.MetroTileSize;
        private readonly string[] _movieFilesTypes = Properties.Settings.Default.VideoFileTypes.Split(',');

        private readonly string _programSettingsFile = $"{Application.StartupPath}\\{Properties.Settings.Default.ProgramSettingsFile}";

        private string _currentFlashairPath;
        private List<string> _selectedFilesLeft = new List<string>();


        private List<string> _selectedFilesRight = new List<string>();


        /// <summary>
        ///     Automode-Download
        /// </summary>
        public FileCopy(bool automode=false)
        {
            InitializeComponent();
            _connection = new Connection(_programSettingsFile);
            _autoMode = automode;
            if (automode)
            {
                FileSplitter.Panel2Collapsed = true;
                FileSplitter.Panel2.Hide();
            }
        }
    

        /// <summary>
        ///     Load Contents from Flashair
        /// </summary>
        /// <param name="flashairPath">Flashair-Path</param>
        /// <param name="localPath">Localpath</param>
        public void LoadContents(string flashairPath, string localPath)
        {
            LeftPanel.Controls.Clear();
            LoadLocalContents(localPath);
            LoadFlashairInfoAsync(flashairPath);
        }

        private void CopyFilesAsync()
        {
            DisablePanels();
            if (_autoMode)
            {
                var allTiles = LeftPanel.Controls.OfType<MetroTile>().ToList();
                _selectedFilesLeft = new List<string>();
                foreach (var tile in allTiles)
                {
                    var fileInfo = (FlashAirFileInformation) tile.Tag;
                    _selectedFilesLeft.Add(fileInfo.Filename);
                }
            }
            var worker = new BackgroundWorker();

            ProgressPanel.Visible = true;

            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = true;
            worker.DoWork += WorkerCopyFilesDoWork;
            worker.ProgressChanged += WorkerCopyFilesProgressChanged;
            worker.RunWorkerCompleted += WorkerCopyFilesCompleted;

            worker.RunWorkerAsync();
        }

        private void WorkerCopyFilesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MetroMessageBox.Show(this, e.Error.Message);
            }
            if (e.Cancelled)
            {
                MetroMessageBox.Show(this, Resources.OperationCancelled);
            }

            MetroMessageBox.Show(this, Resources.CopyFinished);
            ProgressPanel.Visible = false;
            RemoveMarkedElements();
            EnablePanels();
        }

        private void WorkerCopyFilesProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            Progress.Maximum = 100;
            Progress.Value = e.ProgressPercentage;
            Application.DoEvents();
            if (e.UserState == null) return;
            if (e.UserState is MetroTile)
            {
                ShowPreviewFromTile((MetroTile) e.UserState);
            }
            else if (e.UserState is string)
            {
                CurrentAction.Text = (string) e.UserState;
            }
            else if (e.UserState is MetroMessageBoxProperties)
            {
                var props = (MetroMessageBoxProperties) e.UserState;
                if (MetroMessageBox.Show(this, props.Message, props.Title, props.Buttons, props.Icon) == DialogResult.Abort)
                {
                    worker.CancelAsync();
                }
            }
        }

        private void WorkerCopyFilesDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = CopyFiles(worker, e);
        }

        private void LoadFlashAirThumbs(BackgroundWorker worker)
        {
            var counter = 0;
            var tiles = LeftPanel.Controls.OfType<MetroTile>().ToList();
            worker.ReportProgress(0, Resources.ReadingThumbnailsFromFlashair);
            var maximum = tiles.Count;
            foreach (var tile in tiles)
            {
                var progress = 100*counter/maximum;
                var fileInfo = (FlashAirFileInformation) tile.Tag;
                worker.ReportProgress(progress, string.Format(Resources.ReadingThumnailNo, counter, maximum));
                TryGetFlashAirThumb(tile, fileInfo);
                counter++;
            }
        }

        private void LoadFlashairInfoAsync(string path)
        {
            DisablePanels();
            _currentFlashairPath = path;
            var worker = new BackgroundWorker();
            LeftPanel.Controls.Clear();
            path = path.Replace("\\", "/");
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = true;
            worker.DoWork += WorkerListFilesDoWork;
            worker.ProgressChanged += WorkerListFilesProgressChanged;
            worker.RunWorkerCompleted += WorkerListFilesCompleted;
            worker.RunWorkerAsync(path);

            ProgressPanel.Visible = true;
            CurrentAction.Text = Resources.LoadingInfo;
        }

        private void LoadFlashairThumbsAsync()
        {
            var worker = new BackgroundWorker();
            while (worker.IsBusy)
            {
                return;
                // another download still in progress
            }

            ProgressPanel.Visible = true;
            CurrentAction.Text = Resources.LoadingThumbnails;
            DisablePanels();
            Application.DoEvents();

            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = true;
            worker.DoWork += WorkerDownloadThumbsDoWork;
            worker.ProgressChanged += WorkerDownloadThumbsProgressChanged;
            worker.RunWorkerCompleted += WorkerDownloadThumbsCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerDownloadThumbsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CurrentAction.Text = Resources.ReadyToCopy;
            LeftPanel.Refresh();
            foreach (var control in LeftPanel.Controls.OfType<MetroTile>()) { control.Refresh(); }
            Application.DoEvents();
            if (!_autoMode)
            {
                EnablePanels();
                if (!_autoMode) return;
            }
            CopyFilesAsync();
        }

        private void WorkerDownloadThumbsProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressPanel.Visible = true;
            CurrentAction.Text = Resources.LoadingThumbnails;
            Progress.Maximum = 100;
            Progress.Value = e.ProgressPercentage;

            if (e.UserState is string)
            {
                CurrentAction.Text = (string) e.UserState;
            }
            LeftPanel.Refresh();
            foreach (var control in LeftPanel.Controls.OfType<MetroTile>()) { control.Refresh(); }
            Application.DoEvents();
        }

        private void WorkerDownloadThumbsDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            LoadFlashAirThumbs(worker);
        }

        private void WorkerListFilesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResizeTiles(LeftPanel);
            if (_connection.Settings.LoadThumbs)
            {
                LoadFlashairThumbsAsync();
            }
            else
            {
                if (_autoMode)
                {
                    CopyFilesAsync();
                }
            }
            ProgressPanel.Visible = false;

            RemoveMarkedElements();
            EnablePanels();
        }

        private void WorkerListFilesProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            Progress.Maximum = 100;
            Progress.Value = e.ProgressPercentage;
            if (e.UserState == null) return;
            if (e.UserState is string)
            {
                CurrentAction.Text = (string) e.UserState;
            }
            else if (e.UserState is MetroTile)
            {
                var tile = (MetroTile) e.UserState;
                FileTooltip.SetToolTip(tile, tile.Text);
                tile.Click += LeftTile_Click;
                LeftPanel.Controls.Add(tile);
                tile.Refresh();
            }
            else if (e.UserState is MetroMessageBoxProperties)
            {
                var props = (MetroMessageBoxProperties) e.UserState;
                try
                {
                    if (MetroMessageBox.Show(this, props.Message, props.Title, props.Buttons, props.Icon) == DialogResult.Cancel)
                    {
                        worker.CancelAsync();
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                    worker.CancelAsync();
                }
            }
        }

        private void WorkerListFilesDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = LoadFlashairInfo(worker, e, (string) e.Argument);
        }

        private int LoadFlashairInfo(BackgroundWorker worker, DoWorkEventArgs e, string path)
        {
            if (path.Length > 1 && path[0] != '/')
            {
                path = "/" + path;
            }
            var maxValue = 0;
            _log.Info($"Read information from {path}");
            worker.ReportProgress(0, string.Format(Resources.ReadingFlashAirInfoAtPath, path));
            int imageCount;
            try
            {
                _log.Debug($"Download filecount for {path}");
                imageCount = _connection.GetFileCount(path);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                // could not read Number of files. Just ignore this for now. Just download Thumbs and don't show the progress
                imageCount = int.MaxValue;
            }
            if (path.Length > 1 && !_autoMode)
            {
                // parent Tile
                var parentDirectory = path.LastIndexOf("/") == 0 ? "/" : path.Substring(0, path.LastIndexOf("/"));
                var tile = new MetroTile
                {
                    Text = "..",
                    Width = _metroTileSize,
                    Height = _metroTileSize,
                    Tag = new FlashAirFileInformation
                    {
                        Directory = parentDirectory,
                        Filename = string.Empty,
                        IsDirectory = true
                    },
                    Style = MetroColorStyle.Green
                };
                worker.ReportProgress(0, tile);
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                path = "/";
            }

            worker.ReportProgress(0, string.Format(Resources.ReadingInfoFromFilesAtPath, imageCount, path));

            if (imageCount <= 0) return maxValue;

            List<FlashAirFileInformation> allFiles;
            try
            {
                _log.Debug($"Get {imageCount} FileSplitter from {path}");
                allFiles = _connection.GetFiles(path);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                worker.ReportProgress(0, new MetroMessageBoxProperties(null) {Buttons = MessageBoxButtons.RetryCancel, Icon = MessageBoxIcon.Error, Title = Resources.ErrorFlashairGenericTitle, Message = Resources.ErrorDownloadingFilelist});
                e.Cancel = true;
                return 0;
            }


            if (allFiles != null)
            {
                // start with the directories:
                // No ReadOnly, cause the FlashAir-SystemImage is readonly. ANd we do not want to copy that every time
                var nonHiddenfiles = allFiles.Where(af => !af.Hidden && !af.SystemFile && !af.ReadOnly).ToList();
                maxValue = nonHiddenfiles.Count;

                var counter = 0;


                foreach (var singleFile in nonHiddenfiles.Where(nhf => nhf.IsVolume || nhf.IsDirectory))
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return 0;
                    }
                    var progress = 100*counter/maxValue;
                    // there shouldn't really be any volumes on that disc, but doesn't hurt to check
                    worker.ReportProgress(progress);
                    counter++;

                    if (!path.EndsWith("/"))
                    {
                        path += '/';
                    }
                    if (_autoMode)
                    {
                        LoadFlashairInfo(worker, e, path + singleFile.Filename);
                    }
                    else
                    {
                        var tile = new MetroTile
                        {
                            Text = singleFile.Filename,
                            Width = _metroTileSize,
                            Height = _metroTileSize,
                            Tag = singleFile,
                            Style = MetroColorStyle.Yellow
                        };
                        worker.ReportProgress(progress, tile);
                    }
                }
                foreach (var singleFile in nonHiddenfiles.Where(nhf => !nhf.IsVolume && !nhf.IsDirectory))
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return 0;
                    }
                    var progress = 100*counter/maxValue;
                    worker.ReportProgress(progress);
                    counter++;
                    if (_autoMode)
                    {
                        switch (_connection.Settings.FileTypesToCopy)
                        {
                            case (int) ProgramSettings.FileTypes.Images:
                                if (!_imageFileTypes.Contains(singleFile.Extension.ToLower()))
                                {
                                    continue;
                                }
                                break;
                            case (int) ProgramSettings.FileTypes.Videos:
                                if (!_imageFileTypes.Contains(singleFile.Extension.ToLower()) && !_movieFilesTypes.Contains(singleFile.Extension.ToLower()))
                                {
                                    continue;
                                }
                                break;
                        }
                    }
                    var tile = new MetroTile
                    {
                        Text = singleFile.Filename,
                        Width = _metroTileSize,
                        Height = _metroTileSize,
                        Tag = singleFile
                    };
                    worker.ReportProgress(progress, tile);
                }
            }

            return maxValue;
        }

        private string GetSpeed(long size, TimeSpan duration)
        {
            var seconds = duration.TotalSeconds;
            if (seconds.CompareTo(0) == 0)
            {
                return "lotta TBytes/s";
            }
            var currentByteSpeed = size/seconds;
            var unit = "Bytes/s";
            if (currentByteSpeed > 1024)
            {
                currentByteSpeed = currentByteSpeed/1024;
                unit = "KBytes/s";
            }
            if (currentByteSpeed > 1024)
            {
                currentByteSpeed = currentByteSpeed/1024;
                unit = "MBytes/s";
            }
            return $"{currentByteSpeed:N} {unit}";
        }

        private int CopyFiles(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var counter = 0;
            var duration = TimeSpan.FromSeconds(1);
            long lastSize = 0;
            worker.ReportProgress(0, Resources.CopyingFiles);

            var cardId = _connection.GetCid();
            var appId = _connection.GetAppName();

            if (LeftPanel.Controls.OfType<MetroTile>().Any())
            {
                _log.Info($"Start upload of {_selectedFilesLeft.Count} files");
                var allTiles = LeftPanel.Controls.OfType<MetroTile>().ToList();

                var max = allTiles.Count;
                foreach (var tile in allTiles)
                {
                    var progress = 100*counter/max;

                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    worker.ReportProgress(progress, tile);
                    var fileInfo = (FlashAirFileInformation) tile.Tag;
                    if (!_selectedFilesLeft.Contains(fileInfo.Filename)) continue;


                    var currentByteSpeed = GetSpeed(lastSize, duration);


                    worker.ReportProgress(progress, string.Format(Resources.CopyFileOfAtSpeed, counter + 1, max, fileInfo.Filename, currentByteSpeed));

                    var targetFolder = _autoMode ? CreateTargetFolder(fileInfo, cardId, appId) : LocalPath.Text;
                    var targetFile = Path.Combine(targetFolder, fileInfo.Filename);
                    var doDelete = _autoMode && _connection.Settings.DeleteFiles;
                    var doCopy = true;
                    if (File.Exists(targetFile))
                    {
                        if (!_autoMode)
                        {
                            doCopy = MetroMessageBox.Show(this, string.Format(Resources.OverwriteText, targetFile), Resources.OverWriteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        }
                        else
                        {
                            switch (_connection.Settings.ExistingFiles)
                            {
                                case (int) ProgramSettings.OverwriteModes.Copy:
                                    targetFile = Path.Combine(targetFolder, $"{DateTime.Now:yyMMdd-HHss}{fileInfo.Filename}");
                                    break;
                                case (int) ProgramSettings.OverwriteModes.Never:
                                    var targetFileInfo = new FileInfo(targetFile);
                                    doCopy = targetFileInfo.CreationTime < fileInfo.PictureTaken;
                                    break;
                                default:
                                    doCopy = _connection.Settings.ExistingFiles == (int) ProgramSettings.OverwriteModes.Always;
                                    break;
                            }
                        }
                        doDelete &= doCopy;
                    }
                    if (doCopy)
                    {
                        var startTick = DateTime.Now;
                        Stream sourceFileStream = null;
                        try
                        {
                            sourceFileStream = _connection.DownloadFile(fileInfo.Directory, fileInfo.Filename);
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex);

                            if (ex is WebException && ((WebException) ex).Status == WebExceptionStatus.NameResolutionFailure)
                            {
                                worker.ReportProgress(progress, new MetroMessageBoxProperties(null) {Buttons = MessageBoxButtons.OK, Icon = MessageBoxIcon.Error, Title = Resources.CannotFindFlashairTitle, Message = Resources.CannotFindFlashairMessage});
                            }
                            else
                            {
                                worker.ReportProgress(progress, new MetroMessageBoxProperties(null) {Buttons = MessageBoxButtons.OKCancel, Icon = MessageBoxIcon.Error, Title = Resources.ErrorFlashairGenericTitle, Message = string.Format(Resources.FailedDownloadingFile, fileInfo.Filename)});
                            }
                        }
                        if (sourceFileStream == null) continue;
                        try
                        {
                            using (var fileStream = File.Create(targetFile))
                            {
                                try
                                {
                                    sourceFileStream.CopyTo(fileStream);
                                    lastSize = fileStream.Length;
                                }
                                catch (Exception ex)
                                {
                                    _log.Error(ex);
                                    doDelete = false;
                                }
                            }
                            duration = DateTime.Now - startTick;
                            if (doDelete)
                            {
                                _connection.DeleteFile(fileInfo.Directory, fileInfo.Filename);
                            }
                        }
                        catch (Exception ex)
                        {
                               _log.Error(ex);
                        }
                    }
                    counter++;

                    worker.ReportProgress(counter*100/max);
                }
            }
            return counter;
        }


        private string CreateTargetFolder(FlashAirFileInformation fileInfo, string cardId, string appId)
        {
            // cardID=0, appId=1, Date=2

            var targetFolderName = string.Format(_connection.Settings.FolderFomat, cardId, appId, fileInfo.PictureTaken);

            var downloadFolder = new DirectoryInfo(_connection.Settings.LocalPath);
            return !downloadFolder.Exists ? null : Directory.CreateDirectory(Path.Combine(downloadFolder.FullName, targetFolderName)).FullName;
        }

        private void TryGetFlashAirThumb(MetroTile tile, FlashAirFileInformation fileInformation)
        {
            try
            {
                _log.Debug($"Download thumbnail {fileInformation.Directory} {fileInformation.Filename}");
                var thumBitmap = _connection.DownloadThumbnail(fileInformation.Directory, fileInformation.Filename, Properties.Settings.Default.ImageFileTypes);
                if (thumBitmap == null)
                {
                    tile.Style = MetroColorStyle.Red;
                    return;
                }
                Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;
                var thumb = thumBitmap.GetThumbnailImage(_metroTileSize, _metroTileSize, myCallback, IntPtr.Zero);

                tile.Style = MetroColorStyle.Blue;

                tile.TileImage = thumb;

                tile.UseTileImage = true;
                tile.Refresh();
            }
            catch (Exception ex)
            {
                // Could not download Thumb after 5 retries. Well. Just a thumb. Let's ignore this

                _log.Error(ex);
            }
        }

        private void LoadLocalContents(string localPath)
        {
            DisablePanels();
            try
            {
                CurrentAction.Text = Resources.ReadLocalDir;
                ProgressPanel.Visible = true;

                var currentDirectory = new DirectoryInfo(localPath);
                var files = currentDirectory.GetFiles();
                var folders = currentDirectory.GetDirectories();

                RightTiles.Controls.Clear();

                if (Directory.Exists(localPath))
                {
                    LocalPath.Text = localPath;
                    if (localPath.Length > 2)
                    {
                        // parent Tile
                        var parentDirectory = localPath.LastIndexOf("\\") == 0 ? "\\" : localPath.Substring(0, localPath.LastIndexOf("\\"));
                        var tile = new MetroTile
                        {
                            Text = "..",
                            Width = _metroTileSize,
                            Height = _metroTileSize,
                            Tag = parentDirectory,
                            Style = MetroColorStyle.Green
                        };
                        tile.Click += RightTile_Click;
                        RightTiles.Controls.Add(tile);
                    }


                    Progress.Maximum = folders.Length;
                    var counter = 0;
                    foreach (var folder in folders.OrderBy(fld => fld.Name))
                    {
                        var tile = new MetroTile
                        {
                            Text = folder.Name, Width = _metroTileSize, Height = _metroTileSize, Style = MetroColorStyle.Yellow,
                            Tag = folder
                        };
                        tile.Click += RightTile_Click;
                        FileTooltip.SetToolTip(tile, folder.Name);
                        RightTiles.Controls.Add(tile);
                        Progress.Value = counter;
                        counter++;
                        Application.DoEvents();
                    }
                    Progress.Maximum = folders.Length;
                    counter = 0;
                    foreach (var fileInfo in files.OrderBy(fld => fld.Name))
                    {
                        if (!fileInfo.Name.Contains('.') && _connection.Settings.FileTypesToCopy != (int) ProgramSettings.FileTypes.AllFiles)
                        {
                            continue;
                        }

                        var tile = new MetroTile
                        {
                            Text = fileInfo.Name, Width = _metroTileSize, Height = _metroTileSize,
                            Tag = fileInfo
                        };
                        tile.Click += RightTile_Click;
                        FileTooltip.SetToolTip(tile, fileInfo.Name);
                        TryGetThumb(tile, fileInfo);
                        RightTiles.Controls.Add(tile);
                        Progress.Value = counter;
                        counter++;
                        Application.DoEvents();
                    }
                }
                ResizeTiles(RightTiles);
                ProgressPanel.Visible = false;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                MetroMessageBox.Show(this, "That path seems to be terribly wrong.");
            }
            EnablePanels();
        }


        private bool ThumbnailCallback()
        {
            return false;
        }

        private void TryGetThumb(MetroTile tile, FileInfo fileInfo)
        {
            try
            {
                if (fileInfo.Length > _maxThumbnailSize) return;
                var validExtensions = Properties.Settings.Default.ImageFileTypes.Split(',');
                var extension = Path.GetExtension(fileInfo.Name).ToLower();
                if (!validExtensions.Contains(extension)) return;
                Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;
                var thumBitmap = new Bitmap(fileInfo.FullName);
                var thumb = thumBitmap.GetThumbnailImage(_metroTileSize, _metroTileSize, myCallback, IntPtr.Zero);
                tile.TileImage = thumb;
                tile.UseTileImage = true;
                tile.Refresh();
            }
            catch (Exception ex)
            {
                // No valid Image File as it seems. Not a big deal. Just a missing THumbnail
                _log.Error(ex);
            }
        }

        private void ResizeTiles(Control parentControl)
        {
            try
            {
                var maxWidth = parentControl.Width;
                if (maxWidth < _metroTileSize + _metroTileMargin)
                {
                    return;
                }
                var currentX = -_metroTileSize - _metroTileMargin;
                var currentY = 0;

                foreach (var control in parentControl.Controls.OfType<MetroTile>())
                {
                    if (currentX + _metroTileSize*2 + _metroTileMargin <= maxWidth)
                    {
                        currentX += _metroTileSize + _metroTileMargin;
                    }
                    else
                    {
                        currentY += _metroTileSize + _metroTileMargin;
                        currentX = 0;
                    }
                    control.Left = currentX + _metroTileMargin/2;
                    control.Top = currentY + _metroTileMargin/2;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private void RightPanel_Layout(object sender, LayoutEventArgs e)
        {
            ResizeTiles(RightTiles);
            Refresh();
        }

        private void LeftPanel_Layout(object sender, LayoutEventArgs e)
        {
            ResizeTiles(LeftPanel);
            Refresh();
        }


        private void ShowPreviewFromTile(MetroTile tile)
        {
            var fileData = (FlashAirFileInformation) tile.Tag;
            SinglePreviewThumb.TileImage = tile.TileImage;
            SinglePreviewThumb.UseTileImage = true;
            ImageFolderContent.Text = fileData.Directory;
            ImageFilenameContent.Text = fileData.Filename;

            var kbSize = (double) fileData.Size/1024;
            var mbSize = kbSize/1024;
            var gbSize = mbSize/1024;

            if (gbSize > 1)
            {
                ImageSizeContent.Text = $"{gbSize:N} GByte";
            }
            else if (mbSize > 1)
            {
                ImageSizeContent.Text = $"{mbSize:N} MByte";
            }
            else if (kbSize > 1)
            {
                ImageSizeContent.Text = $"{kbSize:N} KByte";
            }
            else
            {
                ImageSizeContent.Text = $"{fileData.Size} Byte";
            }
            ImageInfoPanel.Visible = true;
            SinglePreviewThumb.Refresh();
            Application.DoEvents();
        }

        private void MarkElement(List<string> list, string filename, MetroTile tile)
        {
            if (list.Contains(filename))
            {
                tile.Style = MetroColorStyle.Blue;
                list.Remove(filename);
                tile.UseTileImage = true;
            }
            else
            {
                tile.Style = MetroColorStyle.Magenta;
                list.Add(filename);
                tile.UseTileImage = false;
            }
            ShowCopyPanel();
        }

        private void ShowCopyPanel()
        {
            if (_autoMode)
            {
                CopyPanel.Visible = false;
            }
            else
            {
                CopyToFlashAir.Visible = _selectedFilesRight.Count > 0;
                CopyFromFlashAir.Visible = _selectedFilesLeft.Count > 0;
                CopyPanel.Visible = _selectedFilesRight.Count > 0 || _selectedFilesLeft.Count > 0;
            }
        }

        private void RemoveMarkedElements()
        {
            _selectedFilesLeft = new List<string>();
            _selectedFilesRight = new List<string>();
            foreach (var tile in LeftPanel.Controls.OfType<MetroTile>())
            {
                var fileInfo = (FlashAirFileInformation) tile.Tag;
                if (!fileInfo.IsDirectory && !fileInfo.IsDirectory)
                {
                    tile.Style = MetroColorStyle.Blue;
                    tile.UseTileImage = true;
                }
            }

            foreach (var tile in RightTiles.Controls.OfType<MetroTile>())
            {
                if (!(tile.Tag is FileInfo)) continue;
                tile.Style = MetroColorStyle.Blue;
                tile.UseTileImage = true;
            }
        }

        private void RightTile_Click(object sender, EventArgs e)
        {
            var tile = (MetroTile) sender;

            if (tile.Tag == null) return;
            if (tile.Tag is string)
            {
                // ".."
                RightTiles.Controls.Clear();
                LoadLocalContents((string) tile.Tag);
                _selectedFilesRight = new List<string>();
            }
            else if (tile.Tag is DirectoryInfo)
            {
                var dir = (DirectoryInfo) tile.Tag;
                RightTiles.Controls.Clear();
                LoadLocalContents(dir.FullName);
                _selectedFilesRight = new List<string>();
            }
            else if (tile.Tag is FileInfo)
            {
                var file = (FileInfo) tile.Tag;
                MarkElement(_selectedFilesRight, file.FullName, tile);
            }
        }

        private void LeftTile_Click(object sender, EventArgs e)
        {
            if (_autoMode) return;
            var tile = (MetroTile) sender;
            var fileInfo = (FlashAirFileInformation) tile.Tag;
            if (fileInfo.IsDirectory || fileInfo.IsVolume)
            {
                if (_autoMode) return;
                LeftPanel.Controls.Clear();
                LoadFlashairInfoAsync(Path.Combine(fileInfo.Directory, fileInfo.Filename));
                _selectedFilesLeft = new List<string>();
            }
            else
            {
                MarkElement(_selectedFilesLeft, fileInfo.Filename, tile);
                Application.DoEvents();
                ShowPreviewFromTile(tile);
            }
        }

        private void LocalPath_KeyDown(object sender, KeyEventArgs e)
        {
            var path = (MetroTextBox) sender;
            if (e.KeyValue == (int) Keys.Enter)
            {
                LoadLocalContents(path.Text);
            }
        }

        private void CopyToFlashAir_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                _connection.SetUploadDirectory(_currentFlashairPath);

                var worker = new BackgroundWorker {WorkerReportsProgress = true};

                worker.DoWork += WorkerCopyFilesToFlashAirDoWork;
                worker.ProgressChanged += WorkerCopyFilesToFlashAirProgressChanged;
                worker.RunWorkerCompleted += WorkerCopyFilesToFlashAirCompleted;
                worker.RunWorkerAsync(_selectedFilesRight);
                ProgressPanel.Visible = true;
                CurrentAction.Text = Resources.CopyToFlashAir;
                Progress.Maximum = 100;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private void WorkerCopyFilesToFlashAirCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (int) e.Result;
            if (result == 0)
            {
                MetroMessageBox.Show(this, $"Successfully copied {_selectedFilesRight.Count} files.");
                _selectedFilesRight = new List<string>();
            }
            else
            {
                MetroMessageBox.Show(this, $"{result} from {_selectedFilesRight.Count} files weren't copied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            ProgressPanel.Visible = false;
            ImageInfoPanel.Visible = false;
            LoadFlashairInfoAsync(_currentFlashairPath);
            LoadLocalContents(LocalPath.Text);
            EnablePanels();
            RemoveMarkedElements();
        }

        private void DisablePanels()
        {
            LeftPanel.Enabled = false;
            RightPanel.Enabled = false;
        }

        private void EnablePanels()
        {
            LeftPanel.Enabled = true;
            RightPanel.Enabled = true;
        }

        private void WorkerCopyFilesToFlashAirProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                ImageInfoPanel.Visible = true;
                var imageTile = RightTiles.Controls.OfType<MetroTile>().First(tile => tile.Tag is FileInfo && ((FileInfo) tile.Tag).FullName == (string) e.UserState);
                SinglePreviewThumb.TileImage = imageTile.TileImage;
                var fileInfo = (FileInfo) imageTile.Tag;
                ImageFolderContent.Text = fileInfo.DirectoryName;
                ImageFilenameContent.Text = fileInfo.Name;
                ImageSizeContent.Text = $"{fileInfo.Length} Bytes";
                SinglePreviewThumb.UseTileImage = true;
                SinglePreviewThumb.Refresh();
                Application.DoEvents();
            }
            else
            {
                Progress.Value = e.ProgressPercentage;
                CurrentAction.Text = (string) e.UserState;
            }
        }

        private void WorkerCopyFilesToFlashAirDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            var filesToCopy = (List<string>) e.Argument;
            var maximum = filesToCopy.Count;
            if (maximum == 0) return;

            var counter = 0;
            var errorCount = 0;
            worker.ReportProgress(0, $"Uploading {filesToCopy[0]} to Flashair");
            foreach (var filename in filesToCopy)
            {
                var now = DateTime.Now;
                long filesize;
                if (!_connection.UploadFile(filename, out filesize))
                {
                    errorCount++;
                }
                var duration = DateTime.Now - now;
                if (worker.CancellationPending)
                {
                    e.Result = -1;
                    return;
                }
                counter++;

                var currentByteSpeed = GetSpeed(filesize, duration);
                worker.ReportProgress(counter*100/maximum, $"Uploaded {filename} with {currentByteSpeed}");
                worker.ReportProgress(-1, filename);
            }
            e.Result = errorCount;
        }

        private void CopyFromFlashAir_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressPanel.Visible = true;
                CurrentAction.Text = Resources.CopyFromFlashAir;
                Progress.Maximum = 100;
                CopyFilesAsync();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }
    }
}