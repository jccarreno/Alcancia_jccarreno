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
    public partial class frmCrearAlcancia : Form
    {

        private List<int> atrDenMonedas=new List<int>();
        private List<int> atrDenBilletes = new List<int>();
        private bool atrEditar = false;
        private clsSistema atrSistema;

        
        public frmCrearAlcancia(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }
        public frmCrearAlcancia(clsSistema prmSistema, bool prmEditar)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrEditar = prmEditar;
            if(atrSistema.darAlcancia()!=null)
            {
                txtIDODivisa.Text =""+ atrSistema.darAlcancia().darDivisa().darIDO();
                txtCapMonedas.Text = "" + atrSistema.darAlcancia().darCapacidadMonedas();
                txtCapBilletes.Text = "" + atrSistema.darAlcancia().darCapacidadBilletes();
                atrDenMonedas = atrSistema.darAlcancia().darDenominacionesMonedas();
                atrDenBilletes = atrSistema.darAlcancia().darDenominacionesBilletes();
                actualizarLstBilletes();
                actualizarLstMonedas();
            }
        }

        private void btnAgregarDenMoneda_Click(object sender, EventArgs e)
        {
            int varDenominacion = 0;
            int varDivisa = 0;
            try
            {
                varDenominacion = Int32.Parse(txtDenMonedas.Text);
                varDivisa = Int32.Parse(txtIDODivisa.Text);
            }
            catch
            {
                MessageBox.Show("La denominacion o la id de la divisa no es valida");
            }
            if (!atrDenMonedas.Contains(varDenominacion))
            {
                if (atrSistema.recuperarDivisaCon(varDivisa) != null)
                {
                    if (atrSistema.recuperarDivisaCon(varDivisa).darDenominaciones().Contains(varDenominacion))
                    {
                        atrDenMonedas.Add(varDenominacion);
                        txtDenMonedas.Clear();
                        actualizarLstMonedas();
                    }
                    else
                        MessageBox.Show("La divisa no tiene esta denominacion registrada");
                }
                else
                    MessageBox.Show("La id de la divisa no es valida");
            }
            else
            {
                MessageBox.Show("La denominacion ya esta registrada");
            }
        }
        private void btnAgregarBilletes_Click(object sender, EventArgs e)
        {
            int varDenominacion = 0;
            int varDivisa = 0;
            try
            {
                varDenominacion = Int32.Parse(txtDenBilletes.Text);
                varDivisa = Int32.Parse(txtIDODivisa.Text);
            }
            catch
            {
                MessageBox.Show("La denominacion no es valida");
            }
            if (!atrDenBilletes.Contains(varDenominacion))
            {
                if (atrSistema.recuperarDivisaCon(varDivisa).darDenominaciones().Contains(varDenominacion))
                {
                    atrDenBilletes.Add(varDenominacion);
                    txtDenBilletes.Clear();
                    actualizarLstBilletes();
                }
                else
                    MessageBox.Show("La divisa no tiene esta denominacion registrada");
            }
            else
            {
                MessageBox.Show("La denominacion ya esta registrada");
            }
        }
        private void actualizarLstMonedas()
        {
            lstDenMonedas.Clear();
            for(int i=0;i<atrDenMonedas.Count;i++)
            {
                lstDenMonedas.Items.Add(""+atrDenMonedas[i]);
            }
        }
        private void actualizarLstBilletes()
        {
            lstDenBilletes.Clear();
            for (int i = 0; i < atrDenBilletes.Count; i++)
            {
                lstDenBilletes.Items.Add("" + atrDenBilletes[i]);
            }
        }
        private void btnCreacionAlcancia_Click(object sender, EventArgs e)
        {
            int varCapMonedas = 0;
            int varCapBilletes = 0;
            int varIDODivisa = 0;
            try
            {
                varCapMonedas = Int32.Parse(txtCapMonedas.Text);
            }
            catch
            {
                MessageBox.Show("La capacidad de monedas ingresada no es valida");
                txtCapMonedas.Clear();
                return;
            }
            try
            {
                varCapBilletes = Int32.Parse(txtCapBilletes.Text);
            }
            catch
            {
                MessageBox.Show("La capacidad de billetes ingresada no es valida");
                txtCapBilletes.Clear();
                return;
            }
            try
            {
                varIDODivisa = Int32.Parse(txtIDODivisa.Text);
            }
            catch
            {
                MessageBox.Show("La ID de la divisa ingresada no es valida");
                txtIDODivisa.Clear();
                return;
            }

            if (!atrEditar)
            {
                if (atrSistema.registrarAlcancia(varIDODivisa, varCapMonedas, varCapBilletes, atrDenMonedas, atrDenBilletes))
                {
                    MessageBox.Show("La alcancia se creo correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo crear alcancia\nVerifica que las denominaciones y la divisa sean validas");
                }
            }
            else
            {
                if (atrSistema.editarAlcancia(varIDODivisa, varCapMonedas, varCapBilletes, atrDenMonedas, atrDenBilletes))
                {
                    MessageBox.Show("La alcancia se edito correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo editar alcancia\nVerifica que los datos sean validos respecto al dinero que hay dentro");
                    this.Close();
                }
            }
        }
    }
}
