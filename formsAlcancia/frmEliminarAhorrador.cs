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
    public partial class frmEliminarAhorrador : Form
    {
        private clsSistema atrSistema;

        public frmEliminarAhorrador(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(atrSistema.recuperarAhorradorCon(txtID.Text)!=null)
            {
                if(atrSistema.eliminarAhorrador(txtID.Text))
                    MessageBox.Show("El ahorrador se eliminó correctamente");
                else
                    MessageBox.Show("No se pudo eliminar el ahorrador\nVerifica que no tenga dinero ingresado en la alcancia");
            }
            else
            {
                MessageBox.Show("El ahorrador ingresado no existe");
            }
            this.Close();
        }
    }
}
