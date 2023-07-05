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
    public partial class frmEliminarDivisa : Form
    {
        private clsSistema atrSistema;

        public frmEliminarDivisa(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int varID=0;
            try
            {
                varID = Int32.Parse(txtID.Text);
            }
            catch
            {
                MessageBox.Show("La ID no es valida");
            }

            if(atrSistema.elminarDivisa(varID))
            {
                MessageBox.Show("Divisa eliminada");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la Divisa\nVerifica que la id sea valida y que no haya dinero ni alcancia registrada con esta divisa");
            }
        }
    }
}
