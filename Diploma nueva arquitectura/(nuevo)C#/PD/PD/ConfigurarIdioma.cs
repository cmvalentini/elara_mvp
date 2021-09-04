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
    public partial class ConfigurarIdioma : Defaultform
    {


        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public ConfigurarIdioma()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {

            BLL.IdiomaBLL idioma = new BLL.IdiomaBLL();
            BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
            BLL.Bitacora log = new BLL.Bitacora();

            try
            {


                DialogResult dialogResult = MessageBox.Show("Usted está a punto de cambiar el idioma ,Confirmar Operacion", "Cambio de Idioma", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    if (cmbIdioma.Text == "Español")
                    {
                        idioma.IdiomaID = 1;
                        idioma.Descripcion = idioma.SetearIdioma(idioma.IdiomaID);
                    }
                    if (cmbIdioma.Text == "Ingles")
                    {
                        idioma.IdiomaID = 2;
                        idioma.Descripcion = idioma.SetearIdioma(idioma.IdiomaID);
                    }
                    MessageBox.Show("Se Cambió el idioma satisfactoriamente, por favor reinicie sesion para visualizar los cambios");


                    this.Close();
                  }

                else if (dialogResult == DialogResult.No)
                {
                    //do something else

                }
               

               
            }
            catch (Exception )
            {
                
                throw;
            }

                     


        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarIdioma_Load(object sender, EventArgs e)
        {

        }
    }
}
