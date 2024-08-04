using PTC2024.Controller.Helper;
using PTC2024.formularios.login;
using PTC2024.Model.DAO.LogInDAO;
using PTC2024.View.formularios.inicio;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.LogInController
{
    internal class ControllerLogin
    {
        FrmLogin objLogIn;
        public ControllerLogin(FrmLogin Vista)
        {
            objLogIn = Vista;
            objLogIn.btnLoginBunifu.Click += new EventHandler(DataAccess);
            objLogIn.TxtUserBunifu.Enter += new EventHandler(EnterUsername);
            objLogIn.TxtUserBunifu.Leave += new EventHandler(LeaveUsername);
            objLogIn.txtPasswordBunifu.Enter += new EventHandler(EnterPassword);
            objLogIn.txtPasswordBunifu.Enter += new EventHandler(LeavePassword);
        }
        private void DataAccess(object sender, EventArgs e)
        {
            DAOLogin DAOData = new DAOLogin();
            CommonClasses common = new CommonClasses();
            DAOData.Username = objLogIn.TxtUserBunifu.Text;
            string encriptedpass = common.ComputeSha256Hash(objLogIn.txtPasswordBunifu.Text);
            DAOData.Password = encriptedpass;
            DAOData.UserStatus = 1;
            bool answer = DAOData.ValidarLogin();
            if (answer == true)
            {
                objLogIn.Hide();
                StartMenu startMenu = new StartMenu(objLogIn.TxtUserBunifu.Text);
                startMenu.Show();

            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void EnterUsername(object sender, EventArgs e)
        {
            if (objLogIn.TxtUserBunifu.Text.Trim().Equals("Usuario"))
            {
                objLogIn.TxtUserBunifu.Clear();
                objLogIn.TxtUserBunifu.Visible = true;
            }
        }
        private void LeaveUsername(object sender, EventArgs e)
        {
            if (objLogIn.TxtUserBunifu.Text.Trim().Equals(""))
            {
                objLogIn.TxtUserBunifu.Text = "Usuario";
            }
        }
        private void EnterPassword(object sender, EventArgs e)
        {
            if (objLogIn.txtPasswordBunifu.Text.Trim().Equals("Contraseña"))
            {
                objLogIn.txtPasswordBunifu.UseSystemPasswordChar = true;
                objLogIn.txtPasswordBunifu.Clear();
            }
        }
        private void LeavePassword(object sender, EventArgs e)
        {
            if (objLogIn.txtPasswordBunifu.Text.Trim().Equals(""))
            {
                objLogIn.txtPasswordBunifu.Text = "Contraseña";
            }
        }

    }
}
