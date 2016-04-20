using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using log4net;

namespace fad2.Backend
{
    /// <summary>
    /// Webclient with retries and custom Timeout
    /// </summary>
    public class LongRunningWebClient : WebClient
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly int _maxRetries = 5;
        private readonly int _timeOut = 120*1000; // 120 seconds

        /// <summary>
        /// New Webclient
        /// </summary>
        public LongRunningWebClient()
        {
        }

        /// <summary>
        /// New Webclient
        /// </summary>
        /// <param name="timeoutInSeconds">Timeout in Seconds</param>
        /// <param name="maxRetries">Maximum Retries before throwing the error</param>
        public LongRunningWebClient(int timeoutInSeconds, int? maxRetries = null)
        {
            _timeOut = timeoutInSeconds*1000;
            _maxRetries = maxRetries ?? _maxRetries;
            Thread.Sleep(500);
        }

        /// <summary>
        /// Read Stream from Address
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Filestream</returns>
        public new Stream OpenRead(string address)
        {
            var retryCount = 0;
            while (true)
            {
                try
                {
                    return base.OpenRead(address);
                }
                catch (Exception ex)
                {
                    retryCount++;
                    if (retryCount > _maxRetries)
                    {
                        _log.Error(ex);
                        throw;
                    }
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// Return Url as string
        /// </summary>
        /// <param name="address">URL</param>
        /// <returns>String-COntent</returns>
        public new string DownloadString(string address)
        {
            var retryCount = 0;
            while (true)
            {
                try
                {
                    return base.DownloadString(address);
                }
                catch (WebException ex)
                {
                    _log.Error(ex);

                    retryCount++;
                    if (retryCount > _maxRetries)
                    {
                        throw;
                    }
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// GetRequest
        /// </summary>
        /// <param name="uri">Url</param>
        /// <returns>Request</returns>
        protected override WebRequest GetWebRequest(Uri uri)
        {
            var w = base.GetWebRequest(uri);
            w.Timeout = _timeOut;
            return w;
        }
    }
}