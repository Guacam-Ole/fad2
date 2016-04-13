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

namespace fad2
{
    public partial class Fad : MetroFramework.Forms.MetroForm
    {
        private List<string> _imageLoop;
        private string _currentBackImage;
        Timer _imageSwitchTimer;
        Random _random = new Random();

        public Fad()
        {
            InitializeComponent();
            ImageSwitcher();
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
    }
}
