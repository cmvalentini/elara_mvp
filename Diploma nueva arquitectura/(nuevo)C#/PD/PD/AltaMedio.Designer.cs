namespace PD
{
    partial class AltaMedio
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
            this.BtnAltaMedio = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMedio = new System.Windows.Forms.TextBox();
            this.cmbIva = new System.Windows.Forms.ComboBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAltaMedio
            // 
            this.BtnAltaMedio.Location = new System.Drawing.Point(77, 372);
            this.BtnAltaMedio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAltaMedio.Name = "BtnAltaMedio";
            this.BtnAltaMedio.Size = new System.Drawing.Size(121, 46);
            this.BtnAltaMedio.TabIndex = 0;
            this.BtnAltaMedio.Text = "Alta Medio";
            this.BtnAltaMedio.UseVisualStyleBackColor = true;
            this.BtnAltaMedio.Click += new System.EventHandler(this.BtnAltaMedio_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(236, 372);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 46);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMedio
            // 
            this.txtMedio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedio.Location = new System.Drawing.Point(16, 40);
            this.txtMedio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMedio.Name = "txtMedio";
            this.txtMedio.Size = new System.Drawing.Size(388, 21);
            this.txtMedio.TabIndex = 2;
            // 
            // cmbIva
            // 
            this.cmbIva.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIva.FormattingEnabled = true;
            this.cmbIva.Items.AddRange(new object[] {
            "21.00",
            "10.50",
            "2.70"});
            this.cmbIva.Location = new System.Drawing.Point(56, 325);
            this.cmbIva.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbIva.Name = "cmbIva";
            this.cmbIva.Size = new System.Drawing.Size(59, 23);
            this.cmbIva.TabIndex = 3;
            // 
            // txtdesc
            // 
            this.txtdesc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesc.Location = new System.Drawing.Point(16, 103);
            this.txtdesc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(388, 189);
            this.txtdesc.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre del Medio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "IVA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 329);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // AltaMedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(411, 430);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.cmbIva);
            this.Controls.Add(this.txtMedio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.BtnAltaMedio);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AltaMedio";
            this.Text = "Alta Medio de Comunicación";
            this.Load += new System.EventHandler(this.AltaMedio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAltaMedio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtMedio;
        private System.Windows.Forms.ComboBox cmbIva;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}