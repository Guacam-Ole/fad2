using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using log4net;
using Microsoft.Win32;

namespace fad2.Backend
{
    /// <summary>
    ///     Flashair-Connection-Functions
    /// </summary>
    public class Connection
    {
#pragma warning disable 1591

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

#pragma warning restore 1591
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

        /// <summary>
        /// Set Upload Directory for following uploads
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <returns>Connection State</returns>
        public bool SetUploadDirectory(string directory)
        {
            string command = $"{AddSlash(Settings.FlashAirUrl)}{UploadPrefix}?WRITEPROTECT=ON&UPDIR={directory}";
            var contents = new LongRunningWebClient().DownloadString(command);
            return contents == "SUCCESS";
            //  http://flashair/upload.cgi?UPDIR=/DCIM/101__TSB
        }

        private string GetMimeType(string fileName)
        {
            var mimeType = "application/unknown";
            var ext = Path.GetExtension(fileName).ToLower();
            var regKey = Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey?.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }
            return mimeType;
        }

        /// <summary>
        /// Upload a single File to FlashAir
        /// </summary>
        /// <param name="filename">Local Filename</param>
        /// <param name="filesize">Filesize</param>
        /// <returns>Connection status</returns>
        public bool UploadFile(string filename, out long filesize)
        {
            filesize = 0;
            try
            {
                string url = $"{AddSlash(Settings.FlashAirUrl)}{UploadPrefix}";
                _log.Debug($"Uploading {filename} to {url}");
                var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                var boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                var wr = (HttpWebRequest) WebRequest.Create(url);
                wr.ServicePoint.Expect100Continue = false;
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;
                wr.Credentials = CredentialCache.DefaultCredentials;

                var rs = wr.GetRequestStream();
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                var localFileName = Path.GetFileName(filename);
                var contentType = GetMimeType(filename);
                string header = $"Content-Disposition: form-data; name=\"file\"; filename=\"{localFileName}\"\r\nContent-Type: {contentType}\r\n\r\n";
                var headerbytes = Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                filesize = fileStream.Length;
                var buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();


                var trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();

                WebResponse wresp = null;

                try
                {
                    wresp = wr.GetResponse();
                    var stream2 = wresp.GetResponseStream();
                    var reader2 = new StreamReader(stream2);
                    var response = reader2.ReadToEnd();
                    _log.Debug($"File uploaded, server response is: {response}");
                    return response.ToLower().Contains("success");
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
            }
            catch (Exception ex)
            {
                _log.Error("Error connecting", ex);
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
                var command = string.Format($"{AddSlash(Settings.FlashAirUrl)}{ThumbnailPrefix}{AddSlash(directory)}{filename.ToLower()}");
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