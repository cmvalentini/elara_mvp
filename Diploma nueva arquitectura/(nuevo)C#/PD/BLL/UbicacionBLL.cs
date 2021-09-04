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

        public List<BE.Ubicacion> TraerUbicaciones(string nombremedio)
        {
            DAL.Ubicacion ubi = new DAL.Ubicacion();
            listaubicaciones = ubi.traerubicaciones(nombremedio);

            return listaubicaciones;
        }

        public List<BE.Ubicacion> TraerMedios()
        {
            DAL.Ubicacion ubi = new DAL.Ubicacion();
            DataTable dt = new DataTable();

            listaubicaciones = ubi.TraerMedios();

            

            return listaubicaciones;

        }

        public BE.Ubicacion seliccionarUbicacion(int ubicacionid)
        {
            BE.Ubicacion ubicacionBE = new BE.Ubicacion;
            DAL.Ubicacion ubi = new DAL.Ubicacion();
            ubicacionBE = ubi.seleccionarUbicacion(ubicacionid);


             
            return ubicacionBE;

        }

     

        public string daraltaubicacion(BE.Ubicacion ubicacion)
        {
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();

            
            rta = dalubicacion.daraltaubicacion(ubicacion);

            return rta;
        }

        public decimal traerPrecio(string nombremedio, string ubicacionmedio)
        {
            BE.Ubicacion UBICACION = new BE.Ubicacion();
            decimal precio;
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();

            UBICACION = dalubicacion.traerPrecio(nombremedio,ubicacionmedio);
            precio =  UBICACION.Precio;

            
            return precio;
        }

        public string Modificarubicacion(BE.Ubicacion ubicacion)
        {
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();
            
            rta = dalubicacion.Modificarubicacion(ubicacion);

            return rta;


        }

        public string EliminarUbicacion(int ubicacionid)
        {
            DAL.Ubicacion dalubicacion = new DAL.Ubicacion();
            string result = "False";
            try
            {
                result = dalubicacion.EliminarUbicacion(ubicacionid);

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }


        }
          
         }
    }

