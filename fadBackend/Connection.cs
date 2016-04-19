using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Mime;

namespace fad2.Backend
{
    public class Connection
    {
        public Connection(string settingsfile)
        {
            _settings= new FileLoader().LoadProgramSettings(settingsfile);
        }

      

        
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
                // http://flashair/thumbnail.cgi?/DCIM/100__TSB/DSC_100.JPG
                
                string command = string.Format($"{AddSlash(_settings.FlashAirUrl)}{ThumbnailPrefix}{AddSlash(directory)}{filename}");
                Image thumb = Image.FromStream(new LongRunningWebClient(60).OpenRead(command));
                return thumb;
            }
            catch (Exception ex)
            {
                // TODO: Log
                return null;
            }

        }

        public List<FlashAirFileInformation> GetFiles(string path)
        {
            // TODO: Retries!
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