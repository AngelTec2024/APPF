using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;

namespace PPPP
{
 
        public static class Globales
        {
        public static string RutaImagen { get; set; } // ruta

        public static string RutaImagenCP { get; set; } // ruta se utiliza en Recorte Como Panel
        public static Image ImagenGlobalCP { get; set; } // imagen se utiliza en Recorte Como Panel
        public static Image ImagenGlobal { get; set; } // imagen

        public static ListBox Registro { get; set; } = new ListBox();

        public static Boolean AlertaRecorte { get; set; }

        public static int NC = 0;

        public static int tipoH { get; set; }
     
        public static Size TamañoHoja { get; set; }

        public static int AuxAgregarImagen { get; set; }





        private const string BackupDirectory = @"C:\MiCarpetaDeImagenes\backups";
        private const string ConfigFileName = "configuracion.json";
        private static string ConfigFilePath => Path.Combine(BackupDirectory, ConfigFileName);

        public static int VariableEntera { get; set; }
        public static string VariableCadena { get; set; }


        static Globales()
        {
            // Asegúrate de que el directorio de backups exista
            if (!Directory.Exists(BackupDirectory))
            {
                Directory.CreateDirectory(BackupDirectory);
            }
        }


        public static void GuardarConfiguracion()
        {
            var configuracion = new
            {
                VariableEntera,
                VariableCadena,
                // Agrega otras variables según sea necesario
            };

            string json = JsonConvert.SerializeObject(configuracion, Formatting.Indented);

            // Guarda la configuración actual
            File.WriteAllText(ConfigFilePath, json);

            // Guarda una copia de respaldo con timestamp
            string backupFilePath = Path.Combine(BackupDirectory, $"{Path.GetFileNameWithoutExtension(ConfigFileName)}_{DateTime.Now:yyyyMMdd_HHmmss}.json");
            File.WriteAllText(backupFilePath, json);
        }


        public static void CargarConfiguracion()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                dynamic configuracion = JsonConvert.DeserializeObject(json);

                VariableEntera = configuracion.VariableEntera;
                VariableCadena = configuracion.VariableCadena;
                // Agrega otras variables según sea necesario
            }
        }


        public static void ListarBackups()
        {
            string[] backupFiles = Directory.GetFiles(BackupDirectory, "configuracion_*.json");

            Console.WriteLine("Lista de archivos de configuración disponibles:");
            foreach (var file in backupFiles)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        public static void RestaurarBackup(string backupFileName)
        {
            string backupFilePath = Path.Combine(BackupDirectory, backupFileName);
            if (File.Exists(backupFilePath))
            {
                string json = File.ReadAllText(backupFilePath);
                File.WriteAllText(ConfigFilePath, json);
                CargarConfiguracion();
            }
            else
            {
                Console.WriteLine("El archivo de backup no existe.");
            }
        }



        /*public static void GuardarConfiguracion(string filePath)
        {
            var configuracion = new Configuracion
            {
                RutaImagen = RutaImagen,
                RutaImagenCP = RutaImagenCP,
                ImagenGlobalCP = ImagenToBase64(ImagenGlobalCP),
                ImagenGlobal = ImagenToBase64(ImagenGlobal),
                Registro = Registro.Items.Cast<string>().ToList(),
                AlertaRecorte = AlertaRecorte,
                NC = NC,
                TipoH = tipoH,
                TamañoHoja = TamañoHoja,
                AuxAgregarImagen = AuxAgregarImagen
            };

            var json = JsonConvert.SerializeObject(configuracion, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }


        public static void CargarConfiguracion(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var configuracion = JsonConvert.DeserializeObject<Configuracion>(json);

                RutaImagen = configuracion.RutaImagen;
                RutaImagenCP = configuracion.RutaImagenCP;
                ImagenGlobalCP = Base64ToImagen(configuracion.ImagenGlobalCP);
                ImagenGlobal = Base64ToImagen(configuracion.ImagenGlobal);
                Registro.Items.Clear();
                foreach (var item in configuracion.Registro)
                {
                    Registro.Items.Add(item);
                }
                AlertaRecorte = configuracion.AlertaRecorte;
                NC = configuracion.NC;
                tipoH = configuracion.TipoH;
                TamañoHoja = configuracion.TamañoHoja;
                AuxAgregarImagen = configuracion.AuxAgregarImagen;
            }
        }


        private static string ImagenToBase64(Image image)
        {
            if (image == null) return null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private static Image Base64ToImagen(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return null;
            var imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

        */









    } ///
}
