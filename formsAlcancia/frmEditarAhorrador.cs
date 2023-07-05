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
    public partial class frmEditarAhorrador : Form
    {
        private clsSistema atrSistema;
        private frmAgregarAhorrador ventanaAgregarAhorrador;

        public frmEditarAhorrador(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(atrSistema.recuperarAhorradorCon(txtCedula.Text)!=null)
            {
                ventanaAgregarAhorrador = new frmAgregarAhorrador(atrSistema, txtCedula.Text);
                ventanaAgregarAhorrador.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay ahorradores registrados con esta cédula");
                txtCedula.Clear();
            }
        }
    }
}
