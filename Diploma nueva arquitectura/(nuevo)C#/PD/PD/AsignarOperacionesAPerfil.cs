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
    public partial class AsignarOperacionesAPerfil : Defaultform
    {
        BLL.ManejadorPerfilUsuario MPU = new BLL.ManejadorPerfilUsuario();
        List<string> listaoperaciones = new List<string>();
        int PerfilID;
        string NombrePerfil;
        public AsignarOperacionesAPerfil(int _PerfilID,string _NombrePerfil)
        {
            InitializeComponent();
            PerfilID = _PerfilID;
            NombrePerfil = _NombrePerfil;
        }

        private void AsignarOperacionesAPerfil_Load(object sender, EventArgs e)
        {
            //Muestro lista de operaciones
            lblNombreUsuario.Text = this.NombrePerfil;
            listaoperaciones = MPU.MostrarListaOperaciones();
            foreach (string item in listaoperaciones)
            {
                LstOperaciones.Items.Add(item);
            }
            LstOperaciones.DisplayMember = "Descripcion";
            LstOperaciones.ValueMember = "Descripcion";


            //Muestro lista del Perfil de Usuario

            listaoperaciones.Clear(); // limpio lista y la reutilizo

            listaoperaciones = MPU.MostrarListaOperaciones(this.PerfilID);
            foreach (string item in listaoperaciones)
            {
                LstPerfilOperaciones.Items.Add(item);
                LstOperaciones.Items.Remove(item);
            }
            LstPerfilOperaciones.DisplayMember = "Descripcion";
            LstPerfilOperaciones.ValueMember = "Descripcion";



        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string op = LstOperaciones.SelectedItem.ToString();
                LstPerfilOperaciones.Items.Add(op);


                LstOperaciones.Items.Remove(LstOperaciones.SelectedItem);
                LstOperaciones.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void BtnDesagregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LstPerfilOperaciones.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Seleccione un Elemento!");
                }
                else
                {
                    string op = LstPerfilOperaciones.SelectedItem.ToString();
                    LstOperaciones.Items.Add(op);

                    LstPerfilOperaciones.Items.Remove(LstPerfilOperaciones.SelectedItem);
                    LstPerfilOperaciones.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 
            }
            
            




        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<string> listaoperacionesperfil = new List<string>();
            foreach (string item in LstPerfilOperaciones.Items)
            {
                listaoperacionesperfil.Add(item.ToString());


            }

            try
            {
               MPU.AsignarOperacionesalPerfil(this.PerfilID, listaoperacionesperfil);

            MessageBox.Show("Operaciones asignadas exitosamente", "Asignacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }

            catch (Exception ex)
            {

           MessageBox.Show(ex.Message, "Error en la Asignación", MessageBoxButtons.OK, MessageBoxIcon.None);

            }



        }
    }
}
