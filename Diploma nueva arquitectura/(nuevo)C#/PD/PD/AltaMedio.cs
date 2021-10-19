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
    public partial class AltaMedio : Defaultform
    {

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public AltaMedio()
        {
            InitializeComponent();
        }

        private void BtnAltaMedio_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMedio.Text == "" || txtMedio.Text == " " )
                {
                    MessageBox.Show("Por favor asigne un nombre al medio", "Nombre de Medio sin Asignar", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else if (cmbIva.Text == "" || cmbIva.Text == " ")
                {
                    MessageBox.Show("Por favor asigne un valor al Iva", "Iva sin Asignar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    BE.Medio MedioBE = new BE.Medio();
                    MedioBE.Medionombre = txtMedio.Text;
                    MedioBE.Descripcion = txtdesc.Text;
                    MedioBE.Iva =Convert.ToDecimal(cmbIva.Text);


                    BLL.MedioBLL medio = new BLL.MedioBLL();
                    medio.DarAlta(medionombre, descripcion, iva);

                    MessageBox.Show("Se dió de alta el medio satisfactoriamente", "Alta de Medio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtdesc.Text = "";
                    txtMedio.Text = "";


                }
                
                     
            }
            catch (Exception exc)
            {
      MessageBox.Show(exc.Message, "Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void AltaMedio_Load(object sender, EventArgs e)
        {
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
