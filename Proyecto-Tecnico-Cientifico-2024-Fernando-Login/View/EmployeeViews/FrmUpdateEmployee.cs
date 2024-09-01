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
using PTC2024.Controller.Helper;

namespace PTC2024.View.Empleados
{
    public partial class FrmUpdateEmployee : Form
    {
        //Constructor del formulario updateEmployees
        public FrmUpdateEmployee(int employeeId, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string address, double salary, string bankAccount, string bank, string affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP, int idBank, int idDepartment, int idTypeE, int idMaritalS, int idStatus, int idBusinessP, int gender)
        {
            InitializeComponent();
            ControllerUpdateEmployee objControl = new ControllerUpdateEmployee(this, employeeId, names, lastNames, dui, birthDate, email, phone, address, salary, bankAccount, bank, affiliationNumber, hireDate, department, employeeType, maritalStatus, status, username, businessP, idBank, idDepartment, idTypeE, idMaritalS, idStatus, idBusinessP, gender);
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
