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
    public partial class DesbloquearOperacionAUsuariocs : Defaultform
    {
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        List<string> listaoperaciones = new List<string>();
        BLL.Usuario usu = new BLL.Usuario();
        string NombreUsuario = "";
        BLL.ManejadorPerfilUsuario mpu = new BLL.ManejadorPerfilUsuario();

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public DesbloquearOperacionAUsuariocs()
        {
            InitializeComponent();
        }

        private void DesbloquearOperacionAUsuariocs_Load(object sender, EventArgs e)
        {
            //cargar combo de usuarios
            DataTable datausuario = new DataTable();
            datausuario = log.traerUsuarios();


            foreach (DataRow item in datausuario.Rows)
            {
                cmbUsuario.Items.Add(item[0].ToString());
            }

            


        }

        private void cmbUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            //lleno el CheckedListBox con las operaciones
            
            NombreUsuario = cmbUsuario.Text;
            chklistOperaciones.Items.Clear();
            listaoperaciones = usu.MostrarOperacionesBloqueadas(NombreUsuario);

            foreach (string item in listaoperaciones)
            {
                chklistOperaciones.Items.Add(item.ToString());

            }
            chklistOperaciones.DisplayMember = "Descripcion";
            chklistOperaciones.ValueMember = "Descripcion";


        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            NombreUsuario = cmbUsuario.Text;
            try
            {

                if (cmbUsuario.Text == "")
                {
                    MessageBox.Show("Asigne a un Usuario!");
                }
                else
                {
                    if (chklistOperaciones.CheckedItems.Count > 0)
                    {
                        foreach (string item in chklistOperaciones.CheckedItems)
                        {

                            string patente = item.ToString();

                            mpu.DesbloqueaOperacionaUsuario(NombreUsuario, patente);
                           
                 
                        }

                        MessageBox.Show("Ejecución Finalizada", "Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Complete los Campos!", "Ejecución Fallida", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
