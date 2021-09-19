using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Seguridad

namespace BLL
{
  public class ManejadorPerfilUsuarioBLL   
    {
        List<Operacion> listaoperaciones = new List<Operacion>();
        public void BloqueaOperacionUsuario(BE.Usuario usuBE, Operacion opBE) //string NombreUsuario,string Patente
        {
            DAL.ManejadorPerfilUsuarioDAL mpu = new DAL.ManejadorPerfilUsuarioDAL();

            mpu.BloqueaOperacionUsuario(usuBE, opBE);


        }

        /// <summary>
        ///Verifica en base si existe el perfil descrito
        /// </summary>
        public ManejadorPerfilUsuario VerificarAltafamilia(ManejadorPerfilUsuario mpu) //nombrePerfil
        {
            DAL.ManejadorPerfilUsuarioDAL MPU = new DAL.ManejadorPerfilUsuarioDAL();
            mpu = MPU.VerificarAltafamilia(mpu);

            return mpu;
        }
        
        public List<PerfilUsuario> BuscarPerfilUsuarios()
        {
            List<PerfilUsuario> lpu = new List<PerfilUsuario>();
            DAL.ManejadorPerfilUsuarioDAL pu = new DAL.ManejadorPerfilUsuarioDAL();

            lpu = pu.BuscarPerfilUsuarios();

            return lpu;

        }
    

        public ManejadorPerfilUsuario _CrearPerfilUsuario(PerfilUsuario perfil) //string NombrePerfil,string DescPerfil
        {
            DAL.ManejadorPerfilUsuarioDAL mpuDAL = new DAL.ManejadorPerfilUsuarioDAL();
            BE.Seguridad.ManejadorPerfilUsuario mpuBE = new ManejadorPerfilUsuario();
            mpuBE.Result = mpuBE._CrearPerfilUsuario(perfil);


            return mpuBE;
        }

        public ManejadorPerfilUsuario ModificarPerfilUsuario(ManejadorPerfilUsuario mpu) //NombrePerfil, DescPerfil, perfilID
        {
            mpu.Result = "False";

            try
            {
                DAL.ManejadorPerfilUsuarioDAL mpuDAL = new DAL.ManejadorPerfilUsuarioDAL();

                mpu.Result = mpuDAL.ModificarPerfilUsuario(mpu);

                return mpu;
            }
            catch (Exception ex)
            {
                mpu.Result = ex.Message;
                return mpu; 
            }


        }






        public void DesbloqueaOperacionaUsuario(ManejadorPerfilUsuario mpu,BE.Seguridad.Operacion op) //string NombreUsuario,String Patente
        {
            DAL.ManejadorPerfilUsuarioDAL mpudal = new DAL.ManejadorPerfilUsuarioDAL();

            mpudal.DesbloqueaOperacionaUsuario(mpu, op);
             
        }

        public ManejadorPerfilUsuario EliminarPerfilUsuario(ManejadorPerfilUsuario mpu ) //PerfilID
        {
            mpu.Result = "False";

            try
            {
                DAL.ManejadorPerfilUsuarioDAL mpuDAL = new DAL.ManejadorPerfilUsuarioDAL();
                if (mpuDAL.EliminarPerfilUsuario(mpu.PerfilID) == "True")
                {
                    mpu.Result = "True";
                }
                
                            
            }
            catch (Exception EX)
            {
                mpu.Result = EX.Message;
                return mpu;
            }


            return mpu;
        }

         
        /// Trae Descripcion de todas las operaciones del sistema
       public List<Operacion> MostrarListaOperaciones()
        {
           
            DAL.ManejadorPerfilUsuarioDAL mpuDAL = new DAL.ManejadorPerfilUsuarioDAL();

            listaoperaciones = mpuDAL.MostrarListaOperaciones();

            return listaoperaciones;
        }
  
        public List<Operacion> MostrarListaOperaciones(ManejadorPerfilUsuario mpu ) //perfilID
        {
            listaoperaciones.Clear(); 
            DAL.ManejadorPerfilUsuarioDAL mpudal = new DAL.ManejadorPerfilUsuarioDAL();

            listaoperaciones = mpudal.MostrarListaOperaciones(mpu);

            return listaoperaciones;
        }
       

        public void AsignarOperacionesalPerfil(ManejadorPerfilUsuario mpu, List<Operacion> listaoperacionesperfil)
        {
            DAL.ManejadorPerfilUsuarioDAL mpudal = new DAL.ManejadorPerfilUsuarioDAL();
            mpudal.AsignarOperacionesalPerfil(mpu, listaoperacionesperfil);

        }
        public void AsignarOperacionesalPerfil(BE.Usuario usu, List<Operacion> listaoperacionesperfil) //NombreUsuario listaoperacionesperfil
        {
            DAL.ManejadorPerfilUsuarioDAL mpudal = new DAL.ManejadorPerfilUsuarioDAL();
            mpudal.AsignarOperacionesalPerfil(usu, listaoperacionesperfil);

        }

        public List<BE.Seguridad.Operacion> MostrarMenuPerfiles(BE.Usuario usu ) //Usuarioid
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            DAL.ManejadorPerfilUsuarioDAL mpudal = new DAL.ManejadorPerfilUsuarioDAL();
        
            listaoperaciones = mpudal.MostrarMenuperfiles(usu);
                        
            return listaoperaciones;

        }

        public ManejadorPerfilUsuario AsignarUsuarioaPerfil(ManejadorPerfilUsuario mpu, BE.Usuario usu) // nombreperfil,   nombreUsuario
        {
            mpu.Result = "";
            DAL.ManejadorPerfilUsuarioDAL MPU = new DAL.ManejadorPerfilUsuarioDAL();
             
            mpu.Result = MPU.AsignarUsuarioaPerfil(mpu, usu);

            return mpu;
        }
         
         
       
    }
}
