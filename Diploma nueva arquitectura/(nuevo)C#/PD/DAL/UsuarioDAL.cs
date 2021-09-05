﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class UsuarioDAL  
    {
        
        Conexion con = new Conexion();
        DigitosVerificadores dv = new DigitosVerificadores();
        BE.Usuario UsuarioBE = new BE.Usuario();
        DataTable dt = new DataTable();
        

        public BE.Usuario TraerDatosUsuariobyID(int usuid)
        {

            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          "where usuarioid = " + usuid + "";
                           

            try
            {
                DataTable dt = new DataTable();
                dt = con.Ejecutarreader(sql);



                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader UsuarioDal" + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuarioBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuarioBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuarioBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuarioBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuarioBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuarioBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuarioBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuarioBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {


                }

                 
                return UsuarioBE;

            }
            catch (Exception ex)
            {

                UsuarioBE.Result = ex.Message;
            }



        }

        public void Blanquearintentos(BE.Usuario usube) {
            string sql = "update usuario set  FlagIntentosLogin = 0 where UsuarioID = "+ usube.UsuarioID;

            DataTable dt = new DataTable();
            dt = con.Ejecutarreader(sql);

        }

        public string traerDatosPerfil(string nombreUsuario)
        {

            string rta = "";

            string sql = "select p.NombrePerfil from perfilusuario p "+
" inner join UsuarioFamilia uf on uf.PerfilID = p.PerfilUsuarioID "+
" inner join Usuario u on u.UsuarioID = uf.UsuarioID " +
" where u.Usuario like '%"+nombreUsuario+"%'";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    rta = item[0].ToString();
                }
            }


            return rta;


        }

        public UsuarioDAL BuscarUsuario(string usuario, string clave)
        {
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin from Usuario where Usuario = '" + usuario + "'" +
                "and Clave ='"+ clave +"';";

            try
            {

                dt = con.Ejecutarreader(sql);



                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    this.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    this._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    this.apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    this.nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    this.email = Convert.ToString(dt.Rows[0][6].ToString());
                    this.dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    this.habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    this.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {


                }

                UsuarioDAL usu = new UsuarioDAL(this.UsuarioID, this._Usuario, this.apellido, this.nombre, this.email, this.dni, this.habilitado, this.FlagIntentosLogin);

                return usu;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<string> MostrarOperacionesBloqueadas(string nombreUsuario)
        {

            List<string> listaoperaciones1 = new List<string>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();

            string sql = "Select op.Descripcion from usuariooperacion uo inner join " +
                       " operacion op on op.OperacionID = uo.Operacionid " +
                       " where uo.UsuarioID = (select UsuarioID from Usuario where" +
                       " Usuario like '%" + nombreUsuario + "%')" +
                       " and Habilitado like 'N';";


            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { listaoperaciones1.Add(dt.Rows[i]["Descripcion"].ToString()); }

            }

            return listaoperaciones1;



        }

        public void EnviarMail(int usuarioID,string claveencriptada,string clavesinencriptar)
        {
            string email = "";
            string sql = " select Email from usuario " +
                         " where UsuarioID = " + usuarioID;



            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                   email = item[0].ToString();
                }
            }

            string sql1 = "Update Usuario set Clave = '" + claveencriptada + "' " +
                " where Usuarioid = " + usuarioID + "";
             

            string rta = con.Ejecutar(sql1);
            dv.RecalcularDVH();


            EmailService es = new EmailService();

            es.EnviarEmail(email, clavesinencriptar);



        }

        public List<string> MostraroperacionUsuario(string nombreUsuario)
        {

            List<string> listaoperaciones1 = new List<string>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();

            string sql = "Select op.Descripcion from usuariooperacion uo inner join " +
                       " operacion op on op.OperacionID = uo.Operacionid " +
                       " where uo.UsuarioID = (select UsuarioID from Usuario where" +
                       " Usuario like '" + nombreUsuario + "');";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { listaoperaciones1.Add(dt.Rows[i]["Descripcion"].ToString()); }

            }

            return listaoperaciones1;




        }

        public int verificarDuplicidad(int dni, string email,string usuario,int usuarioid)
        {
            int result;
            string sql = " DECLARE @Dni int = (select count(dni) from usuario where dni = " + dni + " and UsuarioID not in ("+usuarioid +")) " +
             "  DECLARE @Email varchar(50) = (select count(Email) from Usuario where Email like '" + email + "' and UsuarioID not in (" + usuarioid + ")) " +
             " DECLARE @Usuario varchar(50) = (select count(Usuario) from Usuario where Usuario like '" + usuario + "' and UsuarioID not in (" + usuarioid + ")) " +
             " declare @result int = 4;" +
           " set @result = (select CASE when @Email = 1 then 2 ELSE @result END )" +
           "   set @result = (select CASE when @Dni = 1 then  1 ELSE @result END )" +
           "	  set @result = (select CASE when @Usuario = 1 then 5 ELSE @result end) " +
           "   set @result = (select CASE when @Dni = 1 AND @Email = 1 then 3 ELSE @result end) " +
           "  select @result;";

            
            DataTable dt = new DataTable();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));
                result = Convert.ToInt32(dt.Rows[0][0].ToString());
                return result;
            }
                                    else
                                    {
                                        return result = 5;
                                    }
           
           }


        public int verificarDuplicidad(int dni, string email, string usuario)
        {
            try
            {
                int result;
                string sql = " DECLARE @Dni int = (select count(dni) from usuario where dni = " + dni + ")" +
                 "  DECLARE @Email varchar(50) = (select count(Email) from Usuario where Email like '" + email + "') " +
                 " DECLARE @Usuario varchar(50) = (select count(Usuario) from Usuario where Usuario like '" + usuario + "') " +
                 " declare @result int = 4;" +
               " set @result = (select CASE when @Email = 1 then 2 ELSE @result END )" +
               "   set @result = (select CASE when @Dni = 1 then  1 ELSE @result END )" +
               "	  set @result = (select CASE when @Usuario = 1 then 5 ELSE @result end) " +
               "   set @result = (select CASE when @Dni = 1 AND @Email = 1 then 3 ELSE @result end) " +
               "  select @result;";


                DataTable dt = new DataTable();
                dt = con.Ejecutarreader(sql);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));
                    result = Convert.ToInt32(dt.Rows[0][0].ToString());
                    return result;
                }
                else
                {
                    return result = 5;
                }



            }
            catch (Exception)
            {

                throw;
            }
           
        }




        public string ModificarDatosUsuario(string _Usuario, string apellido, string nombre, string email, Int64 dni, bool habilitado, int usuarioid)
        {
           
            int h ;
            if (habilitado.ToString() =="True")
            {
                h = 1;   
            }
            else
            {
                h = 0;
            }
            string sql = "update Usuario set Usuario = '" + _Usuario + "',apellido = '" + apellido + "',nombre='" + nombre + "',DNI=" + dni + ",email='" + email + "',Habilitado=" + h + " "
            + "where Usuarioid = " + usuarioid + ";";

            string result = con.Ejecutar(sql);

            dv.RecalcularDVH();
            return result;

        }

        public string EliminarUsuario(int usuarioid)
        {               
            string sql = " Delete UsuarioOperacion where Usuarioid =" + usuarioid + " " +
                         " Delete usuariofamilia where Usuarioid =" + usuarioid +" " +
                         " Delete usuario where usuarioid = " + usuarioid + ";";

            string result = con.Ejecutar(sql);

            dv.RecalcularDVH();
            return result;
        }

        public UsuarioDAL() { }

        public UsuarioDAL(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado,string clave)
        {
            this._Usuario = _Usuario;
            this.apellido = apellido;
            this.nombre = nombre;
            this.email = email;
            this.dni = dni;
            this.habilitado = habilitado;
            this.Clave = clave;
        }

        public void Dar_Alta_Usuario(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado,string clave,string clavesinencriptar)
        {
           
           
            string sql = "insert into Usuario values( '"+ _Usuario + "',"
               + "'"+ clave +"','"+ nombre + "','"+ apellido  + "',"+ dni + ",'"+  email + "','"+ habilitado + "',0,"+"'_DVH')";

             string result = con.Ejecutar(sql);
            dv.RecalcularDVH();

            EmailService mail = new EmailService();
            mail.EnviarEmail(email,"Se ha generado la clave: "+ clavesinencriptar + " para el usuario:" + _Usuario);

        }

        public void TraerDatosUsuario(string usuario, string clave)
        {


            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          " where usuario = '" + usuario + "'" +
                          " and clave = '" + clave + "' " +
                          " and Habilitado = 1";
            try
            {
                DataTable dt = new DataTable();
                dt =  con.Ejecutarreader(sql);
                 


                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    this.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    this._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    this.apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    this.nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    this.email = Convert.ToString(dt.Rows[0][6].ToString());
                    this.dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    this.habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    this.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {


                }

       UsuarioDAL usu = new UsuarioDAL(this.UsuarioID, this._Usuario, this.apellido, this.nombre, this.email, this.dni, this.habilitado, this.FlagIntentosLogin);

                ServiceLayer.Sesion ss =  ServiceLayer.Sesion.GetInstance();
                ss.UsuarioID = usu.UsuarioID;
                ss.nombreusuario = _Usuario;
                ss.FlagIntentosLogin = usu.FlagIntentosLogin;

            }
            catch (Exception)
            {

                throw;
            }
          
         

        }

        public DataTable MostrarUsuarios()
        {

            string sql = "select UsuarioID, Usuario, Clave, Nombre, Apellido, DNI,"+
                " Email, Habilitado, FlagIntentosLogin from Usuario ";

            dt = con.Ejecutarreader(sql);

            return dt;

        }

        public UsuarioDAL BuscarUsuario(string usuario)
        {
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin from Usuario where Usuario = '" + usuario + "'";

            try
            {
               
                dt = con.Ejecutarreader(sql);



                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    this.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    this._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    this.apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    this.nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    this.email = Convert.ToString(dt.Rows[0][6].ToString());
                    this.dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    this.habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    this.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {


                }

                UsuarioDAL usu = new UsuarioDAL(this.UsuarioID,this._Usuario,this.apellido, this.nombre, this.email, this.dni, this.habilitado,this.FlagIntentosLogin);

                return usu;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public string CambiarClave(string usu, string claveNueva,int Usuarioid)
        {
           string sql = "Update Usuario set Clave = '"+claveNueva+"' "+
                " where Usuario = '" + usu + "'"+
                " and Usuarioid = "+Usuarioid+"";

            string rta = con.Ejecutar(sql);
            dv.RecalcularDVH();
            return rta;




        }

        public void SumarFlagIntentos(int usuID)
        {
            string sp = "SumarFlagIntentos";
            con.EjecutarProcedure(sp,usuID);
        }
    }
}
