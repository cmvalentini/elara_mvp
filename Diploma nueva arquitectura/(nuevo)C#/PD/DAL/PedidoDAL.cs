using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PedidoDAL
    {
        DAL.Conexion con = new Conexion();
                
        public PedidoDAL() { }

        public string GrabarNegocio(BE.Pedido dalpe)
        {
            List<SqlParameter> ParametrosSP = new List<SqlParameter>();

            SqlParameter Parametro1 = new SqlParameter("@preciopedido", dalpe.Preciopedido);
            SqlParameter Parametro2 = new SqlParameter("@impresiones", dalpe.Impresiones);
            SqlParameter Parametro3 = new SqlParameter("@fechafinpublicacion", dalpe.FechafinPublicacion);
            SqlParameter Parametro4 = new SqlParameter("@fechainiciopublicacion",dalpe.FechainicioPublicacion);
            SqlParameter Parametro5 = new SqlParameter("@descripcion", dalpe.Descripcion.ToString());
            SqlParameter Parametro6 = new SqlParameter("@nombreubicacion", dalpe.ubicacion.NombreUbicacion.ToString());
            SqlParameter Parametro7 = new SqlParameter("@medionombre", dalpe.medio.Medionombre.ToString());
            SqlParameter Parametro8 = new SqlParameter("@nombreAgencia", dalpe.NombreAgencia.ToString());

            
            ParametrosSP.Add(Parametro1);
            ParametrosSP.Add(Parametro2);
            ParametrosSP.Add(Parametro3);
            ParametrosSP.Add(Parametro4);
            ParametrosSP.Add(Parametro5);
            ParametrosSP.Add(Parametro6);
            ParametrosSP.Add(Parametro7);
            ParametrosSP.Add(Parametro8);


            try
            {
                

                con.EjecutarProcedureconListaParametros("GrabarPedido", ParametrosSP);

                return "Alta pedido exitosa";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }






        }

        public List<BE.Pedido> ConsultarPedido(BE.Pedido pedidoBE, string sqlmedio)
        {
            List<BE.Pedido> listpedidos = new List<BE.Pedido>();
             
            DataTable dt = new DataTable();

            string sql =
    " select distinct me.medionombre,me.iva,u.Nombreubicacion,cli.razon_social,pe.FechainicioPublicacion,pe.Preciopedido,pe.Impresiones" +
    " from pedido pe"+
    " inner join medio me on pe.medioid = me.medioid" +
    " inner join cliente cli on cli.clienteid = pe.clienteid " +
    " inner join ubicacion u on u.Ubicacionid = pe.ubicacionid " +
    " where  pe.FechainicioPublicacion BETWEEN '" + pedidoBE.FechainicioPublicacion + "' AND '" + pedidoBE.FechafinPublicacion + "' " +
    " AND  me.medionombre  IN(" + sqlmedio + ")";

            con.Conectar();
            dt = con.Ejecutarreader(sql);
            con.Desconectar();
            foreach (DataRow row in dt.Rows)
            {
                pedidoBE.ubicacion.NombreUbicacion = row["Nombreubicacion"].ToString();
                pedidoBE.ubicacion.medio = row["medionombre"].ToString();
                pedidoBE.ubicacion.Medida = row["Medidas"].ToString();
                pedidoBE.ubicacion.Formato = row["Formato"].ToString();
               pedidoBE.ubicacion.Formula = row["Formula"].ToString();
                pedidoBE.ubicacion.Ubicacionid = row["Ubicacionid"].ToString();
                pedidoBE.medio.medioid = Convert.ToInt16(row["Medioid"].ToString());
                pedidoBE.Preciopedido = Convert.ToDecimal(row["precio"].ToString());

                listpedidos.Add(pedidoBE);
            }





            return listpedidos;

        }
    }
}
