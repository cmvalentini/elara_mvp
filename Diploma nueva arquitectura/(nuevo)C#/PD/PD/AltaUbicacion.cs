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
        
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;
        BE.Seguridad.Bitacora LogBE = new BE.Seguridad.Bitacora(); 
        
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
            List<BE.Medio> listamedios = new List<BE.Medio>();
            listamedios = ubi.TraerMedios();

            foreach (BE.Medio row in listamedios)
            {
                cmbmedio.Items.Add(row.Medionombre.ToString());
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
                    BE.Ubicacion ubiBE = new BE.Ubicacion();
                    ubiBE.Formato = txtformato.Text;
                    ubiBE.Formula = txtformula.Text;
                    ubiBE.medio.Medionombre = cmbmedio.Text;
                    ubiBE.Medida = txtmedida.Text;
                    ubiBE.NombreUbicacion = txtnombreubicacion.Text;
                    ubiBE.Precio = Convert.ToDecimal(txtprecio.Text);

                    if (chkhabilitado.Checked == true)
                    {
                        ubiBE.Habilitado = 1;
                    }
                    else
                    {
                        ubiBE.Habilitado = 0;
                    }


                    ubiBE =  ubi.daraltaubicacion(ubiBE);

                   
                    MessageBox.Show("Se creo La ubicación exitosamente", "Creacion de Ubicación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LogBE.Criticidad = 2;
                    LogBE.Descripcion = txtnombreubicacion.Text + " " + txtformato.Text;
                    LogBE.FechayHora = DateTime.Now;
                    LogBE.NombreOperacion = "Alta Ubicación";
                    log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, mp.Usuarioid);

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
