using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD
{
    public partial class MenuUsuarios : Defaultform
    {
        string clavesinencriptar = "";
        string claveencriptada = "";
        public MenuUsuarios()
        {
            InitializeComponent();
        }

        private void MenuUsuarios_Load(object sender, EventArgs e)
        {
           
        }

        private void OnTextChanged(object sender, EventArgs e)
        {

           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
            BLL.Bitacora log = new BLL.Bitacora();
            ServiceLayer.Sesion usulog = ServiceLayer.Sesion.GetInstance();
            try
            {
                bool _habilitado;
                if (checkHabilitado.Checked)
                {
                    _habilitado = true;
                }
                else { _habilitado = false; }

               

                clavesinencriptar = cryp.CrearPassword(8);
                claveencriptada = cryp.Encriptar(clavesinencriptar);

                  
                 
                BLL.Usuario usu = new BLL.Usuario(txtusuario.Text, txtapellido.Text, txtnombre.Text, txtemail.Text, int.Parse(txtdni.Text), _habilitado,claveencriptada, clavesinencriptar);

                BLL.Usuario usu2 = new BLL.Usuario();
                //verificar si existe usuario
                usu2 = usu.BuscarUsuario(txtusuario.Text);

                if (usu2._Usuario != null)
                {
                    MessageBox.Show("el nombre de usuario: " + txtusuario.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }

                else
                {

               
                int oresult = usu.verificarDuplicidad(int.Parse(txtdni.Text), txtemail.Text,txtusuario.Text);
                
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
                        MessageBox.Show("el email: " + txtemail.Text + " y el dni:"+ txtdni.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        break;

                    case 5://usuario repetiro
                            MessageBox.Show("el usuario: " + txtusuario.Text + " ", "Duplicidad de datos", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                            break;


                        case 4://no existe en la base
 
                            usu.Dar_Alta_Usuario(usu._Usuario,usu.Apellido,usu.Nombre,usu.Email,usu.Dni,usu.Habilitado,usu.Clave,usu.clavesinencriptar);

                        MessageBox.Show("Usuario " + txtusuario.Text + " se dió de alta satisfactoriamente, se envia clave al correo","Alta de usuario",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        string[] lineas = { " Usuario: " + txtusuario.Text, " Clave: " + clavesinencriptar };

                        using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Default\\Desktop\\Nueva carpeta\\Usuario.txt")) {
                            foreach (string linea in lineas)
                            {
                                outputfile.WriteLine(linea);
                            }

                        


                        }

                            log.NombreOperacion = cryp.Encriptar("Alta Usuario");
                            log.Descripcion = cryp.Encriptar("Alta de "+txtusuario.Text+" realizada con Exito!");
                            log.Criticidad = 1;
                            
                            string rta = log.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, log.Criticidad, usulog.UsuarioID);
                        

                        txtapellido.Clear();
                        txtdni.Clear();
                        txtemail.Clear();
                        txtnombre.Clear();
                        txtusuario.Clear();

                        break;

                    default: //ocurrio un error
                        MessageBox.Show("Ha ocurrido un error,code description: " + oresult.ToString(),"Error"  );
                        break;
                }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  

            }
        }

             public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

