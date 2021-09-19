using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Seguridad
{
    public class ManejadorPerfilUsuario
    {
        private string _NombrePerfil;
        public string NombrePerfil
        {
            get { return _NombrePerfil; }
            set { _NombrePerfil = value; }
        }
        public string Operacionn
        { get; set; }
        public int PerfilID { get; set; }
        public Usuario usuBE;

        public string DescPerfil { get; set; }

        public string Result;

        public List<Operacion> DatasetOperaciones
        {
            get; set;
        }


    }
}
