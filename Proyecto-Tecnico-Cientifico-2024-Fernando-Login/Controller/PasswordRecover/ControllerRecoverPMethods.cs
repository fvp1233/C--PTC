using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.formularios.login;
using PTC2024.View.Alerts;
using PTC2024.View.login;
using PTC2024.View.PasswordRecover;

namespace PTC2024.Controller.Alerts
{
    internal class ControllerRecoverPMethods
    {
        FrmRecoverPMethods objRecoverMethods;

        public ControllerRecoverPMethods(FrmRecoverPMethods Vista)
        {
            objRecoverMethods = Vista;
            objRecoverMethods.btnVolver.Click += new EventHandler(Back);
            objRecoverMethods.btnEmailR.Click += new EventHandler(OpenEmailRecover);
            objRecoverMethods.btnQuestionsR.Click += new EventHandler(OpenQuestionsRecover);
            objRecoverMethods.btnAdminR.Click += new EventHandler(OpenAdminMethod);
        }

        public void OpenEmailRecover(object sender, EventArgs e)
        {
            FrmRecoverPasswords openForm = new FrmRecoverPasswords();
            objRecoverMethods.Hide();
            openForm.ShowDialog();
        }

        public void OpenQuestionsRecover(object sender, EventArgs e)
        {
            FrmQuestionsMethod openForm = new FrmQuestionsMethod();
            objRecoverMethods.Hide();
            openForm.ShowDialog();
            objRecoverMethods.Show();
        }

        public void OpenAdminMethod(object sender, EventArgs e)
        {
            FrmAdminMethod openForm = new FrmAdminMethod();
            objRecoverMethods.Hide();
            openForm.ShowDialog();
        }

        public void Back(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            objRecoverMethods.Close();
            login.Show();
        }

    }
}
