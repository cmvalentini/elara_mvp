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
    public partial class Alta_Cliente : Defaultform
    {
        BLL.ClienteBLL cli = new BLL.ClienteBLL();
        string result;
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
       ServiceLayer.Sesion usulog = ServiceLayer.Sesion.GetInstance();
        public Alta_Cliente()
        {
            InitializeComponent();
        }

        private void Btn_Alta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRazonSocial.Text == "" || txtRazonSocial.Text == " " || txttelefono.Text == "" || txtdomicilio.Text == "" || txtdomicilio.Text == " " || cmbCondicionFiscal.Text == " " || cmbCondicionFiscal.Text == "")
                {
                    MessageBox.Show("Por favor, Complete los campos", "Campos sin completar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    cli.Condicion_fiscal = cmbCondicionFiscal.Text;
                    cli.Domicilio = txtdomicilio.Text;
                    cli.razon_social = txtRazonSocial.Text;
                    cli.telefono = txttelefono.Text;

                    if (chkhabilitado.Checked)
                    {
                        cli.Habilitado = 1;
                    }
                    else
                    {
                        cli.Habilitado = 0;
                    }

                    cli.daraltacliente(cli);

                    MessageBox.Show("Alta de cliente Exitosa ", "Alta de Cliente OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.NombreOperacion = cryp.Encriptar("Alta Cliente");
                    log.Descripcion = cryp.Encriptar("Alta de " + txtRazonSocial.Text + " realizada con Exito!");
                    log.Criticidad = 1;

                    string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, usulog.UsuarioID);




                    txtdomicilio.Text = "";
                    txtRazonSocial.Text = "";
                    txttelefono.Text = "";


                }


               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.Message.ToString(), "Error,contacte al administrador", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }




        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alta_Cliente_Load(object sender, EventArgs e)
        {

        }
    }
}
