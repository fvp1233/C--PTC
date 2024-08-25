using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.PasswordRecover;

namespace PTC2024.Controller.PasswordRecover
{
    internal class ControllerNextQuestionsMetod
    {
        //Creamos instancia del formulario
        FrmNextQuestionsMethod objQuestionsM;

        //Constructor
        public ControllerNextQuestionsMetod(FrmNextQuestionsMethod View, string username)
        {
            objQuestionsM = View;
        }

    }
}
