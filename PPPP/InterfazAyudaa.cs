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
        private int currentIndex = 0;
        private Timer timer;


        public InterfazAyudaa()
        {
            InitializeComponent();
            LoadImages();
            InitializeTimer();
        }
        private void LoadImages()
        {
            // Carga las rutas de las imágenes en el array
            imagePaths = new string[]
            {
                "C:\\MiCarpetaDeImagenes\\cropped_image_20240525_002905948.png",
                "C:\\MiCarpetaDeImagenes\\cropped_image_20240525_003158171.png"
                
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
                pictureBox1.ImageLocation = imagePaths[currentIndex];
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
            currentIndex = (currentIndex - 1 + imagePaths.Length) % imagePaths.Length;
            ShowImage();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % imagePaths.Length;
            ShowImage();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 3000; // Cambiar cada 3 segundos
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }
    }
}
