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
    
    public partial class AsignarOperacionesaUsuario : Defaultform
    {
        BLL.Bitacora log  = new BLL.Bitacora();
        BLL.ManejadorPerfilUsuario MPU = new BLL.ManejadorPerfilUsuario();
        List<string> listaoperaciones = new List<string>();
        BLL.Usuario usu = new BLL.Usuario();
        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
        DataTable datausuario = new DataTable();
        string NombreUsuario;

        public AsignarOperacionesaUsuario(string nombreusuario)
        {
            InitializeComponent();
            NombreUsuario = nombreusuario;
        }

        private void AsignarOperacionesaUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                lblNombreUsuario.Text = this.NombreUsuario;
                lblNombrePerfil.Text = usu.traerDatosPerfil(this.NombreUsuario);

                // lista de operaciones cargo
                listaoperaciones = MPU.MostrarListaOperaciones();
                foreach (string item in listaoperaciones)
                {
                    LstOperaciones.Items.Add(item);
                }
                LstOperaciones.DisplayMember = "Descripcion";
                LstOperaciones.ValueMember = "Descripcion";


                //Muestro lista del Perfil del Usuario

                listaoperaciones.Clear(); // limpio lista y la reutilizo

                listaoperaciones = usu.MostraroperacionUsuario(this.NombreUsuario);
                foreach (string item in listaoperaciones)
                {
                    LstUsuarioOperaciones.Items.Add(item);
                    LstOperaciones.Items.Remove(item);
                }
                LstUsuarioOperaciones.DisplayMember = "Descripcion";
                LstUsuarioOperaciones.ValueMember = "Descripcion";

                //carga de los perfiles


                datausuario = MPU.BuscarPerfilUsuarios();

                foreach (DataRow item in datausuario.Rows)
                {
                    cmbPerfiles.Items.Add(item[1].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
           



        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string op = LstOperaciones.SelectedItem.ToString();
                LstUsuarioOperaciones.Items.Add(op);


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
                if (LstUsuarioOperaciones.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Seleccione un Elemento!");
                }
                else
                {
                    string op = LstUsuarioOperaciones.SelectedItem.ToString();
                    LstOperaciones.Items.Add(op);

                    LstUsuarioOperaciones.Items.Remove(LstUsuarioOperaciones.SelectedItem);
                    LstUsuarioOperaciones.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAsignarPerfil_Click(object sender, EventArgs e)
        {
            // inicio botin ppal


            if ((MessageBox.Show("¿Esta seguro que desea asignarle el Perfil a "+NombreUsuario +"?", "Asignar Perfil Usuario",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    if (cmbPerfiles.Text == "")
                    {
                        MessageBox.Show("Asigne el Perfil de Usuario!");
                    }
                    else
                    {
                        string nombreperfil = cmbPerfiles.Text;
                        //asignamos la familia al usuario
                       int flag = MPU.AsignarUsuarioaPerfil(nombreperfil, NombreUsuario);

                        //cargamos la familia en los listbox 
                        //para despues grabarla con sus permisos
                        this.reasignaroperaciones(nombreperfil);
                    
                    }
                   
                  





                }
              
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

            }



            //fin boton ppal
        }

        private void reasignaroperaciones(string perfil) {

            //limpio todo
            LstOperaciones.Items.Clear();
            LstUsuarioOperaciones.Items.Clear();

            //Muestro lista de operaciones
            listaoperaciones = MPU.MostrarListaOperaciones();
            foreach (string item in listaoperaciones)
            {
                LstOperaciones.Items.Add(item);
            }
            LstOperaciones.DisplayMember = "Descripcion";
            LstOperaciones.ValueMember = "Descripcion";


            //Muestro lista del Perfil de Usuario

            listaoperaciones.Clear(); // limpio lista y la reutilizo

            listaoperaciones = MPU.MostrarListaOperaciones(perfil);
            foreach (string item in listaoperaciones)
            {
                LstUsuarioOperaciones.Items.Add(item);
                LstOperaciones.Items.Remove(item);
            }
            LstUsuarioOperaciones.DisplayMember = "Descripcion";
            LstUsuarioOperaciones.ValueMember = "Descripcion";


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<string> listaoperacioneUsuario = new List<string>();
            foreach (string item in LstUsuarioOperaciones.Items)
            {
                listaoperacioneUsuario.Add(item.ToString());
            }

            List<string> listaoperacionessistema = new List<string>();
            foreach (string item in LstOperaciones.Items)
            {
                listaoperacionessistema.Add(item.ToString());
            }

           

            string Eliminar = "";
            try
            {
                if (Convert.ToInt16(listaoperacionessistema.Count().ToString()) == 0)
                {
                    //todas las patentes asignadas
                    Eliminar = "True";

                }
                else
                {
                        Eliminar = usu.verificarPatentesEscenciales(listaoperacionessistema, NombreUsuario);
                }

                if (Eliminar == "True")
                {
                    //si es true, lo puede reasignar
                    MPU.AsignarOperacionesalPerfil(NombreUsuario, listaoperacioneUsuario);
                    MessageBox.Show("Operaciones asignadas exitosamente", "Asignacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    log.IngresarDatoBitacora("Asignacion de Patentes", "Asignacion de patentes", 3, sesion.UsuarioID);

                }
                else
                {
                    MessageBox.Show("Usuario con Patentes Unicas, Reasigne las patentes", "Asignacion Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en la Asignación", MessageBoxButtons.OK, MessageBoxIcon.None);

            }






        }
    }
}


          
            