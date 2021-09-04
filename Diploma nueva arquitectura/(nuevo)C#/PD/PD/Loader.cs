using PD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD
{
    public partial class Loader : Form
    {
        Loader loader;
        public Loader()
        {
            InitializeComponent();
        }

        private void Loader_Load(object sender, EventArgs e)
        {

            pbloader.SizeMode = PictureBoxSizeMode.StretchImage;

            pbloader.Location = new Point(this.Width / 2 - pbloader.Width / 2,
                this.Height / 2 - pbloader.Height / 2);



        }


        public async void cargarimgmain()
        {
             
            pbloader.Load("loader.gif");

            show();
            Task otask = new Task(cargartimer);

            otask.Start();

            await otask;
            hide();
         }

        public void cargartimer() {
            Thread.Sleep(3000);

        }


        public void show() {

            loader = new Loader();
             
            loader.Show();

            
        }


        public void hide() {
            if (loader != null)
                loader.Close();

        }





    }
}
