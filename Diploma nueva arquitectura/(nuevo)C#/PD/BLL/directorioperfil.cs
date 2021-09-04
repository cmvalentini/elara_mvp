using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class directorioperfil : ServiceLayer.Component
    { 
        private List<string> listaoperaciones;
        ManejadorPerfilUsuario mpu = new ManejadorPerfilUsuario();


        private List<ServiceLayer.Component> _hijos = new List<ServiceLayer.Component>();
        public directorioperfil(string nombre) : base(nombre)
        {
         //   _hijos = new List<Componente>();
        }

        public override List<string> obtenerpatente
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void AgregarHijo(ServiceLayer.Component c)
        {
            _hijos.Add(c);
        }

        public override IList<ServiceLayer.Component> obtenerhijos()
        {
            return _hijos.ToArray();
        }


        public void obtenerhijos(int usuid)
        {
            listaoperaciones = new List<string>();
            listaoperaciones = mpu.MostrarMenuPerfiles(usuid);
           
            
        }



    }
}
