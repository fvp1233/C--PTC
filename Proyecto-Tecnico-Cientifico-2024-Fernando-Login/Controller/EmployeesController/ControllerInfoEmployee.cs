using System;
using System.Collections.Generic;
using System.Drawing;
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
        public ControllerInfoEmployee(FrmInfoEmployee Vista, string names, string lastNames, string dui, DateTime birthDate, string adress, string phone, string email, DateTime hireDate, string maritalStatus, string typeEmployee, string statusEmployee, double salary, int affiliationNumber, string bankAccount, string username, string businessP, string department, string bank)
        {
            objInfoEmployees = Vista;
            DisableComponents();
            objInfoEmployees.Load += new EventHandler(DarkMode);
            ChargeValues(names, lastNames, dui, birthDate, adress, phone, email, hireDate, maritalStatus, typeEmployee, statusEmployee, salary, affiliationNumber, bankAccount, username, businessP, department, bank);
            //Botón regresar
            objInfoEmployees.BtnCancelar.Click += new EventHandler(CloseForm);

        }

        public void DisableComponents()
        {
            objInfoEmployees.txtNames.Enabled = false;
            objInfoEmployees.txtLastNames.Enabled = false;
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

        public void ChargeValues(string names, string lastNames, string dui, DateTime birthDate, string adress, string phone, string email, DateTime hireDate, string maritalStatus, string typeEmployee, string statusEmployee, double salary, int affiliationNumber, string bankAccount, string username, string businessP, string department, string bank)
        {
            objInfoEmployees.txtNames.Text = names;
            objInfoEmployees.txtLastNames.Text = lastNames;
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

        public void DarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode)
            {
                objInfoEmployees.BackColor = Color.FromArgb(30, 30, 30);
                objInfoEmployees.lblTitle.ForeColor = Color.White;
                objInfoEmployees.groupBox1.ForeColor = Color.White;
                objInfoEmployees.groupBox2.ForeColor = Color.White;
                objInfoEmployees.groupBox3.ForeColor = Color.White;
                objInfoEmployees.bunifuSeparator1.LineColor = Color.White;
                objInfoEmployees.txtNames.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtNames.LineIdleColor = Color.Gray;
                objInfoEmployees.txtNames.ForeColor = Color.White;
                objInfoEmployees.txtLastNames.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtLastNames.LineIdleColor = Color.Gray;
                objInfoEmployees.txtLastNames.ForeColor = Color.White;
                objInfoEmployees.txtDUI.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtDUI.LineIdleColor = Color.Gray;
                objInfoEmployees.txtDUI.ForeColor = Color.White;
                objInfoEmployees.dtBirthDate.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.dtBirthDate.ForeColor = Color.White;
                objInfoEmployees.dtBirthDate.IconColor = Color.White;
                objInfoEmployees.txtAddress.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtAddress.LineIdleColor = Color.Gray;
                objInfoEmployees.txtPhone.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtPhone.LineIdleColor = Color.Gray;
                objInfoEmployees.txtEmail.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtEmail.LineIdleColor = Color.Gray;
                objInfoEmployees.dpHireDate.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.dpHireDate.ForeColor = Color.White;
                objInfoEmployees.dpHireDate.IconColor = Color.White;
                objInfoEmployees.txtMaritalS.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtMaritalS.LineIdleColor = Color.Gray;
                objInfoEmployees.txtDepartment.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtDepartment.LineIdleColor = Color.Gray;
                objInfoEmployees.txtEmployeeStatus.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtEmployeeStatus.LineIdleColor = Color.Gray;
                objInfoEmployees.txtEmployeeType.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtEmployeeType.LineIdleColor = Color.Gray;
                objInfoEmployees.txtSalary.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtSalary.LineIdleColor = Color.Gray;
                objInfoEmployees.txtAffiliationNumber.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtAffiliationNumber.LineIdleColor = Color.Gray;
                objInfoEmployees.txtBankAccount.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtBankAccount.LineIdleColor = Color.Gray;
                objInfoEmployees.txtBank.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtBank.LineIdleColor = Color.Gray;
                objInfoEmployees.txtUsername.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtUsername.LineIdleColor = Color.Gray;
                objInfoEmployees.txtBusinessP.BackColor = Color.FromArgb(60, 60, 60);
                objInfoEmployees.txtBusinessP.LineIdleColor = Color.Gray;
            }
        }
    }
}
