using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Usuario
    {

        public Seguridad.Operacion OP ;
        public int UsuarioID { get; set; }
        public string _Usuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public bool Habilitado { get; set; }
        public int FlagIntentosLogin { get; set; }
        public string Result { get; set; }
        public string clavesinencriptar { get; set; }
        public string Clave { get; set; }
        List<BE.Seguridad.Operacion> ListaOperaciones;

        public Usuario(string _usuario, string apellido, string nombre, string email,
            int dni, bool habilitado,List<BE.Seguridad.Operacion> listaoperaciones)
        {
            _Usuario = _usuario;
            Apellido = apellido;
            Nombre = nombre;
            Email = email;
            Dni = dni;
            Habilitado = habilitado;
            ListaOperaciones = listaoperaciones;
        }

        public Usuario(string _usuario, string apellido, string nombre, string email, int dni, bool habilitado, string clave, string clavesinencriptar)
        {
            this._Usuario = _usuario;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Email = email;
            this.Dni = dni;
            this.Habilitado = habilitado;
            this.Clave = clave;
            this.clavesinencriptar = clavesinencriptar;
        }

        public Usuario(string _usuario, string apellido, string nombre, string email, int dni, bool habilitado, string clave)
        {
            this._Usuario = _usuario;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Email = email;
            this.Dni = dni;
            this.Habilitado = habilitado;
            this.Clave = clave;
        }




    }
}
