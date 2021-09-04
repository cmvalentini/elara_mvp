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
    public partial class HacerBackUp : Defaultform
    {
        ServiceLayer.Sesion usu = ServiceLayer.Sesion.GetInstance();
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();

        public HacerBackUp()
        {
            InitializeComponent();
        }

        private void HacerBackUp_Load(object sender, EventArgs e)
        {

        }

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BLL.Seguridad.BackRestore backup = new BLL.Seguridad.BackRestore();
            
            try
            {
                if (txtPath.Text == "")
                {
                   
                    MessageBox.Show("Por favor ingrese una ruta correcta", "Ruta incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmbCantidad.Text == "")
                {
                    MessageBox.Show("Ingrese la cantidad correcta", "cantidad en 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                else
                {
                    int cantidad = Convert.ToInt16(cmbCantidad.Text);
                    backup.RealizarBackUp(txtPath.Text,cantidad);
                    MessageBox.Show("Back Up realizado con Exito!");


                }

            }
            catch (Exception)
            {

                throw;
            }
            finally {
                log.NombreOperacion = cryp.Encriptar("BackUp");
                log.Descripcion = cryp.Encriptar("Back Up realizado con Exito!");
                log.Criticidad = 2;
                log.Usuarioid = usu.UsuarioID;
                string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, log.Usuarioid);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    txtPath.Text = path;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
