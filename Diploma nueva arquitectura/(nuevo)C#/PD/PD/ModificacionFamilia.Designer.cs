namespace PD
{
    partial class ModificacionFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificacionFamilia));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModPerfil = new System.Windows.Forms.Button();
            this.txtDescripcionPerfil = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombrePerfil = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(206, 242);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 39);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModPerfil
            // 
            this.btnModPerfil.Location = new System.Drawing.Point(67, 242);
            this.btnModPerfil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnModPerfil.Name = "btnModPerfil";
            this.btnModPerfil.Size = new System.Drawing.Size(105, 39);
            this.btnModPerfil.TabIndex = 10;
            this.btnModPerfil.Text = "Modificar Perfil";
            this.btnModPerfil.UseVisualStyleBackColor = true;
            this.btnModPerfil.Click += new System.EventHandler(this.btnModPerfil_Click);
            // 
            // txtDescripcionPerfil
            // 
            this.txtDescripcionPerfil.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionPerfil.Location = new System.Drawing.Point(20, 114);
            this.txtDescripcionPerfil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcionPerfil.Multiline = true;
            this.txtDescripcionPerfil.Name = "txtDescripcionPerfil";
            this.txtDescripcionPerfil.Size = new System.Drawing.Size(299, 106);
            this.txtDescripcionPerfil.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripcion del Perfil:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre del Perfil:";
            // 
            // txtNombrePerfil
            // 
            this.txtNombrePerfil.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePerfil.Location = new System.Drawing.Point(20, 42);
            this.txtNombrePerfil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombrePerfil.Name = "txtNombrePerfil";
            this.txtNombrePerfil.Size = new System.Drawing.Size(299, 21);
            this.txtNombrePerfil.TabIndex = 6;
            // 
            // ModificacionFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(330, 301);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModPerfil);
            this.Controls.Add(this.txtDescripcionPerfil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombrePerfil);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ModificacionFamilia";
            this.Text = "Modificacion Familia";
            this.Load += new System.EventHandler(this.ModificacionFamilia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModPerfil;
        private System.Windows.Forms.TextBox txtDescripcionPerfil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombrePerfil;
    }
}