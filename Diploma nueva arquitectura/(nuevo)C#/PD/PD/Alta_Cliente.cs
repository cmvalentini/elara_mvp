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
        BE.Cliente cliBE = new BE.Cliente();
        string result;
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        BE.Seguridad.Bitacora LogBE = new BE.Seguridad.Bitacora();
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
                    cliBE.Condicion_fiscal = cmbCondicionFiscal.Text;
                    cliBE.Domicilio = txtdomicilio.Text;
                    cliBE.razon_social = txtRazonSocial.Text;
                    cliBE.telefono = txttelefono.Text;

                    if (chkhabilitado.Checked)
                    {
                        cliBE.Habilitado = 1;
                    }
                    else
                    {
                        cliBE.Habilitado = 0;
                    }

                    cli.daraltacliente(cliBE);

                    MessageBox.Show("Alta de cliente Exitosa ", "Alta de Cliente OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LogBE.NombreOperacion = cryp.Encriptar("Alta Cliente").ToString();
                    LogBE.Descripcion = cryp.Encriptar("Alta de " + txtRazonSocial.Text + " realizada con Exito!").ToString();
                    LogBE.Criticidad = 1;

                    log.IngresarDatoBitacora(LogBE.NombreOperacion.ToString(), LogBE.Descripcion.ToString(), Convert.ToInt16(LogBE.Criticidad), usulog.UsuarioID);




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
