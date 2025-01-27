﻿using System;
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
        BE.Seguridad.Bitacora LogBE = new BE.Seguridad.Bitacora();
        BLL.BitacoraBLL log = new BLL.BitacoraBLL();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
        List<BE.Cliente> listaclientes = new List<BE.Cliente>();
        BE.Cliente ClienteBE = new BE.Cliente();
        BLL.ClienteBLL cli = new BLL.ClienteBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;
         
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


            listaclientes = cli.BuscarClientes();
            dgvClientes.DataSource = listaclientes;


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



            listaclientes = cli.BuscarClientes();
            dgvClientes.DataSource = listaclientes;

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
                    ClienteBE.Clienteid = Convert.ToInt16(dgvClientes.Rows[e.RowIndex].Cells["clienteid"].Value.ToString());



                    if ((MessageBox.Show("¿Esta seguro que desea Eliminar el Cliente de forma permanente?", "Eliminar Cliente",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {


                        ClienteBE = cli.EliminarCliente(ClienteBE);

                        if (ClienteBE.result == "True")
                        {

                            LogBE.Criticidad = 2;
                            string a = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                            LogBE.Descripcion = a + " " + b;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Eliminar Cliente";

                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, mp.Usuarioid);

                            // Recargar DataGrid
                            this.Load += new EventHandler(ABMClientes_Load);
                            MessageBox.Show("Eliminación satifactoria" + ClienteBE.result, "Eliminación OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error en la eliminación del Cliente " + ClienteBE.result, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
   
