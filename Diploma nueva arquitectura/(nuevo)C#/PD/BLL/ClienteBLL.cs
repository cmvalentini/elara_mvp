using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        DAL.ClienteDAL dalcli = new DAL.ClienteDAL();
        BE.Cliente ClienteBE = new BE.Cliente();

        public ClienteBLL() { }


        public List<BE.Cliente> BuscarClientes()
        {
            List<BE.Cliente> listaclientes = new List<BE.Cliente>();
            listaclientes = dalcli.BuscarClientes();

            return listaclientes;

        }

        public void daraltacliente(BE.Cliente cli)
        {
            
            dalcli.daraltacliente(cli);
                            
        }

        public List<BE.Cliente> traeragencias()
        {
            List<BE.Cliente> listaclientes = new List<BE.Cliente>();
              
            DAL.ClienteDAL cli = new DAL.ClienteDAL();
            
            listaclientes = cli.traeragencias();

            return listaclientes;
        }

        public BE.Cliente EliminarCliente(BE.Cliente cli) // clienteid
        {

            ClienteBE.result =  dalcli.EliminarCliente(cli);

            return ClienteBE;
        }
    }
}
