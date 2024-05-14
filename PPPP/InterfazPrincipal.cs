using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPP
{
    public partial class InterfazPrincipal : Form
    {
        int TipoH;
        

        public InterfazPrincipal()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            try
            {
                StreamReader lector = new StreamReader(openFileDialog1.FileName);
            }
            catch { 
            
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Mostrar el nuevo formulario
            TipoH = 1;
            
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.TPHoja(TipoH);
            interfazEdicion.Show();
            
            this.Visible=false;
            
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backUpsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TipoH = 2;
            // Mostrar el nuevo formulario
            

            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.TPHoja(TipoH);
            interfazEdicion.Show();

            this.Visible = false;


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TipoH = 3;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.TPHoja(TipoH);
            interfazEdicion.Show();
            this.Visible = false;


        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TipoH = 4;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.TPHoja(TipoH);
            interfazEdicion.Show();
            this.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TipoH = 5;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.TPHoja(TipoH);
            interfazEdicion.Show();
            this.Visible = false;
        }
    }
}
