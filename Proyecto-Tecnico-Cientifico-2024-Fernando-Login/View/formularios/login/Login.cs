using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.View.formularios.inicio;

namespace PTC2024.formularios.login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Fernando" && txtPassword.Text =="1234" )
            { 
                Inicio inicio = new Inicio();
                this.Hide();
                inicio.Show();
            }
            else
            {
                MessageBox.Show ("Datos erroneos");
                txtUser.Clear();
                txtPassword.Clear();
            }
        }

        

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.Black;
            }
        }


        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            { txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;

            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
