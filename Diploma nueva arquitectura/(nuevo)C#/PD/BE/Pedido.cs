using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Pedido
    {
        public int pedidoid { get; set; }

        public decimal Preciopedido { get; set; }
        public DateTime FechainicioPublicacion { get; set; }
        public DateTime FechafinPublicacion { get; set; }
        public int Impresiones { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string NombreAgencia { get; set; }

        public Pedido() { }
        public Ubicacion ubicacion;
        public Medio medio;

        public Pedido(decimal preciopedido,DateTime fechainiciopublicacion,DateTime fechafinpublicacion,int impresiones, string descripcion,
        DateTime fechapedido,DateTime fechaborrado,string nombreagencia,Ubicacion ubi, Medio med) {
            Preciopedido = preciopedido;
            FechainicioPublicacion = fechainiciopublicacion;
            FechafinPublicacion = fechafinpublicacion;
            Impresiones = impresiones;
            Descripcion = descripcion;
            FechaPedido = fechapedido;
            FechaBorrado = fechaborrado;
            NombreAgencia = nombreagencia;
            ubicacion = ubi;
            medio = med;

            
         }
        

    }
}
