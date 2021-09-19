using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
    public class OperacionBLL
    {
        public OperacionBLL() { }

        public List<BE.Seguridad.Operacion> MostrarOperacionesBloqueadas() //nombreUsuario
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            listaoperaciones = usu.MostrarOperacionesBloqueadas(listaoperaciones);

            return listaoperaciones;

        }


        public BE.Usuario verificarPatentesEscenciales(List<BE.Seguridad.Operacion> operacioneshuerfanas, BE.Usuario usube)// ophuerfanas,nombreusuario
        {
            DAL.ManejadorPerfilUsuarioDAL MPU = new DAL.ManejadorPerfilUsuarioDAL();
            usube.Result = MPU.verificarPatentesEscenciales(operacioneshuerfanas, usube);

            return usube;
        }

        public BE.Usuario verificarPatentesEscenciales(BE.Usuario usube) //UsuarioID
        {
            DAL.ManejadorPerfilUsuarioDAL MPU = new DAL.ManejadorPerfilUsuarioDAL();
            usube.Result = MPU.verificarPatentesEscenciales(usube);

            return usube;
        }

        public BE.Usuario verificarPatentesEscenciales(BE.Usuario usube)
        {
            DAL.ManejadorPerfilUsuarioDAL MPU = new DAL.ManejadorPerfilUsuarioDAL();
            usube.Result = MPU.verificarPatentesEscenciales(usube);

            return usube;
        }




    }
}
