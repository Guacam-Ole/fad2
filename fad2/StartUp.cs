using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using fad2.Backend;
using fad2.UI.Properties;
using MetroFramework;

namespace fad2.UI
{
    /// <summary>
    /// Startup-Page
    /// </summary>
    public partial class StartUp : UserControl
    {
        private readonly string _programSettingsFile = $"{Application.StartupPath}\\{Properties.Settings.Default.ProgramSettingsFile}";

        private bool _connected;

        private readonly Connection _connection;

        private int _failCount;

        private Timer _imageSwitchTimer;
        private Control _parentControl;

        public StartUp(Control parent=null)
        {
            _connection = new Connection(_programSettingsFile);
            InitializeComponent();
            AutoDownload.Visible = false;
            FileExplorer.Visible = false;
            ImageSwitcher();
            Application.DoEvents();
            StartConnection();
            _parentControl = parent;
        }

        private void ImageSwitcher()
        {
            _connection.Settings.ImageBackgroundFolder = _connection.Settings.ImageBackgroundFolder ?? $"{Application.StartupPath}\\examplepix";
            UiSettings.ImageLoop = Directory.GetFiles(_connection.Settings.ImageBackgroundFolder).ToList();
            _imageSwitchTimer = new Timer {Interval= _connection.Settings.ImageBackgroundTimer };
            _imageSwitchTimer.Tick += _imageSwitchTimer_Tick;
            _imageSwitchTimer.Start();
            ChangeImage();
        }

        private void _imageSwitchTimer_Tick(object sender, EventArgs e)
        {
            ChangeImage();
        }


        private void ChangeImage()
        {
            BackPicture.Image = UiSettings.ResizedImage(BackPicture.Width, BackPicture.Height, 45);
        }


        private void StartConnection()
        {
            _failCount = 1;
            RetryConnection();
        }

        private void RetryConnection()
        {
            _connected = false;
            var worker = new BackgroundWorker();
            worker.DoWork += (sender, e) => TryToConnect();
            worker.RunWorkerCompleted += (sender, e) => DisplayConnectionSuccess();
            worker.RunWorkerAsync();
        }

        private void ConnectionSuccessFull()
        {
            ConnectionTile.Text = Resources.ConnectionSuccess;
            ConnectionTile.Style = MetroColorStyle.Green;
            metroProgressSpinner1.Style = MetroColorStyle.Green;
            metroProgressSpinner1.Visible = false;
        }

        private void ConnectionFailed()
        {
            ConnectionTile.Text = string.Format(Resources.ConnectionTry, _failCount);

            if (_failCount > 4)
            {
                ConnectionTile.Style = MetroColorStyle.Red;
                metroProgressSpinner1.Style = MetroColorStyle.Red;
            }
            else if (_failCount > 2)
            {
                ConnectionTile.Style = MetroColorStyle.Orange;
                metroProgressSpinner1.Style = MetroColorStyle.Orange;
            }
        }

        private void DisplayConnectionSuccess()
        {
            if (_connected)
            {
                Action helpAction = () =>
                {
                    ConnectionSuccessFull();
                    ConnectionHelp.Visible = false;
                    AutoDownload.Visible = true;
                    FileExplorer.Visible = true;
                };
                ConnectionHelp.Invoke(helpAction);
            }
            else
            {
                _failCount++;

                Action tileAction = ConnectionFailed;
                ConnectionTile.Invoke(tileAction);
                if (_failCount > 1)
                {
                    Action helpAction = () => ConnectionHelp.Visible = true;
                    ConnectionHelp.Invoke(helpAction);
                }
                RetryConnection();
            }
        }

        private void TryToConnect()
        {
           
            _connected = _connection.TestConnection();
        }

        private void StartUp_Resize(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void AutoDownload_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            var auto = new FileCopy(true) {Dock = DockStyle.Fill};
            Controls.Add(auto);
            auto.LoadContents("/DCIM", _connection.Settings.LocalPath);
        }
    }
}