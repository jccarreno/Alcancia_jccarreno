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
    public partial class frmAdministrador : Form
    {
        private frmAgregarDivisa ventanaAgregarDivisa;
        private frmEditarDivisa ventanaEditarDivisa;
        private frmEliminarDivisa ventanaEliminarDivisa;
        private frmAgregarAhorrador ventanaAgregarAhorrador;
        private frmEditarAhorrador ventanaEditarAhorrador;
        private frmEliminarAhorrador ventanaEliminarAhorrador;
        private frmCrearAlcancia ventanaCrearAlcancia;
        private frmRegistrarMoneda ventanaRegistrarMoneda;
        private frmEditarMoneda ventanaEditarMoneda;
        private frmEliminarMoneda ventanaEliminarMoneda;
        private frmRegistrarBillete ventanaRegistrarBillete;
        private frmEditarBillete ventanaEditarBillete;
        private frmEliminarBillete ventanaEliminarBillete;
        private clsSistema atrSistema;


        public frmAdministrador(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            actualizarLstAhorradores();
            actualizarDatosAlcancia();
            actualizarLstBilletes();
            actualizarLstDivisas();
            actualizarLstMonedas();
        }

        #region Divisas
        private void btnAgregarDivisaAdmin_Click(object sender, EventArgs e)
        {
            ventanaAgregarDivisa = new frmAgregarDivisa(atrSistema);
            ventanaAgregarDivisa.ShowDialog();
            actualizarLstDivisas();
        }

        private void actualizarLstDivisas()
        {
            lstDivisasAdmin.Items.Clear();
            for (int i = 0; i < atrSistema.darDivisas().Count; i++)
            {
                lstDivisasAdmin.Items.Add("" + atrSistema.darDivisas()[i].darIDO());
                lstDivisasAdmin.Items.Add(atrSistema.darDivisas()[i].darNombre());
                lstDivisasAdmin.Items.Add(atrSistema.darDivisas()[i].toStringDivisas());

            }
        }

        private void btnEditarDivisaAdmin_Click(object sender, EventArgs e)
        {
            ventanaEditarDivisa = new frmEditarDivisa(atrSistema);
            ventanaEditarDivisa.ShowDialog();
            actualizarLstDivisas();
        }

        private void btnEliminarDivisaAdmin_Click(object sender, EventArgs e)
        {
            ventanaEliminarDivisa = new frmEliminarDivisa(atrSistema);
            ventanaEliminarDivisa.ShowDialog();
            actualizarLstDivisas();
        }
        #endregion
        #region Ahorradores
        private void actualizarLstAhorradores()
        {
            lstAhorradoresAdmin.Items.Clear();
            for (int i = 0; i < atrSistema.darAhorradores().Count; i++)
            {
                lstAhorradoresAdmin.Items.Add(atrSistema.darAhorradores()[i].darIDO());
                lstAhorradoresAdmin.Items.Add(atrSistema.darAhorradores()[i].darNombreCompleto());
                lstAhorradoresAdmin.Items.Add(atrSistema.darAhorradores()[i].darNombre());

            }
        }
        private void btnAgregarAhorradorAdmin_Click(object sender, EventArgs e)
        {
            ventanaAgregarAhorrador = new frmAgregarAhorrador(atrSistema);
            ventanaAgregarAhorrador.ShowDialog();
            actualizarLstAhorradores();
        }

        private void btnEliminarAhorradorAdmin_Click(object sender, EventArgs e)
        {
            ventanaEliminarAhorrador = new frmEliminarAhorrador(atrSistema);
            ventanaEliminarAhorrador.ShowDialog();
            actualizarLstAhorradores();
            actualizarLstBilletes();
            actualizarLstMonedas();
        }

        private void btnEditarAhorradorAdmin_Click(object sender, EventArgs e)
        {
            ventanaEditarAhorrador = new frmEditarAhorrador(atrSistema);
            ventanaEditarAhorrador.ShowDialog();
            actualizarLstAhorradores();
        }
        #endregion
        #region Alcancia
        private void btnCrearAlcanciaAdmin_Click(object sender, EventArgs e)
        {
            if (atrSistema.darAlcancia() == null)
            {
                ventanaCrearAlcancia = new frmCrearAlcancia(atrSistema);
                ventanaCrearAlcancia.ShowDialog();
                actualizarDatosAlcancia();
            }
            else
            {
                MessageBox.Show("Ya hay una alcancia registrada en el sistema");
            }
        }
        private void actualizarDatosAlcancia()
        {
            if(atrSistema.darAlcancia()!=null)
            {
                lbCapacidadBilletes.Text = ""+atrSistema.darAlcancia().darCapacidadBilletes();
                lbCapacidadMonedas.Text = "" + atrSistema.darAlcancia().darCapacidadMonedas();
                lbDivisa.Text = "" + atrSistema.darAlcancia().darDivisa().darNombre();
                lbSaldoBilletes.Text = "" + atrSistema.darAlcancia().darSaldoBilletes();
                lbSaldoMonedas.Text = "" + atrSistema.darAlcancia().darSaldoMonedas();
                lbSaldoTotal.Text = "" + atrSistema.darAlcancia().darSaldoTotal();
            }
        }

        private void btnEditarAlcanciaAdmin_Click(object sender, EventArgs e)
        {
            if (atrSistema.darAlcancia() != null)
            {
                ventanaCrearAlcancia = new frmCrearAlcancia(atrSistema, true);
                ventanaCrearAlcancia.ShowDialog();
                actualizarDatosAlcancia();
            }
            else
            {
                MessageBox.Show("No hay una alcancia registrada en el sistema");
            }
        }

        private void btnEliminarAlcanciaAdmin_Click(object sender, EventArgs e)
        {
            if (atrSistema.darAlcancia() != null)
            {
                if (atrSistema.eliminarAlcancia())
                {
                    MessageBox.Show("La alcancia se eliminó satisfactoriamente");
                    lbCapacidadBilletes.Text = ".";
                    lbCapacidadMonedas.Text = ".";
                    lbDivisa.Text = ".";
                    lbSaldoBilletes.Text = ".";
                    lbSaldoMonedas.Text = ".";
                    lbSaldoTotal.Text = ".";
                }
                else
                    MessageBox.Show("No fue posible eliminar la alcancia, debe estar vacia");
            }
            else
                MessageBox.Show("No hay una alcancia registrada en el sistema");
        }
        #endregion
        #region Monedas
        private void btnRegistrarMoneda_Click(object sender, EventArgs e)
        {
            ventanaRegistrarMoneda = new frmRegistrarMoneda(atrSistema);
            ventanaRegistrarMoneda.ShowDialog();            
            actualizarLstMonedas();
        }

        private void btnEditarMoneda_Click(object sender, EventArgs e)
        {
            ventanaEditarMoneda = new frmEditarMoneda(atrSistema);
            ventanaEditarMoneda.ShowDialog();
            actualizarLstMonedas();
        }

        private void btnEliminarMoneda_Click(object sender, EventArgs e)
        {
            ventanaEliminarMoneda = new frmEliminarMoneda(atrSistema);
            ventanaEliminarMoneda.ShowDialog();
            actualizarLstMonedas();
        }
        private void actualizarLstMonedas()
        {
            lstMonedas.Clear();
            for (int i = 0; i < atrSistema.darMonedas().Count; i++)
            {
                lstMonedas.Items.Add("" + atrSistema.darMonedas()[i].darIDO());
                lstMonedas.Items.Add("" + atrSistema.darMonedas()[i].darDenominacion());
                lstMonedas.Items.Add("" + atrSistema.darMonedas()[i].darAhorrador().darNombreCompleto());
            }
        }
        #endregion
        #region Billetes
        private void btnRegitrarBillete_Click(object sender, EventArgs e)
        {
            ventanaRegistrarBillete = new frmRegistrarBillete(atrSistema);
            ventanaRegistrarBillete.ShowDialog();
            actualizarLstBilletes();
        }

        private void btnEditarBillete_Click(object sender, EventArgs e)
        {
            ventanaEditarBillete = new frmEditarBillete(atrSistema);
            ventanaEditarBillete.ShowDialog();
            actualizarLstBilletes();
        }

        private void btnEliminarBillete_Click(object sender, EventArgs e)
        {
            ventanaEliminarBillete = new frmEliminarBillete(atrSistema);
            ventanaEliminarBillete.ShowDialog();
            actualizarLstBilletes();
        }
        private void actualizarLstBilletes()
        {
            lstBilletes.Clear();
            for (int i = 0; i < atrSistema.darBilletes().Count; i++)
            {
                lstBilletes.Items.Add("" + atrSistema.darBilletes()[i].darIDO());
                lstBilletes.Items.Add("" + atrSistema.darBilletes()[i].darDenominacion());
                lstBilletes.Items.Add("" + atrSistema.darBilletes()[i].darAhorrador().darNombreCompleto());
            }
        }
        #endregion
    }
}
