using System;
using System.Collections.Generic;
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
            ChargeValues(username);
            objChangePassword.HidePassword.Visible = false;
            objChangePassword.btnChange.Click += new EventHandler(ChangePassword);
            objChangePassword.ShowPassword.Click += new EventHandler(ShowPassword);
            objChangePassword.HidePassword.Click += new EventHandler(HidePassword);

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
                bool passLength = ValidatePasswordLength();
                if (passLength == true)
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
                    MessageBox.Show("La contraseña debe de tener un mínimo de 6 carácteres", "Contraseña muy corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                

            }
            else
            {
                MessageBox.Show("Algunos campos se encuentran vacíos, por favor llene todos los apartados.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //método para verificar la longitud de la contraseña
        public bool ValidatePasswordLength()
        {
            if (objChangePassword.txtPassword.Text.Trim().Length >= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
    }
}
