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
        BLL.Bitacora log = new BLL.Bitacora();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
       // DataGridViewButtonColumn AsignarOperaciones = new DataGridViewButtonColumn();
        BLL.MedioBLL medio = new BLL.MedioBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;

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
            DataTable dt = new DataTable();
            dt = medio.BuscarMedios();
            dgvMedios.DataSource = dt;


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
            
            DataTable dt = new DataTable();

            dt.Clear();

            dt = medio.BuscarMedios();
            dgvMedios.DataSource = dt;

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

                            log.Criticidad = 2;
                            string a = dgvMedios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvMedios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            log.Descripcion = a + " " + b;
                            log.FechayHora = DateTime.Now;
                            log.NombreOperacion = "Eliminar Medio";

                            log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, mp.Usuarioid);

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
