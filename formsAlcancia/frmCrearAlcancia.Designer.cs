
namespace appAlcancia.Presentacion.IGU
{
    partial class frmCrearAlcancia
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
            this.btnCreacionAlcancia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDODivisa = new System.Windows.Forms.TextBox();
            this.txtCapMonedas = new System.Windows.Forms.TextBox();
            this.txtCapBilletes = new System.Windows.Forms.TextBox();
            this.lstDenMonedas = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDenMonedas = new System.Windows.Forms.TextBox();
            this.btnAgregarDenMoneda = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarBilletes = new System.Windows.Forms.Button();
            this.txtDenBilletes = new System.Windows.Forms.TextBox();
            this.lstDenBilletes = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCreacionAlcancia
            // 
            this.btnCreacionAlcancia.Location = new System.Drawing.Point(163, 235);
            this.btnCreacionAlcancia.Name = "btnCreacionAlcancia";
            this.btnCreacionAlcancia.Size = new System.Drawing.Size(80, 23);
            this.btnCreacionAlcancia.TabIndex = 0;
            this.btnCreacionAlcancia.Text = "REGISTRAR";
            this.btnCreacionAlcancia.UseVisualStyleBackColor = true;
            this.btnCreacionAlcancia.Click += new System.EventHandler(this.btnCreacionAlcancia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID de la Divisa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Capacidad de monedas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Capacidad de billetes";
            // 
            // txtIDODivisa
            // 
            this.txtIDODivisa.Location = new System.Drawing.Point(137, 47);
            this.txtIDODivisa.Name = "txtIDODivisa";
            this.txtIDODivisa.Size = new System.Drawing.Size(191, 20);
            this.txtIDODivisa.TabIndex = 6;
            // 
            // txtCapMonedas
            // 
            this.txtCapMonedas.Location = new System.Drawing.Point(136, 83);
            this.txtCapMonedas.Name = "txtCapMonedas";
            this.txtCapMonedas.Size = new System.Drawing.Size(192, 20);
            this.txtCapMonedas.TabIndex = 7;
            // 
            // txtCapBilletes
            // 
            this.txtCapBilletes.Location = new System.Drawing.Point(137, 123);
            this.txtCapBilletes.Name = "txtCapBilletes";
            this.txtCapBilletes.Size = new System.Drawing.Size(191, 20);
            this.txtCapBilletes.TabIndex = 8;
            // 
            // lstDenMonedas
            // 
            this.lstDenMonedas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstDenMonedas.HideSelection = false;
            this.lstDenMonedas.Location = new System.Drawing.Point(405, 96);
            this.lstDenMonedas.Name = "lstDenMonedas";
            this.lstDenMonedas.Size = new System.Drawing.Size(102, 172);
            this.lstDenMonedas.TabIndex = 9;
            this.lstDenMonedas.UseCompatibleStateImageBehavior = false;
            // 
            // txtDenMonedas
            // 
            this.txtDenMonedas.Location = new System.Drawing.Point(405, 40);
            this.txtDenMonedas.Name = "txtDenMonedas";
            this.txtDenMonedas.Size = new System.Drawing.Size(102, 20);
            this.txtDenMonedas.TabIndex = 11;
            // 
            // btnAgregarDenMoneda
            // 
            this.btnAgregarDenMoneda.Location = new System.Drawing.Point(405, 67);
            this.btnAgregarDenMoneda.Name = "btnAgregarDenMoneda";
            this.btnAgregarDenMoneda.Size = new System.Drawing.Size(102, 23);
            this.btnAgregarDenMoneda.TabIndex = 12;
            this.btnAgregarDenMoneda.Text = "AGREGAR";
            this.btnAgregarDenMoneda.UseVisualStyleBackColor = true;
            this.btnAgregarDenMoneda.Click += new System.EventHandler(this.btnAgregarDenMoneda_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "DENOMINACIONES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "MONEDAS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "BILLETES";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(563, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "DENOMINACIONES";
            // 
            // btnAgregarBilletes
            // 
            this.btnAgregarBilletes.Location = new System.Drawing.Point(566, 67);
            this.btnAgregarBilletes.Name = "btnAgregarBilletes";
            this.btnAgregarBilletes.Size = new System.Drawing.Size(102, 23);
            this.btnAgregarBilletes.TabIndex = 19;
            this.btnAgregarBilletes.Text = "AGREGAR";
            this.btnAgregarBilletes.UseVisualStyleBackColor = true;
            this.btnAgregarBilletes.Click += new System.EventHandler(this.btnAgregarBilletes_Click);
            // 
            // txtDenBilletes
            // 
            this.txtDenBilletes.Location = new System.Drawing.Point(566, 40);
            this.txtDenBilletes.Name = "txtDenBilletes";
            this.txtDenBilletes.Size = new System.Drawing.Size(102, 20);
            this.txtDenBilletes.TabIndex = 18;
            // 
            // lstDenBilletes
            // 
            this.lstDenBilletes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstDenBilletes.HideSelection = false;
            this.lstDenBilletes.Location = new System.Drawing.Point(566, 96);
            this.lstDenBilletes.Name = "lstDenBilletes";
            this.lstDenBilletes.Size = new System.Drawing.Size(102, 172);
            this.lstDenBilletes.TabIndex = 17;
            this.lstDenBilletes.UseCompatibleStateImageBehavior = false;
            // 
            // frmCrearAlcancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 289);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAgregarBilletes);
            this.Controls.Add(this.txtDenBilletes);
            this.Controls.Add(this.lstDenBilletes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAgregarDenMoneda);
            this.Controls.Add(this.txtDenMonedas);
            this.Controls.Add(this.lstDenMonedas);
            this.Controls.Add(this.txtCapBilletes);
            this.Controls.Add(this.txtCapMonedas);
            this.Controls.Add(this.txtIDODivisa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreacionAlcancia);
            this.Name = "frmCrearAlcancia";
            this.Text = "CREAR ALCANCIA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreacionAlcancia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDODivisa;
        private System.Windows.Forms.TextBox txtCapMonedas;
        private System.Windows.Forms.TextBox txtCapBilletes;
        private System.Windows.Forms.ListView lstDenMonedas;
        private System.Windows.Forms.TextBox txtDenMonedas;
        private System.Windows.Forms.Button btnAgregarDenMoneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregarBilletes;
        private System.Windows.Forms.TextBox txtDenBilletes;
        private System.Windows.Forms.ListView lstDenBilletes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}