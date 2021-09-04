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
        DataTable listu = new DataTable();
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
        MenuPrincipal mp = MenuPrincipal.Instance;


        
        int Ubicacionid;
        public ModificarUbicacion(int ubicacionid)
        {
            InitializeComponent();
            Ubicacionid = ubicacionid;
        }

        private void ModificarUbicacion_Load(object sender, EventArgs e)
        {
            //cargar combobox
            listu = ubi.TraerMedios();

            foreach (DataRow row in listu.Rows)
            {
                cmbmedio.Items.Add(row[0].ToString());
            }


            ubi = ubi.seliccionarUbicacion(Ubicacionid);

            txtformato.Text = ubi.Formato;
            txtformula.Text = ubi.Formula;
            txtmedida.Text = ubi.Medida;
            txtnombreubicacion.Text = ubi.NombreUbicacion;
            //cmbmedio.Text = ubi.medio;
            chkhabilitado.Checked = Convert.ToBoolean(ubi.Habilitado);
            txtPrecio.Text = ubi.Precio.ToString();
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
                    ubi.Formato = txtformato.Text;
                    ubi.Formula = txtformula.Text;
                    ubi.medio = cmbmedio.Text;
                    ubi.Medida = txtmedida.Text;
                    ubi.NombreUbicacion = txtnombreubicacion.Text;
                    ubi.Ubicacionid = Ubicacionid.ToString();
                    ubi.Precio = Convert.ToDecimal(txtPrecio.Text);

                    if (chkhabilitado.Checked == true)
                    {
                        ubi.Habilitado = 1;
                    }
                    else
                    {
                        ubi.Habilitado = 0;
                    }


                    string result = ubi.Modificarubicacion(ubi);


                    MessageBox.Show("Se Modificó La ubicación exitosamente", "Modificación de Ubicación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.Criticidad = 2;
                    log.Descripcion = txtnombreubicacion.Text + " " + txtformato.Text;
                    log.FechayHora = DateTime.Now;
                    log.NombreOperacion = "Modificacion Ubicación";
                    log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, mp.Usuarioid);


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
