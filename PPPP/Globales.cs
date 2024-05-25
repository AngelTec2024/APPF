using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

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

      // public static int inX { get; set; } 
//        public static int inY  { get; set; }
      //  public static PictureBox Imagen { get; set; } = new PictureBox(); 

        public static int NC = 0;

       // public static PictureBox Hoja { get; set; }

        public static int tipoH { get; set; }
     
        public static Size TamañoHoja { get; set; }

    }




}
