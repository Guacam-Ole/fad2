using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace fad2.Backend
{
    public class LongRunningWebClient : WebClient
    {
        private int _timeOut = 120*1000; // 120 seconds
        private int _maxRetries = 5;
        public LongRunningWebClient() : base() { }

        public LongRunningWebClient(int timeoutInSeconds, int? maxRetries=null) : base()
        {
            _timeOut = timeoutInSeconds * 1000;
            _maxRetries = maxRetries ?? _maxRetries;
            Thread.Sleep(500);
        }

        public new Stream OpenRead(string address)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    return base.OpenRead(address);
                }
                catch (WebException ex)
                {
                    retryCount++;
                    if (retryCount > _maxRetries)
                    {
                        throw (ex);
                    }
                    Thread.Sleep(2000);
                }
            }
        }


        public
            new string DownloadString(string address)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    return base.DownloadString(address);
                }
                catch (WebException ex)
                {
                    // TODO: LOG
                    // ex.Status=="NameResolutionFailure" -> http://Flashair gibbet nich
                    // ex.Status=="Timeout" -> watt wohl
                    // ex.Status=="ProtocolError" -> 408 "Anforderungstimeout" = Timeout vom "Server"   Message kann auch 500 sein, dann TOT....


                    retryCount++;
                    if (retryCount > _maxRetries)
                    {
                        throw (ex);
                    }
                    Thread.Sleep(2000);
                }
            }
        }


        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = _timeOut;
            return w;
        }

    }
}
