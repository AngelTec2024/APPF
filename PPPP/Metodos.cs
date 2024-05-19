using System;
using System.Collections.Generic;
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



        public static List<Rectangle> CalcularEspaciosLibres(int hojaAncho, int hojaAlto, List<Rectangle> posicionesOcupadas)
        {
            List<Rectangle> espaciosLibres = new List<Rectangle>
        {
            new Rectangle(0, 0, hojaAncho, hojaAlto)
        };

            foreach (var pos in posicionesOcupadas)
            {
                for (int i = espaciosLibres.Count - 1; i >= 0; i--)
                {
                    var espacio = espaciosLibres[i];
                    if (pos.IntersectsWith(espacio))
                    {
                        espaciosLibres.RemoveAt(i);
                        var interseccion = Rectangle.Intersect(pos, espacio);
                        if (interseccion.Top > espacio.Top)
                        {
                            espaciosLibres.Add(new Rectangle(espacio.Left, espacio.Top, espacio.Width, interseccion.Top - espacio.Top));
                        }
                        if (interseccion.Bottom < espacio.Bottom)
                        {
                            espaciosLibres.Add(new Rectangle(espacio.Left, interseccion.Bottom, espacio.Width, espacio.Bottom - interseccion.Bottom));
                        }
                        if (interseccion.Left > espacio.Left)
                        {
                            espaciosLibres.Add(new Rectangle(espacio.Left, interseccion.Top, interseccion.Left - espacio.Left, interseccion.Height));
                        }
                        if (interseccion.Right < espacio.Right)
                        {
                            espaciosLibres.Add(new Rectangle(interseccion.Right, interseccion.Top, espacio.Right - interseccion.Right, interseccion.Height));
                        }
                    }
                }
            }
            return espaciosLibres;
        }
    







}
}
