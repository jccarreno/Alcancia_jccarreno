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
    public partial class frmEditarDivisa : Form
    {
        private clsSistema atrSistema;
        private frmAgregarDivisa ventanaAgregarDivisa;

        public frmEditarDivisa(clsSistema prmSitema)
        {
            InitializeComponent();
            atrSistema = prmSitema;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int varID = 0;
            try
            {
                varID = Int32.Parse(txtID.Text);
            }
            catch
            {
                MessageBox.Show("ID no valida");
                txtID.Clear();
                this.Close();
                return;
            }
            if(atrSistema.recuperarDivisaCon(varID)!=null)
            {
                ventanaAgregarDivisa = new frmAgregarDivisa(atrSistema, varID);
                ventanaAgregarDivisa.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se encontro una divisa con esta ID");
                txtID.Clear();
            }
        }
    }
}
