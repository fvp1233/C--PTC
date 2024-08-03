using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller;
using PTC2024.Controller.EmployeesController;

namespace PTC2024.View.Empleados
{
    public partial class FrmUpdateEmployee : Form
    {
        //Constructor del formulario updateEmployees
        public FrmUpdateEmployee(string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string adress, double salary, string bankAccount, string bank, int affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP)
        {
            InitializeComponent();
            ControllerUpdateEmployee objControl = new ControllerUpdateEmployee(this, names, lastNames, dui, birthDate, email, phone, adress, salary, bankAccount, bank, affiliationNumber, hireDate, department, employeeType, maritalStatus, status, username, businessP);
        }
    }
}
