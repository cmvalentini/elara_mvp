﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    internal class Conexion  
    {

        DataTable dt;
        // laburo
        // static string stringconexiontest = "Data Source=ID705881;Initial Catalog=ELARA;Integrated Security=True";


        //facu
        //static string stringconexiontest = @"Data Source=090W10113-70968\SQL14_UAI;Initial Catalog=ELARA;Integrated Security=True";


        // casa
        //  static string stringconexiontest = @"Data Source=DESKTOP-VF25GBN\SERVERCHARLY;Initial Catalog = ELARA; Integrated Security = True";
        static string stringconexiontest = ConfigurationManager.AppSettings["conexionBD"].ToString();


        SqlConnection con = new SqlConnection(stringconexiontest);

        internal void Conectar()
        {

            con.Close();
            if (con.State == ConnectionState.Open)
            {

                 
            }
            else
	        {
                con.Open();
          
            }

            Console.WriteLine("Conexion abierta Correctamente");

        }
        internal string VerificarStringConexion(string cadena)
        {
            SqlConnection con = new SqlConnection(cadena);

            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                    throw;
                }
                                              
            }
            else
            {

                return "no se pudo abrir la conexion ";
            }


        }

        internal string EjecutarRestore(int cant)
        {
            
            try
            {
                string stringcon = "DESKTOP-VF25GBN\\SERVERCHARLY;Initial Catalog=master;Integrated Security=True";


                SqlConnection con1 = new SqlConnection(stringcon);
                con1.Open();

                SqlCommand com = new SqlCommand("RealizarRestore", con1);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter Parametro1 = new SqlParameter("@CANT", cant);
                
                com.Parameters.Add(Parametro1);


                com.ExecuteReader();

                con1.Close();
                return "Restore OK";

            }

            catch (Exception ex)
            {
                return ex.Message;
            }
          


        }

        internal void EjecutarProcedureconListaParametros(string NombreParametro, List<SqlParameter> parametrosSP)
        {

            Conectar();
            SqlCommand com = new SqlCommand(NombreParametro, con);
            com.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parametros in parametrosSP)
            {
                com.Parameters.Add(parametros);
            }
             
            com.ExecuteReader();

            Desconectar();


        }

        internal void EjecutarProcedure(string sp, int usuID)
        {
            Conectar();
            SqlCommand com = new SqlCommand(sp, con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@usuid", usuID);

            com.ExecuteReader();

            Desconectar();

        }



        internal void Desconectar()
        {
           // string stringconexiontest = "Data Source=ID705881;Initial Catalog=ELARA;Integrated Security=True";
            SqlConnection con = new SqlConnection(stringconexiontest);
            if (con.State == ConnectionState.Closed)
            {

            }
            else {
                con.Close();
            }

           
            Console.WriteLine("Conexion cerrada Correctamente");
        }


        internal string Ejecutar(string sql)
        {
            try
            {
                Conectar();
                SqlCommand com = con.CreateCommand();
                com.CommandText = sql;
                int fil = com.ExecuteNonQuery();

                if (fil > 0)
                {
                    Console.WriteLine("Se ejecutó satisfactoriamente");
                    return "Se ejecutó satisfactoriamente"; 
                }
                else {

                    return "No se pudo ejecutar la consulta";

                }

            }

            catch (Exception ex) {
                return ex.Message;
                
            }

            finally { Desconectar(); }


             
        }
        

        internal DataTable Ejecutarreader(string sql) //SELECCIONAR DATOS
        {
     
             SqlCommand com = new SqlCommand(sql, con);
           // SqlCommand com = con.CreateCommand();
            //com.CommandText = sql;

            Conectar();
            
            SqlDataReader reader = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            Desconectar();
             
            return dt;

        }

        internal string Dar_Baja(string sql)
        {
            throw new NotImplementedException();
        }

       

        internal string VerificarDatoTabla(string sql)
        {
            DataTable dt = new DataTable();
            string rta;
            SqlCommand com = new SqlCommand(sql, con);

            Conectar();

            SqlDataReader reader = com.ExecuteReader();

            dt.Load(reader);
            Desconectar();

            Console.WriteLine();

            if (dt.Rows.Count > 0)
            {
                rta = System.Convert.ToString((dt.Rows[0][0]));


                return rta;

            }
            else
            {

                rta = "";
                return rta;

            }

           
        }

        

      
    }
}
