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
    public partial class frmRecibirSerialBillete : Form
    {
        private clsSistema atrSistema;
        private clsAhorrador atrAhorrador;
        private string atrModo;
        public frmRecibirSerialBillete(clsSistema prmSistema, clsAhorrador prmAhorrador, string prmModo)
        {
            InitializeComponent();
            atrSistema = prmSistema;
            atrModo = prmModo;
            atrAhorrador = prmAhorrador;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (atrModo.Equals("agregar"))
            {
                bool varBandera = false;
                for (int i = 0; i < atrAhorrador.darBilletes().Count; i++)
                {
                    if (atrAhorrador.darBilletes()[i].darIDO().Equals(txtID.Text))
                        varBandera = true;
                }
                if (varBandera)
                {
                    if (atrSistema.ingresarBilleteAlcancia(txtID.Text))
                    {
                        MessageBox.Show("Billete ingresado con exito");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo ingresar el billete/nVerifica que no se encuentre dentro de la alcancia y que la denominacion sea valida");
                }
                else
                    MessageBox.Show("No hay un billete registrado con este serial");
            }
            else if (atrModo.Equals("eliminar"))
            {
                bool varBandera = false;
                for (int i = 0; i < atrAhorrador.darBilletes().Count; i++)
                {
                    if (atrAhorrador.darBilletes()[i].darIDO().Equals(txtID.Text))
                        varBandera = true;
                }
                if (varBandera)
                {
                    if (atrSistema.sacarBilleteAlcancia(txtID.Text))
                    {
                        MessageBox.Show("Billete retirado con exito");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo retirar el billete. Verifica que se encuentre dentro de la alcancia");
                }
                else
                    MessageBox.Show("No hay un billete registrado con este serial");
            }
        }
    }
}
