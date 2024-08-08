using PTC2024.formularios.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using PTC2024.View.login;
using Microsoft.VisualBasic.ApplicationServices;
using PTC2024.Model.DAO.LogInDAO;

namespace PTC2024.Controller.LogInController
{
    internal class ControllerRecoverPassword
    {
        FrmRecoverPasswords objPassword;
        public ControllerRecoverPassword(FrmRecoverPasswords View)
        {
            objPassword = View;
            objPassword.btnConfirm.Click += new EventHandler(RecoverPassword);
        }

        public void RecoverPassword(object sender, EventArgs e)
        {
            bool validateAnswer = AccessRecover();
            if (validateAnswer == true)
            {
                string result = "Hubo un error al intentar realizar la recuperación de contraseña.";
                //validación de campos vacíos
                if (string.IsNullOrEmpty(objPassword.txtEmail.Text) ||
                    string.IsNullOrEmpty(objPassword.txtUser.Text))
                {
                    MessageBox.Show("Existen campos vacíos, llene todos los apartados.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAORecoverPassword daoRecoverPassword = new DAORecoverPassword();
                    daoRecoverPassword.User = objPassword.txtUser.Text.Trim();
                    daoRecoverPassword.Email = objPassword.txtEmail.Text.Trim();
                    result = daoRecoverPassword.RecoverPassword();
                }
                MessageBox.Show(result, "Recuperación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objPassword.Close();
            }
            else
            {
                MessageBox.Show("No hay ningún usuario en el sistema registrado con el correo ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        //
        public bool AccessRecover()
        {
            DAORecoverPassword DAORecover = new DAORecoverPassword();
            DAORecover.User = objPassword.txtUser.Text.Trim();
            DAORecover.Email = objPassword.txtEmail.Text.Trim();
            bool answer = DAORecover.ValidateCredentials();

            return answer;
        }
    }
}
