﻿using System;
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
        public static string RutaImagenRecortada { get; set; } // ruta
        public static Image ImagenGlobal { get; set; } // imagen

        public static ListBox Registro { get; set; } = new ListBox();

        public static int AlertaRecorte { get; set; }

        public static int inX { get; set; } 
        public static int inY  { get; set; }

        public static int innX { get; set; }
        public static int innY{ get; set; }
        public static int NNC { get; set; }
        public static string Direc { get; set; }
        
        public static string FName { get; set; }

        public static PictureBox Imagen { get; set; } = new PictureBox();
        public static int NC = 0;

        public static PictureBox Hoja { get; set; }
        public static Size TamañoHoja { get; set; }

    }




}
