using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class ManejadorPerfilUsuario    
    {


        private string _NombrePerfil;

        public string NombrePerfil
        {
            get { return _NombrePerfil; }
            set { _NombrePerfil = value; }
        }

        public string Operacionn
        { get; set; }

        public int PerfilID { get; set; }


        public List<string> DatasetOperaciones
        {
            get;set;
        }
    
        public int Usuario { get; set; }

      

        public void BloqueaOperacionUsuario(string NombreUsuario,string Patente)
        {
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

            mpu.BloqueaOperacionUsuario(NombreUsuario, Patente);


        }

        /// <summary>
        ///Verifica en base si existe el perfil descrito
        /// </summary>
        public int VerificarAltafamilia(string nombrePerfil)
        {
            DAL.ManejadorPerfilUsuario MPU = new DAL.ManejadorPerfilUsuario();
            int rta = MPU.VerificarAltafamilia(nombrePerfil);

            return rta;
        }
        
        public DataTable BuscarPerfilUsuarios()
        {
            DataTable dt = new DataTable();
            DAL.ManejadorPerfilUsuario pu = new DAL.ManejadorPerfilUsuario();

            dt = pu.BuscarPerfilUsuarios();

            return dt;

        }
    

        public string _CrearPerfilUsuario(string NombrePerfil,string DescPerfil)
        {
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

            string rta = mpu._CrearPerfilUsuario(NombrePerfil,DescPerfil);

            return rta;
        }

        public string ModificarPerfilUsuario(string NombrePerfil, string DescPerfil, int perfilID)
        {
            string rta = "False";

            try
            {
                DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

               rta = mpu.ModificarPerfilUsuario(NombrePerfil,DescPerfil,perfilID);

                return rta ;
            }
            catch (Exception ex)
            {

                return rta = ex.Message;
            }


        }






        public void DesbloqueaOperacionaUsuario(string NombreUsuario,String Patente)
        {
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

            mpu.DesbloqueaOperacionaUsuario(NombreUsuario, Patente);



             
        }

        public string EliminarPerfilUsuario(int PerfilID)
        {
            string rta = "False";

            try
            {
                DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();
                if (mpu.EliminarPerfilUsuario(PerfilID) == "True")
                {
                    rta = "True";
                }
                else
                {

                }
                            
            }
            catch (Exception)
            {

                throw;
            }


            return rta;
        }

        public void GuardarUsuarios()
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// Trae Descripcion de todas las operaciones del sistema
        /// </summary>
        public List<string> MostrarListaOperaciones()
        {
            List<string> listaoperaciones = new List<string>();
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

            listaoperaciones = mpu.MostrarListaOperaciones();

            return listaoperaciones;
        }
 
        /// <summary>
        /// Trae Descripcion de todas las operaciones del sistema
        /// </summary>
        public List<string> MostrarListaOperaciones(int perfilID)
        {
            List<string> listaoperaciones = new List<string>();
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

            listaoperaciones = mpu.MostrarListaOperaciones(perfilID);

            return listaoperaciones;
        }
        public List<string> MostrarListaOperaciones(string Perfil)
        {
            List<string> listaoperaciones = new List<string>();
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();

            listaoperaciones = mpu.MostrarListaOperaciones(Perfil);

            return listaoperaciones;
        }

        public void AsignarOperacionesalPerfil(int perfilID, List<string> listaoperacionesperfil)
        {

            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();
            mpu.AsignarOperacionesalPerfil(perfilID, listaoperacionesperfil);



        }
        public void AsignarOperacionesalPerfil(string NombreUsuario, List<string> listaoperacionesperfil)
        {

            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();
            mpu.AsignarOperacionesalPerfil(NombreUsuario, listaoperacionesperfil);



        }

        public List<string> MostrarMenuPerfiles(int Usuarioid)
        {
            List<string> listaoperaciones = new List<string>();
            DAL.ManejadorPerfilUsuario mpu = new DAL.ManejadorPerfilUsuario();
        
            listaoperaciones = mpu.MostrarMenuperfiles(Usuarioid);



            return listaoperaciones;

        }

        public int AsignarUsuarioaPerfil(string nombreperfil, string nombreUsuario)
        {
            DAL.ManejadorPerfilUsuario MPU = new DAL.ManejadorPerfilUsuario();
            int FLAG;
            FLAG = MPU.AsignarUsuarioaPerfil(nombreperfil, nombreUsuario);

            return FLAG;
        }

        public void Validar()
        {
            throw new System.NotImplementedException();
        }

        public void VerificarOperacionesBloqueadas()
        {
            throw new System.NotImplementedException();
        }

        public void TraeOperaciones()
        {
            throw new System.NotImplementedException();
        }

        public void ConfirmarOperacion()
        {
            throw new System.NotImplementedException();
        }

        public void BuscarUsuarios()
        {
            throw new System.NotImplementedException();
        }

        public void ListarUsuarios()
        {
            throw new System.NotImplementedException();
        }

        public void Encriptar()
        {
            throw new System.NotImplementedException();
        }

       
    }
}
