using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.formularios.login;
using PTC2024.View.Alerts;
using PTC2024.View.PasswordRecover;

namespace PTC2024.Controller.PasswordRecover
{
    internal class ControllerAdminMethod
    {
        FrmAdminMethod objAdminMethod;

        //Constructor
        public ControllerAdminMethod(FrmAdminMethod View)
        {
            objAdminMethod = View;
            objAdminMethod.btnVolver.Click += new EventHandler(Back);

        }

        public void Back(object sender, EventArgs e)
        {
            FrmRecoverPMethods openForm = new FrmRecoverPMethods();
            //Cerramos el formulario y abrimos nuevamente el formulario para seleccionar los métodos
            objAdminMethod.Close();
            openForm.Show();           
        }
    }
}
