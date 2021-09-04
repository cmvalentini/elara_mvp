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
    public partial class Asignacion_de_Patentes : Defaultform
    {

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }
        
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();


        public Asignacion_de_Patentes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Asignacion_de_Patentes_Load(object sender, EventArgs e)
        {

            DataTable datausuario = new DataTable();
            datausuario = log.traerUsuarios();
 
            foreach (DataRow item in datausuario.Rows)
            {
                cmbUsuario.Items.Add(item[0].ToString());
            }




        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsuario.Text != "") {
                    string usuario = cmbUsuario.Text;
                    AsignarOperacionesaUsuario AOU = new AsignarOperacionesaUsuario(usuario);
                    AOU.Show();

                }
                else{
                MessageBox.Show("Seleccione un usuario", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

             }
              catch (Exception){
                      throw;
                             }
         }


    }//end class
}
