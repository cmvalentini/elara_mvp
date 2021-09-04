using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BackUpRestore
    {
      
        public string RealizarBackUp(string path, int cantidad)
        {

                 List<SqlParameter> ParametrosSP = new List<SqlParameter>();
                 SqlParameter Parametro1 = new SqlParameter("@CANT", cantidad);
                 ParametrosSP.Add(Parametro1);
               

                try
                {
                    DAL.Conexion con = new Conexion();

                    con.EjecutarProcedureconListaParametros("RealizarBackUp", ParametrosSP);

                    return "Back Up exitoso";
                }
                catch (Exception ex)
                {

                    return "Revise el acceso a la carpeta "+ ex.Message;
                }
            }
        
        public string RealizarRestore(int cant)
        {
            string rta;
            try
            {
                DAL.Conexion con = new Conexion();

              rta = con.EjecutarRestore(cant);

            }
            catch (Exception ex)
            {
                rta = ex.Message;
                 
            }


            return rta;

        }
    }
}
