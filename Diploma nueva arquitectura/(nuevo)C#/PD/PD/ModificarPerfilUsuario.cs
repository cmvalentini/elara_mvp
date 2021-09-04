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
    public partial class ModificarPerfilUsuario : Defaultform
    {
        public ModificarPerfilUsuario()
        {
            InitializeComponent();
        }

        private void CrearPerfilUsuario_Load(object sender, EventArgs e)
        {

        }


        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
