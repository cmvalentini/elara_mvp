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
   
    public partial class DigitosVerificadores : Defaultform
    {

        string rta;
        ServiceLayer.Sesion usu = ServiceLayer.Sesion.GetInstance();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.DigitoVerificador digitos = new BLL.DigitoVerificador();
       

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }
           
        public DigitosVerificadores()
        {
            InitializeComponent();
        }

        private void DigitosVerificadores_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            rta = digitos.RecalcularDVH();
                       

            MessageBox.Show("Digitos verificadores: "+rta.ToString(), "Digitos Verificadores", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnverificar_Click(object sender, EventArgs e)
        {

            try{
                rta = digitos.CalcularDigitosVerificadores();


                if (rta.Substring(0, 5) == "Falló"){
                    MessageBox.Show("Digitos verificadores: " + rta.ToString(), "Digitos Verificadores", MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                                                   }


                else {
                    MessageBox.Show("Digitos verificadores: " + rta.ToString(), "Digitos Verificadores", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                     }




               }
            catch (Exception ex){

                MessageBox.Show("Error al calcular los DV" + ex.Message, "Digitos Verificadores", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);


            }
            

            

            
        }
    }
}
