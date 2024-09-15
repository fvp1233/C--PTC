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
using PTC2024.Model.DAO.StartMenuDAO;

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
            objLogIn.TxtUserBunifu.MouseDown += new MouseEventHandler(DisableContextMenu);
            objLogIn.txtPasswordBunifu.MouseDown += new MouseEventHandler(DisableContextMenu);
            objLogIn.TxtUserBunifu.TextChanged += new EventHandler(UsernameMask);
        }
        async private void DataAccess(object sender, EventArgs e)
        {
            await Task.Delay(500);
            DAOLogin DAOData = new DAOLogin();
            CommonClasses common = new CommonClasses();

            //Si el usuario selecciona el checkbox de recuerdame, se ejecuta este método.
            if (objLogIn.chRememberMe.Checked == true)
            {
                DAOData.Username = objLogIn.TxtUserBunifu.Text.Trim();
                string encriptedpass2 = common.ComputeSha256Hash(objLogIn.txtPasswordBunifu.Text.Trim());
                DAOData.Password = encriptedpass2;
                DAOData.UserStatus = 1;
                bool answer2 = DAOData.ValidarLogin();
                if (answer2 == true)
                {
                    //Si el acceso es correcto, entonces guardamos el token para recordar al usuario.
                    UpdateToken();
                    //validación para saber si se trata de una contraseña temporal
                    bool passwordFilter = ValidatePassword();
                    if (passwordFilter == true)
                    {
                        objLogIn.Hide();
                        ChangePassword();
                        objLogIn.TxtUserBunifu.Clear();
                        objLogIn.txtPasswordBunifu.Clear();
                        objLogIn.Show();
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
            else
            {
                //De otra forma, se inicia sesión normalmente.
                DAOData.Username = objLogIn.TxtUserBunifu.Text.Trim();
                string encriptedpass = common.ComputeSha256Hash(objLogIn.txtPasswordBunifu.Text.Trim());
                DAOData.Password = encriptedpass;
                DAOData.UserStatus = 1;
                bool answer = DAOData.ValidarLogin();
                if (answer == true)
                {                    
                    //validación para saber si se trata de una contraseña temporal
                    bool passwordFilter = ValidatePassword();
                    if (passwordFilter == true)
                    {
                        objLogIn.Hide();
                        ChangePassword();
                        objLogIn.TxtUserBunifu.Clear();
                        objLogIn.txtPasswordBunifu.Clear();
                        objLogIn.Show();
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

        //método para validar si el usuario esta ingresando con una contraseña de primer uso o una temporal
        public bool ValidatePassword()
        {
            //Creamos objeto del DAO
            DAOLogin daoLogin = new DAOLogin();
            //Creamos objeto de las commonClasses
            CommonClasses common = new CommonClasses();
            //Damos valor a los getters
            daoLogin.Username = objLogIn.TxtUserBunifu.Text;
            string encriptedpass = common.ComputeSha256Hash(objLogIn.txtPasswordBunifu.Text);
            daoLogin.Password = encriptedpass;
            daoLogin.UserStatus = 1;
            //Creamos variable bool para capturar lo que nos devuelva el método 
            bool temporalPassword = daoLogin.ValidateTemporalPassword();
            //El método captura el dato bool de la vista de la base que nos dice si es una contraseña temporal
            if (temporalPassword == true)
            {
                //si la variable es true entonces se trata de una contraseña temporal, por lo que también retornaremon un true con nuestro método.
                return true;
            }
            else
            {
                //de otra forma, significa que no se trata de una contraseña temporal, por eso devolvemos un false
                return false;
            }
        }

        //public bool ValidatePassword()
        //{
        //    //La variable password es el texto colocado en el textbox de contraseña
        //    string password = objLogIn.txtPasswordBunifu.Text.Trim();
        //    //Si la variable es menor que 6, definitivamente es una contraseña ya actualizada y se regresa un false directamente, pero si es igual o mayor a 6 pasamos a evaluarla.
        //    if (password.Length >= 6)
        //    {
        //        //la variable lastFiveChars captura los últimos 5 carácteres que tenga el texto ingresado en el textbox de la contraseña
        //        string lastFiveChars = password.Substring(password.Length - 5);
        //        //Si los ultimos 5 carácteres son "PU123" entonces es una contraseña de primer uso y se retorna un true, si no, simplemente se retorna un false.
        //        if (lastFiveChars == "PU123" || lastFiveChars == "CR321")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

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

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }

        public void UpdateToken()
        {
            //Creamos objeto del DAO
            DAOLogin daoLogin = new DAOLogin();
            //Generamos un token GUID
            string token = Guid.NewGuid().ToString();
            //Vamos a guardarlo en la base de datos con una fecha de expiración de 7 días.
            daoLogin.Token = token;
            daoLogin.TokenExpiry = DateTime.Now.AddDays(7);
            daoLogin.Username = objLogIn.TxtUserBunifu.Text.Trim();
            //ejecutamos el método del DAO
            int answer = daoLogin.RememberMe();
            if (answer == 1)
            {
                //si la respuesta es 1, el token se guardó correctamente en la base y ahora pasamos a guardarlo localmente.
                Properties.Settings.Default.Token = token;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Ocurrió un error y no se pudieron guardar sus credenciales, tendrá que volver a iniciar sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UsernameMask(object sender, EventArgs e)
        {
            //Almacena la posición original del cursor
            int cursorPosition = objLogIn.TxtUserBunifu.SelectionStart;

            //Filtra el texto del TextBox para eliminar caracteres especiales
            objLogIn.TxtUserBunifu.Text = new string(objLogIn.TxtUserBunifu.Text.Where(c => char.IsLetterOrDigit(c)).ToArray());

            //Restaura la posición del cursor
            objLogIn.TxtUserBunifu.SelectionStart = cursorPosition;
        }
    }
}
