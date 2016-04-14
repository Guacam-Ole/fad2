using fad.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fad2.UI
{
    public partial class Fad : MetroFramework.Forms.MetroForm
    {
        private List<string> _imageLoop;
        Timer _imageSwitchTimer;
        Random _random = new Random();
        private int _failCount = 0;
        private bool _connected = false;
        

        public Fad()
        {
           
            InitializeComponent();
            ImageSwitcher();
            Application.DoEvents();
            StartConnection();
            SetCombos();
        }

        private void SetCombos()
        {
            var appModes= new List<KeyValuePair<int, string>>();
            appModes.Add(new KeyValuePair<int, string>(4, "AP (Access Point) mode " ));
            appModes.Add(new KeyValuePair<int, string>(5, "STA (Station) mode "));
            appModes.Add(new KeyValuePair<int, string>(6, "Pass-Thru mode"));
            VendorAppMode.DataSource = appModes;

            var dnsModes = new List<KeyValuePair<int, string>>();
            dnsModes.Add(new KeyValuePair<int, string>(0, "Return IP Only if request is done with APPNAME"));
            dnsModes.Add(new KeyValuePair<int, string>(1, "Always return IP to DNS requests (default)"));
            VendorDns.DataSource = dnsModes;

            var webdavModes=new List<KeyValuePair<int, string>>();
            webdavModes.Add(new KeyValuePair<int, string>(0, "Disable FlashAir Drive"));
            webdavModes.Add(new KeyValuePair<int, string>(1, "Read only - mode"));
            webdavModes.Add(new KeyValuePair<int, string>(2, "Read/write - mode"));
            VendorWebDav.DataSource = webdavModes;
        }

        private void ImageSwitcher()
        {
            // TODO: Allow local Images
            _imageLoop = Directory.GetFiles($"{Application.StartupPath}\\examplepix").ToList();
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
            int randomImageId= _random.Next(_imageLoop.Count);
            ChangeImage(_imageLoop[randomImageId]);
        }

        private Bitmap ResizedImage(string path)
        {
            int alpha = 150;
            var bitmap = new Bitmap(path);
            double aspectRatio =  bitmap.Width / (double)bitmap.Height;
            int maxWidth = BackPicture.Width;
            int maxHeight = BackPicture.Height;
            int imageWidth = maxWidth;
            int imageHeight = (int)(imageWidth / aspectRatio);
            if (imageHeight<maxHeight)
            {
                imageHeight = maxHeight;
                imageWidth = (int)(imageHeight * aspectRatio);
            }

            var image = new Bitmap(bitmap, new Size(imageWidth, imageHeight));

            using (Graphics g = Graphics.FromImage(image))
            {
                Pen pen = new Pen(Color.FromArgb(alpha, 255, 255, 255), image.Width);
                g.DrawLine(pen, -1, -1, image.Width, image.Height);
                g.Save();
            }

            return image;
        }

        private void ChangeImage(string path)
        {
            BackPicture.Image = ResizedImage(path);
        }

        private void Fad_Resize(object sender, EventArgs e)
        {
            ChangeImage();
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
            else if (_failCount>2)
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

       
      

        private void TryToConnect() {
            var connection = new Connection();
            _connected = connection.TestConnection();
           
        }

        private void DontDoAnythingStupid_Click(object sender, EventArgs e)
        {

        }
    }
}
