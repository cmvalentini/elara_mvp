namespace PD
{
    partial class ABMPerfilesUsuario
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
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.btnSalirPerfil = new System.Windows.Forms.Button();
            this.BtnAltaPerfil = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.Location = new System.Drawing.Point(8, 22);
            this.dgvPerfiles.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.Size = new System.Drawing.Size(666, 253);
            this.dgvPerfiles.TabIndex = 0;
            // 
            // btnSalirPerfil
            // 
            this.btnSalirPerfil.Location = new System.Drawing.Point(515, 343);
            this.btnSalirPerfil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirPerfil.Name = "btnSalirPerfil";
            this.btnSalirPerfil.Size = new System.Drawing.Size(114, 39);
            this.btnSalirPerfil.TabIndex = 2;
            this.btnSalirPerfil.Text = "Salir";
            this.btnSalirPerfil.UseVisualStyleBackColor = true;
            this.btnSalirPerfil.Click += new System.EventHandler(this.btnSalirPerfil_Click);
            // 
            // BtnAltaPerfil
            // 
            this.BtnAltaPerfil.Location = new System.Drawing.Point(250, 343);
            this.BtnAltaPerfil.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAltaPerfil.Name = "BtnAltaPerfil";
            this.BtnAltaPerfil.Size = new System.Drawing.Size(114, 39);
            this.BtnAltaPerfil.TabIndex = 3;
            this.BtnAltaPerfil.Text = "Alta";
            this.BtnAltaPerfil.UseVisualStyleBackColor = true;
            this.BtnAltaPerfil.Click += new System.EventHandler(this.BtnAltaPerfil_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPerfiles);
            this.groupBox1.Location = new System.Drawing.Point(4, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(682, 287);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfiles de Usuario";
            // 
            // ABMPerfilesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(699, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnAltaPerfil);
            this.Controls.Add(this.btnSalirPerfil);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "ABMPerfilesUsuario";
            this.Text = "ABM Perfiles de Usuario";
            this.Load += new System.EventHandler(this.ABMPerfilesUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPerfiles;
        private System.Windows.Forms.Button btnSalirPerfil;
        private System.Windows.Forms.Button BtnAltaPerfil;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}