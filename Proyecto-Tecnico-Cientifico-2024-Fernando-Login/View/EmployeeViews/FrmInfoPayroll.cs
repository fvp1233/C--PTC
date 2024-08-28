using PTC2024.Controller.EmployeesController;
using PTC2024.Controller.Helper;
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
        public FrmInfoPayroll(string dui, string employee, string possition, double bonus, string backAccount, string affiliationNumber,double salary,double grossPay, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate,double christmasBonus, double issEmployer, double afpEmployer, double discountEmployer, string payrollStatus, int daysWorked, double daySalary)
        {
            InitializeComponent();
            ControllerInfoPayroll objControllerAddPayroll = new ControllerInfoPayroll(this,dui,employee,possition, bonus, backAccount, affiliationNumber, salary, grossPay, afp, isss, rent,netSalary, discountEmployee,issueDate, christmasBonus, issEmployer, afpEmployer, discountEmployer, payrollStatus, daysWorked, daySalary);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
