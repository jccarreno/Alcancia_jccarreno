
namespace appAlcancia.Presentacion.IGU
{
    partial class frmInicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNombreUsuarioLogin = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbContraseniaLogin = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegistrarAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNombreUsuarioLogin
            // 
            this.lbNombreUsuarioLogin.AutoSize = true;
            this.lbNombreUsuarioLogin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreUsuarioLogin.Location = new System.Drawing.Point(132, 14);
            this.lbNombreUsuarioLogin.Name = "lbNombreUsuarioLogin";
            this.lbNombreUsuarioLogin.Size = new System.Drawing.Size(133, 16);
            this.lbNombreUsuarioLogin.TabIndex = 0;
            this.lbNombreUsuarioLogin.Text = "Nombre de Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(59, 33);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(277, 15);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbContraseniaLogin
            // 
            this.lbContraseniaLogin.AutoSize = true;
            this.lbContraseniaLogin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContraseniaLogin.Location = new System.Drawing.Point(158, 62);
            this.lbContraseniaLogin.Name = "lbContraseniaLogin";
            this.lbContraseniaLogin.Size = new System.Drawing.Size(83, 16);
            this.lbContraseniaLogin.TabIndex = 2;
            this.lbContraseniaLogin.Text = "Contraseña";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(59, 81);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(276, 15);
            this.txtPass.TabIndex = 3;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.Location = new System.Drawing.Point(225, 116);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 24);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "INICIAR SESION";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegistrarAdmin
            // 
            this.btnRegistrarAdmin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistrarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarAdmin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarAdmin.Location = new System.Drawing.Point(59, 116);
            this.btnRegistrarAdmin.Name = "btnRegistrarAdmin";
            this.btnRegistrarAdmin.Size = new System.Drawing.Size(123, 24);
            this.btnRegistrarAdmin.TabIndex = 5;
            this.btnRegistrarAdmin.Text = "REGISTRAR ADMIN";
            this.btnRegistrarAdmin.UseVisualStyleBackColor = false;
            this.btnRegistrarAdmin.Click += new System.EventHandler(this.btnRegistrarAdmin_Click);
            // 
            // frmInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(404, 161);
            this.Controls.Add(this.btnRegistrarAdmin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbContraseniaLogin);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lbNombreUsuarioLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.frmCusoGestionarDivisa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombreUsuarioLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbContraseniaLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistrarAdmin;
    }
}

