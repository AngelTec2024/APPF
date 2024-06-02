using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPP
{
    public partial class InterfazAyudaa : Form
    {
        private string[] imagePath;
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
            imagePath = new string[]
            {
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/InterfazPrincipal.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Principal_Formatos.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Principal_Cargar.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Principal_Backups.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/InterfazEdicion.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Edicion_Herramientas.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Edicion_pnaux.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Edicion_HojaPre.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/InterfazEdicion_Agregar.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/InterfazEdicion_Guardar.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/InterfazEdicion_Salir.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/InterfazBackups.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Backups_Disponibles.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Backups_Recuperar.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Backups_Eliminar.png",
                "https://raw.githubusercontent.com/AngelTec2024/APPF/ArregloBugs/PPPP/Resources/Backups_Regresar.png"
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
            if (imagePath.Length > 0)
            {
                // URL de la imagen actual
                string imageUrl = imagePath[currentIndex];

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] imageBytes = client.DownloadData(imageUrl);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            Image image = Image.FromStream(ms);
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Ajustar la imagen al tamaño del PictureBox
                            pictureBox1.Image = image;
                        }
                    }

                    // Mostrar la descripción en el label
                    txtDescripcion.Text = descriptions[currentIndex];
                    txtDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen desde la URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % imagePath.Length;
            ShowImage();
        }

        private void InterfazAyudaa_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex - 1 + imagePath.Length) % imagePath.Length;
            ShowImage();
            timer.Start();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex + 1) % imagePath.Length;
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
//            this.Dispose();
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
