using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PD
{
    public partial class AltaUbicacion : Defaultform
    {
        DataTable listu = new DataTable();
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
        MenuPrincipal mp = MenuPrincipal.Instance;

        public AltaUbicacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbmedio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AltaUbicacion_Load(object sender, EventArgs e)
        {
            //cargar combobox
            listu = ubi.TraerMedios();

            foreach (DataRow row in listu.Rows)
            {
                cmbmedio.Items.Add(row[0].ToString());
            }
            
             
        }

        private void button1_Click(object sender, EventArgs e)
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
                    ubi.Precio = Convert.ToDecimal(txtprecio.Text);

                    if (chkhabilitado.Checked == true)
                    {
                        ubi.Habilitado = 1;
                    }
                    else
                    {
                        ubi.Habilitado = 0;
                    }


                 string result =  ubi.daraltaubicacion(ubi);

                   
                    MessageBox.Show("Se creo La ubicación exitosamente", "Creacion de Ubicación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.Criticidad = 2;
                    log.Descripcion = txtnombreubicacion.Text + " " + txtformato.Text;
                    log.FechayHora = DateTime.Now;
                    log.NombreOperacion = "Alta Ubicación";
                    log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, mp.Usuarioid);

                    txtformato.Text = "";
                    txtformula.Text = "";
                    txtmedida.Text = "";
                    txtnombreubicacion.Text = "";
                    
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error con la base de datos,contacte con el administrador del sistema \n" + ex.Message, "Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            

        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
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
