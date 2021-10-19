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
    public partial class ABM_Medios : Defaultform
    {
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        BE.Seguridad.Bitacora LogBE = new BE.Seguridad.Bitacora();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
       // DataGridViewButtonColumn AsignarOperaciones = new DataGridViewButtonColumn();
        BLL.MedioBLL medio = new BLL.MedioBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;
        List<BE.Medio> listamedios = new List<BE.Medio>();
        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public ABM_Medios()
        {
            InitializeComponent();
        }

        private void ABM_Medios_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 3000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traigo usuarios y los cargo
            BLL.MedioBLL medio = new BLL.MedioBLL();
            
            listamedios = medio.BuscarMedios();
            dgvMedios.DataSource = listamedios;


            //añado boton borrar usuario

            uninstallButtonColumn.Name = "BorraMedio";
            uninstallButtonColumn.Text = "Borra Medio";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvMedios.Columns.Add(uninstallButtonColumn);


            dgvMedios.ReadOnly = true;

            //añado boton Modificar usuario

            ModifyButtonColumn.Name = "ModificarMedio";
            ModifyButtonColumn.Text = "Modificar Medio";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvMedios.Columns.Add(ModifyButtonColumn);

            dgvMedios.Columns["medioid"].Visible = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo

            listamedios.Clear();

            listamedios = medio.BuscarMedios();
            dgvMedios.DataSource = listamedios;

            dgvMedios.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaMedio al = new AltaMedio();
            al.Show();
        }

        private void dgvMedios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //modify
            if (e.ColumnIndex == dgvMedios.Columns["ModificarMedio"].Index)
            {
                //Modify 

                string medioid = dgvMedios.Rows[e.RowIndex].Cells["medioid"].Value.ToString();

                ModificarMedio mu = new ModificarMedio(Convert.ToInt16(medioid));
                mu.Show();//mostrar form modificar


            }
            else if (e.ColumnIndex == dgvMedios.Columns["BorraMedio"].Index)
            {
                string medioid = dgvMedios.Rows[e.RowIndex].Cells["medioid"].Value.ToString();



                if ((MessageBox.Show("¿Esta seguro que desea Eliminar el Medio de forma permanente?", "Eliminar Perfil Usuario",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    try
                    {


                        string Eliminar = medio.Eliminarmedio(Convert.ToInt16(medioid));

                        if (Eliminar == "True")
                        {

                            LogBE.Criticidad = 2;
                            string a = dgvMedios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvMedios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            LogBE.Descripcion = a + " " + b;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Eliminar Medio";
                            BE.Seguridad.Encriptacion cyrp = new BE.Seguridad.Encriptacion();
                            
                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, mp.Usuarioid);

                            // Recargar DataGrid
                            this.Load += new EventHandler(ABM_Medios_Load);
                            MessageBox.Show("Medio eliminado correctamente");

                        }
                        else
                        {
                            MessageBox.Show("Error en la eliminación del Medio " + Eliminar, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error: " + ex.Message.ToString(), "Error,contacte al administrador", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }

                }



            }//fin elseif





        }
    }
}
