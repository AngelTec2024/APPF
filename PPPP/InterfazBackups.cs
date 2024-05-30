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
            CargarListaDeBackups();
            //CargarArchivosDeRespaldo();

        }

        private void CargarListaDeBackups()
        {
            string directorio = Globales.BackupDirectory;

            if (Directory.Exists(directorio))
            {
                string[] archivos = Directory.GetFiles(directorio, "*.json");

                LBack.Items.Clear();
                LBack.Items.AddRange(archivos);
            }
            else
            {
                MessageBox.Show("El directorio de backups no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rjButton2_Click(object sender, EventArgs e)
        {
            int selectedIndex = LBack.SelectedIndex;
            if (selectedIndex != -1)
            {
               
                string archivoSeleccionado = LBack.Items[selectedIndex].ToString();
                Globales.CargarConfiguracion(archivoSeleccionado);
                InterfazEdicion IE = new InterfazEdicion();
                IE.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento para restaurar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            InterfazPrincipal interfazPrincipal = new InterfazPrincipal();
            this.Visible = false;
            interfazPrincipal.Show();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selectedIndex = LBack.SelectedIndex;

            // Verificar si hay un elemento seleccionado
            if (selectedIndex != -1)
            {
                // Obtener la ruta del archivo seleccionado
                string archivoSeleccionado = LBack.Items[selectedIndex].ToString();

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el archivo de backup '{archivoSeleccionado}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Eliminar el archivo
                        File.Delete(archivoSeleccionado);

                        // Actualizar la lista de backups
                        CargarListaDeBackups();

                        MessageBox.Show("Archivo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al eliminar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un archivo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
