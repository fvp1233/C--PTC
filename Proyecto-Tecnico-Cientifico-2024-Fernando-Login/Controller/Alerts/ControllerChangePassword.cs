using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.AlertsDAO;
using PTC2024.View.Alerts;

namespace PTC2024.Controller.Alerts
{
    internal class ControllerChangePassword
    {
        FrmChangePassword objChangePassword;
        public ControllerChangePassword(FrmChangePassword Vista, string username) 
        {
            //Métodos que se ejecutarán al mostrar el formulario
            objChangePassword = Vista;
            objChangePassword.Load += new EventHandler(DarkMode);
            ChargeValues(username);
            objChangePassword.HidePassword.Visible = false;
            objChangePassword.btnChange.Click += new EventHandler(ChangePassword);
            objChangePassword.ShowPassword.Click += new EventHandler(ShowPassword);
            objChangePassword.HidePassword.Click += new EventHandler(HidePassword);
            objChangePassword.txtUsername.MouseDown += new MouseEventHandler(DisableContextMenu);
            objChangePassword.txtPassword.MouseDown += new MouseEventHandler(DisableContextMenu);
            objChangePassword.txtConfirmPass.MouseDown += new MouseEventHandler(DisableContextMenu);

        }

        public void DarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objChangePassword.BackColor = Color.FromArgb(30, 30, 30);
                objChangePassword.lblTitle.ForeColor = Color.White;
                objChangePassword.lblSubTitle.ForeColor = Color.White;
                objChangePassword.lblPass2.ForeColor = Color.White;
                objChangePassword.lblPass.ForeColor = Color.White;
                objChangePassword.bunifuSeparator1.LineColor = Color.White;
            }
        }

        public void ChargeValues(string username)
        {
            try
            {
                objChangePassword.txtUsername.Text = username;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangePassword(object sender, EventArgs e)
        {
            //Creamos objeto de la clase DAO y de la clase CommonClasses
            DAOChangePassword daoChangePassword = new DAOChangePassword();
            CommonClasses commonClasses = new CommonClasses();
            //validación de que todos los campos estén llenos
            if (!(string.IsNullOrEmpty(objChangePassword.txtPassword.Text.Trim()) ||
                string.IsNullOrEmpty(objChangePassword.txtConfirmPass.Text.Trim()) 
                ))
            {
                //validación de la longitud de la contraseña
                if (commonClasses.IsValid(objChangePassword.txtPassword.Text) == true && commonClasses.IsValid(objChangePassword.txtConfirmPass.Text) == true)
                {
                    //validación de que la confirmación de la contraseña sea correcta
                    if (objChangePassword.txtPassword.Text.Trim() == objChangePassword.txtConfirmPass.Text.Trim())
                    {
                        //Ahora pasamos a darles valor a los métodos getter
                        daoChangePassword.Username = objChangePassword.txtUsername.Text.Trim();
                        daoChangePassword.Password = commonClasses.ComputeSha256Hash(objChangePassword.txtPassword.Text.Trim());
                        //creamos una variable int que guardará la respuesta que nos devuelve el método en el DAO
                        int answer = daoChangePassword.ChangePassword();
                        //evaluamos la variable
                        if (answer == 1)
                        {
                            MessageBox.Show("Se cambió la contraseña correctamente \n\n Porfavor inicie sesión nuevamente.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            objChangePassword.Close();
                        }
                        else
                        {
                            MessageBox.Show("La contraseña no pudo ser actualizada", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            objChangePassword.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La confirmación de la contraseña no es la misma, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("La contrasela debe tener al menos 8 caracteres, una mayuscula, un numero y un caracter", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                

            }
            else
            {
                MessageBox.Show("Algunos campos se encuentran vacíos, por favor llene todos los apartados.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //método para verificar la longitud de la contraseña

        public void ShowPassword(object sender, EventArgs e)
        {
            objChangePassword.txtPassword.PasswordChar = '\0';
            objChangePassword.ShowPassword.Visible = false;
            objChangePassword.HidePassword.Visible = true;
        }

        public void HidePassword(object sender, EventArgs e)
        {
            objChangePassword.txtPassword.PasswordChar = '*';
            objChangePassword.HidePassword.Visible = false;
            objChangePassword.ShowPassword.Visible = true;
        }

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
    }
}
