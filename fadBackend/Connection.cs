using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using log4net;

namespace fad2.Backend
{
    /// <summary>
    ///     Flashair-Connection-Functions
    /// </summary>
    public class Connection
    {
        /// <summary>
        ///     Known CommandIds
        /// </summary>
        public enum CommandIds
        {
            Files = 100,
            NumberOfFiles = 101,
            UpdateStatus = 102,
            Ssid = 104,
            NetworkPass = 105,
            Mac = 106,
            Lang = 107,
            Firmware = 108,
            ControlImage = 109,
            WlanMode = 110,
            WlanTimeout = 111,
            Unique = 117,
            Cid = 120
        }

        private const string CommandPrefix = "command.cgi?op=";
        private const string ThumbnailPrefix = "thumbnail.cgi?";
        private const string UploadPrefix = "upload.cgi";
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///     Initialize Connectionfunctions
        /// </summary>
        /// <param name="settingsfile">Settingsfile-location</param>
        public Connection(string settingsfile)
        {
            Settings = new FileLoader().LoadProgramSettings(settingsfile);
        }

        /// <summary>
        ///     Settings
        /// </summary>
        public ProgramSettings Settings { get; }

        /// <summary>
        ///     Test if Flashair can be connected
        /// </summary>
        /// <returns>Sucess Status</returns>
        public bool TestConnection()
        {
            try
            {
                OpenUrl(Settings.FlashAirUrl);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }


        /// <summary>
        ///     Add Slash to path if it does not exist already
        /// </summary>
        /// <param name="value">Pfad</param>
        public string AddSlash(string value)
        {
            if (!value.EndsWith("/"))
            {
                value += "/";
            }
            return value;
        }

        public bool SetUploadDirectory(string directory)
        {
            string command = $"{AddSlash(Settings.FlashAirUrl)}{UploadPrefix}?WRITEPROTECT=ON&UPDIR={directory}";
            var contents = new LongRunningWebClient().DownloadString(command);
            return contents == "SUCCESS";
            //  http://flashair/upload.cgi?UPDIR=/DCIM/101__TSB
        }

        private string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey?.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }
            return mimeType;
        }

        public bool UploadFile(string filename )
        {
            string url= $"{AddSlash(Settings.FlashAirUrl)}{UploadPrefix}";
            _log.Debug($"Uploading {filename} to {url}");
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string localFileName = Path.GetFileName(filename);
            string contentType = GetMimeType(filename);
            string header = $"Content-Disposition: form-data; name=\"file\"; filename=\"{localFileName}\"\r\nContent-Type: {contentType}\r\n\r\n";
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
               _log.Debug($"File uploaded, server response is: {reader2.ReadToEnd()}");
                return reader2.ReadToEnd().ToLower().Contains("success");
            }
            catch (Exception ex)
            {
                _log.Error("Error uploading file", ex);
                wresp?.Close();
            }
            finally
            {
                wr = null;
            }
            return false;
        }

        /// <summary>
        ///     Download thumb for an image
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <param name="filename">File</param>
        /// <param name="validExtensions">Valid Image extensions</param>
        /// <returns>Image-Object of the thumb</returns>
        public Image DownloadThumbnail(string directory, string filename, string validExtensions)
        {
            try
            {
                if (!filename.Contains("."))
                {
                    return null;
                }
                var extension = Path.GetExtension(filename);
                if (!validExtensions.Contains(extension.ToLower()))
                {
                    // No valid Image, no download
                    return null;
                }
                var command = string.Format($"{AddSlash(Settings.FlashAirUrl)}{ThumbnailPrefix}{AddSlash(directory)}{filename}");
                var thumb = Image.FromStream(new LongRunningWebClient(5, 2).OpenRead(command));
                return thumb;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }

        /// <summary>
        ///     Get Appname
        /// </summary>
        /// <returns>Appname</returns>
        public string GetAppName()
        {
            string command = $"{AddSlash(Settings.FlashAirUrl)}{CommandPrefix}{(int) CommandIds.Unique}";
            var contents = new LongRunningWebClient().DownloadString(command);
            return contents;
        }

        /// <summary>
        ///     Get the CardId
        /// </summary>
        /// <returns>CardId</returns>
        public string GetCid()
        {
            string command = $"{AddSlash(Settings.FlashAirUrl)}{CommandPrefix}{(int) CommandIds.Cid}";
            var contents = new LongRunningWebClient().DownloadString(command);
            return contents;
        }

        /// <summary>
        ///     Download a single File
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <param name="filename">Filename</param>
        /// <returns>Stream of the file</returns>
        public Stream DownloadFile(string directory, string filename)
        {
            try
            {
                if (directory.StartsWith("/"))
                {
                    directory = directory.Substring(1);
                }
                string command = $"{AddSlash(Settings.FlashAirUrl)}{AddSlash(directory)}{filename}";
                var stream = new LongRunningWebClient(120, 3).OpenRead(command);
                _log.Debug($"Image {filename} downloaded");
                return stream;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        /// <summary>
        ///     Delete a single file
        /// </summary>
        /// <param name="path">Directory</param>
        /// <param name="filename">File</param>
        /// <returns>Successstatus</returns>
        public bool DeleteFile(string path, string filename)
        {
            //   http: //flashair/upload.cgi?DEL=/DCIM/100__TSB/DSC_100.JPG
            try
            {
                string command = $"{AddSlash(Settings.FlashAirUrl)}upload.cgi?DEL={AddSlash(path)}{filename}";
                var returnValue = new LongRunningWebClient(10, 5).DownloadString(command);
                _log.Debug($"Deletion successful for {filename}. Return:{returnValue}");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }

        /// <summary>
        ///     Get File Informations
        /// </summary>
        /// <param name="path">Directory</param>
        /// <returns>List of Fileinformations</returns>
        public List<FlashAirFileInformation> GetFiles(string path)
        {
            string targetUrl = $"{AddSlash(Settings.FlashAirUrl)}{CommandPrefix}{(int) CommandIds.Files}&DIR={path}";
            var allFiles = new LongRunningWebClient().DownloadString(targetUrl);
            if (string.IsNullOrWhiteSpace(allFiles))
            {
                return null;
            }

            return allFiles.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).Select(file => new FlashAirFileInformation(file)).Where(fileInformation => fileInformation.Filename != null).ToList();
        }

        /// <summary>
        ///     Get number of files from a directory
        /// </summary>
        /// <param name="path">directory</param>
        /// <returns>number of files</returns>
        public int GetFileCount(string path)
        {
            int count;
            string targetUrl = $"{AddSlash(Settings.FlashAirUrl)}{CommandPrefix}{(int) CommandIds.NumberOfFiles}&DIR={path}";
            var imageCount = new LongRunningWebClient(10).DownloadString(targetUrl);
            int.TryParse(imageCount, out count);
            return count;
        }


        /// <summary>
        ///     Open Url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Returnwert der Url</returns>
        public string OpenUrl(string url)
        {
            return new LongRunningWebClient().DownloadString(url);
        }
    }
}