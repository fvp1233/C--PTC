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
            if (TxtUserBunifu.Text == "Fernando" && txtPasswordBunifu.Text =="1234" )
            { 
                StartMenu inicio = new StartMenu();
                this.Hide();
                inicio.Show();
            }
            else
            {
                MessageBox.Show ("Datos erroneos");
                TxtUserBunifu.Clear();
                txtPasswordBunifu.Clear();
            }
        }





        //Bunifu
      
      

       

        private void TxtUserBunifu_Leave(object sender, EventArgs e)
        {
            if (TxtUserBunifu.Text == "")
            {
                TxtUserBunifu.Text = "Usuario";
                TxtUserBunifu.ForeColor = Color.Black;
            }
        }

        private void txtPasswordBunifu_Enter(object sender, EventArgs e)
        {
            if (txtPasswordBunifu.Text == "Contraseña")
            {
                txtPasswordBunifu.Text = "";
                txtPasswordBunifu.ForeColor = Color.Black;
                txtPasswordBunifu.UseSystemPasswordChar = true;

            }
        }

        private void txtPasswordBunifu_Leave(object sender, EventArgs e)
        {
            if (txtPasswordBunifu.Text == "")
            {
                txtPasswordBunifu.Text = "Contraseña";
                txtPasswordBunifu.ForeColor = Color.Black;
                txtPasswordBunifu.UseSystemPasswordChar = false;
            }
        }

        private void TxtUserBunifu_Enter(object sender, EventArgs e)
        {
            if (TxtUserBunifu.Text == "Usuario")
            {
                TxtUserBunifu.Text = "";
                TxtUserBunifu.ForeColor = Color.Black;
            }
        }

        private void btnLoginBunifu_Click(object sender, EventArgs e)
        {
            if (TxtUserBunifu.Text == "Fernando" && txtPasswordBunifu.Text == "1234")
            {
                StartMenu inicio = new StartMenu();
                this.Hide();
                inicio.Show();
            }
            else
            {
                MessageBox.Show("Datos erroneos");
                TxtUserBunifu.Clear();
                txtPasswordBunifu.Clear();
            }

        }

        public static implicit operator System.Web.UI.WebControls.Login(Login v)
        {
            throw new NotImplementedException();
        }
    }
}
