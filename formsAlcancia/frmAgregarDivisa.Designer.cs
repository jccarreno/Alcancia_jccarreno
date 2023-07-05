
namespace appAlcancia.Presentacion.IGU
{
    partial class frmAgregarDivisa
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDenominacion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lstDenominaciones = new System.Windows.Forms.ListView();
            this.clDenominacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCrear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Agregar denominacion";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(131, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Location = new System.Drawing.Point(131, 82);
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(100, 20);
            this.txtDenominacion.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(97, 117);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lstDenominaciones
            // 
            this.lstDenominaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clDenominacion});
            this.lstDenominaciones.HideSelection = false;
            this.lstDenominaciones.Location = new System.Drawing.Point(359, 25);
            this.lstDenominaciones.Name = "lstDenominaciones";
            this.lstDenominaciones.Size = new System.Drawing.Size(85, 184);
            this.lstDenominaciones.TabIndex = 5;
            this.lstDenominaciones.UseCompatibleStateImageBehavior = false;
            // 
            // clDenominacion
            // 
            this.clDenominacion.Text = "Denominacion";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(131, 175);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 23);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "CREAR";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Denominaciones actuales";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(190, 117);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmAgregarDivisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 222);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lstDenominaciones);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAgregarDivisa";
            this.Text = "frmAgregarDivisa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDenominacion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListView lstDenominaciones;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader clDenominacion;
        private System.Windows.Forms.Button btnEliminar;
    }
}