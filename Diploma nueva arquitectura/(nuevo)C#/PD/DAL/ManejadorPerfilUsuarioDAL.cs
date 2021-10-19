using System;
using System.Collections.Generic;
using System.Data;
 

namespace DAL
{
    public class ManejadorPerfilUsuarioDAL
    {
        DigitosVerificadores dv = new DigitosVerificadores();
        BE.Seguridad.PerfilUsuario mpu = new BE.Seguridad.PerfilUsuario();
     
        Conexion con = new Conexion();

        public List<BE.Seguridad.Operacion> MostrarMenuperfiles(BE.Usuario usu ) //usuarioid
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            DataTable dt = new DataTable();

            listaoperaciones = this.traeroperacionesusuario(usu);
            BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
            if (dt.Rows.Count > 0)
               {
                  for (int i = 0; i < dt.Rows.Count; i++)
                    {
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones.Add(op);
                      }


            }

            ServiceLayer.Composite.Composite comp = new ServiceLayer.Composite.Composite("comp");

            comp.ObtenerHijos(listaoperaciones);


            return listaoperaciones;
        }

        internal List<BE.Seguridad.Operacion> traeroperacionesusuario(BE.Usuario usu ) // Usuarioid
        {
            DataTable dt = new DataTable();

            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
            string sql = "select o.Descripcion " +
                " from usuariooperacion uo INNER JOIN OPERACION o ON O.OperacionID = UO.OperacionID " +
                 " where uo.UsuarioID = " + usu.UsuarioID + " and uo.Habilitado = 'S' ";

            con.Conectar();
         
                con.Ejecutarreader(sql);
                dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader MPUDAL" + Convert.ToString(dt.Rows[0][0].ToString()));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones.Add(op);
                }

            }


            con.Desconectar();

            return listaoperaciones;
        }

        public void BloqueaOperacionUsuario(BE.Usuario usu, BE.Seguridad.Operacion op) //string nombreUsuario, string patente
        {
            string sql = "update usuariooperacion set Habilitado = 'N' "+
                " where Usuarioid = (select UsuarioID from usuario where Usuario like '%"+usu._Usuario+"%')"+
                " and Operacionid = (select OperacionID from OPERACION where Descripcion like '%"+op.NombreOperacion+"%')";

               con.Ejecutar(sql);
            dv.RecalcularDVH();
        }

        
        ///hacer la verificacion si existe familia antes de dar el alta
        
        public BE.Seguridad.PerfilUsuario VerificarAltafamilia(BE.Seguridad.PerfilUsuario mpu ) //nombrePerfil
        {
            string sql = " select case when count(NombrePerfil) <> 0 then 1 else 0  end 'columna'  from PerfilUsuario where NombrePerfil like '" + mpu.NombrePerfil+"'";
            mpu.Result = "0";
            DataTable dt = new DataTable();
            con.Conectar();
            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);
            con.Desconectar();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { mpu.Result = dt.Rows[i]["columna"].ToString(); }

            }

            return mpu;
        }

        public void DesbloqueaOperacionaUsuario(BE.Usuario usu, BE.Seguridad.Operacion op) //nombreUsuario, patente
        {
            string sql = "update usuariooperacion set Habilitado = 'S' " +
                           " where Usuarioid = (select UsuarioID from usuario where Usuario like '%" + usu._Usuario + "%')" +
                           " and Operacionid = (select OperacionID from OPERACION where Descripcion like '%" + op.NombreOperacion + "%')";

            con.Ejecutar(sql);
            dv.RecalcularDVH();
        }

        public BE.Seguridad.PerfilUsuario ModificarPerfilUsuario(BE.Seguridad.PerfilUsuario mpu) // nombrePerfil, descPerfil, perfilID
        {
            
            string sql = "Update perfilusuario set NombrePerfil = '" + mpu.NombrePerfil + "',DescPerfil= '" + mpu.DescPerfil + "'" +
                 " where PerfilUsuarioID = " + mpu.PerfilUsuarioID + ";";

            try
            {
                con.Ejecutar(sql);
                dv.RecalcularDVH();
                mpu.Result = "True";
                return mpu;
            }

            catch (Exception ex)
            {
                mpu.Result = ex.Message;
                
                dv.RecalcularDVH();
                return mpu;


            }
        }

        public BE.Seguridad.PerfilUsuario verificarPatentesBloqueo(BE.Usuario usu, BE.Seguridad.Operacion patente)
        {
             
            
            string sql = "select Descripcion from operacion where operacionid in " +
" (select distinct OperacionID from usuariooperacion " +
" where UsuarioID = (select usuarioid from usuario where Usuario like '%" + usu._Usuario + "%')" +
" EXCEPT" +
" select distinct OperacionID from usuariooperacion " +
" WHERE OperacionID IN(select distinct OperacionID from usuariooperacion" +
" where UsuarioID <> (select usuarioid from usuario where Usuario like '%" + usu._Usuario + "%') " + " ))"+
" and Descripcion like '"+patente.NombreOperacion+"'";

            DataTable DT = con.Ejecutarreader(sql);


            if (DT.Rows.Count > 0)
            {
                mpu.Result = DT.Rows[0][0].ToString();
                return mpu;
            }
            else
            {   mpu.Result = "True";
                return mpu;
           }


        }

        public BE.Seguridad.PerfilUsuario EliminarPerfilUsuario(BE.Seguridad.PerfilUsuario mpu)
        {
            
            string sql = "Delete perfilusuario where PerfilUsuarioID = "+mpu.PerfilUsuarioID +";" +
                       "Delete perfiloperacion where PerfilUsuarioID = "+ mpu.PerfilUsuarioID + ";";

            try
            {
                con.Ejecutar(sql);
                dv.RecalcularDVH();
                con.Desconectar();
                mpu.Result = "True";
                return mpu;
            }
            catch (Exception ex)
            {
                mpu.Result = ex.Message;
                return mpu;
                     }
           
        }

        public BE.Seguridad.PerfilUsuario _CrearPerfilUsuario(BE.Seguridad.PerfilUsuario mpu) // string nombrePerfil, string descPerfil
        {
            string sql = "insert into PerfilUsuario(NombrePerfil,DescPerfil,DVH) values('" + mpu.NombrePerfil+"','"+mpu.DescPerfil+"',NULL)";


            mpu.Result = con.Ejecutar(sql);
            dv.RecalcularDVH();
            return mpu;
        }

        public List<BE.Seguridad.Operacion> MostrarListaOperaciones()
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            DataTable dt = new DataTable();

            string sql = "select Descripcion from OPERACION";
            
            dt = con.Ejecutarreader(sql);
            BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones.Add(op);
                }

            }

            return listaoperaciones;

         }

        public List<BE.Seguridad.Operacion> MostrarListaOperaciones(BE.Seguridad.PerfilUsuario mpu )// perfilID
        {
            List<BE.Seguridad.Operacion> listaoperaciones1 = new List<BE.Seguridad.Operacion>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();

            //si viene parametro NombrePerfil
            if (  mpu.PerfilUsuarioID.ToString() == "" && mpu.NombrePerfil != null)
            {
                string sql = " Select op.Descripcion from perfiloperacion po inner join" +
                 " operacion op on op.OperacionID = po.Operacionid " +
                 " where PerfilUsuarioID = (select PerfilUsuarioID from PerfilUsuario" +
                 " where NombrePerfil like '%" + mpu.NombrePerfil + "%');";
                dt = con.Ejecutarreader(sql);
            }
            //si viene parametro PerfilID
            else if (mpu.PerfilUsuarioID.ToString() != "")
                    {
                string sql1 = "Select op.Descripcion from perfiloperacion po inner join " +
                " operacion op on op.OperacionID = po.Operacionid " +
                " where PerfilUsuarioID = " + mpu.PerfilUsuarioID;
                dt = con.Ejecutarreader(sql1);
            }
            
           
            BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                   listaoperaciones1.Add(op);
                }

            }

            return listaoperaciones1;
        }
        

        public BE.Seguridad.PerfilUsuario AsignarUsuarioaPerfil(BE.Seguridad.PerfilUsuario mpu, BE.Usuario usu) //  nombreperfil,   nombreUsuario
        {
            
           string sql = "  Delete usuariofamilia where UsuarioID = ( "+
                        "  select UsuarioID from usuario where usuario like '%"+usu._Usuario+ "%');" +
                        "  insert into usuariofamilia(PerfilID, UsuarioID, Actual) "+
                        "  select PerfilUsuarioID, UsuarioID,1 as Actual  from usuario, PerfilUsuario " +
                        "  where PerfilUsuarioID in (select PerfilUsuarioID from PerfilUsuario where NombrePerfil like '%"+mpu.NombrePerfil+"%') "+
                        "  and usuarioID in (select UsuarioID from usuario where usuario like '%"+ usu._Usuario + "%') ; ";
            try
            {
                con.Conectar();
                con.Ejecutar(sql);
                dv.RecalcularDVH();
                mpu.Result = "0";
                return mpu;
            }
            catch (Exception )
            {
                mpu.Result = "1";
                return mpu;
            }
            

        }

        public void AsignarOperacionesalPerfil(BE.Seguridad.PerfilUsuario mpu, List<BE.Seguridad.Operacion> listaoperacionesperfil)
        {
           
          string primersql = "delete perfiloperacion where PerfilUsuarioID = " + mpu.PerfilUsuarioID;
            con.Ejecutar(primersql);
            con.Desconectar();

            con.Conectar();

            string sql;
            foreach (BE.Seguridad.Operacion item in listaoperacionesperfil)
            {
                 
                sql = "INSERT INTO perfiloperacion (OperacionID,PerfilUsuarioID)"+
                      " SELECT OperacionID, "+mpu.PerfilUsuarioID+" "+
                      " FROM OPERACION op"+
                      " WHERE op.Descripcion like '"+ item.NombreOperacion.ToString()+"';"; 

                con.Ejecutar(sql);
                dv.RecalcularDVH();
            }
            con.Desconectar();


        }
        public void AsignarOperacionesalPerfil(BE.Usuario usu, List<BE.Seguridad.Operacion> listaoperacionesperfil)
        {
            //1er sql
            string primersql = " delete usuariooperacion where usuarioid = (select Usuarioid " +
                                " from usuario where Usuario like '"+usu._Usuario +"'); ";
            con.Ejecutar(primersql);
            con.Desconectar();

            con.Conectar();

            string sql;
            foreach (BE.Seguridad.Operacion item in listaoperacionesperfil)
            {
                sql = " INSERT INTO usuariooperacion (UsuarioID,OperacionID,Habilitado)" +
                      " SELECT usu.UsuarioID,op.OperacionID,'S' as Habilitado"+
                      " FROM OPERACION op, Usuario usu" +
                      " WHERE op.Descripcion like '"+item.NombreOperacion.ToString() +"'"+
                      " and usu.Usuario like '" + usu._Usuario.ToString() + "';";

                con.Ejecutar(sql);
            }
            dv.RecalcularDVH();
            con.Desconectar();


        }

        public List<BE.Seguridad.PerfilUsuario>  BuscarPerfilUsuarios()
        {
            DataTable dt = new DataTable();

            string sql = "Select PerfilUsuarioID,NombrePerfil,DescPerfil,DVH from perfilusuario";


            List<BE.Seguridad.PerfilUsuario> listaperfiles = new List<BE.Seguridad.PerfilUsuario>();
            BE.Seguridad.PerfilUsuario mpu = new BE.Seguridad.PerfilUsuario();
            con.Conectar();

            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mpu.PerfilUsuarioID =  Convert.ToInt16(dt.Rows[i][0].ToString());
                mpu.NombrePerfil = dt.Rows[i][1].ToString();
                mpu.DescPerfil = dt.Rows[i][2].ToString();
                listaperfiles.Add(mpu);
            }

            con.Desconectar();
            return listaperfiles;


        }
        public BE.Usuario verificarPatentesEscenciales(List<BE.Seguridad.Operacion> operacioneshuerfanas,BE.Usuario NombreUsuario)
        {
            BE.Usuario UsuBE = new BE.Usuario();
           // operacioneshuerfanas = new List<string>();
            foreach (BE.Seguridad.Operacion item in operacioneshuerfanas)
            {
                string verificarusuariosql = " select UsuarioID from usuariooperacion uo " +
                " inner join operacion o on o.OperacionID = uo.OperacionID " +
                "  where o.Descripcion = '"+ item.NombreOperacion.ToString() +"' " +
      "and UsuarioID = (select usuarioid from usuario where Usuario not like '" + NombreUsuario._Usuario +"');";

                DataTable Data = con.Ejecutarreader(verificarusuariosql);

                if (Data.Rows.Count > 0)
                {
                    UsuBE.Result = "True";
                    return UsuBE;
                }

                else
                {
                    foreach (DataRow row in Data.Rows)
                    {
                        UsuBE.Result = UsuBE.Result + "--" + row[0].ToString() + "--";
                    }
                }
               
            }
            return UsuBE;
           

        }


        public BE.Usuario verificarPatentesEscenciales(BE.Usuario usu)
        {
            BE.Usuario usuBE = new BE.Usuario();
            DataTable DT = new DataTable();
            if (usu._Usuario != "" && usu.UsuarioID.ToString() == "")
            {

                string sql = "select Descripcion from operacion where operacionid in" +
" (select distinct OperacionID from usuariooperacion " +
" where UsuarioID = (select usuarioid from usuario where Usuario like '" + usu._Usuario + "')" +
" EXCEPT" +
" select distinct OperacionID from usuariooperacion " +
" WHERE OperacionID IN(select distinct OperacionID from usuariooperacion" +
" where UsuarioID <> (select usuarioid from usuario where Usuario like '" + usu._Usuario + "') " + " ))";
                DT = con.Ejecutarreader(sql);
            }
            else if (usu.UsuarioID.ToString() != "") {

                string sql = "select Descripcion from operacion where operacionid in" +
" (select distinct OperacionID from usuariooperacion " +
" where UsuarioID = " + usu.UsuarioID +
" EXCEPT" +
" select distinct OperacionID from usuariooperacion " +
" WHERE OperacionID IN(select distinct OperacionID from usuariooperacion" +
" where UsuarioID <>" + usu.UsuarioID + " ))";
                DT = con.Ejecutarreader(sql);
            }
           

            if (DT.Rows.Count > 0){
               foreach (DataRow row in DT.Rows){

                    usuBE.Result = usuBE.Result + "--" + row[0].ToString() + "--";
               }
                Console.WriteLine(mpu.Result);
               return usuBE;
                                }
           else{
                usuBE.Result = "True";
               return usuBE;
               }
           

        }

    }
}