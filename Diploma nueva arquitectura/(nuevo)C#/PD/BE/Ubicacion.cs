using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ubicacion
    {
        public int Ubicacionid { get; set; }
        public string NombreUbicacion { get; set; }
        public string Medida { get; set; }
        public string Formato { get; set; }
        public string Formula { get; set; }
        public int Habilitado { get; set; }
        public string Result { get; set; }
        public decimal Precio { get; set; }
        
        public string NombreMedio { get; set; }

        public Medio medio { get; set; }

        

        


    }
}
