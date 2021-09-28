using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BitacoraBLL
    {
   

        public List<BE.Seguridad.Bitacora> ConsultarBitacora(DateTime fechadesde,DateTime fechahasta,string sqlcriticidad,string sqlusuario)
        {
            List<BE.Seguridad.Bitacora> listabitacora = new List<BE.Seguridad.Bitacora>();
            

            DAL.BitacoraDAL log = new DAL.BitacoraDAL();

            listabitacora = log.ConsultarBitacora(fechadesde, fechahasta, sqlcriticidad, sqlusuario);

            return listabitacora;


        }
 
        public List<BE.Usuario> traerUsuarios()
        {
            List<BE.Usuario> listausuario = new List<BE.Usuario>();
            DAL.BitacoraDAL log = new DAL.BitacoraDAL();
            listausuario = log.traerUsuarios();
            return listausuario;


        }

        public BE.Seguridad.Bitacora IngresarDatoBitacora(string NombreOperacion,string Descripcion,int Criticidad,int Usuarioid)
        {

            BE.Seguridad.Bitacora log = new BE.Seguridad.Bitacora();
            DAL.BitacoraDAL logdal = new DAL.BitacoraDAL();
            
            log.result = logdal.IngresarDatoBitacora(NombreOperacion, Descripcion, Criticidad,Usuarioid);

            return log;

        }
 
    }
}