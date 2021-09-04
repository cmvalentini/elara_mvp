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
    public partial class ModificarMedio : Defaultform
    {
        BLL.MedioBLL medio = new BLL.MedioBLL();
        private int medioid;
        
        public ModificarMedio()
        {
            InitializeComponent();
        }

        public ModificarMedio(int _medioid)
        {
            InitializeComponent();
            this.medioid = _medioid;
        }

        private void ModificarMedio_Load(object sender, EventArgs e)
        {
         

            medio = medio.seleccionarMedio(medioid);

            txtdesc.Text = medio.Descripcion;
            txtMedio.Text = medio.Medionombre;
            cmbIva.Text = medio.Iva.ToString() ;

            this.Show();
        }

        private void BtnAltaMedio_Click(object sender, EventArgs e)
        {
            try
            {
                medio.Descripcion = txtdesc.Text;
                medio.Medionombre = txtMedio.Text;
                medio.Iva = Convert.ToDecimal(cmbIva.Text);
                medio.medioid = this.medioid;

                medio.modificarmedio(medio);

                MessageBox.Show("Se modificó con exito", "Modificación OK", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ocurrió un problema", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);


            }
           


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
