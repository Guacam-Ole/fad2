using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using fad2.Backend;
using log4net;
using MetroFramework;
using MetroFramework.Forms;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Sources;

namespace fad2.UI
{
    /// <summary>
    /// FlashAirDownloader Main Window
    /// </summary>
    public partial class Fad : MetroForm
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// New Main Window
        /// </summary>
        public Fad()
        {
            
            InitializeComponent();
            ShowLoader();
            CheckForUpdates();
                   _log.Debug($"FlashAirDownloader v{Application.ProductVersion}");
        }

        private void CheckForUpdates()
        {
            var settings = new FileLoader().LoadProgramSettings(Application.StartupPath + "\\fad2.json");
            if (settings.CheckForUpdates)
            {
                CheckForUpdates(true);
            }
        }
                 
        /// <summary>
        /// Show Loading Tile
        /// </summary>
        public void ShowLoader()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new StartUp {Dock = DockStyle.Fill});
        }

        private void ShowSettings()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new Settings {Dock = DockStyle.Fill});
        }

        private void ShowIssues()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new GitHub {Dock = DockStyle.Fill});
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoader();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
     

        private void apiDocumentationforDevelopers9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://flashair-developers.com/en/documents/api/");
        }

        private void setupHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/OleAlbers/fad2/wiki");
        }

        private Timer _updateCheckStateTimer;

        private void Fad_Load(object sender, EventArgs e)
        {
            _updateCheckStateTimer = new Timer {Interval = 60000};
            _updateCheckStateTimer.Tick += _updateCheckStateTimer_Tick;
            _updateCheckStateTimer.Start();
        }

        private void _updateCheckStateTimer_Tick(object sender, EventArgs e)
        {
            if (UpdateManager.Instance.State != UpdateManager.UpdateProcessState.Checked) return;
            UpdateManager.Instance.CleanUp();
            _log.Debug("Update state was reset to NotChecked");
        }

        private void CheckForUpdates(bool silent)
        {
            var update = new Update();
            if (update.CheckForUpdate())
            {
                bool install = MetroMessageBox.Show(this, "A new Update is available. Do you want to download and install it?", "Updates found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                if (install)
                {
                    update.StartDownloading();
                }
            }
            else
            {
                if (silent) return;
                MetroMessageBox.Show(this, "You already have the most current version", "No Updates found");
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             CheckForUpdates(false);
        }

        private void licenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FileViewer("License", Path.Combine(Application.StartupPath, "LICENSE.TXT")).ShowDialog();
        }

        private void releaseNotesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FileViewer("Release Notes", Path.Combine(Application.StartupPath, "RELEASE.TXT")).ShowDialog();
        }

        private void supportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowIssues();
        }

        private void watchLogfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Application.StartupPath, "fad2.log"));
        }

        private void userHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://dotnet.work/fad2");
        }
    }
}