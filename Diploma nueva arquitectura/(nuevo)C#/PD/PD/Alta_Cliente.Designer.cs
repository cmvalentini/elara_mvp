namespace PD
{
    partial class Alta_Cliente
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
            this.Btn_Alta = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.cmbCondicionFiscal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.Domicilio = new System.Windows.Forms.Label();
            this.txtdomicilio = new System.Windows.Forms.TextBox();
            this.chkhabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Btn_Alta
            // 
            this.Btn_Alta.Location = new System.Drawing.Point(354, 345);
            this.Btn_Alta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_Alta.Name = "Btn_Alta";
            this.Btn_Alta.Size = new System.Drawing.Size(123, 48);
            this.Btn_Alta.TabIndex = 0;
            this.Btn_Alta.Text = "Dar Alta";
            this.Btn_Alta.UseVisualStyleBackColor = true;
            this.Btn_Alta.Click += new System.EventHandler(this.Btn_Alta_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(533, 346);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(129, 48);
            this.btn_Cancelar.TabIndex = 1;
            this.btn_Cancelar.Text = "Salir";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // cmbCondicionFiscal
            // 
            this.cmbCondicionFiscal.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCondicionFiscal.FormattingEnabled = true;
            this.cmbCondicionFiscal.Items.AddRange(new object[] {
            "Responsable Inscripto",
            "Consumidor Final",
            "Monotributista",
            "Sujeto no Categorizado",
            "Exento"});
            this.cmbCondicionFiscal.Location = new System.Drawing.Point(412, 145);
            this.cmbCondicionFiscal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbCondicionFiscal.Name = "cmbCondicionFiscal";
            this.cmbCondicionFiscal.Size = new System.Drawing.Size(249, 24);
            this.cmbCondicionFiscal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Condición Fiscal : ";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(17, 60);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(644, 24);
            this.txtRazonSocial.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Razón Social :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Telefono : ";
            // 
            // txttelefono
            // 
            this.txttelefono.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefono.Location = new System.Drawing.Point(17, 147);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(385, 24);
            this.txttelefono.TabIndex = 7;
            // 
            // Domicilio
            // 
            this.Domicilio.AutoSize = true;
            this.Domicilio.Location = new System.Drawing.Point(16, 210);
            this.Domicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Size = new System.Drawing.Size(77, 15);
            this.Domicilio.TabIndex = 8;
            this.Domicilio.Text = "Domicilio:";
            // 
            // txtdomicilio
            // 
            this.txtdomicilio.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdomicilio.Location = new System.Drawing.Point(20, 239);
            this.txtdomicilio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtdomicilio.Multiline = true;
            this.txtdomicilio.Name = "txtdomicilio";
            this.txtdomicilio.Size = new System.Drawing.Size(641, 74);
            this.txtdomicilio.TabIndex = 9;
            // 
            // chkhabilitado
            // 
            this.chkhabilitado.AutoSize = true;
            this.chkhabilitado.Location = new System.Drawing.Point(533, 33);
            this.chkhabilitado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkhabilitado.Name = "chkhabilitado";
            this.chkhabilitado.Size = new System.Drawing.Size(99, 19);
            this.chkhabilitado.TabIndex = 10;
            this.chkhabilitado.Text = "Habilitado";
            this.chkhabilitado.UseVisualStyleBackColor = true;
            // 
            // Alta_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(689, 405);
            this.Controls.Add(this.chkhabilitado);
            this.Controls.Add(this.txtdomicilio);
            this.Controls.Add(this.Domicilio);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCondicionFiscal);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.Btn_Alta);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Alta_Cliente";
            this.Text = "Alta de Cliente";
            this.Load += new System.EventHandler(this.Alta_Cliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Alta;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.ComboBox cmbCondicionFiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label Domicilio;
        private System.Windows.Forms.TextBox txtdomicilio;
        private System.Windows.Forms.CheckBox chkhabilitado;
    }
}