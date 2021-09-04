namespace PD
{
    partial class CrearNegocio
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumeropedido = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.cmbmedio = new System.Windows.Forms.ComboBox();
            this.cmbubicacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btncalcularprecio = new System.Windows.Forms.Button();
            this.txtprints = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabnegocio = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbagencia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mcpublicacion = new System.Windows.Forms.MonthCalendar();
            this.tabnegocio.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Publicación : ";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(12, 300);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(708, 88);
            this.txtdescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 282);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción del anuncio:";
            // 
            // lblNumeropedido
            // 
            this.lblNumeropedido.AutoSize = true;
            this.lblNumeropedido.Font = new System.Drawing.Font("Pericles", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeropedido.Location = new System.Drawing.Point(512, 13);
            this.lblNumeropedido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeropedido.Name = "lblNumeropedido";
            this.lblNumeropedido.Size = new System.Drawing.Size(100, 23);
            this.lblNumeropedido.TabIndex = 4;
            this.lblNumeropedido.Text = "numero";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pericles", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(326, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Orden de Pedido:";
            // 
            // btn_grabar
            // 
            this.btn_grabar.Location = new System.Drawing.Point(330, 404);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(140, 40);
            this.btn_grabar.TabIndex = 6;
            this.btn_grabar.Text = "Grabar Negocio";
            this.btn_grabar.UseVisualStyleBackColor = true;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(580, 404);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(140, 40);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // cmbmedio
            // 
            this.cmbmedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmedio.FormattingEnabled = true;
            this.cmbmedio.Items.AddRange(new object[] {
            "--Sin Asignar--"});
            this.cmbmedio.Location = new System.Drawing.Point(10, 30);
            this.cmbmedio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbmedio.Name = "cmbmedio";
            this.cmbmedio.Size = new System.Drawing.Size(211, 23);
            this.cmbmedio.TabIndex = 8;
            this.cmbmedio.TextChanged += new System.EventHandler(this.cmbmedio_TextChanged);
            // 
            // cmbubicacion
            // 
            this.cmbubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbubicacion.FormattingEnabled = true;
            this.cmbubicacion.Location = new System.Drawing.Point(234, 30);
            this.cmbubicacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbubicacion.Name = "cmbubicacion";
            this.cmbubicacion.Size = new System.Drawing.Size(230, 23);
            this.cmbubicacion.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ubicación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Medio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Alta de Negocio";
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(301, 81);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(142, 22);
            this.txtprecio.TabIndex = 13;
            this.txtprecio.Text = "0.00";
            this.txtprecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecio_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Pericles", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(280, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio Publicación ";
            // 
            // btncalcularprecio
            // 
            this.btncalcularprecio.Location = new System.Drawing.Point(39, 94);
            this.btncalcularprecio.Name = "btncalcularprecio";
            this.btncalcularprecio.Size = new System.Drawing.Size(137, 47);
            this.btncalcularprecio.TabIndex = 15;
            this.btncalcularprecio.Text = "Calcular Precio";
            this.btncalcularprecio.UseVisualStyleBackColor = true;
            this.btncalcularprecio.Click += new System.EventHandler(this.btncalcularprecio_Click);
            // 
            // txtprints
            // 
            this.txtprints.Location = new System.Drawing.Point(20, 45);
            this.txtprints.Name = "txtprints";
            this.txtprints.Size = new System.Drawing.Size(171, 22);
            this.txtprints.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Impresiones: ";
            // 
            // tabnegocio
            // 
            this.tabnegocio.Controls.Add(this.tabPage1);
            this.tabnegocio.Controls.Add(this.tabPage2);
            this.tabnegocio.Location = new System.Drawing.Point(12, 39);
            this.tabnegocio.Name = "tabnegocio";
            this.tabnegocio.SelectedIndex = 0;
            this.tabnegocio.Size = new System.Drawing.Size(507, 217);
            this.tabnegocio.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbagencia);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbmedio);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbubicacion);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(499, 189);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Página1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbagencia
            // 
            this.cmbagencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbagencia.FormattingEnabled = true;
            this.cmbagencia.Location = new System.Drawing.Point(10, 109);
            this.cmbagencia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbagencia.Name = "cmbagencia";
            this.cmbagencia.Size = new System.Drawing.Size(454, 23);
            this.cmbagencia.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 91);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Agencia: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtprecio);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btncalcularprecio);
            this.tabPage2.Controls.Add(this.txtprints);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(499, 189);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Página 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mcpublicacion
            // 
            this.mcpublicacion.Location = new System.Drawing.Point(528, 90);
            this.mcpublicacion.Name = "mcpublicacion";
            this.mcpublicacion.TabIndex = 18;
            // 
            // CrearNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(726, 456);
            this.Controls.Add(this.mcpublicacion);
            this.Controls.Add(this.tabnegocio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumeropedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdescripcion);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CrearNegocio";
            this.Text = "";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabnegocio.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumeropedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_grabar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.ComboBox cmbmedio;
        private System.Windows.Forms.ComboBox cmbubicacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btncalcularprecio;
        private System.Windows.Forms.TextBox txtprints;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabnegocio;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MonthCalendar mcpublicacion;
        private System.Windows.Forms.ComboBox cmbagencia;
        private System.Windows.Forms.Label label9;
    }
}