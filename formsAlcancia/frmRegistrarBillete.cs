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
    public partial class frmRegistrarBillete : Form
    {
        private clsSistema atrSistema;
        private string atrSerial=null;
        public frmRegistrarBillete(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }
        public frmRegistrarBillete(clsSistema prmSistema,string prmSerial)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrSerial = prmSerial;
            txtSerial.ReadOnly = true;
            txtIDODivisa.ReadOnly = true;
            txtIDAhorrador.ReadOnly = true;
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

            if (atrSerial==null)
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
                        if (atrSistema.registrarBillete(txtSerial.Text, varDenominacion, varIDODivisa, txtIDAhorrador.Text))
                            MessageBox.Show("El billete se registró correctamente");
                        else
                            MessageBox.Show("No fue posible registrar el billete");
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
                if (atrSistema.recuperarDivisaCon(varIDODivisa).darDenominaciones().Contains(varDenominacion))
                {
                    if (atrSistema.editarBillete(atrSerial, varDenominacion))
                    {
                        MessageBox.Show("El billete se editó correctamente");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo editar el billete");
                }
                else
                {
                    MessageBox.Show("La divisa no tiene esta denominacion registrada");
                }
            }
        }
    }
}
