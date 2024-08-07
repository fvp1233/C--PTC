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
            objPassword.btnSend.Click += new EventHandler(RecoverPassword);
        }

        public void RecoverPassword(object sender, EventArgs e)
        {
            string aRecover = objPassword.txtEmail.Text;
            string result = "Error";
            if (string.IsNullOrEmpty(aRecover) || aRecover.Length == 0 || aRecover == "")
            {
                MessageBox.Show("Debe ingresar su email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAORecoverPassword user = new DAORecoverPassword();
                result = user.recoverPassword(aRecover);
            }
            MessageBox.Show(result);
        }
    }
}
