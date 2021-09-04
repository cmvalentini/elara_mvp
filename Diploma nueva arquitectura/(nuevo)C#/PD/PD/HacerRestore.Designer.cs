namespace PD
{
    partial class HacerRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HacerRestore));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.BtnPath = new System.Windows.Forms.Button();
            this.BtnAtras = new System.Windows.Forms.Button();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.cmbcantidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ruta:";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(16, 50);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(261, 21);
            this.txtPath.TabIndex = 9;
            // 
            // BtnPath
            // 
            this.BtnPath.Location = new System.Drawing.Point(285, 34);
            this.BtnPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnPath.Name = "BtnPath";
            this.BtnPath.Size = new System.Drawing.Size(124, 52);
            this.BtnPath.TabIndex = 8;
            this.BtnPath.Text = "Ingresar Ruta";
            this.BtnPath.UseVisualStyleBackColor = true;
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // BtnAtras
            // 
            this.BtnAtras.Location = new System.Drawing.Point(113, 176);
            this.BtnAtras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAtras.Name = "BtnAtras";
            this.BtnAtras.Size = new System.Drawing.Size(124, 42);
            this.BtnAtras.TabIndex = 7;
            this.BtnAtras.Text = "Volver";
            this.BtnAtras.UseVisualStyleBackColor = true;
            this.BtnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // BtnRestore
            // 
            this.BtnRestore.Location = new System.Drawing.Point(285, 176);
            this.BtnRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(124, 42);
            this.BtnRestore.TabIndex = 6;
            this.BtnRestore.Text = "Hacer Restore";
            this.BtnRestore.UseVisualStyleBackColor = true;
            this.BtnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // cmbcantidad
            // 
            this.cmbcantidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcantidad.FormattingEnabled = true;
            this.cmbcantidad.Items.AddRange(new object[] {
            "3",
            "5",
            "10"});
            this.cmbcantidad.Location = new System.Drawing.Point(16, 122);
            this.cmbcantidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbcantidad.Name = "cmbcantidad";
            this.cmbcantidad.Size = new System.Drawing.Size(91, 23);
            this.cmbcantidad.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cantidad de Particiones :";
            // 
            // HacerRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(424, 230);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbcantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.BtnPath);
            this.Controls.Add(this.BtnAtras);
            this.Controls.Add(this.BtnRestore);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HacerRestore";
            this.Text = "Hacer Restore de la Base de Datos";
            this.Load += new System.EventHandler(this.HacerRestore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button BtnPath;
        private System.Windows.Forms.Button BtnAtras;
        private System.Windows.Forms.Button BtnRestore;
        private System.Windows.Forms.ComboBox cmbcantidad;
        private System.Windows.Forms.Label label2;
    }
}