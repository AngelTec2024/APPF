using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPP
{
    public partial class InterfazAyudaa : Form
    {
        private string[] imagePaths;
        private string[] descriptions;
        private int currentIndex = 0;
        private Timer timer;



        public InterfazAyudaa()
        {
            InitializeComponent();
            LoadImages();
            InitializeTimer();
        }
        private void LoadImages()
        {// Carga las rutas de las imágenes en el array
            imagePaths = new string[]
            {
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\InterfazPrincipal.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Principal_Formatos.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Principal_Cargar.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Principal_Backups.png",

                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\InterfazEdicion.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Edicion_Herramientas.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Edicion_pnaux.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Edicion_HojaPre.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\InterfazEdicion_Agregar.png.",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\InterfazEdicion_Guardar.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\InterfazEdicion_Salir.png",


                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\InterfazBackups.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Backups_Disponibles.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Backups_Recuperar.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Backups_Eliminar.png",
                "C:\\MiCarpetaDeImagenes\\ImgAyuda\\Backups_Regresar.png"
            };

            // Carga las descripciones en el array
            descriptions = new string[]
            {
                "Interfaz Principal",
                "Interfaz Princiapal - Formatos disponibles de hojas",
                "Interfaz Princiapal - Cargar estado de programa",
                "Interfaz Princiapal - Acceder a las backups realizadas",

                "Interfaz Edición",
                "Interfaz Edición - Barra de herrameintas",
                "Interfaz Edición - Panel de trabajo",
                "Interfaz Edición - Previsualización de la hoja",
                "Interfaz Edición - Agregar imagen a la hoja",
                "Interfaz Edición - Guardar hoja",
                "Interfaz Edición - Salir a la interfaz principal",

                "Interfaz Backups",
                "Interfaz Backups - Backups disponibles para restaurar",
                "Interfaz Backups - Restaurar backup",
                "Interfaz Backups - Eliminar backup",
                "Interfaz Backups - Regresar a la interfaz principal"
            };

            ShowImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ShowImage()
        {
            if (imagePaths.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Ajusta la imagen al tamaño del PictureBox

                // Ruta de la imagen principal
                string mainImagePath = imagePaths[currentIndex];

                try
                {
                    // Verificar si la ruta es correcta y el archivo existe
                    if (!System.IO.File.Exists(mainImagePath))
                    {
                        throw new System.IO.FileNotFoundException($"Imagen principal no encontrada: {mainImagePath}");
                    }

                    // Cargar la imagen principal
                    Image mainImage = Image.FromFile(mainImagePath);

                    // Mostrar la imagen principal en pictureBox1
                    pictureBox1.Image = mainImage;

                    // Mostrar la descripción en el label
                    txtDescripcion.Text = descriptions[currentIndex];

                    //txtDescripcion.Text = descriptions[currentIndex];
                    //txtDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                    //txtDescripcion.AutoSize = true;
                    //txtDescripcion.Dock = DockStyle.Fill;
                    //txtDescripcion.Padding = new Padding(10);


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar imágenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % imagePaths.Length;
            ShowImage();
        }

        private void InterfazAyudaa_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex - 1 + imagePaths.Length) % imagePaths.Length;
            ShowImage();
            timer.Start();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex + 1) % imagePaths.Length;
            ShowImage();
            timer.Start();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 2000; // Cambiar cada 3 segundos
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
