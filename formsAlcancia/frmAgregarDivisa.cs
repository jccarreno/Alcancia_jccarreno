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
    public partial class frmAgregarDivisa : Form
    {
        private List<int> atrDenominaciones = new List<int>();
        private clsSistema atrSistema;
        private int atrIDODivisa = -99;

        public frmAgregarDivisa(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }

        public frmAgregarDivisa(clsSistema prmSistema,int prmIDODivisa)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrIDODivisa = prmIDODivisa;
            atrDenominaciones = atrSistema.recuperarDivisaCon(prmIDODivisa).darDenominaciones();
            txtNombre.Text = atrSistema.recuperarDivisaCon(prmIDODivisa).darNombre();
            actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int varDenominacion=0;
            try
            {
                varDenominacion=Int32.Parse(txtDenominacion.Text);
            }
            catch
            {
                MessageBox.Show("La denominacion no es valida");
            }
            if (!atrDenominaciones.Contains(varDenominacion))
            {
                atrDenominaciones.Add(varDenominacion);
                txtDenominacion.Clear();
                actualizar();
            }
            else
            {
                MessageBox.Show("La denominacion ya esta registrada");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (atrIDODivisa == -99)
            {
                if (atrSistema.registrarDivisa(txtNombre.Text, atrDenominaciones))
                {
                    MessageBox.Show("La Divisa " + txtNombre.Text + " se registró correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La divisa ingreada ya existe");
                    atrDenominaciones.Clear();
                    actualizar();
                    txtNombre.Clear();
                }
            }
            else
            {
                if(atrSistema.editarDivisa(atrIDODivisa,txtNombre.Text,atrDenominaciones))
                {
                    MessageBox.Show("La divisa se actualizó correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la divisa");
                }
                this.Close();
            }
        }

        private void actualizar()
        {
            lstDenominaciones.Items.Clear();
            for(int i=0;i<atrDenominaciones.Count;i++)
            {
                lstDenominaciones.Items.Add(new ListViewItem(""+atrDenominaciones[i],i));
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int varDenominacion=0;
            try
            {
                varDenominacion = Int32.Parse(txtDenominacion.Text);
            }
            catch
            {
                MessageBox.Show("La denominacion no es valida");
            }

            atrDenominaciones.Remove(varDenominacion);
            txtDenominacion.Clear();
            actualizar();
        }
    }
}
