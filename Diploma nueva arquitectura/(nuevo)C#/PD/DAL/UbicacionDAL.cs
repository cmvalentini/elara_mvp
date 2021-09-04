using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Ubicacion
    {

        List<BE.Ubicacion> listaubicacion = new List<BE.Ubicacion>();
        public string Nombremedio { get; set; }
        Conexion con = new Conexion();
        List<BE.Ubicacion> listubi = new List<BE.Ubicacion>();
        BE.Ubicacion ubicacionbe = new BE.Ubicacion();
        DataTable dt = new DataTable();

       
        string rta;

        public List<BE.Ubicacion> traerubicaciones()
        {
            string sql = "select u.Nombreubicacion,m.medionombre, " +
                    "u.Medidas,u.Formato, u.Formula,u.Habilitado, " +
                    "u.Ubicacionid,u.Medioid,u.precio "             +
                    "from ubicacion u inner join medio m "          +
                    "on m.medioid = u.Medioid";
 

            dt = con.Ejecutarreader(sql);

            foreach (DataRow row in dt.Rows)
            {
              ubicacionbe.NombreUbicacion = row["Nombreubicacion"].ToString();
                ubicacionbe.medio  = row["medionombre"].ToString();
                ubicacionbe.medio = row["medionombre"].ToString();
                ubicacionbe.Medida = row["Medidas"].ToString();
                ubicacionbe.Formato = row["Formato"].ToString();
                ubicacionbe.Formula = row["Formula"].ToString();
                ubicacionbe.Ubicacionid = row["Ubicacionid"].ToString();
                ubicacionbe.Ubicacionid =row["Medioid"].ToString();
                ubicacionbe.Precio = Convert.ToDecimal(row["precio"].ToString());

                listaubicacion.Add(ubicacionbe);
            }


            return listaubicacion
                ;

        }

        public List<BE.Ubicacion> traerubicaciones(string nombremedio)
        {
            string sql = "select u.Nombreubicacion,m.medionombre, " +
                    "u.Medidas,u.Formato, u.Formula,u.Habilitado, " +
                    "u.Ubicacionid,u.Medioid,u.precio " +
                    "from ubicacion u inner join medio m " +
                    "on m.medioid = u.Medioid " +
                    "where m.medionombre like '%"+ nombremedio + "%';";

            dt = con.Ejecutarreader(sql);

            foreach (DataRow row in dt.Rows)
            {
                ubicacionbe.NombreUbicacion = row["Nombreubicacion"].ToString();
                ubicacionbe.medio = row["medionombre"].ToString();
                ubicacionbe.medio = row["medionombre"].ToString();
                ubicacionbe.Medida = row["Medidas"].ToString();
                ubicacionbe.Formato = row["Formato"].ToString();
                ubicacionbe.Formula = row["Formula"].ToString();
                ubicacionbe.Ubicacionid = row["Ubicacionid"].ToString();
                ubicacionbe.Ubicacionid = row["Medioid"].ToString();
                ubicacionbe.Precio = Convert.ToDecimal(row["precio"].ToString());

                listaubicacion.Add(ubicacionbe);
            }


            return listaubicacion;
        }

        public List<BE.Ubicacion> TraerMedios()
        {
            
            string sql = "select distinct medionombre from medio";
            con.Conectar();    
            dt = con.Ejecutarreader(sql);
            con.Desconectar();

            foreach (DataRow row in dt.Rows)
            {
                ubicacionbe.NombreUbicacion = row["Nombreubicacion"].ToString();
                ubicacionbe.medio = row["medionombre"].ToString();
                ubicacionbe.medio = row["medionombre"].ToString();
                ubicacionbe.Medida = row["Medidas"].ToString();
                ubicacionbe.Formato = row["Formato"].ToString();
                ubicacionbe.Formula = row["Formula"].ToString();
                ubicacionbe.Ubicacionid = row["Ubicacionid"].ToString();
                ubicacionbe.Ubicacionid = row["Medioid"].ToString();
                ubicacionbe.Precio = Convert.ToDecimal(row["precio"].ToString());

                listaubicacion.Add(ubicacionbe);
            }


            return listaubicacion;
        }

        public BE.Ubicacion seleccionarUbicacion(int ubicacionid)
        {
            string sql = " select Ubicacionid,medionombre,Nombreubicacion,medidas,Formato,Formula,Habilitado,precio "+
                         " from ubicacion u inner join medio m on m.medioid = u.Medioid "+
                         " where u.Ubicacionid ="+ ubicacionid + ";";


            dt = con.Ejecutarreader(sql);
            BE.Ubicacion ubi = new BE.Ubicacion();
            foreach (DataRow item in dt.Rows)
            {

                ubi.Ubicacionid = item[0].ToString();
                ubi.NombreMedio = item[1].ToString();
                ubi.NombreUbicacion = item[2].ToString();
                ubi.Medida = item[3].ToString();
                ubi.Formato = item[4].ToString();
                ubi.Formula = item[5].ToString();
                ubi.Habilitado = item[6].ToString();
                ubi.Precio = Convert.ToDecimal(item[7].ToString());
                listubi.Add(ubi);
            }


            return ubi;
        }

        public string daraltaubicacion(BE.Ubicacion dalubicacion)
        {
            
            string sql = "select medioid from medio where medionombre "+
                         "like '%"+ dalubicacion.NombreMedio.ToString() + "%'";
            con.Conectar();
            dt = con.Ejecutarreader(sql);
            string medioid = "";

            foreach (DataRow item in dt.Rows)
            {
                 medioid = item[0].ToString();
            }

            con.Desconectar();

            con.Conectar();
            string sql1 = "insert into ubicacion(Nombreubicacion, Medioid, Medidas, Formato, Formula, Habilitado,Precio) "+
                         " values('" +dalubicacion.NombreUbicacion.ToString() +"',"+ medioid.ToString()+", "+
                         "'"+ dalubicacion.Medida.ToString() + "','"+ dalubicacion.Formato.ToString() +"','"+dalubicacion.Formula.ToString()+"', " +
                         " "+dalubicacion.Habilitado.ToString() +","+ dalubicacion.Precio + ") ";

            try
            {
             rta = con.Ejecutar(sql1);

               

            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }

            return rta;
 

        }

        public BE.Ubicacion traerPrecio(string nombremedio, string ubicacionmedio)
        {

            string sql = " select Ubicacionid,medionombre,Nombreubicacion,medidas,Formato,Formula,Habilitado,precio " +
                        " from ubicacion u inner join medio m on m.medioid = u.Medioid " +
                        " where u.habilitado = 1 " +
                        " and m.medionombre like '%"+nombremedio+"%' " +
                        " and u.Nombreubicacion like '%" + ubicacionmedio + "%' ";

            dt = con.Ejecutarreader(sql);
            BE.Ubicacion ubi = new BE.Ubicacion();
            foreach (DataRow item in dt.Rows)
            {

                ubi.Ubicacionid = item[0].ToString();
                ubi.NombreMedio = item[1].ToString();
                ubi.NombreUbicacion = item[2].ToString();
                ubi.Medida = item[3].ToString();
                ubi.Formato = item[4].ToString();
                ubi.Formula = item[5].ToString();
                ubi.Habilitado = item[6].ToString() ;
                ubi.Precio = Convert.ToDecimal(item[7].ToString());
                listubi.Add(ubi);
            }



            return ubi;
        }

        public string EliminarUbicacion(int vubicacionid)
        {
            string result = "False";
            string sql = "delete ubicacion where ubicacionid = "+ vubicacionid + "; ";
            try
            {
                con.Conectar();
                con.Ejecutar(sql);
                result = "True";
                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            finally
            {
                con.Desconectar();
            }

        }

        public string Modificarubicacion(BE.Ubicacion ubicacionBE)
        {
            string sql = 
                           " update ubicacion  " +
                           " set Nombreubicacion ='"+ ubicacionBE.NombreUbicacion+"',"+
                           " Medioid = m.medioid ," +
                           " medidas ='"+ ubicacionBE.Medida + "',"+
		                   " Formato ='"+ ubicacionBE.Formato + "',"+
	                       " formula ='"+ ubicacionBE.Formula + "',"+
	                       " habilitado =" + ubicacionBE.Habilitado +","+
                           " precio =" + ubicacionBE.Precio + "" +
                           " from medio m where m.medioid = ubicacion.medioid" +
                           " and ubicacionid ="+ ubicacionBE.Ubicacionid+" "+
                           " and m.medionombre like '%"+ ubicacionBE.NombreMedio+"%'";

            con.Conectar();
            rta = con.Ejecutar(sql);


            return rta;

        }
    }
}
