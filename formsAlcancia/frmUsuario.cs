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
    public partial class frmUsuario : Form
    {
        private clsSistema atrSistema;
        private clsAhorrador atrAhorrador;
        private frmRecibirIDMoneda ventanaIDmoneda;
        private frmRecibirSerialBillete ventanaSerialBillete;

        public frmUsuario(clsSistema prmSistema,clsAhorrador prmAhorrador)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrAhorrador = prmAhorrador;
            actualizarLstMonedasAlcancia();
            actualizarLstMonedasBolsillo();
            actualizarLstBilletesAlcancia();
            actualizarLstBilletesBolsillo();
            actualizarDatosBolsillo();
            actualizarDatosAlcancia();
        }

        #region Saldos
        private void actualizarDatosBolsillo()
        {
            lbConteoMonedasBolsillo.Text = "" + atrAhorrador.darConteoMonedasBolsillo();
            lbConteoBilletesBolsillo.Text = "" + atrAhorrador.darConteoBilletesBolsillo();
        }
        private void actualizarDatosAlcancia()
        {
            lbSaldoTotalAlcancia.Text = "" + atrAhorrador.darSaldoTotalAlcancia();
            lbSaldoMonedasAlcancia.Text = "" + atrAhorrador.darSaldoMonedasAlcancia();
            lbSaldoBilletesAlcancia.Text = "" + atrAhorrador.darSaldoBilletesAlcancia();
            lbConteoMonedasAlcancia.Text = "" + atrAhorrador.darConteoMonedasAlcancia();
            lbConteoBilletesAlcancia.Text = "" + atrAhorrador.darConteoBilletesAlcancia();
            lbDivisaAlcancia.Text = "" + atrSistema.darAlcancia().darDivisa().darNombre();
        }
        #endregion

        #region Alcancia

        #endregion

        private void btnAgregarMoneda_Click(object sender, EventArgs e)
        {
            if (!atrSistema.darAlcancia().hayEspacioMonedas())
                MessageBox.Show("No hay espacio disponible en la alcancia");
            else
            {
                ventanaIDmoneda = new frmRecibirIDMoneda(atrSistema, atrAhorrador, "agregar");
                ventanaIDmoneda.ShowDialog();
                actualizarLstMonedasAlcancia();
                actualizarLstMonedasBolsillo();
                actualizarDatosBolsillo();
                actualizarDatosAlcancia();
            }
        }

        private void btnSacarMoneda_Click(object sender, EventArgs e)
        {
            ventanaIDmoneda = new frmRecibirIDMoneda(atrSistema, atrAhorrador, "eliminar");
            ventanaIDmoneda.ShowDialog();
            actualizarLstMonedasAlcancia();
            actualizarLstMonedasBolsillo();
            actualizarDatosBolsillo();
            actualizarDatosAlcancia();
        }

        private void btnAgregarBillete_Click(object sender, EventArgs e)
        {
            if (!atrSistema.darAlcancia().hayEspacioBilletes())
                MessageBox.Show("No hay espacio disponible en la alcancia");
            else
            {
                ventanaSerialBillete = new frmRecibirSerialBillete(atrSistema, atrAhorrador, "agregar");
                ventanaSerialBillete.ShowDialog();
                actualizarLstBilletesAlcancia();
                actualizarLstBilletesBolsillo();
                actualizarDatosBolsillo();
                actualizarDatosAlcancia();
            }
        }

        private void btnSacarBillete_Click(object sender, EventArgs e)
        {
            ventanaSerialBillete = new frmRecibirSerialBillete(atrSistema, atrAhorrador, "eliminar");
            ventanaSerialBillete.ShowDialog();
            actualizarLstBilletesAlcancia();
            actualizarLstBilletesBolsillo();
            actualizarDatosBolsillo();
            actualizarDatosAlcancia();
        }
        private void actualizarLstMonedasAlcancia()
        {
            lstMonedas.Clear();
            for (int i = 0; i < atrAhorrador.darMonedas().Count; i++)
            {
                if (atrAhorrador.darMonedas()[i].darAlcancia() != null)
                {
                    lstMonedas.Items.Add("" + atrAhorrador.darMonedas()[i].darIDO());
                    lstMonedas.Items.Add("" + atrAhorrador.darMonedas()[i].darDenominacion());
                    lstMonedas.Items.Add("" + atrAhorrador.darMonedas()[i].darDivisa().darNombre());
                }
            }
        }
        private void actualizarLstBilletesAlcancia()
        {
            lstBilletes.Clear();
            for (int i = 0; i < atrAhorrador.darBilletes().Count; i++)
            {
                if (atrAhorrador.darBilletes()[i].darAlcancia() != null)
                {
                    lstBilletes.Items.Add("" + atrAhorrador.darBilletes()[i].darIDO());
                    lstBilletes.Items.Add("" + atrAhorrador.darBilletes()[i].darDenominacion());
                    lstBilletes.Items.Add("" + atrAhorrador.darBilletes()[i].darDivisa().darNombre());
                }
            }
        }
        private void actualizarLstMonedasBolsillo()
        {
            lstMonedasBolsillo.Clear();
            for (int i = 0; i < atrAhorrador.darMonedas().Count; i++)
            {
                if (atrAhorrador.darMonedas()[i].darAlcancia() == null)
                {
                    lstMonedasBolsillo.Items.Add("" + atrAhorrador.darMonedas()[i].darIDO());
                    lstMonedasBolsillo.Items.Add("" + atrAhorrador.darMonedas()[i].darDenominacion());
                    lstMonedasBolsillo.Items.Add("" + atrAhorrador.darMonedas()[i].darDivisa().darNombre());
                }
            }
        }
        private void actualizarLstBilletesBolsillo()
        {
            lstBilletesBolsillo.Clear();
            for (int i = 0; i < atrAhorrador.darBilletes().Count; i++)
            {
                if (atrAhorrador.darBilletes()[i].darAlcancia() == null)
                {
                    lstBilletesBolsillo.Items.Add("" + atrAhorrador.darBilletes()[i].darIDO());
                    lstBilletesBolsillo.Items.Add("" + atrAhorrador.darBilletes()[i].darDenominacion());
                    lstBilletesBolsillo.Items.Add("" + atrAhorrador.darBilletes()[i].darDivisa().darNombre());
                }
            }
        }
    }
}
