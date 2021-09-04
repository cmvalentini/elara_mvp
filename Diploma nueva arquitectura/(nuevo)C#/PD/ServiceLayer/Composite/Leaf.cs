using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Composite
{
   public class Leaf : Component
    {
        private IList<Component> _hijos = new List<Component>();
        private List<string> listaoperaciones;
        

        public override List<string> obtenerpatente
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void AgregarHijo(Component c)
        {
            _hijos.Add(c);
        }

        public override IList<Component> obtenerhijos()
        {


            throw new NotImplementedException();
        }



        public Leaf(string nombre) : base(nombre)
        {


        }


        public IList<Component> obtenerhijos(IList<Component> Hijos )
        {
            

            foreach (var operacion in listaoperaciones)
            {
                foreach (var item in _hijos)
                {
                    Leaf leaf = new Leaf(operacion.ToString());

                    this.AgregarHijo(leaf);

                }

            }


            return _hijos;
        }

    }
}
