using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Account
{
   public class Sesion
    {
        private static Sesion oInstance;
        private BLL.Usuario usuario;

        protected Sesion()
        {
        }

        public static Sesion Instance()
        {

            if (oInstance == null)
                oInstance = new Sesion();

            return oInstance;

        }
        public int Usuarioid { get; set; }

        public static string usuid { get; set; } = string.Empty;


    }
}
