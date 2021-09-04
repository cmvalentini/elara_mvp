using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Idioma
{
   public class Idioma
    {
        public string ISeleccionado = "";
        public Idioma() { }
        public int IdiomaID { get; set; }
        public string Descripcion { get; set; }

        public string Result { get; set; }

    }
}
