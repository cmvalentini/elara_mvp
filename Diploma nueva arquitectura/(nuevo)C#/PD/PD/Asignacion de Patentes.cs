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
        
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
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

            List<BE.Usuario> listausuarios = new List<BE.Usuario>();
            listausuarios = log.traerUsuarios();
 
            foreach (BE.Usuario item in listausuarios)
            {
                cmbUsuario.Items.Add(item._Usuario);
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
              catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
         }


    } 
}
