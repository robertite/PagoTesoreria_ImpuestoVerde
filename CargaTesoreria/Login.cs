using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaTesoreria
{
    
    public partial class Login : Form
    {
        public static Login GetInstance()
        {

            Login login = (Login)Application.OpenForms["login"];
            if (login != null)
            {
                return login;
            }
            else
            {
                login = new Login();
                return login;
            }

        }
        public Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("") | txtContraseña.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Datos", "Error Login", MessageBoxButtons.OK);
                return;
            }

            //globalClass globalClass = new globalClass();
            //globalClass.validateUser(txtUsuario.Text, txtContraseña.Text);

            this.Hide();
            Principal principal = new Principal ();
            principal.Show();
           
            


        }

    }
}
