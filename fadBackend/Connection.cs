using System;
using System.Net;
using System.Timers;

namespace fad2.Backend
{
    public class Connection
    {
        private int _currentAttempt;
        private int _maxAttempts;
        private Timer _retryTimer;
        private Settings _settings;


        public bool TestConnection()
        {
            _settings = new Settings();
            try
            {
                var result = OpenUrl(_settings.Url);
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