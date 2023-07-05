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
    public partial class frmAgregarAhorrador : Form
    {
        private clsSistema atrSistema;
        private string atrPID=null;

        public frmAgregarAhorrador(clsSistema prmSistema)
        {
            InitializeComponent();
            atrSistema = prmSistema;
        }
        public frmAgregarAhorrador(clsSistema prmSistema,string prmPID)
        {
            InitializeComponent();
            txtUsuario.ReadOnly = true;
            txtPID.ReadOnly = true;
            atrSistema = prmSistema;
            atrPID = prmPID;
            txtNombreCompleto.Text = atrSistema.recuperarAhorradorCon(atrPID).darNombreCompleto();
            txtUsuario.Text = atrSistema.recuperarAhorradorCon(atrPID).darNombre();
            txtPass.Text = atrSistema.recuperarAhorradorCon(atrPID).darClave();
            txtPID.Text = atrSistema.recuperarAhorradorCon(atrPID).darIDO();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(txtNombreCompleto.Text!="" && txtPID.Text != "" && txtUsuario.Text != "" && txtPass.Text != "")
            {
                if (atrPID == null)
                {
                    if (atrSistema.registrarAhorrador(txtPID.Text, txtUsuario.Text, txtNombreCompleto.Text, txtPass.Text))
                    {
                        MessageBox.Show("Ahorrador " + txtUsuario.Text + " registrado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("La cedula o nombre de usuario ingresados ya han sido registrados previamente");
                    }
                }
                else
                {
                    if(atrSistema.editarAhorrador(atrPID,txtNombreCompleto.Text,txtPass.Text))
                    {
                        MessageBox.Show("Ahorrador actualizado");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el ahorrador");
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser rellenados");
            }
        }
    }
}
