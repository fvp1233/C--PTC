using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.EmployeeViews;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerInfoEmployee
    {
        FrmInfoEmployee objInfoEmployees;
        //CONSTRUCTOR 
        public ControllerInfoEmployee(FrmInfoEmployee Vista, string employee, string dui, DateTime birthDate, string adress, string phone, string email, DateTime hireDate, string maritalStatus, string typeEmployee, string statusEmployee, double salary, int affiliationNumber, string bankAccount, string username, string businessP, string department, string bank)
        {
            objInfoEmployees = Vista;
            DisableComponents();
            ChargeValues(employee, dui, birthDate, adress, phone, email, hireDate, maritalStatus, typeEmployee, statusEmployee, salary, affiliationNumber, bankAccount, username, businessP, department, bank);
            //Botón regresar
            objInfoEmployees.BtnCancelar.Click += new EventHandler(CloseForm);

        }

        public void DisableComponents()
        {
            objInfoEmployees.txtEmployee.Enabled = false;
            objInfoEmployees.txtDUI.Enabled = false;
            objInfoEmployees.dtBirthDate.Enabled = false;
            objInfoEmployees.txtAddress.Enabled = false;
            objInfoEmployees.txtPhone.Enabled = false;
            objInfoEmployees.txtEmail.Enabled = false;
            objInfoEmployees.dpHireDate.Enabled = false;
            objInfoEmployees.txtMaritalS.Enabled = false;
            objInfoEmployees.txtDepartment.Enabled = false;
            objInfoEmployees.txtEmployeeType.Enabled = false;
            objInfoEmployees.txtEmployeeStatus.Enabled = false;
            objInfoEmployees.txtSalary.Enabled = false;
            objInfoEmployees.txtAffiliationNumber.Enabled = false;
            objInfoEmployees.txtBankAccount.Enabled = false;
            objInfoEmployees.txtBank.Enabled = false;
            objInfoEmployees.txtUsername.Enabled = false;
            objInfoEmployees.txtBusinessP.Enabled = false;

        }

        public void ChargeValues(string employee, string dui, DateTime birthDate, string adress, string phone, string email, DateTime hireDate, string maritalStatus, string typeEmployee, string statusEmployee, double salary, int affiliationNumber, string bankAccount, string username, string businessP, string department, string bank)
        {
            objInfoEmployees.txtEmployee.Text = employee;
            objInfoEmployees.txtDUI.Text = dui;
            objInfoEmployees.dtBirthDate.Value = birthDate;
            objInfoEmployees.txtAddress.Text = adress;
            objInfoEmployees.txtPhone.Text = phone;
            objInfoEmployees.txtEmail.Text = email;
            objInfoEmployees.dpHireDate.Value = hireDate;
            objInfoEmployees.txtMaritalS.Text = maritalStatus;
            objInfoEmployees.txtDepartment.Text = department;
            objInfoEmployees.txtEmployeeType.Text = typeEmployee;
            objInfoEmployees.txtEmployeeStatus.Text = statusEmployee;
            objInfoEmployees.txtSalary.Text = salary.ToString();
            objInfoEmployees.txtAffiliationNumber.Text = affiliationNumber.ToString();
            objInfoEmployees.txtBankAccount.Text = bankAccount;
            objInfoEmployees.txtBank.Text = bank;
            objInfoEmployees.txtUsername.Text = username;
            objInfoEmployees.txtBusinessP.Text = businessP;
        }
        public void CloseForm(object sender, EventArgs e)
        {
            objInfoEmployees.Close();
        }

    }
}
