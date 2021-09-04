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
    public partial class ABMUbicacion : Defaultform
    {
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BE.Ubicacion ubiBE = new BE.Ubicacion();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
        MenuPrincipal mp = MenuPrincipal.Instance;

        public void cargar()
        {
            ABMUbicacion u = new ABMUbicacion();
            u.Load += new EventHandler(ABMUbicacion_Load);
        }

        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public ABMUbicacion()
        {
            InitializeComponent();
        }

        private void ABMUbicacion_Load(object sender, EventArgs e)
        {
             
            dgvubicaciones.DataSource = ubi.TraerUbicaciones();

            //añado boton borrar ubicacion

            uninstallButtonColumn.Name = "Borraubicacion";
            uninstallButtonColumn.Text = "Borra Ubicación";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvubicaciones.Columns.Add(uninstallButtonColumn);


            dgvubicaciones.ReadOnly = true;

            //añado boton Modificar ubicacion

            ModifyButtonColumn.Name = "ModificarUbicacion";
            ModifyButtonColumn.Text = "Modificar Ubicación";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvubicaciones.Columns.Add(ModifyButtonColumn);

        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo

            DataTable dt = new DataTable();

            dt.Clear();

            dgvubicaciones.DataSource = ubi.TraerUbicaciones();
            dgvubicaciones.AllowUserToAddRows = false;

            dgvubicaciones.Columns["ubicacionid"].Visible = false;
            dgvubicaciones.Columns["medioid"].Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_altaubicacion_Click(object sender, EventArgs e)
        {
            AltaUbicacion au = new AltaUbicacion();

            au.Show();

        }

        private void dgvubicaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvubicaciones.Columns["ModificarUbicacion"].Index)
            {
                //Modify 

                string ubicacionid = dgvubicaciones.Rows[e.RowIndex].Cells["ubicacionid"].Value.ToString();

                ModificarUbicacion mu = new ModificarUbicacion(Convert.ToInt16(ubicacionid));
                mu.Show();//mostrar form modificar
            }

            else if (e.ColumnIndex == dgvubicaciones.Columns["Borraubicacion"].Index)
            {
                //delete at!

                string ubicacionid = dgvubicaciones.Rows[e.RowIndex].Cells["ubicacionid"].Value.ToString();


                if ((MessageBox.Show("¿Esta seguro que desea Eliminar La Ubicacion de forma permanente?", "Eliminar Ubicación",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {

                    try
                    {

                        //hacer
                        string Eliminar = ubi.EliminarUbicacion(Convert.ToInt16(ubicacionid));
                       

                        if (Eliminar == "True")
                        {

                            log.Criticidad = 2;
                            string a = dgvubicaciones.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvubicaciones.Rows[e.RowIndex].Cells[3].Value.ToString();
                            log.Descripcion = a + " " + b;
                            log.FechayHora = DateTime.Now;
                            log.NombreOperacion = "Eliminar Perfil";

                            log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, mp.Usuarioid);

                            // Recargar DataGrid
                            this.Load += new EventHandler(ABMUbicacion_Load);
                            MessageBox.Show("Perfil eliminado correctamente");

                        }
                        else
                        {
                            MessageBox.Show("Error en la eliminacion de Perfil " + Eliminar, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);


                        }


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error" + ex, "Se presentó un Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }


                }
            }
        }
    }
}
