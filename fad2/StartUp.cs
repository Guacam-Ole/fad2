using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using fad2.Backend;

namespace fad2.UI
{
    public partial class StartUp : UserControl
    {
       
        Timer _imageSwitchTimer;
       
        private int _failCount = 0;
        private bool _connected = false;


        public StartUp()
        {
            InitializeComponent();
            ImageSwitcher();
            Application.DoEvents();
            StartConnection();
        }

        private void ImageSwitcher()
        {
            // TODO: Allow local Images
            UiSettings.ImageLoop = Directory.GetFiles($"{Application.StartupPath}\\examplepix").ToList();
            _imageSwitchTimer = new Timer();
            _imageSwitchTimer.Interval = 10000;  // TODO: From Settings
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
            var worker = new System.ComponentModel.BackgroundWorker();
            worker.DoWork += (sender, e) => TryToConnect();
            worker.RunWorkerCompleted += (sender, e) => DisplayConnectionSuccess(sender, e);
            worker.RunWorkerAsync();
        }

        private void ConnectionSuccessFull()
        {
            ConnectionTile.Text = "Connection succeeded";
            ConnectionTile.Style = MetroFramework.MetroColorStyle.Green;
            metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Green;
            metroProgressSpinner1.Visible = false;
        }

        private void ConnectionFailed()
        {
            ConnectionTile.Text = $"Connecting (Attempt {_failCount})";

            if (_failCount > 4)
            {
                ConnectionTile.Style = MetroFramework.MetroColorStyle.Red;
                metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Red;
            }
            else if (_failCount > 2)
            {
                ConnectionTile.Style = MetroFramework.MetroColorStyle.Orange;
                metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Orange;
            }
        }

        private void DisplayConnectionSuccess(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_connected)
            {
                Action tileAction = () => ConnectionSuccessFull();
                ConnectionTile.Invoke(tileAction);

                Action helpAction = () => ConnectionHelp.Visible = false;
                ConnectionHelp.Invoke(helpAction);

                // TODO: Switch Panel
            }
            else
            {
                _failCount++;

                Action tileAction = () => ConnectionFailed();
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
            var connection = new Connection();
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
