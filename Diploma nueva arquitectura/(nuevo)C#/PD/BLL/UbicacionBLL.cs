using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BLL
{
    public class UbicacionBLL
    {
        string rta;

        List<BE.Ubicacion> listaubicaciones;
 

        public UbicacionBLL() {
                    
               }



        public List<BE.Ubicacion> TraerUbicaciones()
        {
            DAL.Ubicacion ubidal = new DAL.Ubicacion();
            listaubicaciones =  ubidal.traerubicaciones();
            

              return listaubicaciones;       
        }

        public List<BE.Ubicacion> TraerUbicaciones(BE.Medio medio)
        {
            DAL.Ubicacion ubi = new DAL.Ubicacion();
            listaubicaciones = ubi.traerubicaciones(medio);

            return listaubicaciones;
        }

        public List<BE.Medio> TraerMedios()
        {
            DAL.Ubicacion ubi = new DAL.Ubicacion();
            List<BE.Medio> listamedios = new List<BE.Medio>();

            listamedios = ubi.TraerMedios();

            

            return listamedios;

        }

        public BE.Ubicacion seliccionarUbicacion(BE.Ubicacion ubibe)//ubicacionid
        {
            BE.Ubicacion ubicacionBE = new BE.Ubicacion();
            DAL.Ubicacion ubi = new DAL.Ubicacion();
            ubicacionBE = ubi.seleccionarUbicacion(ubibe);


             
            return ubicacionBE;

        }

     

        public BE.Ubicacion daraltaubicacion(BE.Ubicacion ubicacion)
        {
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();

            
            ubicacion = dalubicacion.daraltaubicacion(ubicacion);
             
            return ubicacion;
        }

        public BE.Ubicacion traerPrecio(BE.Ubicacion ubibe) //nombremedio, ubicacionmedio
        {
            
             
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();

            ubibe = dalubicacion.traerPrecio(ubibe);
            

            
            return ubibe;
        }

        public BE.Ubicacion Modificarubicacion(BE.Ubicacion ubicacion)
        {
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();

            ubicacion = dalubicacion.Modificarubicacion(ubicacion);

            return ubicacion;


        }

        public BE.Ubicacion EliminarUbicacion(BE.Ubicacion ubiBE)
        {
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();
            ubiBE.Result = "False";
            try
            {
                ubiBE = dalubicacion.EliminarUbicacion(ubiBE);

                return ubiBE;
            }
            catch (Exception ex)
            {
                ubiBE.Result = ex.Message;
                return ubiBE;
            }


        }
          
         }
    }

