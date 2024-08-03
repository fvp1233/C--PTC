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
        Login objLogIn;
        public ControllerLogin(Login Vista)
        {
            objLogIn = Vista;
            objLogIn.btnLoginBunifu.Click += new EventHandler(DataAccess);
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
    }
}
