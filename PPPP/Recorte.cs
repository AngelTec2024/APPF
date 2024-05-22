using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PPPP.Metodos;


namespace PPPP
{
    public partial class Recorte : Form
    {

        public Image ImagenRecortada { get; private set; } // COMPARTIR IMAGEN
        private bool recortarActivo = true;
        private int xDown = 0;
        private int yDown = 0;
        private int xUp = 0;
        private int yUp = 0;
        Rectangle rectCropArea = new Rectangle();
        Task timeout;
        string fn = "";
        public Image imagenARecortar;




        public Recorte(Image imagen)
        {
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.imagenARecortar = imagen;
            MostrarImagen();
        }

        private void MostrarImagen()
        {
            if (imagenARecortar != null)
            {
                pbRecortar2.Image = imagenARecortar;
                pbRecortar2.Size = pbRecortar2.Image.Size;
                pbRecortar2.Cursor = Cursors.Cross;
            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crea un nuevo Bitmap para la imagen recortada
                Bitmap recortadaBitmap = new Bitmap(rectCropArea.Width, rectCropArea.Height);

                // Dibuja el área recortada en el nuevo Bitmap
                using (Graphics g = Graphics.FromImage(recortadaBitmap))
                {
                    g.DrawImage(pbRecortar2.Image, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                }

                // Actualiza la imagen del PictureBox pbRecortar con la imagen recortada
                pbRecortar2.Image = recortadaBitmap;

                this.ImagenRecortada = pbRecortar2.Image;

                ImageContainer.ImagenRecortada = this.ImagenRecortada;
                ImageContainer.ImagenRecortada = recortadaBitmap;

                // Cerrar el formulario de recorte
                //this.Close();



            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                MessageBox.Show("Error al aplicar el recorte: " + ex.Message);
            }
        }




        private void btnRegresar_Click(object sender, EventArgs e)
        {
            InterfazEdicion IE = new InterfazEdicion();
            IE.Show();
            //Recorte pnRecorte = new Recorte();
            //pnRecorte.Show();
            this.Visible = false;
        }

        private void pbRecortar2_MouseDown(object sender, MouseEventArgs e)
        {
            if (recortarActivo)
            {
                // Guarda las coordenadas del punto inicial del área de recorte
                xDown = e.X;
                yDown = e.Y;
            }
        }

        private void pbRecortar2_MouseUp(object sender, MouseEventArgs e)
        {
            if (recortarActivo)
            {
                // Guarda las coordenadas del punto final del área de recorte
                xUp = e.X;
                yUp = e.Y;

                // Calcula las coordenadas y dimensiones del área de recorte
                rectCropArea = new Rectangle(
                    Math.Min(xDown, xUp),
                    Math.Min(yDown, yUp),
                    Math.Abs(xUp - xDown),
                    Math.Abs(yUp - yDown));

                // Dibuja un rectángulo en el PictureBox para mostrar el área seleccionada
                using (Pen pen = new Pen(Color.YellowGreen, 3))
                {
                    pbRecortar2.CreateGraphics().DrawRectangle(pen, rectCropArea);
                }
            }
        }

        private void Recortar_Click(object sender, EventArgs e)
        {

            try
            {
                // Crea un nuevo Bitmap para la imagen recortada
                Bitmap recortadaBitmap = new Bitmap(rectCropArea.Width, rectCropArea.Height);

                // Dibuja el área recortada en el nuevo Bitmap
                using (Graphics g = Graphics.FromImage(recortadaBitmap))
                {
                    g.DrawImage(pbRecortar2.Image, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                }

                // Actualiza la imagen del PictureBox pbRecortar con la imagen recortada
                pbRecortar2.Image = recortadaBitmap;

                this.ImagenRecortada = pbRecortar2.Image;

                ImageContainer.ImagenRecortada = this.ImagenRecortada;
                ImageContainer.ImagenRecortada = recortadaBitmap;

                // Cerrar el formulario de recorte
                //this.Close();



            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                MessageBox.Show("Error al aplicar el recorte: " + ex.Message);
            }


        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            InterfazEdicion IE = new InterfazEdicion();
            IE.Show();
            //Recorte pnRecorte = new Recorte();
            //pnRecorte.Show();
            this.Visible = false;
        }
    }
}
