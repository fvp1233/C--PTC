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
                string result = "Error";
                if (string.IsNullOrEmpty(objPassword.txtEmail.Text) || objPassword.txtEmail.Text.Length == 0 || objPassword.txtEmail.Text == "")
                {
                    MessageBox.Show("Debe ingresar su email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAORecoverPassword daoRecoverPassword = new DAORecoverPassword();
                    daoRecoverPassword.User = objPassword.txtUser.Text.Trim();
                    daoRecoverPassword.Email = objPassword.txtEmail.Text.Trim();
                    result = daoRecoverPassword.recoverPassword();
                }
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
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
