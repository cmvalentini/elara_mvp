using System;
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
        

        public BE.Usuario TraerDatosUsuariobyID(BE.Usuario usube ) //usuid
        {

            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          "where usuarioid = " + usube.UsuarioID + "";
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
                return UsuarioBE;
            }



        }

        public void Blanquearintentos(BE.Usuario usube) {
            string sql = "update usuario set  FlagIntentosLogin = 0 where UsuarioID = "+ usube.UsuarioID;

            DataTable dt = new DataTable();
            dt = con.Ejecutarreader(sql);

        }

        public BE.Seguridad.PerfilUsuario traerDatosPerfil(BE.Usuario usube)
        {
            
            string sql = "select p.NombrePerfil from perfilusuario p "+
" inner join UsuarioFamilia uf on uf.PerfilID = p.PerfilUsuarioID "+
" inner join Usuario u on u.UsuarioID = uf.UsuarioID " +
" where u.Usuario like '%"+usube._Usuario+"%'";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    UsuarioBE.PerfilUsuario.NombrePerfil = item[0].ToString();
                }
            }


            return UsuarioBE.PerfilUsuario;
            
        }

        public BE.Usuario BuscarUsuarioconClave(BE.Usuario usube) //usuario, clave
        {
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin from Usuario where Usuario = '" + usube._Usuario + "'" +
                "and Clave ='"+ usube.Clave + "';";

            try
            {

                dt = con.Ejecutarreader(sql);



                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    usube.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    usube._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    usube.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    usube.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    usube.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    usube.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    usube.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    usube.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {
                    return usube;
                }
                                 
                return usube;

            }
            catch (Exception)
            {
                usube.Result = "hubo un problema en la conexion de datos";
                Console.WriteLine(usube.Result);
                return usube;
            }
            
        }

        public List<BE.Seguridad.Operacion> MostrarOperacionesBloqueadas(BE.Usuario nombreUsuario)
        {

            List<BE.Seguridad.Operacion> listaoperaciones1 = new List<BE.Seguridad.Operacion>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();
            BE.Seguridad.Operacion opbe = new BE.Seguridad.Operacion();
            string sql = "Select op.Descripcion from usuariooperacion uo inner join " +
                       " operacion op on op.OperacionID = uo.Operacionid " +
                       " where uo.UsuarioID = (select UsuarioID from Usuario where" +
                       " Usuario like '%" + nombreUsuario._Usuario + "%')" +
                       " and Habilitado like 'N';";


            dt = con.Ejecutarreader(sql);
             
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    {
                    opbe.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones1.Add(opbe); }

            }

            return listaoperaciones1;



        }

        public void EnviarMail(BE.Usuario UsuBE) //int usuarioID,string claveencriptada,string clavesinencriptar
        {
            string email = "";
            string sql = " select Email from usuario " +
                         " where UsuarioID = " + UsuBE.UsuarioID;



            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                   email = item[0].ToString();
                }
            }

            string sql1 = "Update Usuario set Clave = '" + UsuBE.Clave + "' " +
                " where Usuarioid = " + UsuBE.clavesinencriptar + "";
             

            string rta = con.Ejecutar(sql1);
            dv.RecalcularDVH();


            EmailServiceDAL es = new EmailServiceDAL();

            es.EnviarEmail(email, UsuBE.clavesinencriptar);



        }

        public List<BE.Seguridad.Operacion> MostraroperacionUsuario(BE.Usuario nombreUsuario)
        {

            List<BE.Seguridad.Operacion> listaoperaciones1 = new List<BE.Seguridad.Operacion>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();

            string sql = "Select op.Descripcion from usuariooperacion uo inner join " +
                       " operacion op on op.OperacionID = uo.Operacionid " +
                       " where uo.UsuarioID = (select UsuarioID from Usuario where" +
                       " Usuario like '" + nombreUsuario._Usuario + "');";
            BE.Seguridad.Operacion OpBE = new BE.Seguridad.Operacion();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OpBE.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones1.Add(OpBE); }

            }

            return listaoperaciones1;




        }

        public BE.Usuario verificarDuplicidad(BE.Usuario UsuBE,int usuarioid) //dni, email,usuario,usuarioid
        {
            
            string sql = " DECLARE @Dni int = (select count(dni) from usuario where dni = " + UsuBE.Dni + " and UsuarioID not in ("+ usuarioid + ")) " +
             "  DECLARE @Email varchar(50) = (select count(Email) from Usuario where Email like '" + UsuBE.Email + "' and UsuarioID not in (" + usuarioid + ")) " +
             " DECLARE @Usuario varchar(50) = (select count(Usuario) from Usuario where Usuario like '" + UsuBE._Usuario + "' and UsuarioID not in (" + usuarioid + ")) " +
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
                UsuBE.Result = dt.Rows[0][0].ToString();
                return UsuBE;
            }
                                    else
                                    {
                                        UsuBE.Result = "5";
                                        return UsuBE;
                                    }
           
           }


        public BE.Usuario verificarDuplicidad(BE.Usuario UsuBE) // dni, email, usuario
        {
            try
            {
                
                string sql = " DECLARE @Dni int = (select count(dni) from usuario where dni = " + UsuBE.Dni + ")" +
                 "  DECLARE @Email varchar(50) = (select count(Email) from Usuario where Email like '" + UsuBE.Email + "') " +
                 " DECLARE @Usuario varchar(50) = (select count(Usuario) from Usuario where Usuario like '" + UsuBE._Usuario + "') " +
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
                    UsuBE.Result = dt.Rows[0][0].ToString();
                    return UsuBE;
                }
                else
                {
                    UsuBE.Result = "5";
                    return UsuBE;
                }



            }
            catch (Exception EX)
            {
                UsuBE.Result = EX.Message.ToString();
                Console.WriteLine( "func verificarDuplicidad: " + EX.Message);
                return UsuBE;
            }
           
        }




        public BE.Usuario ModificarDatosUsuario(BE.Usuario UsuBE) // _Usuario, apellido, nombre, email, dni, habilitado usuarioid
        {
           
            int h ;
            if (UsuBE.Habilitado.ToString() =="True")
            {
                h = 1;   
            }
            else
            {
                h = 0;
            }
            string sql = "update Usuario set Usuario = '" + UsuBE._Usuario + "',apellido = '" + UsuBE.Apellido + "',nombre='" + UsuBE.Nombre + "',DNI=" + UsuBE.Dni + ",email='" + UsuBE.Email + "',Habilitado=" + h + " "
            + "where Usuarioid = " + UsuBE.UsuarioID + ";";

            UsuBE.Result = con.Ejecutar(sql);

            dv.RecalcularDVH();
            return UsuBE;

        }

        public BE.Usuario EliminarUsuario(BE.Usuario UsuBE) //usuarioid
        {               
            string sql = " Delete UsuarioOperacion where Usuarioid =" + UsuBE.UsuarioID + " " +
                         " Delete usuariofamilia where Usuarioid =" + UsuBE.UsuarioID + " " +
                         " Delete usuario where usuarioid = " + UsuBE.UsuarioID + ";";

            UsuBE.Result = con.Ejecutar(sql);

            dv.RecalcularDVH();
            return UsuBE;
        }

        public UsuarioDAL() { }

        
        public void Dar_Alta_Usuario(BE.Usuario UsuBE) //_Usuario, apellido, nombre, email, dni, habilitado, clave,clavesinencriptar
        {
           
           
            string sql = "insert into Usuario values( '"+ UsuBE._Usuario + "',"
               + "'"+ UsuBE.Clave + "','"+ UsuBE.Nombre + "','"+ UsuBE.Apellido + "',"+ UsuBE.Dni + ",'"+ UsuBE.Email + "','"+ UsuBE.Habilitado + "',0,"+"'_DVH')";

             string result = con.Ejecutar(sql);
            dv.RecalcularDVH();

            EmailServiceDAL mail = new EmailServiceDAL();
            mail.EnviarEmail(UsuBE.Email, "Se ha generado la clave: "+ UsuBE.clavesinencriptar + " para el usuario:" + UsuBE._Usuario);

        }

        public void TraerDatosUsuario(BE.Usuario UsuBE)
        {


            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          " where usuario = '" + UsuBE._Usuario + "'" +
                          " and clave = '" + UsuBE.Clave + "' " +
                          " and Habilitado = 1";
            try
            {
                DataTable dt = new DataTable();
                dt =  con.Ejecutarreader(sql);
                 


                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {


                }
                 
                ServiceLayer.Sesion ss =  ServiceLayer.Sesion.GetInstance();
                ss.UsuarioID = UsuBE.UsuarioID;
                ss.nombreusuario = UsuBE._Usuario;
                ss.FlagIntentosLogin = UsuBE.FlagIntentosLogin;

            }
            catch (Exception EX)
            {

                Console.WriteLine(EX.Message);
            }
          
         

        }

        public List<BE.Usuario> MostrarUsuarios()
        {
            List<BE.Usuario> listausuarios = new List<BE.Usuario>();

            BE.Usuario UsuBE = new BE.Usuario();

            string sql = "select UsuarioID, Usuario, Clave, Nombre, Apellido, DNI,"+
                " Email, Habilitado, FlagIntentosLogin from Usuario ";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    UsuBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                    listausuarios.Add(UsuBE);

                }
            }



            return listausuarios;

        }

        public BE.Usuario BuscarUsuario(BE.Usuario usuario)
        {
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin from Usuario where Usuario = '" + usuario._Usuario + "'";

            try
            {
               
                dt = con.Ejecutarreader(sql);



                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuarioBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuarioBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuarioBE.Apellido   = Convert.ToString(dt.Rows[0][4].ToString());
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
            catch (Exception)
            {

                throw;
            }

        }

        public BE.Usuario CambiarClave(BE.Usuario usu) // usu, claveNueva, Usuarioid
        {
           string sql = "Update Usuario set Clave = '"+ usu.Clave + "' "+
                " where Usuario = '" + usu._Usuario + "'"+
                " and Usuarioid = "+ usu.UsuarioID + "";

            usu.Result = con.Ejecutar(sql);
            dv.RecalcularDVH();
            return usu;




        }

        public void SumarFlagIntentos(int usuID)
        {
            string sp = "SumarFlagIntentos";
            con.EjecutarProcedure(sp,usuID);
        }
    }
}
