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
using static Bunifu.UI.WinForms.BunifuSnackbar;

namespace PTC2024.View.Empleados
{
    public partial class FrmInfoPayroll : Form
    {
        public FrmInfoPayroll(string dui, string employee, string possition, double bonus, string backAccount, int affiliationNumber,double salary, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, double issEmployer, double afpEmployer, double discountEmployer, string payrollStatus)
        {
            InitializeComponent();
            ControllerInfoPayroll objControllerAddPayroll = new ControllerInfoPayroll(this,dui,employee,possition, bonus, backAccount, affiliationNumber, salary, afp, isss, rent,netSalary, discountEmployee,issueDate, issEmployer, afpEmployer, discountEmployer, payrollStatus);
        }

    }
}
