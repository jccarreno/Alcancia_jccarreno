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
    public partial class frmRecibirIDMoneda : Form
    {
        private clsSistema atrSistema;
        private clsAhorrador atrAhorrador;
        private string atrModo;
        public frmRecibirIDMoneda(clsSistema prmSistema,clsAhorrador prmAhorrador, string prmModo)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrModo = prmModo;
            atrAhorrador = prmAhorrador;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int varID = 0;
            try
            {
                varID = Int32.Parse(txtID.Text);
            }
            catch
            {
                MessageBox.Show("ID de la moneda no valido");
                return;
            }
            if(atrModo.Equals("agregar"))
            {
                bool varBandera = false;
                for(int i=0;i<atrAhorrador.darMonedas().Count;i++)
                {
                    if(atrAhorrador.darMonedas()[i].darIDO()==varID)
                        varBandera = true;
                }
                if (varBandera)
                {
                    if (atrSistema.ingresarMonedaAlcancia(varID))
                    {
                        MessageBox.Show("Moneda ingresada con exito");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo ingresar la moneda/nVerifica que no se encuentre dentro de la alcancia\nY que la denominacion sea valida");
                }
                else
                    MessageBox.Show("No hay moneda registrada con esta ID");
            }
            else if(atrModo.Equals("eliminar"))
            {
                bool varBandera = false;
                for (int i = 0; i < atrAhorrador.darMonedas().Count; i++)
                {
                    if (atrAhorrador.darMonedas()[i].darIDO() == varID)
                        varBandera = true;
                }
                if (varBandera)
                {
                    if (atrSistema.sacarMonedaAlcancia(varID))
                    {
                        MessageBox.Show("Moneda retirada con exito");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo ingresar la moneda/nVerifica que se encuentre dentro de la alcancia\nY que la denominacion sea valida");
                }
                else
                    MessageBox.Show("No hay moneda registrada con esta ID");
            }
        }
    }
}
