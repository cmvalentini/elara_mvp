using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Config
    {
        DAL.Config conf = new DAL.Config();

        public bool LeerStringConexion(string cadena)
        {
            conf.VerificarStringConexion(cadena);

            return conf.conectarok;

        }
        public string Cadena { get; set; }

        public void saveconection(string cadena)
        {
            conf.saveconection(cadena);            


        }
    }
}