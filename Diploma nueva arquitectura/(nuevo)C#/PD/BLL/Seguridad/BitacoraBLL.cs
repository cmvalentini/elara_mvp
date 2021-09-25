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
 
        public DataTable traerUsuarios()
        {
            DataTable datausuario = new DataTable();
            DAL.BitacoraDAL log = new DAL.BitacoraDAL();
            datausuario = log.traerUsuarios();
            return datausuario;


        }

        public string IngresarDatoBitacora(string NombreOperacion,string Descripcion,int Criticidad,int Usuarioid)
        {


            DAL.BitacoraDAL log = new DAL.BitacoraDAL();

            
           string rta = log.IngresarDatoBitacora(NombreOperacion, Descripcion, Criticidad,Usuarioid);

            return rta;

        }

        public void Exportar_a_Excel()
        {
            throw new System.NotImplementedException();
        }
    }
}