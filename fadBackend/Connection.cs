using System;
using System.Net;

namespace fad2.Backend
{
    public class Connection
    {
        public Connection(string settingsfile)
        {
            _settings= new FileLoader().LoadProgramSettings(settingsfile);
        }
        private ProgramSettings _settings;

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


        /// <summary>
        ///     Url öffnen
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Returnwert der Url</returns>
        public string OpenUrl(string url)
        {
            return new WebClient().DownloadString(url);
        }
    }
}