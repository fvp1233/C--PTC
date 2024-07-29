using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerUpdateEmployee
    {
        FrmUpdateEmployee objUpdateEmployee;
        //CONSTRUCTOR
        public ControllerUpdateEmployee(FrmUpdateEmployee View)
        {
            objUpdateEmployee = View;
            objUpdateEmployee.BtnCancelar.Click += new EventHandler(CancelProcess);
        }

        public void CancelProcess(object sender, EventArgs e)
        {
            objUpdateEmployee.Close();
        }
    }
}
