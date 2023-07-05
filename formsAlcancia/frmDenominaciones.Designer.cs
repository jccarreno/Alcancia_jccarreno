
namespace appAlcancia.Presentacion.IGU
{
    partial class frmDenominaciones
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
            this.btnCrearDenMoneda = new System.Windows.Forms.Button();
            this.btnEliminarDenMoneda = new System.Windows.Forms.Button();
            this.btnCrearDenBillete = new System.Windows.Forms.Button();
            this.btnEliminarDenBillete = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Denominaciones de monedas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Denominaciones de billetes";
            // 
            // btnCrearDenMoneda
            // 
            this.btnCrearDenMoneda.Location = new System.Drawing.Point(22, 226);
            this.btnCrearDenMoneda.Name = "btnCrearDenMoneda";
            this.btnCrearDenMoneda.Size = new System.Drawing.Size(75, 23);
            this.btnCrearDenMoneda.TabIndex = 4;
            this.btnCrearDenMoneda.Text = "CREAR";
            this.btnCrearDenMoneda.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDenMoneda
            // 
            this.btnEliminarDenMoneda.Location = new System.Drawing.Point(136, 226);
            this.btnEliminarDenMoneda.Name = "btnEliminarDenMoneda";
            this.btnEliminarDenMoneda.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarDenMoneda.TabIndex = 5;
            this.btnEliminarDenMoneda.Text = "ELIMINAR";
            this.btnEliminarDenMoneda.UseVisualStyleBackColor = true;
            // 
            // btnCrearDenBillete
            // 
            this.btnCrearDenBillete.Location = new System.Drawing.Point(278, 226);
            this.btnCrearDenBillete.Name = "btnCrearDenBillete";
            this.btnCrearDenBillete.Size = new System.Drawing.Size(75, 23);
            this.btnCrearDenBillete.TabIndex = 6;
            this.btnCrearDenBillete.Text = "CREAR";
            this.btnCrearDenBillete.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDenBillete
            // 
            this.btnEliminarDenBillete.Location = new System.Drawing.Point(392, 226);
            this.btnEliminarDenBillete.Name = "btnEliminarDenBillete";
            this.btnEliminarDenBillete.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarDenBillete.TabIndex = 7;
            this.btnEliminarDenBillete.Text = "ELIMINAR";
            this.btnEliminarDenBillete.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(189, 160);
            this.listBox1.TabIndex = 8;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(278, 47);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(189, 160);
            this.listBox2.TabIndex = 9;
            // 
            // frmDenominaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 284);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnEliminarDenBillete);
            this.Controls.Add(this.btnCrearDenBillete);
            this.Controls.Add(this.btnEliminarDenMoneda);
            this.Controls.Add(this.btnCrearDenMoneda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDenominaciones";
            this.Text = "Denominaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrearDenMoneda;
        private System.Windows.Forms.Button btnEliminarDenMoneda;
        private System.Windows.Forms.Button btnCrearDenBillete;
        private System.Windows.Forms.Button btnEliminarDenBillete;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}