﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.Seguridad
{
   
    public class EncriptacionBLL
    {
        BE.Seguridad.Encriptacion cryp = new BE.Seguridad.Encriptacion();
        public readonly string key = "MasterKey";

        public BE.Seguridad.Encriptacion Encriptar(string  Texto) {

            byte[] keyArray;
     
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(Texto.ToString());

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

             
            //se guarda la llave para que se le realice hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key.ToString()));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();

           cryp.Result =  Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            return cryp;
            
        }


        public BE.Seguridad.Encriptacion Desencriptar(string TextoEncriptado) //string encriptado
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(TextoEncriptado);


            //se llama a las clases que tienen los algoritmos //de encriptación se le aplica hashing

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();

            cryp.Result = UTF8Encoding.UTF8.GetString(resultArray);

            return cryp;
        }

        public BE.Seguridad.Encriptacion CrearPassword(BE.Seguridad.Encriptacion cryp) //int longitud
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < cryp.Longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            cryp.Result = res.ToString();
            return cryp;
        }







    }
}
