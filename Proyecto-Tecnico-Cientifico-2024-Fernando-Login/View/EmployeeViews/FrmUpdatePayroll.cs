using PTC2024.Controller.EmployeesController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Empleados
{
    public partial class FrmUpdatePayroll : Form
    {

        public FrmUpdatePayroll(string dui, string employee, double salary, string possition, double bonus, string bankAccount, int affiliationNumber, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate , string payrollStatus)
        {
            InitializeComponent();
            ControllerUpdatePayroll objUpdatePayroll = new ControllerUpdatePayroll(this, dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, afp, isss, rent, netSalary, discountEmployee, issueDate , payrollStatus);
        }
    }
}
