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
    public partial class frmInicioSesion : Form
    {
        private clsSistema atrSistema = clsSistema.darInstancia();
        private frmAdministrador ventanaAdministrador;
        private frmRegistrarAdmin ventanaRegistrarAdmin;
        private frmUsuario ventanaUsuario;

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void frmCusoGestionarDivisa_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string varUsuario=txtUsuario.Text, varPass=txtPass.Text;
            if(atrSistema.darAdministrador()==null)
            {
                MessageBox.Show("No hay un administrador registrado, registra uno para continuar");
            }
            else if (varUsuario.Equals("Admin") && varPass.Equals(atrSistema.darAdministrador().darClave()))
            {
                ventanaAdministrador = new frmAdministrador(atrSistema);
                ventanaAdministrador.ShowDialog();
            }
            else if(comprobarUsuario()!=null)
            {
                ventanaUsuario=new frmUsuario(atrSistema, comprobarUsuario());
                ventanaUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Contraseña o usuario incorrecta");
                txtPass.Clear();
            }
        }

        private void btnRegistrarAdmin_Click(object sender, EventArgs e)
        {
            ventanaRegistrarAdmin = new frmRegistrarAdmin(atrSistema);
            if (atrSistema.darAdministrador() == null)
                ventanaRegistrarAdmin.ShowDialog();
            else
                MessageBox.Show("Ya hay un administrador registrado en el sistema");
        }

        private clsAhorrador comprobarUsuario()
        {
            for(int i=0;i<atrSistema.darAhorradores().Count;i++)
            {
                if(atrSistema.darAhorradores()[i].darNombre()==txtUsuario.Text && atrSistema.darAhorradores()[i].darClave()==txtPass.Text)
                    return atrSistema.darAhorradores()[i];
            }
            return null;
        }
    }
}
