using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IdiomaDAL
    {
        BE.Idioma.Idioma IdiomaBE = new BE.Idioma.Idioma();
        Conexion con = new Conexion();
        public BE.Idioma.Idioma CargarIdioma()
        {

            string sql = "select Descripcion from idioma where Seleccionado = 1";
            //traigo idioma 
            DataTable dt = con.Ejecutarreader(sql);

            IdiomaBE.Descripcion = dt.Rows[0][0].ToString();

            return IdiomaBE;
        }

        public BE.Idioma.Idioma SetearIdioma(int idiomaID)
        {
            string sql = "update Idioma set Seleccionado = 0;update idioma set seleccionado = 1 where IdiomaID = "+ idiomaID + "";

           IdiomaBE.Result = con.Ejecutar(sql);

            return IdiomaBE;
        }
    }
}
