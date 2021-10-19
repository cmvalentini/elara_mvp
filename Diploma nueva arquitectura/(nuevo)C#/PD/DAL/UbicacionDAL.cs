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
                ubicacionbe.medio.Medionombre = row["medionombre"].ToString();
                ubicacionbe.Medida = row["Medidas"].ToString();
                ubicacionbe.Formato = row["Formato"].ToString();
                ubicacionbe.Formula = row["Formula"].ToString();
                ubicacionbe.Ubicacionid = Convert.ToInt16(row["Ubicacionid"].ToString());
                ubicacionbe.medio.medioid = Convert.ToInt16(row["Medioid"].ToString());
                ubicacionbe.Precio = Convert.ToDecimal(row["precio"].ToString());

                listaubicacion.Add(ubicacionbe);
            }


            return listaubicacion
                ;

        }

        public List<BE.Ubicacion> traerubicaciones(BE.Medio MedioBE)
        {
            string sql = "select u.Nombreubicacion,m.medionombre, " +
                    "u.Medidas,u.Formato, u.Formula,u.Habilitado, " +
                    "u.Ubicacionid,u.Medioid,u.precio " +
                    "from ubicacion u inner join medio m " +
                    "on m.medioid = u.Medioid " +
                    "where m.medionombre like '%"+ MedioBE.Medionombre + "%';";

            dt = con.Ejecutarreader(sql);

            foreach (DataRow row in dt.Rows)
            {
                ubicacionbe.NombreUbicacion = row["Nombreubicacion"].ToString();
                ubicacionbe.medio.Medionombre = row["medionombre"].ToString();
                ubicacionbe.Medida = row["Medidas"].ToString();
                ubicacionbe.Formato = row["Formato"].ToString();
                ubicacionbe.Formula = row["Formula"].ToString();
                ubicacionbe.Ubicacionid = Convert.ToInt16(row["Ubicacionid"].ToString());
                ubicacionbe.medio.medioid = Convert.ToInt16(row["Medioid"].ToString());
                ubicacionbe.Precio = Convert.ToDecimal(row["precio"].ToString());

                listaubicacion.Add(ubicacionbe);
            }


            return listaubicacion;
        }

        public List<BE.Medio> TraerMedios()
        {
            List<BE.Medio> listamedios = new List<BE.Medio>();
            BE.Medio medio = new BE.Medio();
            string sql = "select distinct medionombre from medio";
            con.Conectar();    
            dt = con.Ejecutarreader(sql);
            con.Desconectar();

            foreach (DataRow row in dt.Rows)
            {
                medio.Medionombre = row[0].ToString();
                
                listamedios.Add(medio);
            }


            return listamedios;
        }

        public BE.Ubicacion seleccionarUbicacion(BE.Ubicacion ubibe)
        {
            string sql = " select Ubicacionid,medionombre,Nombreubicacion,medidas,Formato,Formula,Habilitado,precio "+
                         " from ubicacion u inner join medio m on m.medioid = u.Medioid "+
                         " where u.Ubicacionid ="+ ubibe.Ubicacionid + ";";


            dt = con.Ejecutarreader(sql);
            BE.Ubicacion ubi = new BE.Ubicacion();
            foreach (DataRow item in dt.Rows)
            {

                ubi.Ubicacionid = Convert.ToInt16(item[0].ToString());
                ubi.NombreMedio = item[1].ToString();
                ubi.NombreUbicacion = item[2].ToString();
                ubi.Medida = item[3].ToString();
                ubi.Formato = item[4].ToString();
                ubi.Formula = item[5].ToString();
                ubi.Habilitado = Convert.ToInt16(item[6].ToString());
                ubi.Precio = Convert.ToDecimal(item[7].ToString());
                listubi.Add(ubi);
            }


            return ubi;
        }

        public BE.Ubicacion daraltaubicacion(BE.Ubicacion dalubicacion)
        {
            
            string sql = "select medioid from medio where medionombre "+
                         "like '%"+ dalubicacion.medio.medioid.ToString() + "%'";
            con.Conectar();
            dt = con.Ejecutarreader(sql);
             

            foreach (DataRow item in dt.Rows)
            {
                dalubicacion.medio.medioid = Convert.ToInt16( item[0].ToString());
            }

            con.Desconectar();

            con.Conectar();
            string sql1 = "insert into ubicacion(Nombreubicacion, Medioid, Medidas, Formato, Formula, Habilitado,Precio) "+
                         " values('" +dalubicacion.NombreUbicacion.ToString() +"',"+ dalubicacion.medio.medioid.ToString()+", "+
                         "'"+ dalubicacion.Medida.ToString() + "','"+ dalubicacion.Formato.ToString() +"','"+dalubicacion.Formula.ToString()+"', " +
                         " "+dalubicacion.Habilitado.ToString() +","+ dalubicacion.Precio + ") ";

            try
            {
                dalubicacion.Result = con.Ejecutar(sql1);

               

            }
            catch (Exception ex)
            {

                dalubicacion.Result = ex.Message;
            }

            return dalubicacion;
 

        }

        public BE.Ubicacion traerPrecio(BE.Ubicacion UbiBE) // nombremedio, ubicacionmedio
        {

            string sql = " select Ubicacionid,medionombre,Nombreubicacion,medidas,Formato,Formula,Habilitado,precio " +
                        " from ubicacion u inner join medio m on m.medioid = u.Medioid " +
                        " where u.habilitado = 1 " +
                        " and m.medionombre like '%"+ UbiBE.medio.Medionombre+ "%' " +
                        " and u.Nombreubicacion like '%" + UbiBE.NombreUbicacion + "%' ";

            dt = con.Ejecutarreader(sql);
            BE.Ubicacion ubi = new BE.Ubicacion();
            foreach (DataRow item in dt.Rows)
            {

                ubi.Ubicacionid = Convert.ToInt16(item[0].ToString());
                ubi.NombreMedio = item[1].ToString();
                ubi.NombreUbicacion = item[2].ToString();
                ubi.Medida = item[3].ToString();
                ubi.Formato = item[4].ToString();
                ubi.Formula = item[5].ToString();
                ubi.Habilitado =Convert.ToInt16(item[6].ToString()) ;
                ubi.Precio = Convert.ToDecimal(item[7].ToString());
               // listubi.Add(ubi);
            }



            return ubi;
        }

        public BE.Ubicacion EliminarUbicacion(BE.Ubicacion UBIbe) //vubicacionid
        {
            UBIbe.Result = "False";
            string sql = "delete ubicacion where ubicacionid = "+ UBIbe.Ubicacionid + "; ";
            try
            {
                con.Conectar();
                con.Ejecutar(sql);
                UBIbe.Result = "True";
                return UBIbe;
            }
            catch (Exception ex)
            {
                UBIbe.Result = ex.Message;
                return UBIbe;
            }

            finally
            {
                con.Desconectar();
            }

        }

        public BE.Ubicacion Modificarubicacion(BE.Ubicacion ubicacionBE)
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
            ubicacionBE.Result = con.Ejecutar(sql);


            return ubicacionBE;

        }
    }
}
