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
    public partial class BloquearDesbloquearOperacionesaUsuario : Defaultform
    {

        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new  BLL.Seguridad.EncriptacionBLL();
        List<string> listaoperaciones = new List<string>();
        BLL.Usuario usu = new BLL.Usuario();
        string NombreUsuario = "";
        BLL.ManejadorPerfilUsuario mpu = new BLL.ManejadorPerfilUsuario();

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }
        public BloquearDesbloquearOperacionesaUsuario()
        {
            InitializeComponent();
        }

        private void Bloquear_DesbloquearOperacionesaUsuario_Load(object sender, EventArgs e)
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
            listaoperaciones = usu.MostraroperacionUsuario(NombreUsuario);
            
            foreach (string item in listaoperaciones)
            {
                chklistOperaciones.Items.Add(item.ToString());

            }
            chklistOperaciones.DisplayMember = "Descripcion";
            chklistOperaciones.ValueMember = "Descripcion";





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if ((MessageBox.Show("¿Esta seguro que desea bloquearle la operación a "+NombreUsuario+"?", "Bloqueo de Operaciones",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    if (cmbUsuario.Text == "")
                    {
                        MessageBox.Show("Asigne a un Usuario!");
                    }
                    else
                    {

                        foreach (string item in chklistOperaciones.CheckedItems)
                        {

                            //verificar Patentes Unicas
                            string patente = item.ToString();
                            
                            string Eliminar = usu.verificarPatentesBloqueo(NombreUsuario, patente);

                            if (Eliminar == "True")
                            {
                                //se puede bloquear
                                //Bloquear Patentes

                                mpu.BloqueaOperacionUsuario(NombreUsuario,patente);


                            }
                            else
                            {
 
                                MessageBox.Show("Usuario con Patente Unica["+patente+"],no se puede Bloquear!", "No se puede Bloquear", MessageBoxButtons.OK, MessageBoxIcon.Stop);


                            }
                        }

                        MessageBox.Show("Ejecución Finalizada", "Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    }


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

            }






    
         


        }
    }
}
