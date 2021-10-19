using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ServiceLayer;

namespace BLL
{
    public class UsuarioBLL: ServiceLayer.Ilogin
    {
        BE.Usuario usuarioBE = new BE.Usuario();
        public UsuarioBLL() { }

        public BE.Usuario TraerDatosUsuariobyID(BE.Usuario usube) //usuid
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            
            usuarioBE = usu.TraerDatosUsuariobyID(usube);
                      

            return usuarioBE;


        }

        public BE.Usuario traerDatosPerfil(BE.Usuario usube)
        {
                       
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usuarioBE.PerfilUsuario = usu.traerDatosPerfil(usube);
            return usuarioBE;

        }

       public int verificarDuplicidad(BE.Usuario usuBE, int usuarioid) //dni,email,usuario,usuarioid
        {
            int result = 0;
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            result = usu.verificarDuplicidad(usuBE,usuarioid); //dni, email,usuario,usuarioid

            return result;
            
        }


        public int verificarDuplicidad(BE.Usuario usuBE) // dni,  email, usuario
        {
            int result = 0;
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            result = usu.verificarDuplicidad(usuBE); //dni, email, usuario

            return result;

        }

        public void TraerDatosUsuario(BE.Usuario usuBE) // nombreusuario,  clave
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usu.TraerDatosUsuario(usuBE); //nombreusuario, clave

        }

        public List<BE.Seguridad.Operacion> MostraroperacionUsuario(List<BE.Seguridad.Operacion> listaoperaciones ) //nombreUsuario
        {
            List<BE.Seguridad.Operacion> ListaOperaciones = new List<BE.Seguridad.Operacion>();
            DAL.OperacionDAL opDAL = new DAL.OperacionDAL() ;

            ListaOperaciones = opDAL.MostraroperacionUsuario(listaoperaciones);

            return ListaOperaciones;
        }

      

      

        public void Dar_Alta_Usuario(BE.Usuario usube)
      //(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado, string clave, string clavesinencriptar)
        {
        DAL.UsuarioDAL usu1 = new DAL.UsuarioDAL();
        usu1.Dar_Alta_Usuario(usube);

        }
 

        public BE.Usuario verificarPatentesBloqueo(BE.Usuario usube,BE.Seguridad.Operacion opbe)
        {
            DAL.ManejadorPerfilUsuarioDAL MPU = new DAL.ManejadorPerfilUsuarioDAL();
            usube.Result = MPU.verificarPatentesBloqueo(usube, opbe);

            return usube;
        }

                 

        public BE.Usuario BuscarUsuario(BE.Usuario usube ) //NombreUsuario
        {
                    
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usuarioBE = usu.BuscarUsuario(usube);
            return usuarioBE;
        }

        public BE.Usuario BuscarUsuario(BE.Usuario usube)
        {
            
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            usuarioBE = usu.BuscarUsuario(usube);
            
            return usuarioBE;
        }

        public BE.Usuario ModificarDatosUsuario(BE.Usuario usube )
     //(string _Usuario, string apellido, string nombre, string email, Int64 dni, bool habilitado,int usuarioid)
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usube.Result = usu.ModificarDatosUsuario(usube);


            return usube;

        }

        public void EnviarMail(int usuarioID,string claveencriptada,string clavesinencriptar)
        {
            DAL.UsuarioDAL usu2 = new DAL.UsuarioDAL();
            usu2.EnviarMail(usuarioID, claveencriptada, clavesinencriptar);
        }

        public BE.Usuario EliminarUsuario(BE.Usuario usube) //idusuario
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usube.Result = usu.EliminarUsuario(usube);

                return usube;
        }

        
        public BE.Usuario CambiarClave(BE.Usuario usube, string ClaveNueva) //Usuario, ClaveNueva,Usuarioid
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            
          usuarioBE.Result =  usu.CambiarClave(usube, ClaveNueva);

            return usuarioBE;
        }

       
        
        public void BlanquearIntentos(BE.Usuario usube ) //usuarioID
        {
            DAL.UsuarioDAL usu  = new DAL.UsuarioDAL();
            usu.Blanquearintentos(usube);
        }

     
        public List<BE.Usuario> MostrarUsuarios()
        {
            List<BE.Usuario> listausuarios = new List<BE.Usuario>();
             
            DAL.UsuarioDAL USU = new DAL.UsuarioDAL();

            listausuarios = USU.MostrarUsuarios();
            

            return listausuarios;
        }

      
        public void SumarFlagIntentos(BE.Usuario usube) //usuID
        {
            DAL.UsuarioDAL USU = new DAL.UsuarioDAL();
            USU.SumarFlagIntentos(usube);

        }
    
        

               

     


    }
}