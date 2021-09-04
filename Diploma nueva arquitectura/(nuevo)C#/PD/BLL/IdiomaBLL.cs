using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE.Idioma;

namespace BLL
{
    public class IdiomaBLL 
    {


        BE.Idioma.Idioma IdiomaBE = new BE.Idioma.Idioma();
        public BE.Idioma.Idioma CargarIdioma()
        {
             
            DAL.IdiomaDAL _idioma = new DAL.IdiomaDAL();
            IdiomaBE = _idioma.CargarIdioma();



            return IdiomaBE;
        }

        public BE.Idioma.Idioma SetearIdioma(int idiomaID)
        {
            
            DAL.IdiomaDAL idioma1 = new DAL.IdiomaDAL();

            IdiomaBE = idioma1.SetearIdioma(idiomaID);


            return IdiomaBE;


        }
    }
}