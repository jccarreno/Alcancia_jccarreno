
namespace appAlcancia.Presentacion.IGU
{
    partial class frmRegistrarBillete
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtDenominaciones = new System.Windows.Forms.TextBox();
            this.txtIDAhorrador = new System.Windows.Forms.TextBox();
            this.txtIDODivisa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(109, 196);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 15;
            this.btnCrear.Text = "REGITRAR";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtDenominaciones
            // 
            this.txtDenominaciones.Location = new System.Drawing.Point(119, 139);
            this.txtDenominaciones.Name = "txtDenominaciones";
            this.txtDenominaciones.Size = new System.Drawing.Size(127, 20);
            this.txtDenominaciones.TabIndex = 14;
            // 
            // txtIDAhorrador
            // 
            this.txtIDAhorrador.Location = new System.Drawing.Point(119, 105);
            this.txtIDAhorrador.Name = "txtIDAhorrador";
            this.txtIDAhorrador.Size = new System.Drawing.Size(127, 20);
            this.txtIDAhorrador.TabIndex = 13;
            // 
            // txtIDODivisa
            // 
            this.txtIDODivisa.Location = new System.Drawing.Point(119, 74);
            this.txtIDODivisa.Name = "txtIDODivisa";
            this.txtIDODivisa.Size = new System.Drawing.Size(127, 20);
            this.txtIDODivisa.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Denominacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ID del ahorrador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "IDO Divisa:";
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(119, 39);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(127, 20);
            this.txtSerial.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Serial:";
            // 
            // frmRegistrarBillete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 231);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtDenominaciones);
            this.Controls.Add(this.txtIDAhorrador);
            this.Controls.Add(this.txtIDODivisa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRegistrarBillete";
            this.Text = "Registrar billete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtDenominaciones;
        private System.Windows.Forms.TextBox txtIDAhorrador;
        private System.Windows.Forms.TextBox txtIDODivisa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label4;
    }
}