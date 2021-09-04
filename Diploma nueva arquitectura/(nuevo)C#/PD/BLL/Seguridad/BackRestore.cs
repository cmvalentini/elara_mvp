using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
    public class BackRestore
    {
        string rta;
        public void RealizarBackUp(string path, int cantidad)
        {

          //  string parte1 = path + @"\parte1.Bak";
       

            DAL.BackUpRestore backup = new DAL.BackUpRestore();

            backup.RealizarBackUp(path,cantidad);

        }


        public string RealizarRestore(int cant)
        {

           
            DAL.BackUpRestore Restore = new DAL.BackUpRestore();

            rta =  Restore.RealizarRestore(cant);

            return rta; 
        }
    }
}
