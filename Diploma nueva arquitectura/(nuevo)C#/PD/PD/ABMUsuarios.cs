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
    public partial class ABMUsuarios : Defaultform
    {

        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
 
        BLL.Bitacora log = new BLL.Bitacora();

        //cargo el help
    

        public void cargar() {

            ABMUsuarios mu = new ABMUsuarios();
            mu.Load += new EventHandler(ABMUsuarios_Load);

        }
        public ABMUsuarios()
        {
            InitializeComponent();
        }
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
        public void ABMUsuarios_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 10000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traigo usuarios y los cargo
            BLL.Usuario usu = new BLL.Usuario();
            DataTable dt = new DataTable();
            dt = usu.MostrarUsuarios();
            dgvUsuarios.DataSource = dt;


            //añado boton borrar usuario

            uninstallButtonColumn.Name = "BorrarUsuario";
            uninstallButtonColumn.Text = "BorrarUsuario";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvUsuarios.Columns.Add(uninstallButtonColumn);


            dgvUsuarios.ReadOnly = true;

            //añado boton Modificar usuario


            ModifyButtonColumn.Name = "ModificarUsuario";
            ModifyButtonColumn.Text = "ModificarUsuario";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvUsuarios.Columns.Add(ModifyButtonColumn);



            dgvUsuarios.Columns["UsuarioID"].Visible = false;
            dgvUsuarios.Columns["Clave"].Visible = false;


            HelpProvider helpProvider1 = new HelpProvider();

            /*string path =;
            Help.ShowHelp("");*/
            
            helpProvider1.ResetShowHelp(this);
            helpProvider1.HelpNamespace = Application.StartupPath + @"D:\Facu\Trabajo de Campo 1\Proyecto Diploma\(nuevo)C#\PD\Usuario\helpusuario.chm";
            helpProvider1.SetHelpKeyword(this,"USUARIOS");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);






        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo
            BLL.Usuario usu = new BLL.Usuario();
            DataTable dt = new DataTable();
            dt = usu.MostrarUsuarios();
            dgvUsuarios.DataSource = dt;


            dgvUsuarios.AllowUserToAddRows = false;

        }

        private void ModificarUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void borrarUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //aca poner accion de borrar usuario y grabar en la bitacora
            if (e.ColumnIndex == dgvUsuarios.Columns["BorrarUsuario"].Index)
            {
                //Do something with your button.
            }
        }

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }


        private void btnaltausuario_Click(object sender, EventArgs e)
        {
            MenuUsuarios alta = new MenuUsuarios();
            alta.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            BLL.Usuario usu = new BLL.Usuario();
            if (e.ColumnIndex == dgvUsuarios.Columns["ModificarUsuario"].Index)
            {
                //Modify 
               
                string usuid = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                ModifyUser mu = new ModifyUser(usuid);
             
                mu.Show();

                          
            }

            else if (e.ColumnIndex == dgvUsuarios.Columns["BorrarUsuario"].Index)
            {
                //delete it!
                
                string usuid = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();


              

                if ((MessageBox.Show("¿Esta seguro que desea Eliminar al usuario " +usu.Nombre+" de forma permanente?", "Eliminar Usuario",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    try
                    {
                        
                        string Eliminar = usu.verificarPatentesEscenciales(Convert.ToInt16(usuid));

                        if (Eliminar == "True")
                        {



                           
                            log.Criticidad = 2;
                            string a = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            log.Descripcion = a + " " + b;
                            log.FechayHora = DateTime.Now;
                            log.NombreOperacion = "Eliminar Usuario";

                            log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, usu.UsuarioID);

                            string result = usu.EliminarUsuario(Convert.ToInt16(usuid));


                            // Recargar DataGrid
                            this.Load += new EventHandler(ABMUsuarios_Load);
                            MessageBox.Show("Usuario eliminado correctamente");

                        }
                        else
                        {
                            MessageBox.Show("Usuario con Patentes Unicas,no se puede eliminar!,Patentes: " + Eliminar, "Error al Borrado" ,MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        
                      
                        }
                       


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString()); 
                    
                    }
                    
                }

            


            }
        }
    }

}
