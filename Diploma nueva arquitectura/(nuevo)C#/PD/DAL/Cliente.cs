using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cliente
    {
        public int Clienteid { get; set; }
        public string razon_social { get; set; }
        public string Condicion_fiscal { get; set; }
        public string telefono { get; set; }
        public string Domicilio { get; set; }
        public int Habilitado { get; set; }

        DataTable dt = new DataTable();
        Conexion con = new Conexion();
        public DataTable BuscarClientes()
        {
            String sql = " select clienteid,razon_social,condicion_fiscal,telefono,Domicilio,"+
                          " Habilitado from cliente " +
                          " where Habilitado = 1";
            con.Conectar();

            dt = con.Ejecutarreader(sql);

            con.Desconectar();

            return dt;

        }

        public void daraltacliente(Cliente dalcli)
        {
            string sql = "insert into cliente(razon_social,condicion_fiscal,telefono,Domicilio,Habilitado) values (" +
                          "'"+dalcli.razon_social+"','"+dalcli.Condicion_fiscal+"','" +dalcli.telefono + "',"+
                          "'"+dalcli.Domicilio+"',"+dalcli.Habilitado+");";


            con.Conectar();

            con.Ejecutar(sql);
            con.Desconectar();



        }

        public DataTable traeragencias()
        {
            string sql = "select distinct razon_social from cliente";
            con.Conectar();
            dt = con.Ejecutarreader(sql);
            con.Desconectar();

            return dt;
        }

        public string EliminarCliente(int clienteid)
        {
            string sql = "delete cliente where clienteid ="+ clienteid +"";

            try
            {
                con.Conectar();

                con.Ejecutar(sql);
                con.Desconectar();

                return "True";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }    

            
            
        }
    }
}
