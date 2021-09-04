using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;

namespace DAL
{
   public class Config
    {
        Conexion con = new Conexion();
        public bool conectarok { get; set; }

        public void VerificarStringConexion(string cadena)
        {


            if (con.VerificarStringConexion(cadena) == "OK")
            {
                conectarok = true;

            }
            else
            {
                conectarok = false;
            }

        }

        public void saveconection(string cadena)
        {
            //XmlTextReader reader = new XmlTextReader();
        }
    }
}
