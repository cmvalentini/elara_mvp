using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Threading;
using PD.Properties;

namespace PD
{
    public partial class LogIn : Defaultform
    {


        BLL.DigitoVerificador dv = new BLL.DigitoVerificador();
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        string var1 = "";
        BLL.IdiomaBLL Oidioma = new BLL.IdiomaBLL();

        public LogIn()
        {
            InitializeComponent();

        }


        private void CheckCambiarClave_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCambiarClave.Checked)
            {
                this.Size = new Size(458, 491);
            }

            else { this.Size = new Size(441, 304); }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);

        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
           
            if (txtClave.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor, complete los campos", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var1 = cryp.Encriptar(txtClave.Text);

        
            try
            {
                BLL.Usuario USU1 = new BLL.Usuario();
                USU1.TraerDatosUsuario(txtUsuario.Text, var1); //trae usuario y clave

                ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();

                if (sesion.FlagIntentosLogin >= 3)
                {
                    MessageBox.Show("El Usuario se encuentra Bloquedao");


                }
                else
                {

                    if (sesion.nombreusuario == null)
                    {
                        
                        USU1.BuscarUsuario(txtUsuario.Text);
                        

                        if (USU1.nombreusuario == null)
                        {

                            MessageBox.Show("Usuario no Encontrado:Error 104", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            log.NombreOperacion = cryp.Encriptar("Login");
                            log.Descripcion = cryp.Encriptar("Login Usuario no encontrado" + txtUsuario.Text + " ");
                            log.Criticidad = 4;
                            log.Usuarioid = 0;
                            string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);

                        }
                        else
                        {
                            switch (USU1.nombreusuario.ToString())
                            {
                                case "null":
                                    MessageBox.Show("Usuario no Encontrado:Error 105", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                case "":
                                    MessageBox.Show("Complete el campo usuario por favor", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    log.NombreOperacion = cryp.Encriptar("Login");
                                    log.Descripcion = cryp.Encriptar("Login Usuario no encontrado" + txtUsuario.Text + " ");
                                    log.Criticidad = 4;
                                    log.Usuarioid = 0;
                                    string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);

                                    break;

                                default:

                                    MessageBox.Show("Clave incorrecta para usuario ");
                                    if (USU1.FlagIntentosLogin >= 3)
                                    {
                                        //MessageBox.Show("El Usuario se encuentra Bloquedao");
                                        MessageBox.Show("El Usuario se encuentra Bloqueado", "Usuario Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        // ENVIO MAIL CON PASSWORD NUEVA
                                        string clave = cryp.CrearPassword(8);
                                        string claveencriptada = cryp.Encriptar(clave);


                                        USU1.EnviarMail(USU1.UsuarioID, claveencriptada, clave);

                                    }
                                    else
                                    {
                                        log.NombreOperacion = cryp.Encriptar("Login");
                                        log.Descripcion = cryp.Encriptar("Clave incorrecta para usuario" + txtUsuario.Text + " ");
                                        log.Criticidad = 4;
                                        log.Usuarioid = USU1.UsuarioID;
                                        rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);
                                        USU1.SumarFlagIntentos(USU1.UsuarioID);
                                    }
                                    break;
                            }
                        }

                    }
                    else
                     {

                        log.NombreOperacion = cryp.Encriptar("Login");
                        log.Descripcion = cryp.Encriptar("Login Exitoso: " + txtUsuario.Text + " ");
                        log.Criticidad = 5;
                        log.Usuarioid = sesion.UsuarioID;

                        //USUARIO Y CLAVE CORRECTOS
                        string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);
                        MenuPrincipal mp = MenuPrincipal.Instance;

                        mp.Usuarioid = sesion.UsuarioID; //asigno var usuarioid en mp

                        USU1.BlanquearIntentos(sesion.UsuarioID);
                        mp.Show();


                        this.Close();


                    }

                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }






        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor ingrese Usuario en donde lo indica", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BLL.Usuario USU = new BLL.Usuario();

                BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();


                string var1 = cryp.Encriptar(txtClave.Text);
                string var2 = cryp.Encriptar(txtClaveAtn.Text);
                string var3 = cryp.Encriptar(txtClaveNew.Text);
               

                try
                {
                    USU = USU.BuscarUsuario(txtUsuario.Text, var2);

                    if (USU._Usuario != null)
                    {
                        try
                        {
                            string rta = USU.CambiarClave(txtUsuario.Text, var3, USU.UsuarioID);
                            MessageBox.Show("Se cambió la Clave exitosamente  " + rta);

                            log.NombreOperacion = cryp.Encriptar("Cambio de Clave");
                            log.Descripcion = cryp.Encriptar("Cambio Exitoso: " + txtUsuario.Text + " ");
                            log.Criticidad = 3;
                            log.Usuarioid = USU.UsuarioID;

                            log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);

                            txtClaveAtn.Text = "";
                            txtClaveNew.Text = "";
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Hubo un error al cambiar la clave");
                            throw;
                        }


                    }

                    else { MessageBox.Show("La Clave ingresada, no coincide con la anterior"); }



                }
                catch (Exception)
                {

                    throw;
                }



            }




        }

      


        private void LogIn_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            



            //calculo DV
            string resultdv =  dv.CalcularDigitosVerificadores();
            MessageBox.Show("Aguarde mientras revisamos los Dígitos Verificadores", "Dígitos Verificadores", MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

            //revisar esto

            Loader loading = new Loader();
            loading.cargarimgmain();


            if (resultdv == "Dígitos calculados correctamente!")
            {
                MessageBox.Show("Digitos verificadores: " + resultdv, "Digitos Verificadores", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Digitos verificadores: " + resultdv, "Digitos Verificadores", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }



            BLL.IdiomaBLL Observeridi = new BLL.IdiomaBLL();
            Observeridi.Descripcion = Observeridi.CargarIdioma();

               switch (Observeridi.Descripcion.ToString())
                {
                    case "Español":

                        LblUsuario.Text = Idioma.Espanol.LblUsuario.ToString();
                        btnConfirmar.Text = Idioma.Espanol.btnConfirmar.ToString();
                        btnIngresar.Text = Idioma.Espanol.btnIngresar.ToString();
                        btnSalir.Text = Idioma.Espanol.btnSalir.ToString();
                        CheckCambiarClave.Text = Idioma.Espanol.CheckCambiarClave.ToString();
                        LblClave.Text = Idioma.Espanol.LblClave.ToString();
                        LblClaveAnterior.Text = Idioma.Espanol.LblClaveAnterior.ToString();
                        LblClaveNueva.Text = Idioma.Espanol.LblClaveNueva.ToString();

                        break;

                    case "Ingles":

                        LblUsuario.Text = Idioma.Ingles.LblUsuario.ToString();
                        btnConfirmar.Text = Idioma.Ingles.btnConfirmar.ToString();
                        btnIngresar.Text = Idioma.Ingles.btnIngresar.ToString();
                        btnSalir.Text = Idioma.Ingles.btnSalir.ToString();
                        CheckCambiarClave.Text = Idioma.Ingles.CheckCambiarClave.ToString();
                        LblClave.Text = Idioma.Ingles.LblClave.ToString();
                        LblClaveAnterior.Text = Idioma.Ingles.LblClaveAnterior.ToString();
                        LblClaveNueva.Text = Idioma.Ingles.LblClaveNueva.ToString();
                                                
                        break;

                      default:
                        break;

                }







            
        }

        private void txtClaveNew_Validating(object sender, CancelEventArgs e)
        {


            if (txtClaveNew.Text.Length <= 6 && CheckCambiarClave.Checked == true)
            {
                MessageBox.Show("La longitud debe ser mayor a 6 digitos/The length must be greater than 6 digits");
            }

            if (Regex.IsMatch(txtClaveNew.Text,@"[^A-Za-z0-9]"))
            {
              MessageBox.Show("No se permiten caracteres especiales", "ErrorKey", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           }


        }

        private void txtClaveNew_Validated(object sender, EventArgs e)
        {

        }

        private void txtClave_Validating(object sender, CancelEventArgs e)
        {
            

            if (Regex.IsMatch(txtClave.Text, @"[^A-Za-z0-9]"))
            {
                MessageBox.Show("No se permiten caracteres especiales", "ErrorKey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {

            if (Regex.IsMatch(txtUsuario.Text, @"[^A-Za-z0-9]"))
            {
                MessageBox.Show("No se permiten caracteres especiales", "ErrorKey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
