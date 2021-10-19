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
    public partial class ModificarUbicacion : Defaultform
    {
         
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;
        BE.Seguridad.Bitacora logBE = new BE.Seguridad.Bitacora();
        BE.Ubicacion Ubibe = new BE.Ubicacion();
        List<BE.Ubicacion> listaubi = new List<BE.Ubicacion>(); 
       
        public ModificarUbicacion(BE.Ubicacion UbiBE)
        {
            InitializeComponent();
            Ubibe = UbiBE;
        }

        private void ModificarUbicacion_Load(object sender, EventArgs e)
        {
            //cargar combobox
            listaubi = ubi.TraerMedios();

            foreach (BE.Ubicacion row in listaubi)
            {
                cmbmedio.Items.Add(row.medio);
            }


            Ubibe = ubi.seliccionarUbicacion(Ubibe);

            txtformato.Text = Ubibe.Formato;
            txtformula.Text = Ubibe.Formula;
            txtmedida.Text = Ubibe.Medida;
            txtnombreubicacion.Text = Ubibe.NombreUbicacion;
            //cmbmedio.Text = ubi.medio;
            chkhabilitado.Checked = Convert.ToBoolean(Ubibe.Habilitado);
            txtPrecio.Text = Ubibe.Precio.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_acept_Click(object sender, EventArgs e)
        {
            try
            {
                //no entra
                if ((txtnombreubicacion.Text == "") || (txtformato.Text == "") || (cmbmedio.Text == ""))//no entra

                {
                    MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else //entra
                {
                    Ubibe.Formato = txtformato.Text;
                    Ubibe.Formula = txtformula.Text;
                    Ubibe.medio = cmbmedio.Text;
                    Ubibe.Medida = txtmedida.Text;
                    Ubibe.NombreUbicacion = txtnombreubicacion.Text;
                    Ubibe.Ubicacionid = Ubibe.Ubicacionid;
                    Ubibe.Precio = Convert.ToDecimal(txtPrecio.Text);

                    if (chkhabilitado.Checked == true)
                    {
                        Ubibe.Habilitado = 1;
                    }
                    else
                    {
                        Ubibe.Habilitado = 0;
                    }


                    Ubibe.Result = ubi.Modificarubicacion(Ubibe);


                    MessageBox.Show("Se Modificó La ubicación exitosamente", "Modificación de Ubicación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    logBE.Criticidad = 2;
                    logBE.Descripcion = txtnombreubicacion.Text + " " + txtformato.Text;
                    logBE.FechayHora = DateTime.Now;
                    logBE.NombreOperacion = "Modificacion Ubicación";
                    log.IngresarDatoBitacora(cryp.Encriptar(logBE.NombreOperacion).ToString(), cryp.Encriptar(logBE.Descripcion).ToString(), logBE.Criticidad, mp.Usuarioid);


                    txtformato.Text = "";
                    txtformula.Text = "";
                    txtmedida.Text = "";
                    txtnombreubicacion.Text = "";
                    txtPrecio.Text = "";
                 

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error ,contacte con el administrador del sistema \n" + ex.Message, "Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }




        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
