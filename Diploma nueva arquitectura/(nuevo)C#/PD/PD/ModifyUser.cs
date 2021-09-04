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
    public partial class ModifyUser : Defaultform
    {
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Usuario usu = new BLL.Usuario();
        BLL.Bitacora log = new BLL.Bitacora();

        public string Dato { get; set; }



        public ModifyUser()
        {
            InitializeComponent();
        }

        public ModifyUser(string dato)
        {
            InitializeComponent();
            Dato = dato;
        }




        private void ModifyUser_Load(object sender, EventArgs e)
        {
            

            usu = usu.TraerDatosUsuariobyID(Convert.ToInt16(Dato));

            txtname.Text = usu.Nombre.ToString();
            txtdni.Text = usu.Dni.ToString();
            txtemail.Text = usu.Email.ToString();
            txtlastname.Text = usu.Apellido.ToString();
            txtuser.Text = usu._Usuario.ToString();

            if (usu.Habilitado.ToString() == "true")
            {
                checkHabilitado.Checked = true;
            }
            else
            {
                checkHabilitado.Checked = false;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ABMUsuarios mu = new ABMUsuarios();

            mu.cargar();
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int oresult = usu.verificarDuplicidad(int.Parse(txtdni.Text), txtemail.Text,txtuser.Text, Convert.ToInt16(Dato));
             
            switch (oresult)
            {       
                case 1://dni repetido
                    MessageBox.Show("el dni: " + txtdni.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                    break;
                case 2://email repetido
                    MessageBox.Show("el email: " + txtemail.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    break;
                case 3://email y dni repetido
                    MessageBox.Show("el email: " + txtemail.Text + " y el dni:" + txtdni.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    break;
                case 5://Usuario repetido
                    MessageBox.Show("el Usuario: " + txtuser.Text + " !", "Duplicidad de datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    break;
                case 4: //modifica*/
                    try
                    {
                        bool check;
                        if (checkHabilitado.Checked)
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                        }
                        string result = usu.ModificarDatosUsuario(txtuser.Text, txtlastname.Text, txtname.Text, txtemail.Text,
                                    Convert.ToInt64(txtdni.Text), check, usu.UsuarioID);

                        MessageBox.Show(result);

                        log.Criticidad = 3;
                        log.Descripcion = txtuser.Text + " " + txtlastname.Text + " " + txtname.Text + " " + txtemail.Text + " "
                        + txtdni.Text + " " + check + " " + usu.UsuarioID;
                        log.FechayHora = DateTime.Now;
                        log.NombreOperacion = "Modificar Usuario";

                        log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, usu.UsuarioID);

                        ABMUsuarios abmusu = new ABMUsuarios();
                        abmusu.Load += new EventHandler(abmusu.ABMUsuarios_Load);

                        this.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;


            }
        }

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
