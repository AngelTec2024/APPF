using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPP
{
    public class Configuracion
    {
        public string RutaImagen { get; set; }
        public string RutaImagenCP { get; set; }
        public List<string> Registro { get; set; } = new List<string>();
        public bool AlertaRecorte { get; set; }
        public int NC { get; set; }

        public int TipoH { get; set; }
        public Size TamañoHoja { get; set; }
        public int AuxAgregarImagen { get; set; }
    }
}
