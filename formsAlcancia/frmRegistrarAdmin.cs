using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appAlcancia.Dominio;

namespace appAlcancia.Presentacion.IGU
{
    public partial class frmRegistrarAdmin : Form
    {
        private clsSistema atrSistema;
        public frmRegistrarAdmin(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (atrSistema.darAdministrador() == null)
            {
                atrSistema.registrarAdministrador(txtPass.Text);
                MessageBox.Show("Se registró el administrador");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya hay un adminstrador registrado en el sistema");
            }
        }
    }
}
