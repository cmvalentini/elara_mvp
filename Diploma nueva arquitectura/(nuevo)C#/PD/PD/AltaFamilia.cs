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
    public partial class AltaFamilia : Defaultform
    {
        BLL.ManejadorPerfilUsuario mpu = new BLL.ManejadorPerfilUsuario();
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();


        PD.MenuPrincipal mp = MenuPrincipal.Instance; 
        
        

        public AltaFamilia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        

        string nombrePerfil = txtNombrePerfil.Text;
        string descPerfil = txtDescripcionPerfil.Text;

            if ((txtNombrePerfil.Text == "") || (txtDescripcionPerfil.Text == ""))//no entra
            {
                MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            else // Entra
            {

           
            int verificar  = mpu.VerificarAltafamilia(nombrePerfil);

            if (verificar == 1) //ya existe
            {
                MessageBox.Show("El nombre de Perfil de Usuario ya existe en la base de datos, "+
                                "Verifique el mismo o cambie el nombre", "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if(verificar == 0)//se puede crear
            {
                string rta = mpu._CrearPerfilUsuario(txtNombrePerfil.Text,txtDescripcionPerfil.Text);
                MessageBox.Show("Se creo el Perfil de Usuario, configure las operaciones para el mismo", "Creacion de Perfil Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                log.Criticidad = 2;
                log.Descripcion = txtNombrePerfil.Text + " " + txtDescripcionPerfil.Text;
                log.FechayHora = DateTime.Now;
                log.NombreOperacion = "Alta Perfil";
                log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad,mp.Usuarioid);

                txtDescripcionPerfil.Text = "";
                txtNombrePerfil.Text = "";
            }

            else // hubo un quilombo con la BD
            {
                MessageBox.Show("Hubo un error con la base de datos,contacte con el administrador del sistema","Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaFamilia_Load(object sender, EventArgs e)
        {

        }
    }
}
