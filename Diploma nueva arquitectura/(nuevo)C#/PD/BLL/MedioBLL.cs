using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedioBLL
    {

        BE.Medio Medio = new BE.Medio();
        public MedioBLL() { }

         

        public void DarAlta(BE.Medio medio)
        {
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();

            dalmedio.AltaMedio(medio);

        }

        public BE.Medio seleccionarMedio(BE.Medio medio)
        {
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();
            BE.Medio medioBE = new BE.Medio();

            medioBE = dalmedio.seleccionarMedio(medio);

             

            return medioBE;
        }

        public void modificarmedio(BE.Medio medio)
        {
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();      
            dalmedio.modificarmedio(medio);

        }

        public List<BE.Medio> BuscarMedios()
        {
            List<BE.Medio> listamedios = new List<BE.Medio>();
            DAL.MedioDAL mediodal = new DAL.MedioDAL(); 
            listamedios = mediodal.BuscarMedios();

            return listamedios;
        }

        public BE.Pedido traernumeropedido()
        {
            DAL.MedioDAL medio = new DAL.MedioDAL();
            BE.Pedido pedidoBE = new BE.Pedido();
            pedidoBE = medio.traernumeropedido();
            return pedidoBE;

        }

        public BE.Medio Eliminarmedio(BE.Medio medioBE)
        {
            
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();
            medioBE = dalmedio.Eliminarmedio(medioBE);

            return medioBE;
        }
    }
}
