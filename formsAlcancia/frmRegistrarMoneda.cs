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
    public partial class frmRegistrarMoneda : Form
    {
        private clsSistema atrSistema;
        private int atrIDO=-99;

        public frmRegistrarMoneda(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }
        public frmRegistrarMoneda(clsSistema prmSistema,int prmIDO)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrIDO = prmIDO;
            txtIDAhorrador.ReadOnly = true;
            txtIDODivisa.ReadOnly = true;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int varIDODivisa = 0;
            int varDenominacion = 0;
            try
            {
                varDenominacion = Int32.Parse(txtDenominaciones.Text);
            }
            catch
            {
                MessageBox.Show("La denominacion no es valida");
                return;
            }

            if (atrIDO==-99)
            {
                try
                {
                    varIDODivisa = Int32.Parse(txtIDODivisa.Text);
                }
                catch
                {
                    MessageBox.Show("La id de la divisa no es valida");
                    return;
                }
                if (atrSistema.recuperarDivisaCon(varIDODivisa) != null && atrSistema.recuperarAhorradorCon(txtIDAhorrador.Text) != null)
                {
                    if (atrSistema.recuperarDivisaCon(varIDODivisa).darDenominaciones().Contains(varDenominacion))
                    {
                        if (atrSistema.registrarMoneda(varDenominacion, varIDODivisa, txtIDAhorrador.Text))
                        {
                            MessageBox.Show("La moneda se registró correctamente");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar la moneda");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La divisa no tiene esta denominacion registrada");
                    }
                }
                else
                    MessageBox.Show("La divisa o ahorrador ingresados no están registrados en el sistema");
            }
            else
            {
                if(atrSistema.recuperarMonedaCon(atrIDO).darDivisa().darDenominaciones().Contains(varDenominacion))
                {
                    if (atrSistema.editarMoneda(atrIDO, varDenominacion))
                    {
                        MessageBox.Show("La moneda se editó correctamente");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo editar la moneda");
                }
                else
                {
                    MessageBox.Show("La divisa no tiene esta denominacion registrada");
                }
            }
        }
    }
}
