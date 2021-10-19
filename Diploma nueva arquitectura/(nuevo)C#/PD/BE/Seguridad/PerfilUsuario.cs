using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Seguridad
{
  public class PerfilUsuario
    {
        public string NombrePerfil { get; set; }
        public string DescPerfil { get; set; }
        public PerfilUsuario() { }
        public int PerfilUsuarioID { get; set; }

        public string Result { get; set; }
    }
}
