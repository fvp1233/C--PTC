using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.PasswordRecover;

namespace PTC2024.Controller.PasswordRecover
{
    internal class ControllerQuestionsMethod
    {
        FrmQuestionsMethod objQMethod;

        public ControllerQuestionsMethod(FrmQuestionsMethod Vista)
        {
            objQMethod = Vista;
            objQMethod.btnVolver.Click += new EventHandler(Back);
        }

        public void Back(object sender, EventArgs e)
        {
            objQMethod.Close();
        }
    }
}
