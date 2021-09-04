using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PedidoBLL
    {
                 
        DAL.PedidoDAL dalpe = new DAL.PedidoDAL();
              
        string result;

        public PedidoBLL() { }

        public string GrabarNegocio(BE.Pedido ped)
        {
            try
            {
                result = dalpe.GrabarNegocio(ped);

            }
            catch (Exception ex)
            {
                result = ex.Message;
                
            }
          
            return result;
        }

        public List<BE.Pedido> ConsultarPedido(BE.Pedido pedidoBE, string sqlmedio)
        {
            List<BE.Pedido> listpedidos = new List<BE.Pedido>();
            listpedidos = dalpe.ConsultarPedido(pedidoBE, sqlmedio);

                return listpedidos;
        }
    }
}
