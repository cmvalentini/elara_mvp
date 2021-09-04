namespace PD
{
    partial class AsignarOperacionesAPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LstOperaciones = new System.Windows.Forms.ListBox();
            this.LstPerfilOperaciones = new System.Windows.Forms.ListBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnDesagregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstOperaciones
            // 
            this.LstOperaciones.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstOperaciones.FormattingEnabled = true;
            this.LstOperaciones.ItemHeight = 15;
            this.LstOperaciones.Location = new System.Drawing.Point(23, 95);
            this.LstOperaciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LstOperaciones.Name = "LstOperaciones";
            this.LstOperaciones.Size = new System.Drawing.Size(295, 289);
            this.LstOperaciones.TabIndex = 2;
            // 
            // LstPerfilOperaciones
            // 
            this.LstPerfilOperaciones.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstPerfilOperaciones.FormattingEnabled = true;
            this.LstPerfilOperaciones.ItemHeight = 15;
            this.LstPerfilOperaciones.Location = new System.Drawing.Point(421, 95);
            this.LstPerfilOperaciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LstPerfilOperaciones.Name = "LstPerfilOperaciones";
            this.LstPerfilOperaciones.Size = new System.Drawing.Size(288, 289);
            this.LstPerfilOperaciones.TabIndex = 3;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(376, 403);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(136, 43);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Guardar Configuración";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(561, 403);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(136, 43);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Pericles", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(343, 166);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(56, 37);
            this.BtnAgregar.TabIndex = 6;
            this.BtnAgregar.Text = "->";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnDesagregar
            // 
            this.BtnDesagregar.Font = new System.Drawing.Font("Pericles", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDesagregar.Location = new System.Drawing.Point(343, 250);
            this.BtnDesagregar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDesagregar.Name = "BtnDesagregar";
            this.BtnDesagregar.Size = new System.Drawing.Size(56, 37);
            this.BtnDesagregar.TabIndex = 7;
            this.BtnDesagregar.Text = "<-";
            this.BtnDesagregar.UseVisualStyleBackColor = true;
            this.BtnDesagregar.Click += new System.EventHandler(this.BtnDesagregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Operaciones del Sistema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Operaciones Asignadas a Perfil";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(16, 24);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(156, 25);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre de Perfil";
            // 
            // AsignarOperacionesAPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(751, 459);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDesagregar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LstPerfilOperaciones);
            this.Controls.Add(this.LstOperaciones);
            this.Controls.Add(this.lblNombreUsuario);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AsignarOperacionesAPerfil";
            this.Text = "Asignar Operaciones a Perfil";
            this.Load += new System.EventHandler(this.AsignarOperacionesAPerfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox LstOperaciones;
        private System.Windows.Forms.ListBox LstPerfilOperaciones;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnDesagregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreUsuario;
    }
}