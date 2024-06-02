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
using static PPPP.Metodos;
using System.ComponentModel;

namespace PPPP
{
 
        public static class Globales
        {
        public static string RutaImagen { get; set; } // ruta

        public static string RutaImagenCP { get; set; } // ruta se utiliza en Recorte Como Panel
        public static Image ImagenGlobalCP { get; set; } // imagen se utiliza en Recorte Como Panel
        public static ListBox Registro { get; set; } = new ListBox();
        public static Boolean AlertaRecorte { get; set; }

        //  public static int NC = 0;
        public static int tipoH { get; set; }
        //public static Size TamañoHoja { get; set; }
        public static int AuxAgregarImagen { get; set; }
        public static string BackupDirectory { get; } = @"C:\MiCarpetaDeImagenes\backups";


        //public static string CargarDirectory { get; } = @"C:\MiCarpetaDeImagenes\backups";

        static Globales()
        {
            // Asegúrate de que el directorio de backups exista
            if (!Directory.Exists(BackupDirectory))
            {
                Directory.CreateDirectory(BackupDirectory);
            }
        }

        public static void GuardarConfiguracion(string filePath)
        {
            var configuracion = new Configuracion
            {
                RutaImagen = Globales.RutaImagen,
                RutaImagenCP = Globales.RutaImagenCP,
                Registro = Globales.Registro.Items.Cast<string>().ToList(),
                AlertaRecorte = Globales.AlertaRecorte,
               // NC = Globales.NC,
                TipoH = Globales.tipoH,
                //TamañoHoja = Globales.TamañoHoja,
                AuxAgregarImagen = Globales.AuxAgregarImagen
            };
            Console.WriteLine(tipoH);
              var json = JsonConvert.SerializeObject(configuracion, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }


        public static void CargarConfiguracion(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var configuracion = JsonConvert.DeserializeObject<Configuracion>(json);

                Globales.RutaImagen = configuracion.RutaImagen;
                Globales.RutaImagenCP = configuracion.RutaImagenCP;
                foreach (var item in configuracion.Registro)
                {
                    Globales.Registro.Items.Add(item);
                }
                Globales.AlertaRecorte = configuracion.AlertaRecorte;
                //Globales.NC = configuracion.NC;
                Globales. tipoH = configuracion.TipoH;
                //Globales.TamañoHoja = configuracion.TamañoHoja;
                Globales.AuxAgregarImagen = configuracion.AuxAgregarImagen;
             
            }

            string rutaCompletaCarpetaEspecifica = Path.GetFullPath(BackupDirectory);
            if (filePath.StartsWith(rutaCompletaCarpetaEspecifica, StringComparison.OrdinalIgnoreCase))
            {
                File.Delete(filePath);
            }
            else {
            }
            
            
        }

        /*
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

        public static void ReiniciarVariables()
        {
            RutaImagen = null;
            RutaImagenCP = null;
            ImagenGlobalCP = null;
            //ImagenGlobal = null;
            Registro.Items.Clear();


            AlertaRecorte = false;
            //NC = 0;
            tipoH = 0;
          //  TamañoHoja = Size.Empty;
            AuxAgregarImagen = 0;
            Globales.RutaImagen = null;
            ImageContainer.ImagenRecortada =null;
        }


    } ///
}
