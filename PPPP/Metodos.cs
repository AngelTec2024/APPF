using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PPPP
{
    public class Metodos
    {


        public void AddImageToPictureBox(string imagePath, PictureBox Img,int inX,int  inY)
        {
            // Cargar la imagen original
            Image originalImage = Image.FromFile(imagePath);
            // Redimensionar la imagen
            Image resizedImage = ResizeImage(originalImage, (inX * 300), (inY * 300));
            // Mostrar la imagen redimensionada en el PictureBox
            Img.SizeMode = PictureBoxSizeMode.StretchImage;
            Img.Size = resizedImage.Size;
            Img.Image = resizedImage;
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }









    }
}
