using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
  public class LeafOperacion:Componente
    {
        private IList<Componente> _hijos = new List<Componente>();
        private List<string> listaoperaciones;
        ManejadorPerfilUsuario mpu = new ManejadorPerfilUsuario();
         
        public override List<string> obtenerpatente
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }

        public override IList<Componente> obtenerhijos()
        {


            throw new NotImplementedException();
        }



        public LeafOperacion(string nombre) : base(nombre)
        {


        }

        public IList<Componente> obtenerhijos(int usuid)
        {
            listaoperaciones = new List<string>();
            listaoperaciones = mpu.MostrarMenuPerfiles(usuid);
            

            foreach (var operacion in listaoperaciones)
                {
                foreach (var item in _hijos)
                {
                    LeafOperacion leaf = new LeafOperacion(operacion.ToString());

                    this.AgregarHijo(leaf);
                    
                } 

            }


            return _hijos;
        }




    }
}
