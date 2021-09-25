using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Seguridad
{
   public class Bitacora
    {
        public string Accion { get; set; }
        public int Criticidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechayHora { get; set; }
        public string NombreOperacion { get; set; }

        public int Usuarioid { get; set; }


    }
}
