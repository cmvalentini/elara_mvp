using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DigitoVerificador
    {
        int contadorDVV = 0;
       
        DAL.DigitosVerificadores digitos = new DAL.DigitosVerificadores();
        string rta = "";

        public string CalcularDigitosVerificadores()
        {
            rta = digitos.VerificarDV();

            return rta;
        }

        public void CalcularDVV()
        {
           
        }

        public int CarlcularDVH(string aux)
        {
            char[] charArray = aux.ToCharArray();

            foreach (char ch in charArray)
            {
                contadorDVV += (int)ch;
            }

            return contadorDVV;
        }

        public string RecalcularDVH()
        {
            
        
            rta = digitos.RecalcularDVH();
            return rta;
        }
    }
}