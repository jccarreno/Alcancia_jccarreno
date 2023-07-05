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
    public partial class frmEditarBillete : Form
    {

        private clsSistema atrSistema;
        private frmRegistrarBillete ventanaRegistrarBillete;

        public frmEditarBillete(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (atrSistema.recuperarBilleteCon(txtSerial.Text) != null)
            {
                ventanaRegistrarBillete = new frmRegistrarBillete(atrSistema, txtSerial.Text);
                ventanaRegistrarBillete.ShowDialog();
            }
            else
                MessageBox.Show("No hay billetes registrados con esta ID");
            this.Close();
        }
    }
}
