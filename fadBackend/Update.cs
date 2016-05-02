using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;

namespace fad2.Backend
{
    /// <summary>
    /// Update functions
    /// </summary>
    public class Update
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Update()
        {
            UpdateManager updManager = UpdateManager.Instance;
            updManager.UpdateSource = new SimpleWebSource("https://files.oles-cloud.de/fad2/feed.xml");
            updManager.Config.TempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Fad2\\Updates");
            updManager.ReinstateIfRestarted();
        }

        /// <summary>
        /// Check if Updates available
        /// </summary>
        /// <returns>true if updates available</returns>
        public bool CheckForUpdate()
        {
            var updateManager = UpdateManager.Instance;
            if (updateManager.State != UpdateManager.UpdateProcessState.NotChecked) return false;
            try
            {
                updateManager.CheckForUpdates();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            if (updateManager.UpdatesAvailable == 0)
            {
                _log.Debug("No Updates available");
                return false;
            }
            _log.Debug($"{updateManager.UpdatesAvailable} Updates available");
            return true;
        }

        /// <summary>
        /// Start Downloading updates
        /// </summary>
        public void StartDownloading()
        {
            var updateManager = UpdateManager.Instance;
            updateManager.BeginPrepareUpdates(OnDownloadCompleted, null);
        }

        private void OnDownloadCompleted(IAsyncResult ar)
        {
            try
            {
                ((UpdateProcessAsyncResult)ar).EndInvoke();
            }
            catch (Exception ex)
            {
               _log.Error(ex);
                return;
            }
            UpdateManager updManager = UpdateManager.Instance;
            try
            {
                updManager.ApplyUpdates(true, true,true);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }
    }
}
