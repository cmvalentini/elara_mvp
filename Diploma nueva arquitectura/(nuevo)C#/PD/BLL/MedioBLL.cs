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

         

        public void DarAlta(string medionombre, string descripcion, string iva)
        {
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();

            dalmedio.AltaMedio(medionombre,descripcion,iva);

        }

        public BE.Medio seleccionarMedio(int medioid)
        {
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();
            BE.Medio medioBE = new BE.Medio();

            medioBE = dalmedio.seleccionarMedio(medioid);

             

            return medioBE;
        }

        public void modificarmedio(BE.Medio medio)
        {
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();      
            dalmedio.modificarmedio(dalmedio);

        }

        public List<BE.Medio> BuscarMedios()
        {
            List<BE.Medio> listamedios = new List<BE.Medio>();
            DAL.MedioDAL mediodal = new DAL.MedioDAL(); 
            listamedios = mediodal.BuscarMedios();

            return listamedios;
        }

        public int traernumeropedido()
        {
            DAL.MedioDAL medio = new DAL.MedioDAL();
            int numeropedido;
            numeropedido = medio.traernumeropedido();
            return numeropedido;

        }

        public string Eliminarmedio(Int16 medioid)
        {
            string result = "";
            DAL.MedioDAL dalmedio = new DAL.MedioDAL();
           result = dalmedio.Eliminarmedio(medioid);

            return result;
        }
    }
}
