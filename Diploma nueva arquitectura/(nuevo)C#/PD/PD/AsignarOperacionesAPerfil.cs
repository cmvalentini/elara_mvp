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
        BLL.ManejadorPerfilUsuarioBLL MPU = new BLL.ManejadorPerfilUsuarioBLL();
        List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
        BE.Seguridad.PerfilUsuario PerfilBE = new BE.Seguridad.PerfilUsuario();
        public AsignarOperacionesAPerfil(int _PerfilID,string _NombrePerfil)
        {
            InitializeComponent();
            PerfilBE.PerfilUsuarioID = _PerfilID;
            PerfilBE.NombrePerfil = _NombrePerfil;
        }

        private void AsignarOperacionesAPerfil_Load(object sender, EventArgs e)
        {
            //Muestro lista de operaciones
            lblNombreUsuario.Text = PerfilBE.NombrePerfil;
            listaoperaciones = MPU.MostrarListaOperaciones();
            foreach (BE.Seguridad.Operacion item in listaoperaciones)
            { 
                LstOperaciones.Items.Add(item);
            }
            LstOperaciones.DisplayMember = "NombreOperacion";
            LstOperaciones.ValueMember = "NombreOperacion";


            //Muestro lista del Perfil de Usuario

            listaoperaciones.Clear(); // limpio lista y la reutilizo

            listaoperaciones = MPU.MostrarListaOperaciones(PerfilBE);
            foreach (BE.Seguridad.Operacion item in listaoperaciones)
            { 

                LstPerfilOperaciones.Items.Add(item);
                LstOperaciones.Items.Remove(item);
            }
            LstPerfilOperaciones.DisplayMember = "NombreOperacion";
            LstPerfilOperaciones.ValueMember = "NombreOperacion";



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
            List<BE.Seguridad.Operacion> listaoperacionesperfil = new List<BE.Seguridad.Operacion>();
            foreach (BE.Seguridad.Operacion item in LstPerfilOperaciones.Items)
            {
                listaoperacionesperfil.Add(item);


            }

            try
            {
               MPU.AsignarOperacionesalPerfil(PerfilBE, listaoperacionesperfil);

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
