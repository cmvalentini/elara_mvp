using System;
using System.Data;

namespace DAL
{
    public class BitacoraDAL
    {
        DigitosVerificadores dv = new DigitosVerificadores();
        Conexion con = new Conexion();
        public string IngresarDatoBitacora(string nombreOperacion, string descripcion, int criticidad,int usuarioid)
        {
            string sql = "insert into Bitacora(NombreOperacion,Descripcion,UsuarioID,Criticidad,FechayHora) values ('" 
                        + nombreOperacion +"','"+descripcion+"',"+ usuarioid + ","
                        + criticidad + ",getdate())";
            

            string rta = con.Ejecutar(sql);
            dv.RecalcularDVH();


            return rta;

           
        }

        public DataTable traerUsuarios()
        {
            DataTable datausuario = new DataTable();
            string sql = "select distinct usuario from usuario";
            datausuario = con.Ejecutarreader(sql);


            return datausuario;

        }

        public DataTable ConsultarBitacora(DateTime fechadesde, DateTime fechahasta, string sqlcriticidad, string sqlusuario)
        {
            DataTable dt = new DataTable();

            string sql =
         "select NombreOperacion, Descripcion, UsuarioID, Criticidad, FechayHora from Bitacora"+
         " where fechayhora BETWEEN '"+fechadesde +"' AND '"+fechahasta+"' "+
         " and Criticidad IN("+sqlcriticidad+")"+
         " AND UsuarioID IN("+sqlusuario+")";

            dt = con.Ejecutarreader(sql);
            return dt;

        }
    }
}