using PD.Properties;
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
    public partial class Defaultform : Form
    {
        public Defaultform()
        {
            InitializeComponent();
        }

        private void Defaultform_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.backgray;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
