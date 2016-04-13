using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace fad.Backend
{
    public class Connection
    {
        private int _maxAttempts;
        private int _currentAttempt;
        private Timer _retryTimer;
        private Settings _settings;


        public bool TestConnection()
        {
            _settings = new Settings();
            try {
                string result = OpenUrl(_settings.Url);
                return true;
            } catch (Exception ex)
            {

                // TODO: LOG
                return false;
            }
        }


        /// <summary>
        /// Url öffnen
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Returnwert der Url</returns>
        public string OpenUrl(string url)
        {
            return new WebClient().DownloadString(url);
        }


    }
}
