using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedioDAL
    {
        string aux = "";
        Conexion con = new Conexion();
        DataTable dt = new DataTable();

        public MedioDAL() { }
        public void AltaMedio(string medionombre, string descripcion, string iva)
        {
            string sql = "insert into Medio (medionombre,descripcion,iva) values"+
                         " ('"+ medionombre +"','"+ descripcion + "',CAST('" +iva+ "'AS DECIMAL(4, 2)) ) ";
          

            con.Ejecutar(sql);
        }

        public List<BE.Medio>  BuscarMedios()
        {
            string sql = "select medionombre,descripcion,iva,medioid from medio";

            List<BE.Medio> listamedio = new List<BE.Medio>();
            con.Conectar();
            
            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);
            BE.Medio medioBE = new BE.Medio();

            foreach (DataRow item in dt.Rows){

                medioBE.Medionombre = item[0].ToString();
                medioBE.Descripcion = item[1].ToString();
                medioBE.Iva = Convert.ToDecimal(item[2].ToString());
                medioBE.medioid = Convert.ToInt16(item[3].ToString());
                
                listamedio.Add(medioBE);
            }

            con.Desconectar();
            
            return listamedio;
        }

        public BE.Medio seleccionarMedio(int medioid)
        {
            BE.Medio medioBE = new BE.Medio();
            string sql = "select descripcion,medionombre,iva from medio " +
                       " where medioid = "+ medioid +";";

            dt = con.Ejecutarreader(sql);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                medioBE.Descripcion = dt.Rows[0][0].ToString();
                medioBE.Medionombre = dt.Rows[0][1].ToString();
                medioBE.Iva = Convert.ToDecimal(dt.Rows[0][2].ToString());
                                   
                }

                                  
                return medioBE;
            
                }

        public int traernumeropedido()
        {
            int numeropedido = 0;
            string sql = "select top(1)pedidoid from pedido order by 1 desc";
            dt = con.Ejecutarreader(sql);

            foreach (DataRow item in dt.Rows)
            {
              numeropedido =   Convert.ToInt16(item[0].ToString()) + 1;
            }


            return numeropedido;
        }

        public string Eliminarmedio(Int16 medioid)
        {

           string sql = "delete medio where medioid = "+ medioid + ";";
            try
            {
                con.Ejecutar(sql);
                aux = "True";
            }
            catch (Exception exp)
            {
                aux = exp.Message;
            }
                return aux;
                    

        }


        public void modificarmedio(BE.Medio medioBE)
        {
            string sql = "update medio set medionombre = '"+ medioBE.Medionombre +"',"+
                          "descripcion = '"+ medioBE.Descripcion +"',"+
                          "iva = " + medioBE.Iva.ToString().Replace(",",".") +" "+ 
                          "where medioid ="+ medioBE.medioid + " ;";

            con.Ejecutar(sql);
            
        }
    }
}


