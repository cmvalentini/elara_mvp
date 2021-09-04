using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace PD
{
    public partial class EstablecerCadena : Defaultform
    {

        BLL.Config conf = new BLL.Config();
        

        public EstablecerCadena()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstablecerCadena_Load(object sender, EventArgs e)
        {

           verificarconexion();

        }

        private void verificarconexion()
        {

           conf.Cadena = ConfigurationManager.AppSettings["conexionBD"].ToString();

            if (conf.LeerStringConexion(conf.Cadena))
            {

                //entra
                LogIn login = new LogIn();
                login.Show();

                this.Close();

            }


            else
            {
                //Tira la nueva conexion
              MessageBox.Show("No se pudo establecer conexion a la base de datos, pro favor complete la cadena");
 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBase.Text == "" || txtServidor.Text =="")
            {
             
                MessageBox.Show("Por favor complete los campos", "Datos sin completar", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

            }
            else
            {
                try
                {

                    string cadena = @"Data Source=" + txtServidor.Text.Trim().ToString() + ";Initial Catalog = " + txtBase.Text.Trim() + "; Integrated Security = True";


                    XmlDocument xmldoc = new XmlDocument();

                    xmldoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                    foreach (XmlElement element  in xmldoc.DocumentElement)
                    {

                        if (element.Name.Equals("appSettings"))
                        {
                            foreach (XmlNode node in element.ChildNodes)
                            {
                                if (node.Attributes[0].Value == "conexionBD")
                                {
                                    node.Attributes[1].Value = cadena;
                                }

                            }                                                   }
                    }

                    xmldoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                   // config.Save(ConfigurationSaveMode.Modified); ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                    
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.Save(ConfigurationSaveMode.Minimal);

                    ConfigurationManager.RefreshSection("appSettings");

                    // Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    // config.AppSettings.Settings["conexionBD"].Value = @"Data Source=" + @txtServidor.Text.Trim().ToString() + ";Initial Catalog = " + txtBase.Text.Trim() + "; Integrated Security = True";
                    // config.Save(ConfigurationSaveMode.Modified);
                    // conf.saveconection(cadena);


                    MessageBox.Show("Verificando cadena");

                    verificarconexion();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
           
        

        }
    }
}
