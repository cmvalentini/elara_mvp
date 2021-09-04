namespace PD
{
    partial class ABMUbicacion
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
            this.btn_altaubicacion = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvubicaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvubicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_altaubicacion
            // 
            this.btn_altaubicacion.Location = new System.Drawing.Point(304, 263);
            this.btn_altaubicacion.Margin = new System.Windows.Forms.Padding(4);
            this.btn_altaubicacion.Name = "btn_altaubicacion";
            this.btn_altaubicacion.Size = new System.Drawing.Size(130, 41);
            this.btn_altaubicacion.TabIndex = 0;
            this.btn_altaubicacion.Text = "Alta Ubicación";
            this.btn_altaubicacion.UseVisualStyleBackColor = true;
            this.btn_altaubicacion.Click += new System.EventHandler(this.btn_altaubicacion_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(613, 263);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(4);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(124, 41);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ubicaciones";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvubicaciones
            // 
            this.dgvubicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvubicaciones.Location = new System.Drawing.Point(11, 38);
            this.dgvubicaciones.Margin = new System.Windows.Forms.Padding(4);
            this.dgvubicaciones.Name = "dgvubicaciones";
            this.dgvubicaciones.Size = new System.Drawing.Size(726, 209);
            this.dgvubicaciones.TabIndex = 3;
            this.dgvubicaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvubicaciones_CellClick);
            // 
            // ABMUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(754, 314);
            this.Controls.Add(this.dgvubicaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_altaubicacion);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "ABMUbicacion";
            this.Text = "Ubicaciones de los Medios";
            this.Load += new System.EventHandler(this.ABMUbicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvubicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_altaubicacion;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvubicaciones;
    }
}