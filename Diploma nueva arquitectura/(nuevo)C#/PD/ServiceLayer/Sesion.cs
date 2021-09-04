using System;

namespace ServiceLayer
{
    public class Sesion: Ilogin
    {
        private string usuario;
        private string clave;
        private static Sesion _instancia;
        

     
        public string nombreusuario { get; set; }
        public string Password {get; set; }
        public int UsuarioID { get; set; }
        public int FlagIntentosLogin { get; set; }

     
        
        public static Sesion GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new Sesion();
            }
            return _instancia;
        }

        
        public Sesion() { }

        public Sesion(string usuario, string clave, int usuarioID, int flagintentoslogin)
        {
            this.usuario = usuario;
            this.clave = clave;
            UsuarioID = usuarioID;
            FlagIntentosLogin = flagintentoslogin;
        }

      
    }
}