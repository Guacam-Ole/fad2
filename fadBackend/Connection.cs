using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using log4net;

namespace fad2.Backend
{
    public class Connection
    {
        public Connection(string settingsfile)
        {
            _settings= new FileLoader().LoadProgramSettings(settingsfile);
        }
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);



        private ProgramSettings _settings;
        public  ProgramSettings Settings { get { return _settings; } }

        public bool TestConnection()
        {
           // _settings = new ProgramSettings();
            try
            {
                var result = OpenUrl(_settings.FlashAirUrl);
                return true;
            }
            catch (Exception ex)
            {
                // TODO: LOG
                return false;
            }
        }


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


        /// <summary>
        /// Slash an Pfad hängen, wenn noch nicht vorhanden
        /// </summary>
        /// <param name="value">Pfad</param>
        public string AddSlash( string value)
        {
            if (!value.EndsWith("/"))
            {
                value += "/";
            }
            return value;
        }

        private const string CommandPrefix="command.cgi?op="; 
        private const string ThumbnailPrefix="thumbnail.cgi?";

        public Image DownloadThumbnail(string directory, string filename)
        {
            try
            {
                if (!filename.Contains("."))
                {
                    return null;
                }
                string[] validExtensions = "jpg,jpeg,gif,ping,png".Split(',');
                string extension = filename.Substring(filename.LastIndexOf('.') + 1);
                if (!validExtensions.Contains(extension.ToLower()))
                {
                    // No valid Image, no download
                    return null;
                }
                
                // http://flashair/thumbnail.cgi?/DCIM/100__TSB/DSC_100.JPG
                
                string command = string.Format($"{AddSlash(_settings.FlashAirUrl)}{ThumbnailPrefix}{AddSlash(directory)}{filename}");
                Image thumb = Image.FromStream(new LongRunningWebClient(5,2).OpenRead(command));
                return thumb;
            }
            catch (Exception ex)
            {
                // TODO: Log
                return null;
            }

        }

        public string GetAppName()
        {
            string command = $"{AddSlash(_settings.FlashAirUrl)}{CommandPrefix}{(int)CommandIds.Unique}";
            string contents = new LongRunningWebClient().DownloadString(command);
            return contents;
        }
       
        public string GetCid()
        {
            string command = $"{AddSlash(_settings.FlashAirUrl)}{CommandPrefix}{(int) CommandIds.Cid}";
            string contents = new LongRunningWebClient().DownloadString(command);
            return contents;
        }

        public Stream DownloadFile( string directory, string filename)
        {
            try
            {
                if (directory.StartsWith("/"))
                {
                    directory = directory.Substring(1);
                }
                // http://flashair/DCIM/102_PANA/P1020062.JPG
                string command = $"{AddSlash(_settings.FlashAirUrl)}{AddSlash(directory)}{filename}";
                 var stream= new LongRunningWebClient(120,3).OpenRead(command);
                _log.Debug($"Image {filename} downloaded");
                return stream;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public bool DeleteFile( string path, string filename)
        {
            //   http: //flashair/upload.cgi?DEL=/DCIM/100__TSB/DSC_100.JPG
            try
            {
                string command = $"{AddSlash(_settings.FlashAirUrl)}upload.cgi?DEL={AddSlash(path)}{filename}";
                string returnValue = new WebClient().DownloadString(command);
                _log.Debug($"Deletion successful for {filename}. Return:{returnValue}");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }


        public List<FlashAirFileInformation> GetFiles(string path)
        {
            string targetUrl = $"{AddSlash(_settings.FlashAirUrl)}{CommandPrefix}{(int)CommandIds.Files}&DIR={path}";
            string allFiles= new LongRunningWebClient().DownloadString(targetUrl);
            if (string.IsNullOrWhiteSpace(allFiles))
            {
                return null;
            }

            List<FlashAirFileInformation> fileInformations = new List<FlashAirFileInformation>();
            foreach (var file in allFiles.Split(new string[] {"\r\n"},StringSplitOptions.RemoveEmptyEntries))
            {
                FlashAirFileInformation fileInformation=new FlashAirFileInformation(file);
                if (fileInformation.Filename != null)
                {
                    fileInformations.Add(fileInformation);
                }
            }
            return fileInformations;
        }

        public int GetFileCount(string path)
        {

            int count;
            string targetUrl = $"{AddSlash(_settings.FlashAirUrl)}{CommandPrefix}{(int) CommandIds.NumberOfFiles}&DIR={path}";
            string imageCount = new LongRunningWebClient(10).DownloadString(targetUrl);
            int.TryParse(imageCount, out count);
            return count;
        }


        /// <summary>
        ///     Url öffnen
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Returnwert der Url</returns>
        public string OpenUrl(string url)
        {
            return new LongRunningWebClient().DownloadString(url);
        }
    }
}