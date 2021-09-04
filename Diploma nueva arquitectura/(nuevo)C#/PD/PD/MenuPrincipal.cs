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
    public partial class MenuPrincipal : Defaultform
    {
        public static MenuPrincipal mdiobj;
        IList<ServiceLayer.Component> listaoperaciones = new List<ServiceLayer.Component>();
        public int Usuarioid;
        ABMUsuarios abmusuario;
        BLL.IdiomaBLL idi = new BLL.IdiomaBLL();

        private static MenuPrincipal instance;

        
        public static MenuPrincipal Instance
        {
            get {
                if (instance == null)
                {
                    instance = new MenuPrincipal();
                }
                return instance;
            }
          
        }
        
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        

        public void MapeoComponentes(IList<ServiceLayer.Component> listaoperaciones)
        {


            //Cambio el idioma de los componentes
            BLL.IdiomaBLL idi = new BLL.IdiomaBLL();
            string idioma = idi.CargarIdioma();
          

            //--INSTANCIACION--//
            
            /*LogOut logout = new LogOut();
            logout.MdiParent = this;
            abmusuario = new ABMUsuarios();
            abmusuario.MdiParent = this;
            HacerBackUp hacerbackup = new HacerBackUp();
            //--HABILITACION DE PERMISOS --/*/

            foreach (var i in listaoperaciones) //hacer aca el composite
            {
                string var = i.Nombre.ToString();

                switch (var)
                {
                    //agregar aca las Operaciones del Menu
                    case "hacerbackup":
                         
                        gestiónDeBackUpToolStripMenuItem.Visible = true;
                     
                        break;

                    case "abmusuario":
                        aBMUsuariosToolStripMenuItem.Visible = true; 
                       /* ToolStripButton BtnAbmUsuario = new ToolStripButton("ABM Usuarios", null, new System.EventHandler(abmusuario.Show));
                        BtnAbmUsuario.Visible = true;
                        abmusuario.MdiParent = this;
                        drop.Items.Add(BtnAbmUsuario);*/
                        break;

                    case "abmperfilusuario":
                        aBMPerfilDeUsuariosToolStripMenuItem.Visible = true;
 
                        break;

                    case "ConfigurarIdioma":
                        configurarIdiomaToolStripMenuItem.Visible = true;
                     
                      break;
                        
                    case "abmfamilias":
                        aBMFamiliasToolStripMenuItem.Visible = true;
                        
                        break;

                    case "hacerrestore":
                        gestionDeRestoreToolStripMenuItem.Visible = true;


                        break;

                    case "consultarbitacora":
                        consultarBitácoraToolStripMenuItem.Visible = true;
                        break;
                                                

                    case "digitosverificadores":

                        dígitosVerificadoresToolStripMenuItem.Visible = true;

                        break;


                    case "Asignacion_de_Patentes":
                        asignaciónDePatentesToolStripMenuItem.Visible = true;
                        break;

                        
                    case "BloquearDesbloquearOperacionesaUsuario":
                        bloqueoDeOperacionesToolStripMenuItem.Visible = true;
                            
                            break;


                    case "DesbloquearOperacionAUsuariocs":
                        desbloqueoDeOperacionesToolStripMenuItem.Visible = true;

                        break;

                    //menu negocio
                    
                    case "ABMMedios":
                        aBMUbicacionesToolStripMenuItem.Visible = true;
                        break;


                    case "ABMUbicacion":
                        aBMUbicacionesToolStripMenuItem.Visible = true;
                        break;

                    case "ABMClientes":
                        aBMClientesToolStripMenuItem.Visible = true;
                        break;

                        
                     case "CrearNegocio":
                        crearNegocioToolStripMenuItem.Visible = true;
                        break;
                        
                     case "ConsultaOperacion":
                        consultarBitácoraToolStripMenuItem.Visible = true;
                        break;


                    default:
                        
                        break;

                        
                }

            }
            

             string idiom = idi.CargarIdioma();

             switch (idiom)
             {
                 case "Español":

                    crearNegocioToolStripMenuItem.Text = Idioma.Espanol.crearnegocio;
                    aBMClientesToolStripMenuItem.Text = Idioma.Espanol.abmclientes;
                    aBMUbicacionesToolStripMenuItem.Text = Idioma.Espanol.abmubicaciones;
                    aBMMediosToolStripMenuItem.Text = Idioma.Espanol.abmmedios;
                  
                    dígitosVerificadoresToolStripMenuItem.Text = Idioma.Espanol.calculardigitosverificadores.ToString();
                    aBMUsuariosToolStripMenuItem.Text = Idioma.Espanol.abmusuario.ToString();
                    aBMPerfilDeUsuariosToolStripMenuItem.Text = Idioma.Espanol.abmfamilias.ToString();
                    gestionDeRestoreToolStripMenuItem.Text = Idioma.Espanol.hacerrestore.ToString();
                    gestiónDeBackUpToolStripMenuItem.Text = Idioma.Espanol.hacerbackup.ToString();
                    configurarIdiomaToolStripMenuItem.Text = Idioma.Espanol.configuraridioma.ToString();
                    consultarBitácoraToolStripMenuItem.Text = Idioma.Espanol.consultarbitacora.ToString();
                    asignaciónDePatentesToolStripMenuItem.Text = Idioma.Espanol.Asignacion_de_Patentes.ToString();
                    bloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Espanol.BloquearDesbloquearOperacionesaUsuario.ToString();
                    desbloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Espanol.DesbloquearOperacionAUsuariocs.ToString();


                     break;

                 case "Ingles":

                    crearNegocioToolStripMenuItem.Text = Idioma.Ingles.crearnegocio;
                    aBMClientesToolStripMenuItem.Text = Idioma.Ingles.abmclientes;
                    aBMUbicacionesToolStripMenuItem.Text = Idioma.Ingles.abmubicaciones;
                    aBMMediosToolStripMenuItem.Text = Idioma.Ingles.abmmedios;

                    dígitosVerificadoresToolStripMenuItem.Text = Idioma.Ingles.calculardigitosverificadores.ToString();
                    aBMUsuariosToolStripMenuItem.Text = Idioma.Ingles.abmusuario.ToString();
                    aBMPerfilDeUsuariosToolStripMenuItem.Text = Idioma.Ingles.abmfamilias.ToString();
                    gestionDeRestoreToolStripMenuItem.Text = Idioma.Ingles.hacerrestore.ToString();
                    gestiónDeBackUpToolStripMenuItem.Text = Idioma.Ingles.hacerbackup.ToString();
                    configurarIdiomaToolStripMenuItem.Text = Idioma.Ingles.configuraridioma.ToString();
                    consultarBitácoraToolStripMenuItem.Text = Idioma.Ingles.consultarbitacora.ToString();
                    asignaciónDePatentesToolStripMenuItem.Text = Idioma.Ingles.Asignacion_de_Patentes.ToString();
                    bloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Ingles.BloquearDesbloquearOperacionesaUsuario.ToString();
                    desbloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Ingles.DesbloquearOperacionAUsuariocs.ToString();

                    break;

                 default:
                     break;

             }
              







        }





        private void aBMUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ABMUsuarios mu = new ABMUsuarios();
            mu.MdiParent = this;
            mu.Show();

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;
            
            seguridadYProcesosToolStripMenuItem.Visible = true;
            salirToolStripMenuItem.Visible = true;
            gestionComercialToolStripMenuItem.Visible = true;
            gestiónDeBackUpToolStripMenuItem.Visible = false;
            aBMUsuariosToolStripMenuItem.Visible = false;
            aBMPerfilDeUsuariosToolStripMenuItem.Visible = false;
            configurarIdiomaToolStripMenuItem.Visible = false;
            aBMFamiliasToolStripMenuItem.Visible = false;
            gestionDeRestoreToolStripMenuItem.Visible = false;
            consultarBitácoraToolStripMenuItem.Visible = false;
            dígitosVerificadoresToolStripMenuItem.Visible = false;
            asignaciónDePatentesToolStripMenuItem.Visible = false;
            bloqueoDeOperacionesToolStripMenuItem.Visible = false;
            desbloqueoDeOperacionesToolStripMenuItem.Visible = false;
            aBMUbicacionesToolStripMenuItem.Visible = false;
            aBMClientesToolStripMenuItem.Visible = false;
            crearNegocioToolStripMenuItem.Visible = false;
            consultarBitácoraToolStripMenuItem.Visible = false;

            this.BackgroundImage = Resources.Elara_Photo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            

            BLL.directorioperfil Lo= new BLL.directorioperfil("LogIn");
             
           
            Lo.obtenerhijos(Usuarioid);
            ServiceLayer.Composite.Composite composite = new ServiceLayer.Composite.Composite("LogIn");
            listaoperaciones = composite.devolerinstanciapermisos();
            this.MapeoComponentes(listaoperaciones);



        }
       
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             
           // this.MapeoComponentes(listaoperaciones);
        }
        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut lg = new LogOut();
            lg.MdiParent = this;
            lg.Show();
        }

        private void seguridadYProcesos_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LogOut lg = new LogOut();
            lg.Show();
        }
       

      

        private void seguridadYProcesosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asignaciónDePatentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignacion_de_Patentes ap = new Asignacion_de_Patentes();
            ap.MdiParent = this;
            ap.Show();
        }

        private void aBMPerfilDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMPerfilesUsuario pu = new ABMPerfilesUsuario();
            pu.MdiParent = this;
            pu.Show();
        }

        private void configurarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarIdioma ci = new ConfigurarIdioma();
            ci.MdiParent = this;
            ci.Show();
        }

        private void consultarBitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarBitacora cb = new ConsultarBitacora();
            cb.MdiParent = this;
            cb.Show();
        }

        private void bloqueoDeOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BloquearDesbloquearOperacionesaUsuario BloquearDesbloquearOperacionesaUsuario = new BloquearDesbloquearOperacionesaUsuario();
            BloquearDesbloquearOperacionesaUsuario.MdiParent = this;
            BloquearDesbloquearOperacionesaUsuario.Show();
        }

        private void desbloqueoDeOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BloquearDesbloquearOperacionesaUsuario BloquearDesbloquearOperacionesaUsuario = new BloquearDesbloquearOperacionesaUsuario();
            BloquearDesbloquearOperacionesaUsuario.MdiParent = this;
            BloquearDesbloquearOperacionesaUsuario.Show();
        }

        private void aBMUsuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ABMUsuarios abm = new ABMUsuarios();
            abm.MdiParent = this;
            abm.Show();
        }

        private void gestiónDeBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HacerBackUp hb = new HacerBackUp();
            hb.MdiParent = this;
            hb.Show();
        }

        private void gestionDeRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HacerRestore hr = new HacerRestore();
            hr.MdiParent = this;
            hr.Show();
        }

        private void aBMFamiliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMFamilias af = new ABMFamilias();
            af.MdiParent = this;
            af.Show();
        }

        private void dígitosVerificadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DigitosVerificadores dv = new DigitosVerificadores();
            dv.MdiParent = this;
            dv.Show();
        }

        private void aBMMediosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Medios Medios = new ABM_Medios();
            Medios.MdiParent = this;
            Medios.Show();
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMClientes Clientes = new ABMClientes();
            Clientes.MdiParent = this;
            Clientes.Show();
        }

        private void aBMUbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMUbicacion Ubicacion = new ABMUbicacion();
            Ubicacion.MdiParent = this;
            Ubicacion.Show();
        }

        private void crearNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearNegocio cn = new CrearNegocio();
            cn.MdiParent = this;
            cn.Show();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarPedidos cp = new ConsultarPedidos();
            cp.MdiParent = this;
            cp.Show();
        }
    }

}
