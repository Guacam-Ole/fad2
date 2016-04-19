using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace fad2.Backend
{
    public class LongRunningWebClient : WebClient
    {
        private int _timeOut = 5*60*1000; // 5 mins
        private int _maxRetries = 20;
        public LongRunningWebClient() : base() { }

        public LongRunningWebClient(int timeoutInSeconds, int? maxRetries=null) : base()
        {
            _timeOut = timeoutInSeconds * 1000;
            _maxRetries = maxRetries ?? _maxRetries;
        }
      

        public new string DownloadString(string address)
        {
            int retryCount = 0;
            while (true)
            {


                try
                {
                    return base.DownloadString(address);
                }
                catch (Exception ex)
                {
                    // TODO: LOG

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
