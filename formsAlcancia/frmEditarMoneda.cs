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
    public partial class frmEditarMoneda : Form
    {
        private clsSistema atrSistema;
        private frmRegistrarMoneda ventanaRegistrarMoneda;
        public frmEditarMoneda(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int varIDO = 0;
            try
            {
                varIDO = Int32.Parse(txtID.Text);
            }
            catch
            {
                MessageBox.Show("ID ingresado no valido");
                return;
            }
            if(atrSistema.recuperarMonedaCon(varIDO)!=null)
            {
                ventanaRegistrarMoneda = new frmRegistrarMoneda(atrSistema,varIDO);
                ventanaRegistrarMoneda.ShowDialog();
            }
            else
                MessageBox.Show("No hay monedas registradas con esta ID");
            this.Close();
        }
    }
}
