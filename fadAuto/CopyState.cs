using fad2.Backend;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fadAuto
{
    public class CopyState
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _programSettingsFile = $"{Application.StartupPath}\\{Properties.Settings.Default.ProgramSettingsFile}";
        private readonly string[] _imageFileTypes = Properties.Settings.Default.ImageFileTypes.Split(',');
        private readonly string[] _movieFilesTypes = Properties.Settings.Default.VideoFileTypes.Split(',');
        List<FlashAirFileInformation> _filesToCopy;

        Connection _connection;

        public CopyState()
        {
            _connection = new Connection(_programSettingsFile);
        }

        public event EventHandler Connected;
        public event EventHandler DisConnected;
        public event EventHandler FileCopyFinished;
        public event EventHandler FileCopyStarted;
        public event EventHandler CopyFinished;
        private Timer _reconnectTimer = new Timer();


        public void StartLoop()
        {
            _reconnectTimer.Interval = _connection.Settings.FileCheckInterval * 1000;
            _reconnectTimer.Tick += _reconnectTimer_Tick;
            _reconnectTimer.Start();
        }

        private void _reconnectTimer_Tick(object sender, EventArgs e)
        {
            _reconnectTimer.Stop();
            Connect();
            _reconnectTimer.Start();
        }

        private void Connect()
        {
            if (_connection.TestConnection())
            {
                if (Connected != null) Connected.Invoke(this, new EventArgs());
                try
                {
                    GetFiles();
                } catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
        }

        private void GetFiles()
        {
            _filesToCopy = new List<FlashAirFileInformation>();
            int imageCount = LoadFlashairInfo(_connection.Settings.CardStartupPath);
            if (imageCount < 0)
            {
                _log.Warn("Cannot retrieve files");
                return;
            }
            TotalFiles = imageCount;
            FilesCopied = 0;
            foreach (var singleFile in _filesToCopy)
            {
                DoCopy(singleFile);
            }

            if (CopyFinished != null) CopyFinished.Invoke(this, new EventArgs());

        }

        private string CreateTargetFolder(FlashAirFileInformation fileInfo, string cardId, string appId)
        {
            // cardID=0, appId=1, Date=2
            var targetFolderName = string.Format(_connection.Settings.FolderFomat, cardId, appId, fileInfo.PictureTaken);

            var downloadFolder = new DirectoryInfo(_connection.Settings.LocalPath);
            return !downloadFolder.Exists ? null : Directory.CreateDirectory(Path.Combine(downloadFolder.FullName, targetFolderName)).FullName;
        }

        private void DoCopy(FlashAirFileInformation fileInfo)
        {
            if (FileCopyStarted!=null) FileCopyStarted.Invoke(this, new EventArgs());
            var doDelete = _connection.Settings.DeleteFiles;
            var cardId = _connection.GetCid();
            var appId = _connection.GetAppName();
            var targetFolder = CreateTargetFolder(fileInfo, cardId, appId);
            var targetFile = Path.Combine(targetFolder, fileInfo.Filename);
            Stream sourceFileStream = null;
            try
            {
                sourceFileStream = _connection.DownloadFile(fileInfo.Directory, fileInfo.Filename);
            }
            catch (Exception ex)
            {
                _log.Error(ex);

                if (ex is WebException && ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                {
                    _log.Warn("Connection lost, should retry");
                }
                else
                {
                    _log.Error(ex);
                }
            }
            if (sourceFileStream == null) return;
            try
            {
                using (var fileStream = File.Create(targetFile))
                {
                    try
                    {
                        sourceFileStream.CopyTo(fileStream);
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex);
                        doDelete = false;
                    }
                }
               
                if (doDelete)
                {
                    _connection.DeleteFile(fileInfo.Directory, fileInfo.Filename);
                }
                if (FileCopyFinished != null) FileCopyFinished.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private int LoadFlashairInfo(string path)
        {
            if (path.Length > 1 && path[0] != '/')
            {
                path = "/" + path;
            }
            _log.Info($"Read information from {path}");

            int imageCount = 0;


            if (string.IsNullOrWhiteSpace(path))
            {
                path = "/";
            }
            List<FlashAirFileInformation> allFiles;
            try
            {
                _log.Debug($"Get {imageCount} FileSplitter from {path}");
                allFiles = _connection.GetFiles(path);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return -1;
            }

            if (allFiles != null)
            {
                // start with the directories:
                // No ReadOnly, cause the FlashAir-SystemImage is readonly. ANd we do not want to copy that every time
                var nonHiddenfiles = allFiles.Where(af => !af.Hidden && !af.SystemFile && !af.ReadOnly).ToList();

                foreach (var singleFile in nonHiddenfiles.Where(nhf => nhf.IsVolume || nhf.IsDirectory))
                {
                    if (!path.EndsWith("/"))
                    {
                        path += '/';
                    }
                    int subCount = LoadFlashairInfo(path + singleFile.Filename);
                    if (subCount == -1) { return -1; }
                    imageCount += subCount;

                }
                foreach (var singleFile in nonHiddenfiles.Where(nhf => !nhf.IsVolume && !nhf.IsDirectory))
                {
                    switch (_connection.Settings.FileTypesToCopy)
                    {
                        case (int)ProgramSettings.FileTypes.Images:
                            if (!_imageFileTypes.Contains(singleFile.Extension.ToLower()))
                            {
                                continue;
                            }
                            break;
                        case (int)ProgramSettings.FileTypes.Videos:
                            if (!_imageFileTypes.Contains(singleFile.Extension.ToLower()) && !_movieFilesTypes.Contains(singleFile.Extension.ToLower()))
                            {
                                continue;
                            }
                            break;
                    }
                    imageCount++;
                    _filesToCopy.Add(singleFile);
                }
                return imageCount;
            }

            return 0;
        }

        public string CurrentFile { get; set; }
        public int TotalFiles { get; set; }

        public int FilesCopied { get; set; }
    }
}
