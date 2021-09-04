namespace PD
{
    partial class LogIn
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblClave = new System.Windows.Forms.Label();
            this.CheckCambiarClave = new System.Windows.Forms.CheckBox();
            this.txtClaveAtn = new System.Windows.Forms.TextBox();
            this.txtClaveNew = new System.Windows.Forms.TextBox();
            this.LblClaveAnterior = new System.Windows.Forms.Label();
            this.LblClaveNueva = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(110, 47);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(240, 21);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsuario_Validating);
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(110, 100);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(240, 21);
            this.txtClave.TabIndex = 1;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.Validating += new System.ComponentModel.CancelEventHandler(this.txtClave_Validating);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(63, 152);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(115, 48);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(250, 152);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 48);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(40, 50);
            this.LblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(62, 15);
            this.LblUsuario.TabIndex = 4;
            this.LblUsuario.Text = "Usuario";
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Location = new System.Drawing.Point(52, 103);
            this.LblClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(45, 15);
            this.LblClave.TabIndex = 5;
            this.LblClave.Text = "Clave";
            // 
            // CheckCambiarClave
            // 
            this.CheckCambiarClave.AutoSize = true;
            this.CheckCambiarClave.Location = new System.Drawing.Point(63, 234);
            this.CheckCambiarClave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckCambiarClave.Name = "CheckCambiarClave";
            this.CheckCambiarClave.Size = new System.Drawing.Size(122, 19);
            this.CheckCambiarClave.TabIndex = 6;
            this.CheckCambiarClave.Text = "Cambiar Clave";
            this.CheckCambiarClave.UseVisualStyleBackColor = true;
            this.CheckCambiarClave.CheckedChanged += new System.EventHandler(this.CheckCambiarClave_CheckedChanged);
            // 
            // txtClaveAtn
            // 
            this.txtClaveAtn.Location = new System.Drawing.Point(112, 285);
            this.txtClaveAtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtClaveAtn.Name = "txtClaveAtn";
            this.txtClaveAtn.PasswordChar = '*';
            this.txtClaveAtn.Size = new System.Drawing.Size(263, 22);
            this.txtClaveAtn.TabIndex = 7;
            this.txtClaveAtn.UseSystemPasswordChar = true;
            // 
            // txtClaveNew
            // 
            this.txtClaveNew.Location = new System.Drawing.Point(112, 327);
            this.txtClaveNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtClaveNew.Name = "txtClaveNew";
            this.txtClaveNew.PasswordChar = '*';
            this.txtClaveNew.Size = new System.Drawing.Size(263, 22);
            this.txtClaveNew.TabIndex = 8;
            this.txtClaveNew.UseSystemPasswordChar = true;
            this.txtClaveNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtClaveNew_Validating);
            this.txtClaveNew.Validated += new System.EventHandler(this.txtClaveNew_Validated);
            // 
            // LblClaveAnterior
            // 
            this.LblClaveAnterior.AutoSize = true;
            this.LblClaveAnterior.Location = new System.Drawing.Point(8, 285);
            this.LblClaveAnterior.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClaveAnterior.Name = "LblClaveAnterior";
            this.LblClaveAnterior.Size = new System.Drawing.Size(113, 15);
            this.LblClaveAnterior.TabIndex = 9;
            this.LblClaveAnterior.Text = "Clave Anterior:";
            // 
            // LblClaveNueva
            // 
            this.LblClaveNueva.AutoSize = true;
            this.LblClaveNueva.Location = new System.Drawing.Point(8, 330);
            this.LblClaveNueva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClaveNueva.Name = "LblClaveNueva";
            this.LblClaveNueva.Size = new System.Drawing.Size(96, 15);
            this.LblClaveNueva.TabIndex = 10;
            this.LblClaveNueva.Text = "Clave Nueva:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(180, 367);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(115, 36);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PD.Properties.Resources.graybackground;
            this.ClientSize = new System.Drawing.Size(425, 265);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.LblClaveNueva);
            this.Controls.Add(this.LblClaveAnterior);
            this.Controls.Add(this.txtClaveNew);
            this.Controls.Add(this.txtClaveAtn);
            this.Controls.Add(this.CheckCambiarClave);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.CheckBox CheckCambiarClave;
        private System.Windows.Forms.TextBox txtClaveAtn;
        private System.Windows.Forms.TextBox txtClaveNew;
        private System.Windows.Forms.Label LblClaveAnterior;
        private System.Windows.Forms.Label LblClaveNueva;
        private System.Windows.Forms.Button btnConfirmar;
    }
}