namespace PD
{
    partial class falloDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(falloDV));
            this.rdbackup = new System.Windows.Forms.RadioButton();
            this.rbRecalcularDV = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbackup
            // 
            this.rdbackup.AutoSize = true;
            this.rdbackup.Checked = true;
            this.rdbackup.Font = new System.Drawing.Font("Pericles", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbackup.Location = new System.Drawing.Point(6, 31);
            this.rdbackup.Name = "rdbackup";
            this.rdbackup.Size = new System.Drawing.Size(242, 30);
            this.rdbackup.TabIndex = 0;
            this.rdbackup.TabStop = true;
            this.rdbackup.Text = "Restaurar Backup";
            this.rdbackup.UseVisualStyleBackColor = true;
            // 
            // rbRecalcularDV
            // 
            this.rbRecalcularDV.AutoSize = true;
            this.rbRecalcularDV.Font = new System.Drawing.Font("Pericles", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRecalcularDV.Location = new System.Drawing.Point(6, 83);
            this.rbRecalcularDV.Name = "rbRecalcularDV";
            this.rbRecalcularDV.Size = new System.Drawing.Size(209, 30);
            this.rbRecalcularDV.TabIndex = 1;
            this.rbRecalcularDV.Text = "Recalcular DV";
            this.rbRecalcularDV.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnaceptar);
            this.groupBox1.Controls.Add(this.rdbackup);
            this.groupBox1.Controls.Add(this.rbRecalcularDV);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 144);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione ";
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(274, 31);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(88, 82);
            this.btnaceptar.TabIndex = 2;
            this.btnaceptar.Text = "Siguiente";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // falloDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(413, 176);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "falloDV";
            this.Text = "fallo DV";
            this.Load += new System.EventHandler(this.falloDV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbackup;
        private System.Windows.Forms.RadioButton rbRecalcularDV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnaceptar;
    }
}