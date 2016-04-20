using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using fad2.Backend;
using fad2.UI.Properties;
using log4net;
using MetroFramework;
using MetroFramework.Controls;

namespace fad2.UI
{
    public partial class AutoMode : MetroUserControl
    {
        private readonly Connection _connection;
        private readonly string[] _imageFileTypes = Properties.Settings.Default.ImageFileTypes.Split(',');
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly long _maxThumbnailSize = Properties.Settings.Default.MaxImageThumbSize;
        private readonly int _metroTileMargin = Properties.Settings.Default.MetroTileMargin;
        private readonly int _metroTileSize = Properties.Settings.Default.MetroTileSize;
        private readonly string[] _movieFilesTypes = Properties.Settings.Default.VideoFileTypes.Split(',');

        private readonly Fad _parent;
        private readonly string _programSettingsFile = $"{Application.StartupPath}\\{Properties.Settings.Default.ProgramSettingsFile}";

        /// <summary>
        /// Automode-Download
        /// </summary>
        public AutoMode()
        {
            InitializeComponent();
            _parent = (Fad) Parent.Parent.Parent;
            _connection = new Connection(_programSettingsFile);
        }

        /// <summary>
        /// Load Contents from Flashair
        /// </summary>
        /// <param name="flashairPath">Flashair-Path</param>
        /// <param name="localPath">Localpath</param>
        public void LoadContents(string flashairPath, string localPath)
        {
            LeftPanel.Controls.Clear();
            LoadLocalContents(localPath);
            LoadFlashairInfo(flashairPath);
            LoadFlashAirThumbs();
            CurrentAction.Text = Resources.ReadyToCopy;
            StartCopy.Visible = true;
        }


        private void LoadFlashAirThumbs()
        {
            var counter = 0;
            var tiles = LeftPanel.Controls.OfType<MetroTile>().ToList();
            Progress.Maximum = tiles.Count;
            CurrentAction.Text = Resources.ReadingThumbnailsFromFlashair;
            foreach (var tile in tiles)
            {
                var fileInfo = (FlashAirFileInformation) tile.Tag;
                CurrentAction.Text = string.Format(Resources.ReadingThumnailNo, counter, Progress.Maximum);
                Progress.Value = counter;
                TryGetFlashAirThumb(tile, fileInfo);
                tile.Refresh();
                Application.DoEvents();
                counter++;
            }
        }

        private void LoadFlashairInfo(string path)
        {
            _log.Info($"Read information from {path}");
            CurrentAction.Text = string.Format(Resources.ReadingFlashAirInfoAtPath, path);
            Application.DoEvents();
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
            CurrentAction.Text = string.Format(Resources.ReadingInfoFromFilesAtPath, imageCount, path);
            Application.DoEvents();
            if (imageCount > 0)
            {
                List<FlashAirFileInformation> allFiles = null;
                var errResponse = DialogResult.None;
                do
                {
                    try
                    {
                        _log.Debug($"Get {imageCount} FileSplitter from {path}");
                        allFiles = _connection.GetFiles(path);
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex);
                        errResponse = MetroMessageBox.Show(this,Resources.ErrorDownloadingFilelist,Resources.ErrorFlashairGenericTitle,MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                        if (errResponse != DialogResult.Abort) continue;
                        MetroMessageBox.Show(this, Resources.ErrorBlameToshiba,Resources.ErrorBlameTitle);var parent = (Fad) Parent;
                        parent.ShowLoader();
                    }
                } while (allFiles == null && errResponse != DialogResult.Ignore);

                if (allFiles != null)
                {
                    // start with the directories:
                    // No ReadOnly, cause the FlashAir-SystemImage is readonly. ANd we do not want to copy that every time
                    var nonHiddenfiles = allFiles.Where(af => !af.Hidden && !af.SystemFile && !af.ReadOnly).ToList();

                    Progress.Maximum = nonHiddenfiles.Count;
                    var counter = 0;
                    foreach (var singleFile in nonHiddenfiles.Where(nhf => nhf.IsVolume || nhf.IsDirectory))
                    {
                        // there shouldn't really be any volumes on that disc, but doesn't hurt to check
                        Progress.Value = counter;
                        counter++;
                        Application.DoEvents();

                        if (!path.EndsWith("/"))
                        {
                            path += '/';
                        }
                        LoadFlashairInfo(path + singleFile.Filename);
                    }
                    foreach (var singleFile in nonHiddenfiles.Where(nhf => !nhf.IsVolume && !nhf.IsDirectory))
                    {
                        var tile = new MetroTile
                        {
                            Text = singleFile.Filename,
                            Width = _metroTileSize,
                            Height = _metroTileSize,
                            Tag = singleFile
                        };
                        tile.Click += LeftTile_Click;
                        FileTooltip.SetToolTip(tile, singleFile.Filename);
                        LeftPanel.Controls.Add(tile);
                        Progress.Value = counter;
                        counter++;
                        tile.Refresh();
                        Application.DoEvents();
                    }
                }
            }
            ResizeTiles(LeftPanel);
        }

        private void CopyFiles()
        {
            var duration = TimeSpan.FromSeconds(1);
            long lastSize = 0;

            CurrentAction.Text = Resources.CopyingFiles;

            var cardId = _connection.GetCid();
            var appId = _connection.GetAppName();

            if (LeftPanel.Controls.OfType<MetroTile>().Any())
            {
                var allTiles = LeftPanel.Controls.OfType<MetroTile>().ToList();
                _log.Info($"Start upload of {allTiles.Count} files");

                Progress.Maximum = allTiles.Count;
                Progress.Value = 0;
                StartCopy.Visible = false;

                var counter = 0;
                foreach (var tile in allTiles)
                {
                    LeftTile_Click(tile, new EventArgs());
                    var fileInfo = (FlashAirFileInformation) tile.Tag;
                    var currentByteSpeed = lastSize/duration.TotalSeconds;
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

                    CurrentAction.Text = string.Format(Resources.CopyFileOfAtSpeed, counter + 1, Progress.Maximum, fileInfo.Filename, currentByteSpeed, unit);
                    Application.DoEvents();


                    var targetFolder = CreateTargetFolder(fileInfo, cardId, appId);
                    var targetFile = Path.Combine(targetFolder, fileInfo.Filename);
                    var doDelete = _connection.Settings.DeleteFiles;
                    bool doCopy = true;
                    if (File.Exists(targetFile))
                    {
                        switch (_connection.Settings.ExistingFiles) {
                            case (int) ProgramSettings.OverwriteModes.Copy:
                                targetFile = Path.Combine(targetFolder, $"{DateTime.Now:yy-MM-dd-HH-ss}{fileInfo.Filename}");
                                break;
                            case (int) ProgramSettings.OverwriteModes.Never:
                                var targetFileInfo = new FileInfo(targetFile);
                                doCopy = targetFileInfo.CreationTime < fileInfo.PictureTaken;
                                break;
                            default:
                                doCopy = _connection.Settings.ExistingFiles == (int) ProgramSettings.OverwriteModes.Always;
                                break;
                        }
                        doDelete &= doCopy;
                    }
                    if (doCopy)
                    {
                        var startTick = DateTime.Now;
                        var errResponse = DialogResult.None;
                        Stream sourceFileStream = null;
                        do
                        {
                            try
                            {
                                sourceFileStream = _connection.DownloadFile(fileInfo.Directory, fileInfo.Filename);
                            }
                            catch (Exception ex)
                            {
                                _log.Error(ex);
                                if (ex is WebException && ((WebException) ex).Status == WebExceptionStatus.NameResolutionFailure)
                                {
                                    errResponse = MetroMessageBox.Show(this, "Flashair cannot be found anymore. This usually means that the card has gone offline. Re-Power your camera and try again. \r\n\r\n[ignore=continue with next file, abort=abort all downloads, retry=retry downloading this file]", "Flashair cannot be found anymore", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    errResponse = MetroMessageBox.Show(this, $"Failed downloading File '{fileInfo.Filename}. Ignore this error and continue with next file?  \r\n[ignore=continue with next file, abort=abort all downloads, retry=retry downloading this file]", Resources.ErrorFlashairGenericTitle, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                                }
                                if (errResponse != DialogResult.Abort) continue;
                                MetroMessageBox.Show(this, Resources.ErrorBlameToshiba, Resources.ErrorBlameTitle);
                                _parent.ShowLoader();
                            }
                        } while (sourceFileStream == null && errResponse != DialogResult.Ignore);
                        if (sourceFileStream == null) continue;
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
                            }
                        }
                        duration = DateTime.Now - startTick;
                        if (doDelete)
                        {
                            _connection.DeleteFile(fileInfo.Directory, fileInfo.Filename);
                        }
                    }
                    Progress.Value = counter;
                    Application.DoEvents();
                    counter++;
                }
            }
            Progress.Value = Progress.Maximum;
            CurrentAction.Text = Resources.DoneCopying;
            Thread.Sleep(10000);
            _parent.ShowLoader();
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
                var thumBitmap = _connection.DownloadThumbnail(fileInformation.Directory, fileInformation.Filename);
                if (thumBitmap == null)
                {
                    return;
                }
                Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;
                var thumb = thumBitmap.GetThumbnailImage(_metroTileSize, _metroTileSize, myCallback, IntPtr.Zero);
                tile.TileImage = thumb;
                tile.UseTileImage = true;
            }
            catch (Exception ex)
            {
                // Could not download Thumb after 5 retries. Well. Just a thumb. Let's ignore this
                _log.Error(ex);
            }
        }


        private void LoadLocalContents(string localPath)
        {
            CurrentAction.Text = Resources.ReadLocalDir;
            if (Directory.Exists(localPath))
            {
                var currentDirectory = new DirectoryInfo(localPath);
                var files = currentDirectory.GetFiles();
                var folders = currentDirectory.GetDirectories();

                RightPanel.Controls.Clear();
                Progress.Maximum = folders.Length;
                var counter = 0;
                foreach (var folder in folders.OrderBy(fld => fld.Name))
                {
                    var tile = new MetroTile {Text = folder.Name, Width = _metroTileSize, Height = _metroTileSize, Style = MetroColorStyle.Yellow};
                    FileTooltip.SetToolTip(tile, folder.Name);
                    RightPanel.Controls.Add(tile);
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
                    var extension = fileInfo.Name.Substring(fileInfo.Name.LastIndexOf('.') + 1).ToLower();

                    var doCopy = true;
                    switch (_connection.Settings.FileTypesToCopy)
                    {
                        case (int) ProgramSettings.FileTypes.Images:
                            doCopy = _imageFileTypes.Contains(extension);
                            break;
                        case (int) ProgramSettings.FileTypes.Videos:
                            doCopy = _imageFileTypes.Contains(extension) || _movieFilesTypes.Contains(extension);
                            break;
                    }

                    if (!doCopy)
                    {
                        _log.Debug($"Ignoring {fileInfo.Directory} {fileInfo.Name}, because it has the wrong extension");
                        continue;
                    }


                    var tile = new MetroTile {Text = fileInfo.Name, Width = _metroTileSize, Height = _metroTileSize};
                    FileTooltip.SetToolTip(tile, fileInfo.Name);
                    TryGetThumb(tile, fileInfo);
                    RightPanel.Controls.Add(tile);
                    Progress.Value = counter;
                    counter++;
                    Application.DoEvents();
                }
            }
            ResizeTiles(RightPanel);
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
                string[] validExtensions = {"jpg", "jpeg", "png", "ping", "gif", "tif", "tiff"};
                var extension = fileInfo.Name.Substring(fileInfo.Name.LastIndexOf('.') + 1).ToLower();
                if (!validExtensions.Contains(extension)) return;
                Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;
                var thumBitmap = new Bitmap(fileInfo.FullName);
                var thumb = thumBitmap.GetThumbnailImage(_metroTileSize, _metroTileSize, myCallback, IntPtr.Zero);
                tile.TileImage = thumb;
                tile.UseTileImage = true;
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
            ResizeTiles(RightPanel);
            Refresh();
        }

        private void LeftPanel_Layout(object sender, LayoutEventArgs e)
        {
            ResizeTiles(LeftPanel);
            Refresh();
        }

        private void StartCopy_Click(object sender, EventArgs e)
        {
            StartCopy.Visible = false;
            CopyFiles();
        }

        private void LeftTile_Click(object sender, EventArgs e)
        {
            var tile = (MetroTile) sender;
            var fileData = (FlashAirFileInformation) tile.Tag;
            SinglePreviewThumb.TileImage = tile.TileImage;
            SinglePreviewThumb.UseTileImage = tile.UseTileImage;
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
    }
}