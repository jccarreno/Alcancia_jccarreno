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
    public partial class frmEliminarBillete : Form
    {
        private clsSistema atrSistema;
        public frmEliminarBillete(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (atrSistema.recuperarBilleteCon(txtID.Text) != null)
            {
                if (atrSistema.eliminarBillete(txtID.Text))
                    MessageBox.Show("Billete eliminado correctamente");
                else
                    MessageBox.Show("No fue posible eliminar el billete");
            }
            else
                MessageBox.Show("No hay billetes registrados con esta ID");
            this.Close();
        }
    }
}
