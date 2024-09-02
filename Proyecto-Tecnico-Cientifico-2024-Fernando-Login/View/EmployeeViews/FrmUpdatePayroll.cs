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

namespace PTC2024.View.Empleados
{
    public partial class FrmUpdatePayroll : Form
    {

        public FrmUpdatePayroll(int nP,string dui, string employee, double salary, string possition, double bonus, string bankAccount, string affiliationNumber, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate , int daysWorked, double daySalary, double grossPay, int hoursWorked, double hourSalary, int extraHours)
        {
            InitializeComponent();
            ControllerUpdatePayroll objUpdatePayroll = new ControllerUpdatePayroll(this, nP,dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, afp, isss, rent, netSalary, discountEmployee, issueDate , daysWorked, daySalary, grossPay, hoursWorked, hourSalary, extraHours);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Verificar si Ctrl+C o Ctrl+V se presionaron
            if (keyData == (Keys.Control | Keys.C) || keyData == (Keys.Control | Keys.V))
            {
                //Retorna true para ignorar el comando y evitar la acción de copiar o pegar
                return true;
            }

            //Llamar al método base para manejar otras teclas
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
