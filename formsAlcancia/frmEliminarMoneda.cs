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
    public partial class frmEliminarMoneda : Form
    {
        private clsSistema atrSistema;
        public frmEliminarMoneda(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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
            if (atrSistema.recuperarMonedaCon(varIDO) != null)
            {
                if(atrSistema.eliminarMoneda(varIDO))
                    MessageBox.Show("Moneda eliminada correctamente");
                else
                    MessageBox.Show("No fue posible eliminar la moneda\nVerifica que no se encuentre dentro de la alcancia");
            }
            else
                MessageBox.Show("No hay monedas registradas con esta ID");
            this.Close();
        }

    }
}
