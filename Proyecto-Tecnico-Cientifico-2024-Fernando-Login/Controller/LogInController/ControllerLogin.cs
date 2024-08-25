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
using PTC2024.View.Alerts;
using PTC2024.View.login;

namespace PTC2024.Controller.LogInController
{
    internal class ControllerLogin
    {
        FrmLogin objLogIn;
        public ControllerLogin(FrmLogin Vista)
        {
            objLogIn = Vista;
            objLogIn.Load += new EventHandler(InitialCharge);
            objLogIn.btnLoginBunifu.Click += new EventHandler(DataAccess);
            objLogIn.linkRecoverPssword.Click += new EventHandler(OpenRecoverPassword);
            objLogIn.HidePassword.Click += new EventHandler(HidePassword);
            objLogIn.ShowPassword.Click += new EventHandler(ShowPassword);
            objLogIn.btnCerrar.Click += new EventHandler(Close);
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
                bool passwordFilter = ValidatePassword();
                if (passwordFilter == true)
                {
                    ChangePassword();
                    objLogIn.Hide();
                    StartMenu startMenu = new StartMenu(objLogIn.TxtUserBunifu.Text);
                    startMenu.Show();
                }
                else
                {
                    objLogIn.Hide();
                    StartMenu startMenu = new StartMenu(objLogIn.TxtUserBunifu.Text);
                    startMenu.Show();
                }              

            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region ???
        //private void EnterUsername(object sender, EventArgs e)
        //{
        //    objLogIn.lblUser.Visible = true;
        //    objLogIn.TxtUserBunifu.PlaceholderText = "";
        //}
        //private void LeaveUsername(object sender, EventArgs e)
        //{
        //    if (objLogIn.TxtUserBunifu.Text.Trim().Equals(""))
        //    {
        //        objLogIn.lblUser.Visible = false;
        //        objLogIn.TxtUserBunifu.PlaceholderText = "Usuario";
        //    }
        //}

        //private void EnterPassword(object sender, EventArgs e)
        //{
        //    objLogIn.lblPassword.Visible = true;
        //    objLogIn.txtPasswordBunifu.PlaceholderText = "";
        //}
        //private void LeavePassword(object sender, EventArgs e)
        //{
        //    if (objLogIn.txtPasswordBunifu.Text.Trim().Equals(""))
        //    {
        //        objLogIn.lblPassword.Visible = false;
        //        objLogIn.txtPasswordBunifu.PlaceholderText = "Contraseña";
        //    }
        //}
        #endregion
        public void ShowPassword(object sender, EventArgs e)
        {
            objLogIn.txtPasswordBunifu.PasswordChar = '\0';
            objLogIn.ShowPassword.Visible = false;
            objLogIn.HidePassword.Visible = true;
        }

        public void HidePassword(object sender, EventArgs e)
        {
            objLogIn.txtPasswordBunifu.PasswordChar = '*';
            objLogIn.HidePassword.Visible = false;
            objLogIn.ShowPassword.Visible = true;
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            objLogIn.txtPasswordBunifu.PasswordChar = '*';
            objLogIn.HidePassword.Visible = false;
        }

        public void ChangePassword()
        {
            //Creamos instancia del FrmPassword pasandole el parámetro que necesita, que sería el username
            FrmChangePassword abrirForm = new FrmChangePassword(objLogIn.TxtUserBunifu.Text.Trim());
            //Ahora abrimos el form
            abrirForm.FormBorderStyle = FormBorderStyle.None;
            abrirForm.ShowDialog();

        }

        //método para validar si el usuario esta ingresando con una contraseña de primer uso
        public bool ValidatePassword()
        {
            //La variable password es el texto colocado en el textbox de contraseña
            string password = objLogIn.txtPasswordBunifu.Text.Trim();
            //Si la variable es menor que 6, definitivamente es una contraseña ya actualizada y se regresa un false directamente, pero si es igual o mayor a 6 pasamos a evaluarla.
            if (password.Length >= 6)
            {
                //la variable lastFiveChars captura los últimos 5 carácteres que tenga el texto ingresado en el textbox de la contraseña
                string lastFiveChars = password.Substring(password.Length - 5);
                //Si los ultimos 5 carácteres son "PU123" entonces es una contraseña de primer uso y se retorna un true, si no, simplemente se retorna un false.
                if (lastFiveChars == "PU123" || lastFiveChars == "CR321")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
                      
        }
        public void OpenRecoverPassword(object sender, EventArgs e)
        {
            FrmRecoverPMethods objRecover = new FrmRecoverPMethods();
            objLogIn.Hide();
            objRecover.ShowDialog();
            
        }

        public void Close(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
