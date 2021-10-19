using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;

namespace PD
{
    public partial class ABMPerfilesUsuario : Defaultform
    {
        List<BE.Seguridad.PerfilUsuario> listaperfiles = new List<BE.Seguridad.PerfilUsuario>();

        public ABMPerfilesUsuario()
        {
            InitializeComponent();
           
        }

        private void btnSalirPerfil_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMPerfilesUsuario_Load(object sender, EventArgs e)
        {
         
            BLL.ManejadorPerfilUsuarioBLL pu = new BLL.ManejadorPerfilUsuarioBLL();

            listaperfiles = pu.BuscarPerfilUsuarios();
            dgvPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerfiles.DataSource = listaperfiles;
        }



        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        private void BtnAltaPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}
