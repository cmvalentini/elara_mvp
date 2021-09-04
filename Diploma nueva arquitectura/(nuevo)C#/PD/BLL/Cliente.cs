using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
        DAL.Cliente dalcli = new DAL.Cliente();
        DataTable dt = new DataTable();
        public int Clienteid { get; set; }
        public string razon_social { get; set; }
        public string Condicion_fiscal { get; set; }
        public string telefono { get; set; }
        public string Domicilio { get; set; }
        public int Habilitado { get; set; }

        string result = "";

        public Cliente() { }


        public DataTable BuscarClientes()
        {
            dt = dalcli.BuscarClientes();

            return dt;

        }

        public void daraltacliente(Cliente cli)
        {
            dalcli.Condicion_fiscal = cli.Condicion_fiscal;
            dalcli.razon_social = cli.razon_social;
            dalcli.telefono = cli.telefono;
            dalcli.Domicilio = cli.Domicilio;
            dalcli.Habilitado = cli.Habilitado;

            dalcli.daraltacliente(dalcli);

                
        }

        public DataTable traeragencias()
        {
            DAL.Cliente cli = new DAL.Cliente();
            DataTable dt = new DataTable();

            dt = cli.traeragencias();



            return dt;
        }

        public string EliminarCliente(int clienteid)
        {
         result=  dalcli.EliminarCliente(clienteid);

            return result;
        }
    }
}
