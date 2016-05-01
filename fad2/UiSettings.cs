using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Reflection;
using log4net;

namespace fad2.UI
{
    /// <summary>
    /// UI-Settings
    /// </summary>
    public static class UiSettings
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Images for the ImageLoop (Start and Settings)
        /// </summary>
        public static List<string> ImageLoop;

        /// <summary>
        /// Randomizer
        /// </summary>
        private static readonly Random Random = new Random();
        /// <summary>
        /// Current Card Version
        /// </summary>
        public static string CardVersion { get; set; }

        /// <summary>
        /// Check if the current card has a feature
        /// </summary>
        /// <param name="versionToCompare">Required Version</param>
        /// <returns>true if Version is high enough</returns>
        public static bool HasFeature(string versionToCompare)
        {
            if (string.IsNullOrEmpty(versionToCompare))
            {
                return true;
            }
            return versionToCompare.CompareTo(CardVersion) <= 0;
        }

        /// <summary>
        /// Get a random Image from the list
        /// </summary>
        /// <returns>ImageName</returns>
        public static string RandomImageUrl()
        {
            if (ImageLoop == null || ImageLoop.Count == 0)
            {
                return null;
            }
            var randomImageId = Random.Next(ImageLoop.Count);
            return ImageLoop[randomImageId];
        }


        /// <summary>
        /// Get a random resized Image
        /// </summary>
        /// <param name="maxWidth">Width</param>
        /// <param name="maxHeight">Height</param>
        /// <param name="alpha">Transparency</param>
        /// <returns>Image</returns>
        public static Bitmap ResizedImage(int maxWidth, int maxHeight, int alpha = 100)
        {
            var path = RandomImageUrl();
            return ResizedImage(path, alpha, maxWidth, maxHeight);
        }

        /// <summary>
        /// Resize an Image
        /// </summary>
        /// <param name="url">Image</param>
        /// <param name="alpha">Transparency</param>
        /// <param name="maxWidth">Width</param>
        /// <param name="maxHeight">Height</param>
        /// <returns>Image</returns>
        public static Bitmap ResizedImage(Uri url, int alpha, int maxWidth, int maxHeight)
        {
            try
            {
                var request = WebRequest.Create(url.ToString());


                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return ResizedImage(Image.FromStream(stream), alpha, maxWidth, maxHeight);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }

        /// <summary>
        /// Get resized Image from Image
        /// </summary>
        /// <param name="image">Image</param>
        /// <param name="alpha">Transparency</param>
        /// <param name="maxWidth">Width</param>
        /// <param name="maxHeight">Height</param>
        /// <returns>Image</returns>
        public static Bitmap ResizedImage(Image image, int alpha, int maxWidth, int maxHeight)
        {
            var destRect = new Rectangle(0, 0, maxWidth, maxHeight);
            var destImage = new Bitmap(maxWidth, maxHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    if (alpha != 100)
                    {
                        var colormatrix = new ColorMatrix();
                        colormatrix.Matrix33 = alpha/100F;
                        wrapMode.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    }
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        /// <summary>
        /// Get a resized Image from Path
        /// </summary>
        /// <param name="path">local path</param>
        /// <param name="alpha">Transparency</param>
        /// <param name="maxWidth">Width</param>
        /// <param name="maxHeight">Height</param>
        /// <returns>Image</returns>
        public static Bitmap ResizedImage(string path, int alpha, int maxWidth, int maxHeight)
        {
            return string.IsNullOrWhiteSpace(path) ? null : ResizedImage(new Bitmap(path), alpha, maxWidth, maxHeight);
        }
    }
}