using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WcatIndexDownload
{
    static class Static_Function
    {
        public static Bitmap ResizeImage(this Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(width, height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }
            return bitmap;
        }

        public static bool ComparisonFileName(this string fileName)
        {
            try
            {
                string tempFileName = "";
                foreach (char item in fileName)
                {
                    if ((item >= 48 && item <= 57) || (item >= 65 && item <= 90) || item == 95 || (item >= 97 && item <= 122))
                        tempFileName += item;
                }
                return fileName == tempFileName;
            }
            catch (Exception) { return false; }
        }
    }
}
