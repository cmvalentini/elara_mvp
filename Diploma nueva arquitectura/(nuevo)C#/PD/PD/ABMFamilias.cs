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
    public partial class ABMFamilias : Defaultform
    {

        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn AsignarOperaciones = new DataGridViewButtonColumn();
        BE.Seguridad.PerfilUsuario mpuBE = new BE.Seguridad.PerfilUsuario();
        List<BE.Seguridad.PerfilUsuario> listampu = new List<BE.Seguridad.PerfilUsuario>();
        BE.Seguridad.Bitacora LogBE = new BE.Seguridad.Bitacora();
        public ABMFamilias()
        {
            InitializeComponent();
        }


        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;

        public void cargar()
        {

            ABMFamilias mu = new ABMFamilias();
            mu.Load += new EventHandler(ABMFamilias_Load);

        }

     
        private void ABMFamilias_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 3000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traigo usuarios y los cargo
            BLL.ManejadorPerfilUsuarioBLL mpf = new BLL.ManejadorPerfilUsuarioBLL();
             
            listampu = mpf.BuscarPerfilUsuarios();
            dgvPerfiles.DataSource = listampu;


            //añado boton borrar usuario

            uninstallButtonColumn.Name = "BorrarPerfil";
            uninstallButtonColumn.Text = "BorrarPerfil";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; 
            this.dgvPerfiles.Columns.Add(uninstallButtonColumn);


            dgvPerfiles.ReadOnly = true;

            //añado boton Modificar usuario
            
            ModifyButtonColumn.Name = "ModificarPerfil";
            ModifyButtonColumn.Text = "ModificarPerfil";
            ModifyButtonColumn.UseColumnTextForButtonValue = true;  
            this.dgvPerfiles.Columns.Add(ModifyButtonColumn);

            //añado boton asignar operaciones
            AsignarOperaciones.Name = "AsignarOperaciones";
            AsignarOperaciones.Text = "AsignarOperaciones";
            AsignarOperaciones.UseColumnTextForButtonValue = true;
            AsignarOperaciones.Width = 110;
            this.dgvPerfiles.Columns.Add(AsignarOperaciones);


            dgvPerfiles.Columns["PerfilUsuarioID"].Visible = false;
            dgvPerfiles.Columns["DVH"].Visible = false;

        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo
            BLL.ManejadorPerfilUsuarioBLL mpu = new BLL.ManejadorPerfilUsuarioBLL();
            listampu.Clear();
            listampu = mpu.BuscarPerfilUsuarios();
            dgvPerfiles.DataSource = listampu;
            dgvPerfiles.AllowUserToAddRows = false;
        }

        private void btnalta_Click(object sender, EventArgs e)
        {
            AltaFamilia AT = new AltaFamilia();

            AT.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BLL.ManejadorPerfilUsuarioBLL MPU = new BLL.ManejadorPerfilUsuarioBLL();
            if (e.ColumnIndex == dgvPerfiles.Columns["ModificarPerfil"].Index)
            {
                //Modify 

                mpuBE.PerfilUsuarioID = Convert.ToInt16(dgvPerfiles.Rows[e.RowIndex].Cells["PerfilUsuarioID"].Value.ToString());

                ModificacionFamilia mu = new ModificacionFamilia(mpuBE.PerfilUsuarioID);
                 mu.Show();//mostrar form modificar


            }

            else if (e.ColumnIndex == dgvPerfiles.Columns["BorrarPerfil"].Index)
            {
                //delete it!
                try
                {
                    mpuBE.PerfilUsuarioID = Convert.ToInt16(dgvPerfiles.Rows[e.RowIndex].Cells["PerfilUsuarioID"].Value.ToString());
           
                 
                
                if ((MessageBox.Show("¿Esta seguro que desea Eliminar el perfil de forma permanente?", "Eliminar Perfil Usuario",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    


                        mpuBE = MPU.EliminarPerfilUsuario(mpuBE);

                        if (mpuBE.Result == "True")
                        {
                           
                            LogBE.Criticidad = 2;
                            string a = dgvPerfiles.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvPerfiles.Rows[e.RowIndex].Cells[3].Value.ToString();
                            LogBE.Descripcion = a + " " + b;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Eliminar Perfil";

                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, mp.Usuarioid);
                            
                // Recargar DataGrid
                this.Load += new EventHandler(ABMFamilias_Load);
                            MessageBox.Show("Perfil eliminado correctamente");

                        }
                        else
                        {
                            MessageBox.Show("El perfil esta siendo utilizado, no se puede eliminar " + Eliminar, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);


                        }



                    }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());

                    }

            }




            
            //Boton Asignar Operaciones
            else if (e.ColumnIndex == dgvPerfiles.Columns["AsignarOperaciones"].Index)
            {
                               
              string PerfilID = dgvPerfiles.Rows[e.RowIndex].Cells["PerfilUsuarioID"].Value.ToString();
              string NombrePerfil = dgvPerfiles.Rows[e.RowIndex].Cells["NombrePerfil"].Value.ToString();

                AsignarOperacionesAPerfil aop = new AsignarOperacionesAPerfil(Convert.ToInt16(PerfilID),NombrePerfil);
               aop.Show();//mostrar form modificar

                




            }






        }
    }
}
