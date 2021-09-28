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
    public partial class CrearNegocio : Defaultform
    {
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
        MenuPrincipal mp = MenuPrincipal.Instance;
        ServiceLayer.Sesion usulog = ServiceLayer.Sesion.GetInstance();
        
        DataTable listu = new DataTable();
        DataTable listm = new DataTable();
        DataTable listcli = new DataTable();
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BLL.ClienteBLL agencias = new BLL.ClienteBLL();
        BLL.MedioBLL medio = new BLL.MedioBLL();
        decimal Preciopedido;
        decimal precioubicacion;
        string nombremedio = "";
        string ubicacionmedio = "";
        int impresiones = 0;
        int numeropedido = 0;

        public CrearNegocio()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //cargar Medios
            listm = ubi.TraerMedios();

            foreach (DataRow row in listm.Rows)
            {
                cmbmedio.Items.Add(row[0].ToString());
            }

            //Cargar Agencias
            listcli = agencias.traeragencias();

            foreach (DataRow row in listcli.Rows)
            {
                cmbagencia.Items.Add(row[0].ToString());
            }


            numeropedido =  medio.traernumeropedido() ;

            lblNumeropedido.Text = numeropedido.ToString();
        }


        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbmedio_TextChanged(object sender, EventArgs e)
        {
            cmbubicacion.Items.Clear();
            nombremedio = cmbmedio.Text;
            listu = ubi.TraerUbicaciones(nombremedio);


            foreach (DataRow row in listu.Rows)
            {
                cmbubicacion.Items.Add(row[0].ToString());
            }


        }

        private void btncalcularprecio_Click(object sender, EventArgs e)
        {
            if (txtprints.Text == "" || txtprints.Text == " " || cmbubicacion.Text == " " || cmbubicacion.Text == "" || cmbmedio.Text == "--Sin Asignar--")
            {
                MessageBox.Show("Por favor, Complete los campos", "Campos sin completar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                nombremedio = cmbmedio.Text;
                ubicacionmedio = cmbubicacion.Text;
                impresiones = Convert.ToInt32(txtprints.Text);
                
                precioubicacion = ubi.traerPrecio(nombremedio,ubicacionmedio);

                Preciopedido = precioubicacion * impresiones;

                txtprecio.Text = Preciopedido.ToString();
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

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            DateTime fechainicio = mcpublicacion.SelectionStart;
            DateTime fechafin = mcpublicacion.SelectionEnd;

            BLL.PedidoBLL ped = new BLL.PedidoBLL();

            try
            {
                if (impresiones == 0 || cmbagencia.Text == "" || cmbagencia.Text == " " )
                {
                    MessageBox.Show("Ha ocurrido un error,verifique los datos que ingresa ", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToDecimal(txtprecio.Text) <= 0)
                {
                    MessageBox.Show("No se permiten valores menores a Cero", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    ped.Preciopedido = Preciopedido;
                    ped.Impresiones = impresiones;
                    ped.FechainicioPublicacion = fechainicio;
                    ped.FechafinPublicacion = fechafin;
                    ped.Descripcion = txtdescripcion.Text;
                    ubi.NombreUbicacion = cmbubicacion.Text;
                    medio.Medionombre = cmbmedio.Text;
                    ped.NombreAgencia = cmbagencia.Text;

                    string result = ped.GrabarNegocio(ped, ubi, medio);

                    log.NombreOperacion = cryp.Encriptar("Alta de Pedido");
                    log.Descripcion = cryp.Encriptar("Alta de pedido" + lblNumeropedido.Text + " realizada con Exito!");
                    log.Criticidad = 1;

                    string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, usulog.UsuarioID);

                    MessageBox.Show("Alta de Pedido Exitosa " + lblNumeropedido.Text + "", "Alta de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    numeropedido = medio.traernumeropedido();

                    lblNumeropedido.Text = numeropedido.ToString();
                }




            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha ocurrido un error: "+ex.Message+" ", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }





        }
    }
}
