using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bitacora
    {
        public string Accion { get; set; }
        public int Criticidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechayHora { get; set; }
        public string NombreOperacion { get; set; }
        // public int Usuarioid { get; set = 0; }
        public int Usuarioid { get; set; }

        public DataTable ConsultarBitacora(DateTime fechadesde,DateTime fechahasta,string sqlcriticidad,string sqlusuario)
        {
            DataTable dt = new DataTable();

            DAL.Bitacora log = new DAL.Bitacora();

            dt = log.ConsultarBitacora(fechadesde, fechahasta, sqlcriticidad, sqlusuario);

            return dt;


        }

        public void Encriptar()
        {
            throw new System.NotImplementedException();
        }

        public void ExportarBitacora()
        {
            throw new System.NotImplementedException();
        }

        public void ImportarBitacora()
        {
            throw new System.NotImplementedException();
        }

        public DataTable traerUsuarios()
        {
            DataTable datausuario = new DataTable();
            DAL.Bitacora log = new DAL.Bitacora();
            datausuario = log.traerUsuarios();
            return datausuario;


        }

        public string IngresarDatoBitacora(string NombreOperacion,string Descripcion,int Criticidad,int Usuarioid)
        {


            DAL.Bitacora log = new DAL.Bitacora();

            
           string rta = log.IngresarDatoBitacora(NombreOperacion, Descripcion, Criticidad,Usuarioid);

            return rta;

        }

        public void Exportar_a_Excel()
        {
            throw new System.NotImplementedException();
        }
    }
}