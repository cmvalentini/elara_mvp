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
    public partial class ModificacionFamilia : Defaultform
    {
        BLL.ManejadorPerfilUsuario mpu = new BLL.ManejadorPerfilUsuario();
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        PD.MenuPrincipal mp = MenuPrincipal.Instance;

        int _PerfilID;

        public ModificacionFamilia(int PerfilID)
        {
            InitializeComponent();
            _PerfilID = PerfilID;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificacionFamilia_Load(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DT = mpu.BuscarPerfilUsuarios();
           DataRow[] dato = DT.Select("PerfilUsuarioID = "+_PerfilID);

         
           txtNombrePerfil.Text = dato[0].ItemArray[1].ToString();
            txtDescripcionPerfil.Text = dato[0].ItemArray[2].ToString();

        }

        private void btnModPerfil_Click(object sender, EventArgs e)
        {
            if ((txtNombrePerfil.Text == "") || (txtDescripcionPerfil.Text == ""))//no entra
            {
                MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string rta = mpu.ModificarPerfilUsuario(txtNombrePerfil.Text, txtDescripcionPerfil.Text, _PerfilID);

                if (rta == "True")
                {
                    log.Criticidad = 2;
                    log.Descripcion = txtNombrePerfil.Text + " " + txtDescripcionPerfil.Text;
                    log.FechayHora = DateTime.Now;
                    log.NombreOperacion = "Modificacion Perfil";
                    log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, mp.Usuarioid);

                    txtDescripcionPerfil.Text = "";
                    txtNombrePerfil.Text = "";

                    MessageBox.Show("Se modificó el perfil exitosamente", "Modificacion OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el perfil", "Modificacion Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                

                
            }


        }
    }
}
