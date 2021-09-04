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
    public partial class falloDV : Defaultform
    {
        public falloDV()
        {
            InitializeComponent();
        }

        private void falloDV_Load(object sender, EventArgs e)
        {



        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbackup.Checked == true)
                {
                    HacerRestore hr = new HacerRestore();
                    hr.Show();
                }
                else if (rbRecalcularDV.Checked == true)
                {
                    DigitosVerificadores dv = new DigitosVerificadores();
                    dv.Show();

                }
                else if (rdbackup.Checked == true && rbRecalcularDV.Checked == true)
                {
                    MessageBox.Show("Por favor, seleccione uno");
                }
                else
                {

                }




            }
            catch (Exception)
            {

                throw;
            }
           


        }
    }
}
