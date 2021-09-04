using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DAL
{
    public class DigitosVerificadores
    {

        EncriptacionDAL cryp = new EncriptacionDAL();
        Conexion con = new Conexion();
        DataTable dtusuarios = new DataTable();
        DataTable dtusuariooperacion = new DataTable();
        DataTable dtbitacora = new DataTable();
        DataTable dtperfil = new DataTable();
        DataTable dtoperacion = new DataTable();

        long totdvhusuario = 0;
        long totdvhusuariooperacion = 0;
        long totdvhBitacora = 0;
        long totdvhPerfilUsuario = 0;
        long totdvhOPERACION = 0;

        public string VerificarDV()
        {

            try
            {
                DataTable dt = new DataTable();
                string dvusuario = "select dvh from usuario";
                string dvvusuario = "select dvv from dvv where tabla like 'Usuario'";
                string dvusuariooperacion= "select dvh from usuariooperacion";
                string dvvusuariooperacion= "select dvv from dvv where tabla like 'usuariooperacion'";
                string dvbitacora= "select dvh from Bitacora";
                string dvvbitacora = "select dvv from dvv where tabla like 'bitacora'"; ;
                string dvperfil = "select dvh from PerfilUsuario"; 
                string dvvperfil = "select dvv from dvv where tabla like 'PerfilUsuario'";
                string dvoperacion = "select dvh from Operacion"; ;
                string dvvoperacion = "select dvv from dvv where tabla like 'Operacion'";

                dtusuarios = con.Ejecutarreader(dvusuario);
                totdvhusuario = sumardvh(dtusuarios);
                string totdvvusuariocryp = con.VerificarDatoTabla(dvvusuario);
                long totdvvusuario = Convert.ToInt32(cryp.Desencriptar(totdvvusuariocryp));

                dtusuariooperacion = con.Ejecutarreader(dvusuariooperacion);
                totdvhusuariooperacion = sumardvh(dtusuariooperacion);
                string totdvvusuariooperacioncryp = con.VerificarDatoTabla(dvvusuariooperacion);
                long totdvvusuariooperacion = Convert.ToInt32(cryp.Desencriptar(totdvvusuariooperacioncryp));

                dtbitacora = con.Ejecutarreader(dvbitacora);
                totdvhBitacora = sumardvh(dtbitacora);
                string totdvvbitacoracryp = con.VerificarDatoTabla(dvvbitacora);
                long totdvvbitacora = Convert.ToInt32(cryp.Desencriptar(totdvvbitacoracryp));

                dtperfil = con.Ejecutarreader(dvperfil);
                totdvhPerfilUsuario = sumardvh(dtperfil);
                string totdvvperfilusuariocryp = con.VerificarDatoTabla(dvvperfil);
                long totdvvperfilusuario = Convert.ToInt32(cryp.Desencriptar(totdvvperfilusuariocryp));

                dtoperacion = con.Ejecutarreader(dvoperacion);
                totdvhOPERACION = sumardvh(dtoperacion);
                string totdvvoperacioncryp = con.VerificarDatoTabla(dvvoperacion);
                long totdvvoperacion = Convert.ToInt32(cryp.Desencriptar(totdvvoperacioncryp));

               if (totdvhusuario == totdvvusuario){
                    
                }
                else {
                    return "Falló Calculo de DV en los registros de USUARIO,la base esta corrupta, contacte al administrador";
                }
                if (totdvhusuariooperacion == totdvvusuariooperacion){

                }
                else
                {
                    return "Falló Calculo de DV en los registros de PATENTE-USUARIO,la base esta corrupta, contacte al administrador";
                }
                if (totdvhBitacora == totdvvbitacora)
                {

                }
                else
                {
                    return "Falló Calculo de DV en los registros de BITACORA,la base esta corrupta, contacte al administrador";
                }
                if (totdvhPerfilUsuario == totdvvperfilusuario)
                {

                }
                else
                {
                    return "Falló Calculo de DV en los registros de ROLES DE USUARIO,la base esta corrupta, contacte al administrador";
                }
                if (totdvhOPERACION == totdvvoperacion)
                {

                }
                else
                {
                    return "Falló Calculo de DV en los registros de Patentes,la base esta corrupta, contacte al administrador";
                }


                 totdvhusuario = 0;
                 totdvhusuariooperacion = 0;
                 totdvhBitacora = 0;
                 totdvhPerfilUsuario = 0;
                 totdvhOPERACION = 0;
                 dtusuarios.Clear();
                 dtusuariooperacion.Clear();
                 dtbitacora.Clear();
                 dtperfil.Clear();
                 dtoperacion.Clear();

                
                return "Dígitos calculados correctamente!";

            }

            catch (Exception ex)
            {
                return "Hubo con problema con los Dígitos Verificadores : " + ex.Message;


            }


        }

        private long sumardvh(DataTable dt1){

            long tot = 0;

            try {
                foreach (DataRow item in dt1.Rows){

                    string desencriptardvh = cryp.Desencriptar(item[0].ToString());
                    tot += Convert.ToInt64(desencriptardvh);

                }

                return tot;
            }
            catch (Exception)
            {
                return -2;
            }
        }




        public string RecalcularDVH()
        {
            try
            {
                Thread tdv = new Thread(new ThreadStart(RecalcularDVHprocess));
                tdv.Start();


                return "Recalculando Dìgitos, siga utilizando el sistema normalmente, en caso de error, sera notificado";


            }

            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        private void RecalcularDVHprocess()
        {

            con.Conectar();
            //usuarios
            string sql = "select Usuarioid,Usuario,Clave from usuario";
            dtusuarios = con.Ejecutarreader(sql);

            string sqlusuop = " select UsuarioID,OperacionID,Habilitado from usuariooperacion";
            dtusuariooperacion = con.Ejecutarreader(sqlusuop);

            string sqlbitacora = " select BitacoraID,UsuarioID,FechayHora from bitacora";
            dtbitacora = con.Ejecutarreader(sqlbitacora);

            string sqlperfil = "  select PerfilUsuarioID,NombrePerfil,DescPerfil from PerfilUsuario";
            dtperfil = con.Ejecutarreader(sqlperfil);


            string sqloperacion = "  select OperacionID,Descripcion,PatenteEscencial from Operacion";
            dtoperacion = con.Ejecutarreader(sqloperacion);

            //ACTUALIZO DVH

            foreach (DataRow item in dtoperacion.Rows)
            {
                string concat = item[0].ToString() + item[1].ToString() + item[2].ToString();

                int flag = recalculartabladvh(concat);
                totdvhOPERACION += flag;
                string crypflag = cryp.Encriptar(flag.ToString());


                string sqlop1 = "update operacion set dvh = '" + crypflag + "' where OperacionID = " + item[0].ToString() + " ;";

                con.Ejecutar(sqlop1);
            }

            foreach (DataRow item in dtusuarios.Rows)
            {
                string concat = item[0].ToString() + item[1].ToString() + item[2].ToString();

                int flag = recalculartabladvh(concat);
                totdvhusuario += flag;
                string crypflag = cryp.Encriptar(flag.ToString());

                string sql2 = "update usuario set dvh = '" + crypflag + "' where usuarioid= " + item[0].ToString() + " ;";

                con.Ejecutar(sql2);
            }
            int a = 0;
            foreach (DataRow item in dtusuariooperacion.Rows)
            {
                string concat = item[0].ToString() + item[1].ToString() + item[2].ToString();

                int flag = recalculartabladvh(concat);
                totdvhusuariooperacion += flag;
                string crypflag = cryp.Encriptar(flag.ToString());
                
                int tot = 0;
                Console.WriteLine(a);
                string sqluo = "update usuariooperacion set dvh = '" + crypflag + "' where usuarioid = " + item[0].ToString() + " " +
                    " and OperacionID = " + item[1].ToString() + ";";

                con.Ejecutar(sqluo);
                tot = a++;
            }

            foreach (DataRow item in dtbitacora.Rows)
            {
                string concat = item[0].ToString() + item[1].ToString() + item[2].ToString();

                int flag = recalculartabladvh(concat);
                totdvhBitacora += flag;
                string crypflag = cryp.Encriptar(flag.ToString());

                string sqlbit = "update bitacora set dvh = '" + crypflag + "' where BitacoraID = " + item[0].ToString() + " " +
                    " and UsuarioID = " + item[1].ToString() + ";";

                con.Ejecutar(sqlbit);
            }

            foreach (DataRow item in dtperfil.Rows)
            {
                string concat = item[0].ToString() + item[1].ToString() + item[2].ToString();

                int flag = recalculartabladvh(concat);
                totdvhPerfilUsuario += flag;
                string crypflag = cryp.Encriptar(flag.ToString());

                string sqlperfil1 = "update PerfilUsuario set dvh = '" + crypflag + "' where PerfilUsuarioID = " + item[0].ToString() + " " +
                    " and NombrePerfil like '" + item[1].ToString() + "';";

                con.Ejecutar(sqlperfil1);
            }


            // actualizo DVV
            string crypusu = cryp.Encriptar(totdvhusuario.ToString());
            string crypusuop = cryp.Encriptar(totdvhusuariooperacion.ToString());
            string crypbita = cryp.Encriptar(totdvhBitacora.ToString());
            string crypperfilusu = cryp.Encriptar(totdvhPerfilUsuario.ToString());
            string crypopo = cryp.Encriptar(totdvhOPERACION.ToString());

            String sql3 = " update dvv set dvv = '" + crypusu + "' " +
                " where tabla like 'Usuario'";
            dtusuarios.Rows.Clear();
            dtusuarios = con.Ejecutarreader(sql3);

            String sqlusuarioop = " update dvv set dvv = '" + crypusuop + "' " +
           " where tabla like 'usuariooperacion'";
            dtusuarios.Rows.Clear();
            dtusuarios = con.Ejecutarreader(sqlusuarioop);

            String sqlbita = " update dvv set dvv = '" + crypbita + "' " +
          " where tabla like 'bitacora'";
            dtusuarios.Rows.Clear();
            dtusuarios = con.Ejecutarreader(sqlbita);

            String sqlperfil2 = " update dvv set dvv = '" + crypperfilusu + "' " +
            " where tabla like 'PerfilUsuario'";
            dtusuarios.Rows.Clear();
            dtusuarios = con.Ejecutarreader(sqlperfil2);

            String sqloperaciones = " update dvv set dvv = '" + crypopo + "' " +
        " where tabla like 'Operacion'";
            dtusuarios.Rows.Clear();
            dtusuarios = con.Ejecutarreader(sqloperaciones);

            


            totdvhusuario = 0;
            totdvhusuariooperacion = 0;
            totdvhBitacora = 0;
            totdvhPerfilUsuario = 0;
            totdvhOPERACION = 0;
            dtusuarios.Clear();
            dtusuariooperacion.Clear();
            dtbitacora.Clear();
            dtperfil.Clear();
            dtoperacion.Clear();

            con.Desconectar();  


        }


        private int recalculartabladvh(string cadenaRegistro)
        {


            int digitoHorizontal = 0;
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(cadenaRegistro);

            int posicion = 1;
            foreach (byte b in ASCIIValues)
            {
                digitoHorizontal += b * posicion;
                posicion += 1;
            }
            return digitoHorizontal;

        }

    }
}
