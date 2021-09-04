namespace PD
{
    partial class ModificarUbicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarUbicacion));
            this.chkhabilitado = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtmedida = new System.Windows.Forms.TextBox();
            this.txtformula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtformato = new System.Windows.Forms.TextBox();
            this.txtnombreubicacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbmedio = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn_acept = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkhabilitado
            // 
            this.chkhabilitado.AutoSize = true;
            this.chkhabilitado.Location = new System.Drawing.Point(291, 300);
            this.chkhabilitado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkhabilitado.Name = "chkhabilitado";
            this.chkhabilitado.Size = new System.Drawing.Size(99, 19);
            this.chkhabilitado.TabIndex = 23;
            this.chkhabilitado.Text = "Habilitado";
            this.chkhabilitado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtmedida);
            this.groupBox1.Controls.Add(this.txtformula);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtformato);
            this.groupBox1.Location = new System.Drawing.Point(13, 109);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(611, 210);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo de Reglas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(11, 162);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(168, 21);
            this.txtPrecio.TabIndex = 14;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtmedida
            // 
            this.txtmedida.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmedida.Location = new System.Drawing.Point(8, 46);
            this.txtmedida.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtmedida.Name = "txtmedida";
            this.txtmedida.Size = new System.Drawing.Size(244, 21);
            this.txtmedida.TabIndex = 10;
            // 
            // txtformula
            // 
            this.txtformula.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtformula.Location = new System.Drawing.Point(280, 46);
            this.txtformula.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtformula.Multiline = true;
            this.txtformula.Name = "txtformula";
            this.txtformula.Size = new System.Drawing.Size(301, 104);
            this.txtformula.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fórmula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Medidas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Formato";
            // 
            // txtformato
            // 
            this.txtformato.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtformato.Location = new System.Drawing.Point(9, 103);
            this.txtformato.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtformato.Name = "txtformato";
            this.txtformato.Size = new System.Drawing.Size(170, 21);
            this.txtformato.TabIndex = 6;
            // 
            // txtnombreubicacion
            // 
            this.txtnombreubicacion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreubicacion.Location = new System.Drawing.Point(13, 67);
            this.txtnombreubicacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtnombreubicacion.Name = "txtnombreubicacion";
            this.txtnombreubicacion.Size = new System.Drawing.Size(244, 21);
            this.txtnombreubicacion.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre de la ubicación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Medio : ";
            // 
            // cmbmedio
            // 
            this.cmbmedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmedio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbmedio.FormattingEnabled = true;
            this.cmbmedio.Location = new System.Drawing.Point(279, 65);
            this.cmbmedio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbmedio.Name = "cmbmedio";
            this.cmbmedio.Size = new System.Drawing.Size(331, 23);
            this.cmbmedio.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(481, 325);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 38);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btn_acept
            // 
            this.btn_acept.Location = new System.Drawing.Point(265, 325);
            this.btn_acept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_acept.Name = "btn_acept";
            this.btn_acept.Size = new System.Drawing.Size(141, 38);
            this.btn_acept.TabIndex = 16;
            this.btn_acept.Text = "Aceptar";
            this.btn_acept.UseVisualStyleBackColor = true;
            this.btn_acept.Click += new System.EventHandler(this.btn_acept_Click);
            // 
            // ModificarUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(658, 374);
            this.Controls.Add(this.chkhabilitado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtnombreubicacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbmedio);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn_acept);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ModificarUbicacion";
            this.Text = "Modificar Ubicación";
            this.Load += new System.EventHandler(this.ModificarUbicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkhabilitado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmedida;
        private System.Windows.Forms.TextBox txtformula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtformato;
        private System.Windows.Forms.TextBox txtnombreubicacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbmedio;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btn_acept;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecio;
    }
}