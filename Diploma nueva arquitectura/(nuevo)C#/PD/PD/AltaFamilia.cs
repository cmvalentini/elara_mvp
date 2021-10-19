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

        BLL.ManejadorPerfilUsuarioBLL mpu = new BLL.ManejadorPerfilUsuarioBLL();
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BE.Seguridad.PerfilUsuario mpuBE = new BE.Seguridad.PerfilUsuario();
        BE.Seguridad.Bitacora LogBE = new BE.Seguridad.Bitacora();
        PD.MenuPrincipal mp = MenuPrincipal.Instance; 
        
        

        public AltaFamilia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            mpuBE.NombrePerfil = txtNombrePerfil.Text;
            mpuBE.DescPerfil = txtDescripcionPerfil.Text;
        
            if ((txtNombrePerfil.Text == "") || (txtDescripcionPerfil.Text == ""))//no entra
            {
                MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            else // Entra
            {

             //   int verificar
             mpuBE.Result  = mpu.VerificarAltafamilia(mpuBE).ToString();

            if (Convert.ToInt16(mpuBE.Result) == 1) //ya existe
            {
                MessageBox.Show("El nombre de Perfil de Usuario ya existe en la base de datos, "+
                                "Verifique el mismo o cambie el nombre", "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if(Convert.ToInt16(mpuBE.Result) == 0)//se puede crear
            {
                mpuBE = mpu._CrearPerfilUsuario(mpuBE);
                MessageBox.Show("Se creo el Perfil de Usuario, configure las operaciones para el mismo", "Creacion de Perfil Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LogBE.Criticidad = 2;
                    LogBE.Descripcion = txtNombrePerfil.Text + " " + txtDescripcionPerfil.Text;
                    LogBE.FechayHora = DateTime.Now;
                    LogBE.NombreOperacion = "Alta Perfil";
                    log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad,mp.Usuarioid);

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
