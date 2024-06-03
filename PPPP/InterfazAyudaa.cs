using System;
using System.Drawing;
using System.Windows.Forms;

namespace PPPP
{
    public partial class InterfazAyudaa : Form
    {
        private Image[] images;
        private string[] descriptions;
        private int currentIndex = 0;
        private Timer timer;

        public InterfazAyudaa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadImages();
            InitializeTimer();
        }

        private void LoadImages()
        {
            // Carga las descripciones en el array
            descriptions = new string[]
            {
                "Interfaz Principal",
                "Interfaz Principal - Formatos disponibles de hojas",
                "Interfaz Principal - Cargar estado de programa",
                "Interfaz Principal - Acceder a las backups realizadas",
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

            // Carga las imágenes desde los recursos
            images = new Image[]
            {
                PPPP.Properties.Resources.InterfazPrincipal,
                PPPP.Properties.Resources.Principal_Formatos,
                PPPP.Properties.Resources.Principal_Cargar,
                PPPP.Properties.Resources.Principal_Backups,
                PPPP.Properties.Resources.InterfazEdicion,
                PPPP.Properties.Resources.Edicion_Herramientas,
                PPPP.Properties.Resources.Edicion_pnaux,
                PPPP.Properties.Resources.Edicion_HojaPre,
                PPPP.Properties.Resources.InterfazEdicion_Agregar,
                PPPP.Properties.Resources.InterfazEdicion_Guardar,
                PPPP.Properties.Resources.InterfazEdicion_Salir,
                PPPP.Properties.Resources.InterfazBackups,
                PPPP.Properties.Resources.Backups_Disponibles,
                PPPP.Properties.Resources.Backups_Recuperar,
                PPPP.Properties.Resources.Backups_Eliminar,
                PPPP.Properties.Resources.Backups_Regresar
            };

            ShowImage();
        }

        private void ShowImage()
        {
            if (images.Length > 0)
            {
                // Imagen actual
                Image image = images[currentIndex];

                // Mostrar la imagen en el PictureBox
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Ajustar la imagen al tamaño del PictureBox
                pictureBox1.Image = image;

                // Mostrar la descripción en el label
                txtDescripcion.Text = descriptions[currentIndex];
                txtDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Length;
            ShowImage();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex - 1 + images.Length) % images.Length;
            ShowImage();
            timer.Start();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex + 1) % images.Length;
            ShowImage();
            timer.Start();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 2000; // Cambiar cada 2 segundos
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InterfazAyudaa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
