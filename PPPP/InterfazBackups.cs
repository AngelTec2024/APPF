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
    public partial class InterfazBackups : Form
    {


        private string backupFolderPath = @"C:\MiCarpetaDeImagenes\backups";

        public InterfazBackups()
        {
            InitializeComponent();
            CargarArchivosDeRespaldo();

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            int selectedIndex = LBack.SelectedIndex;
            
            // Verificar si hay un elemento seleccionado
            if (selectedIndex != -1)
            {
                // Eliminar el elemento seleccionado
                //Globales.Registro.Items.RemoveAt(selectedIndex);
               //string CarpertaBck = Environment.GetFolderPath();
                //LeerRegistro();
                Globales.CargarConfiguracion(LBack.SelectedIndex.ToString());
                InterfazEdicion IE = new InterfazEdicion();
                IE.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }





        }

        private void CargarArchivosDeRespaldo()
        {
            LBack.Items.Clear();

            if (Directory.Exists(backupFolderPath))
            {
                string[] archivos = Directory.GetFiles(backupFolderPath, "*.json");

                foreach (string archivo in archivos)
                {
                   LBack.Items.Add(Path.GetFileName(archivo));
                }
            }
            else
            {
                MessageBox.Show("La carpeta de respaldo no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
