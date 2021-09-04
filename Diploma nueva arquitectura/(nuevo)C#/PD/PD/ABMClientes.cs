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
    public partial class ABMClientes : Form
    {
        BLL.Bitacora log = new BLL.Bitacora();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();

        BLL.Cliente cli = new BLL.Cliente();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;
        DataTable dt = new DataTable();
        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public ABMClientes()
        {
            InitializeComponent();
        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {

            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 3000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traigo usuarios y los cargo


            dt = cli.BuscarClientes();
            dgvClientes.DataSource = dt;


            //añado boton borrar cliente

            uninstallButtonColumn.Name = "BorrarCliente";
            uninstallButtonColumn.Text = "Borrar Cliente";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvClientes.Columns.Add(uninstallButtonColumn);


            dgvClientes.ReadOnly = true;

            //añado boton Modificar cliente

            ModifyButtonColumn.Name = "ModificarCliente";
            ModifyButtonColumn.Text = "Modificar Cliente";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvClientes.Columns.Add(ModifyButtonColumn);

            dgvClientes.Columns["clienteid"].Visible = false;






        }


        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo Clientes y los cargo



            dt.Clear();

            dt = cli.BuscarClientes();
            dgvClientes.DataSource = dt;

            dgvClientes.AllowUserToAddRows = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnalta_Click(object sender, EventArgs e)
        {
            Alta_Cliente acli = new Alta_Cliente();

            acli.Show();

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //modify
                if (e.ColumnIndex == dgvClientes.Columns["ModificarCliente"].Index)
                {
                    //Modify 

                    string clienteid = dgvClientes.Rows[e.RowIndex].Cells["clienteid"].Value.ToString();

                    //  ModificarMedio mu = new ModificarMedio(Convert.ToInt16(clienteid));
                    //   mu.Show();//mostrar form modificar
                    MessageBox.Show(clienteid);

                }
                else if (e.ColumnIndex == dgvClientes.Columns["BorrarCliente"].Index)
                {
                    string clienteid = dgvClientes.Rows[e.RowIndex].Cells["clienteid"].Value.ToString();



                    if ((MessageBox.Show("¿Esta seguro que desea Eliminar el Cliente de forma permanente?", "Eliminar Cliente",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {


                        string Eliminar = cli.EliminarCliente(Convert.ToInt16(clienteid));

                        if (Eliminar == "True")
                        {

                            log.Criticidad = 2;
                            string a = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                            log.Descripcion = a + " " + b;
                            log.FechayHora = DateTime.Now;
                            log.NombreOperacion = "Eliminar Cliente";

                            log.IngresarDatoBitacora(cryp.Encriptar(log.NombreOperacion), cryp.Encriptar(log.Descripcion), log.Criticidad, mp.Usuarioid);

                            // Recargar DataGrid
                            this.Load += new EventHandler(ABMClientes_Load);
                            MessageBox.Show("Eliminación satifactoria" + Eliminar, "Eliminación OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error en la eliminación del Cliente " + Eliminar, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.Message.ToString(), "Error,contacte al administrador", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }





                }
            }
        }
   
