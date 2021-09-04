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
    public partial class HacerRestore : Defaultform
    {
        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        ServiceLayer.Sesion usu = ServiceLayer.Sesion.GetInstance();
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        public HacerRestore()
        {
            InitializeComponent();
        }

        private void BtnPath_Click(object sender, EventArgs e)
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

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            BLL.Seguridad.BackRestore Restore = new BLL.Seguridad.BackRestore();
            

            try
            {
                int cantidad = Convert.ToInt16(cmbcantidad.Text);

                if (txtPath.Text == "")
                {
                    MessageBox.Show("Por favor ingrese una ruta correcta", "Ruta incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
                }
                else if (cmbcantidad.Text =="")
                {
                    MessageBox.Show("Ingrese la cantidad correcta", "cantidad en 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }         
                else
                {
                   string rta1 = Restore.RealizarRestore(cantidad);

                    MessageBox.Show(rta1, "Proceso Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.NombreOperacion = cryp.Encriptar("Restore");
                    log.Descripcion = cryp.Encriptar("Restore realizado con Exito!");
                    log.Criticidad = 1;
                    
                    string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad,1);
                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HacerRestore_Load(object sender, EventArgs e)
        {

        }
    }
}
