using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using fad2.Backend;
using MetroFramework;

namespace fad2.UI
{
    public partial class StartUp : UserControl
    {
        private bool _connected;

        private int _failCount;

        private Timer _imageSwitchTimer;
        private readonly string _programSettingsFile = Application.StartupPath + "\\fad2.json";

        public StartUp()
        {
            InitializeComponent();
            AutoDownload.Visible = false;
            FileExplorer.Visible = false;
            ImageSwitcher();
            Application.DoEvents();
            StartConnection();
        }

        private void ImageSwitcher()
        {
            // TODO: Allow local Images
            UiSettings.ImageLoop = Directory.GetFiles($"{Application.StartupPath}\\examplepix").ToList();
            _imageSwitchTimer = new Timer();
            _imageSwitchTimer.Interval = 10000; // TODO: From Settings
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
            worker.RunWorkerCompleted += (sender, e) => DisplayConnectionSuccess(sender, e);
            worker.RunWorkerAsync();
        }

        private void ConnectionSuccessFull()
        {
            ConnectionTile.Text = "Connection succeeded";
            ConnectionTile.Style = MetroColorStyle.Green;
            metroProgressSpinner1.Style = MetroColorStyle.Green;
            metroProgressSpinner1.Visible = false;
        }

        private void ConnectionFailed()
        {
            ConnectionTile.Text = $"Connecting (Attempt {_failCount})";

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

        private void DisplayConnectionSuccess(object sender, RunWorkerCompletedEventArgs e)
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
            var connection = new Connection(_programSettingsFile);
            _connected = connection.TestConnection();
        }

        private void StartUp_Resize(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            ChangeImage();
        }
    }
}