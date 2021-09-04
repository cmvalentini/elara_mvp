using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ServiceLayer;

namespace BLL
{
    public class Usuario: ServiceLayer.Ilogin
    {


        public int UsuarioID { get; set; }
        public string _Usuario { get; set; }

        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public bool Habilitado { get; set; }
        public int FlagIntentosLogin { get; set; }

        public string clavesinencriptar { get; set; }
        

      

        public Usuario TraerDatosUsuariobyID(int usuid)
        {
            DAL.Usuario usu = new DAL.Usuario();
            Usuario usu1 = new Usuario();
            usu.TraerDatosUsuariobyID(usuid);
            //convierto un objeto dal a uno bll y traigo datos

            this.usuarioadapter(usu1, usu);

            return usu1;


        }

        public string traerDatosPerfil(string nombreUsuario)
        {
            string perfil;
            DAL.Usuario usu = new DAL.Usuario();
            perfil = usu.traerDatosPerfil(nombreUsuario);
            return perfil;

        }

        public int verificarDuplicidad(int dni, string email,string usuario,int usuarioid)
        {
            int result = 0;
            DAL.Usuario usu = new DAL.Usuario();

            result = usu.verificarDuplicidad(dni, email,usuario,usuarioid);

            return result;
            
        }


        public int verificarDuplicidad(int dni, string email, string usuario)
        {
            int result = 0;
            DAL.Usuario usu = new DAL.Usuario();

            result = usu.verificarDuplicidad(dni, email, usuario);

            return result;

        }

        public void TraerDatosUsuario(string nombreusuario, string clave)
        {
            DAL.Usuario usu = new DAL.Usuario();
            usu.TraerDatosUsuario(nombreusuario, clave);

        }

        public List<string> MostraroperacionUsuario(string nombreUsuario)
        {
            List<string> listaopusuario = new List<string>();
            DAL.Usuario usu = new DAL.Usuario();

            listaopusuario = usu.MostraroperacionUsuario(nombreUsuario);

            return listaopusuario;
        }

        public List<string> MostrarOperacionesBloqueadas(string nombreUsuario)
        {
            List<string> listaopusuario = new List<string>();
            DAL.Usuario usu = new DAL.Usuario();

            listaopusuario = usu.MostrarOperacionesBloqueadas(nombreUsuario);

            return listaopusuario;



        }

      

        public void Dar_Alta_Usuario(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado, string clave, string clavesinencriptar)
        {
            
            DAL.Usuario usu1 = new DAL.Usuario();
            usu1.Dar_Alta_Usuario(_Usuario, apellido, nombre, email, dni, habilitado, clave, clavesinencriptar);

        }
 

        public string verificarPatentesBloqueo(string nombreUsuario, string patente)
        {
            DAL.ManejadorPerfilUsuario MPU = new DAL.ManejadorPerfilUsuario();
            string rta = MPU.verificarPatentesBloqueo(nombreUsuario,patente);

            return rta;
        }

                 

        public Usuario BuscarUsuario(string NombreUsuario)
        {

            Usuario BLL_USU = new BLL.Usuario();
           
            DAL.Usuario usu = new DAL.Usuario();
            
            usu = usu.BuscarUsuario(NombreUsuario);
                       

            BLL_USU.nombreusuario = usu._Usuario;
            BLL_USU.UsuarioID = usu.UsuarioID;
            BLL_USU.FlagIntentosLogin = usu.FlagIntentosLogin;

            return BLL_USU;
        }

        public Usuario BuscarUsuario(string NombreUsuario,string clave)
        {

            Usuario BLL_USU = new BLL.Usuario();

            DAL.Usuario usu = new DAL.Usuario();

            usu = usu.BuscarUsuario(NombreUsuario,clave);


            BLL_USU.nombreusuario = usu._Usuario;
            BLL_USU.UsuarioID = usu.UsuarioID;
            BLL_USU.FlagIntentosLogin = usu.FlagIntentosLogin;

            return BLL_USU;
        }

        public string ModificarDatosUsuario(string _Usuario, string apellido, string nombre, string email, Int64 dni, bool habilitado,int usuarioid)
        {
            

                DAL.Usuario usu = new DAL.Usuario();
                string flag = usu.ModificarDatosUsuario(_Usuario, apellido, nombre, email, dni, habilitado,usuarioid);


            return flag;

        }

        public void EnviarMail(int usuarioID,string claveencriptada,string clavesinencriptar)
        {
            DAL.Usuario usu2 = new DAL.Usuario();
            usu2.EnviarMail(usuarioID, claveencriptada, clavesinencriptar);
        }

        public string EliminarUsuario(int usuarioid)
        {
            DAL.Usuario usu = new DAL.Usuario();
            string result = usu.EliminarUsuario(usuarioid);

                return result;
        }

        public Usuario usuarioadapter(Usuario u, DAL.Usuario ud) {

            u.UsuarioID = ud.UsuarioID;
            u.Apellido = ud.apellido  ;
            u.Nombre = ud.nombre ;
            u.Email = ud.email ;
            u.Dni =  ud.dni ;
            u.Habilitado = ud.habilitado ;
            u._Usuario = ud._Usuario ;
            u.FlagIntentosLogin = ud.FlagIntentosLogin;

            return u;
        }

        public void VerificarOperacionesBloqueadas()
        {
            throw new System.NotImplementedException();
        }

        public string CambiarClave(string Usuario, string ClaveNueva,int Usuarioid)
        {
            DAL.Usuario usu = new DAL.Usuario();

            
          string rta=  usu.CambiarClave(Usuario, ClaveNueva, Usuarioid);

            return rta;
        }

        public string verificarPatentesEscenciales(List<string> operacioneshuerfanas,string NombreUsuario)
        {
            DAL.ManejadorPerfilUsuario MPU = new DAL.ManejadorPerfilUsuario();
            string rta = MPU.verificarPatentesEscenciales(operacioneshuerfanas,NombreUsuario);

            return rta;
        }

        public string verificarPatentesEscenciales(int UsuarioID)
        {
            DAL.ManejadorPerfilUsuario MPU = new DAL.ManejadorPerfilUsuario();
            string rta = MPU.verificarPatentesEscenciales(UsuarioID);

            return rta;
        }



        public void BlanquearIntentos(int usuarioID)
        {
            DAL.Usuario usu  = new DAL.Usuario();
            usu.Blanquearintentos(usuarioID);
        }

        public string verificarPatentesEscenciales(string NombreUsuario)
        {
            DAL.ManejadorPerfilUsuario MPU = new DAL.ManejadorPerfilUsuario();
            string rta = MPU.verificarPatentesEscenciales(NombreUsuario);

            return rta;
        }

        public void ValidarClaveNueva()
        {
            throw new System.NotImplementedException();
        }

        public DataTable MostrarUsuarios()
        {
            DataTable dt = new DataTable();
            DAL.Usuario USU = new DAL.Usuario();

            dt = USU.MostrarUsuarios();
            

            return dt;
        }

         
        public string Clave { get; set; }
       
        public string nombreusuario { get;  set;}

        public string Password { get; set; }


        public void SumarFlagIntentos(int usuID)
        {
            DAL.Usuario USU = new DAL.Usuario();
            USU.SumarFlagIntentos(usuID);

        }


        //CONSTRUCTOR
        public Usuario(int Usuarioid, string _Usuario, string apellido, string _nombre, string _email, int _dni, bool _habilitado, int _FlagIntentos)
        {
            this.UsuarioID = Usuarioid;
            this._Usuario = _Usuario;
            this.Apellido = apellido;
            this.Nombre = _nombre;
            this.Email = _email;
            this.Dni = _dni;
            this.Habilitado = _habilitado;
            this.FlagIntentosLogin = _FlagIntentos;
            
            }


        public Usuario() { }

               

     public Usuario(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado, string clave,string clavesinencriptar)
        {
            this._Usuario = _Usuario;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Email = email;
            this.Dni = dni;
            this.Habilitado = habilitado;
            this.Clave = clave;
            this.clavesinencriptar = clavesinencriptar;
        }

        public Usuario(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado,string clave)
        {
            this._Usuario = _Usuario;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Email = email;
            this.Dni = dni;
            this.Habilitado = habilitado;
            this.Clave = clave;
        }


    }
}