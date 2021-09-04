using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD
{
    public partial class LogOut : Defaultform
    {
        ServiceLayer.Sesion usu = ServiceLayer.Sesion.GetInstance();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
        public LogOut()
        {
            InitializeComponent();
        }

        private void LogOut_Load(object sender, EventArgs e)
        {

            BLL.IdiomaBLL idi = new BLL.IdiomaBLL();
            string idiom = idi.CargarIdioma();

            switch (idiom)
            {
                case "Español":

                    

                    lblConfirm.Text = Idioma.Espanol.lblConfirm.ToString();
                    btn_cancelar.Text = Idioma.Espanol.btn_cancelar.ToString();
                    btn_salir.Text = Idioma.Espanol.btn_salir.ToString();

                    break;

                case "Ingles":

                    lblConfirm.Text = Idioma.Ingles.lblConfirm.ToString();
                    btn_cancelar.Text = Idioma.Ingles.btn_cancelar.ToString();
                    btn_salir.Text = Idioma.Ingles.btn_salir.ToString();

                    break;

                default:
                    break;

            }
        }


        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            
            log.NombreOperacion = cryp.Encriptar("LogOut");
            log.Descripcion = cryp.Encriptar("LogOut Usuario " + usu.UsuarioID + " ");
            log.Criticidad = 4;
            log.Usuarioid = usu.UsuarioID;
            string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);
       


            Environment.Exit(1);

            }
        }
    }

