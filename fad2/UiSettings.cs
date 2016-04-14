using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace fad2.UI
{
    public static class UiSettings
    {
        public static List<string> ImageLoop;
        public static string CardVersion { get; set; }
        private static Random _random = new Random();
        public static bool HasFeature(string versionToCompare)
        {
            return versionToCompare.CompareTo(CardVersion) >= 0;
        }

        public static string RandomImageUrl()
        {
            int randomImageId = _random.Next(ImageLoop.Count);
            return ImageLoop[randomImageId];
        }


        public static Bitmap ResizedImage( int maxWidth, int maxHeight)
        {
            string path = RandomImageUrl();
            int alpha = 150;
            var bitmap = new Bitmap(path);
            double aspectRatio = bitmap.Width / (double)bitmap.Height;
          
            int imageWidth = maxWidth;
            int imageHeight = (int)(imageWidth / aspectRatio);
            if (imageHeight < maxHeight)
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
    }
}
