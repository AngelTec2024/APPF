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
using Newtonsoft.Json;

namespace PPPP
{
    public partial class InterfazPrincipal : Form
    {
        private const string ConfigFilePath = "configuracion.json";


        int TipoH;
        

        public InterfazPrincipal()
        {
            InitializeComponent();
        }


        
        private void InterfazPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Globales.GuardarConfiguracion(ConfigFilePath);
            Globales.GuardarConfiguracion();
        }

        private void listarBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globales.ListarBackups();
        }

        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\MiCarpetaDeImagenes\backups";
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Selecciona un archivo de backup";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFileName = Path.GetFileName(openFileDialog.FileName);
                Globales.RestaurarBackup(backupFileName);
                MessageBox.Show("Backup restaurado exitosamente.");
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////

        public void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            try
            {
                StreamReader lector = new StreamReader(openFileDialog1.FileName);
            }
            catch { 
            
            }


        }


        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
                InterfazAyudaa InterfazAyuda = new InterfazAyudaa();

                InterfazAyuda.Show();
        }

        private void backUpsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {
            Globales.CargarConfiguracion();
            //Globales.CargarConfiguracion(ConfigFilePath);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void Carta_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //Carta
            Globales.tipoH= 1;
            // Mostrar el nuevo formulario

            
            
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.Show();

            this.Visible = false;
        }

        private void Oficio_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Oficio
            Globales.tipoH = 2;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            
            interfazEdicion.Show();

            this.Visible = false;
        }

        private void A4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //A4
            Globales.tipoH = 3;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            
            interfazEdicion.Show();
            this.Visible = false;

        }


        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //A3
            Globales.tipoH = 4;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            interfazEdicion.Show();

            this.Visible = false;
        }


        private void A2_MouseClick(object sender, MouseEventArgs e)
        {
            //A2
            Globales.tipoH = 5;
            InterfazEdicion interfazEdicion = new InterfazEdicion();
            
            interfazEdicion.Show();
            this.Visible = false;
        }


        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //A2
            Globales.tipoH = 6;
            InterfazEdicion interfazEdicion = new InterfazEdicion();

            interfazEdicion.Show();
            this.Visible = false;
        }

        private void Carta_MouseEnter(object sender, EventArgs e)
        {
            Carta.BackColor = Color.LightGray;
        }

        private void Carta_MouseLeave(object sender, EventArgs e)
        {
            Carta.BackColor = Color.Transparent;
        }

        private void Oficio_MouseEnter(object sender, EventArgs e)
        {
            Oficio.BackColor = Color.LightGray;
        }

        private void Oficio_MouseLeave(object sender, EventArgs e)
        {
            Oficio.BackColor = Color.Transparent;
        }

        private void A4_MouseEnter(object sender, EventArgs e)
        {
            A4.BackColor = Color.LightGray;
        }

        private void A4_MouseLeave(object sender, EventArgs e)
        {
            A4.BackColor = Color.Transparent;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
               panel2.BackColor = Color.LightGray;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Transparent;
        }

        private void Tabloide_MouseEnter(object sender, EventArgs e)
        {
            Tabloide.BackColor = Color.LightGray;
        }

        private void Tabloide_MouseLeave(object sender, EventArgs e)
        {
            Tabloide.BackColor = Color.Transparent;
        }

        private void A2_MouseEnter(object sender, EventArgs e)
        {
            A2.BackColor = Color.LightGray;

        }

        private void A2_MouseLeave(object sender, EventArgs e)
        {
            A2.BackColor = Color.Transparent;

        }
    }
}
