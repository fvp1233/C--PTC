using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerInfoPayroll
    {
        FrmInfoPayroll objInfoPayroll;
        //dui,employee,possition,bonus,banckAccount,affiliationNumber,afp,isss,rent, netSalary, discountEmployee, issueDate, issEmployer,afpEmployer, discountEmployer)
        public ControllerInfoPayroll(FrmInfoPayroll Vista, string dui, string employee, string possition, double bonus, string bankAccount, string affiliationNumber,double salary, double grossPay, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, double christmasBonus, double issEmployer, double afpEmployer, double discountEmployer,string payrollStatus, int daysWorked, double daySalary)
        {
            objInfoPayroll = Vista;
            DisableComponents();
            objInfoPayroll.Load += new EventHandler(DarkMode);
            ChargeValues(dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, grossPay, afp, isss, rent, netSalary, discountEmployee, issueDate, christmasBonus, issEmployer, afpEmployer, discountEmployer, payrollStatus, daysWorked, daySalary);
            objInfoPayroll.btnCancelar.Click += new EventHandler(CloseForm);
        }
        public void ChargeValues(string dui, string employee, string possition, double bonus, string bankAccount, string affiliationNumber, double salary,  double grossPay, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate,double christmasBonus, double issEmployer, double afpEmployer, double discountEmployer, string payrollStatus, int daysWorked, double daySalary)
        {
            try
            {
                objInfoPayroll.txtEmployee.Text = employee;
                objInfoPayroll.txtDUI.Text = dui;
                objInfoPayroll.txtPossition.Text = possition;
                objInfoPayroll.txtBankAccount.Text = bankAccount;
                objInfoPayroll.txtAffiliationNumber.Text = affiliationNumber.ToString();
                objInfoPayroll.txtSalary.Text = salary.ToString();
                objInfoPayroll.txtBonus.Text = bonus.ToString();
                objInfoPayroll.txtAFP.Text = afp.ToString();
                objInfoPayroll.txtISSS.Text = isss.ToString();
                objInfoPayroll.txtRent.Text = rent.ToString();
                objInfoPayroll.txtNetSalary.Text = netSalary.ToString();
                objInfoPayroll.txtEmployeeDiscount.Text = discountEmployee.ToString();
                objInfoPayroll.dtpDate.Value = issueDate;
                objInfoPayroll.txtChristmasBonus.Text = christmasBonus.ToString();
                objInfoPayroll.txtEmployerISSS.Text = issEmployer.ToString();
                objInfoPayroll.txtEmployerAFP.Text = afpEmployer.ToString();
                objInfoPayroll.txtEmployerDiscount.Text = discountEmployer.ToString();
                objInfoPayroll.txtPayrollStatus.Text = payrollStatus.ToString();
                objInfoPayroll.txtDaySalary.Text = daySalary.ToString();
                objInfoPayroll.txtDaysWorked.Text = daysWorked.ToString();
                objInfoPayroll.txtGrossPay.Text = grossPay.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objInfoPayroll.BackColor = Color.FromArgb(30, 30, 30);
                objInfoPayroll.lblPayroll.ForeColor = Color.White;
                objInfoPayroll.bunifuGroupBox1.ForeColor = Color.White;
                objInfoPayroll.bunifuGroupBox2.ForeColor = Color.White;
                objInfoPayroll.bunifuSeparator1.LineColor = Color.White;
                objInfoPayroll.txtEmployee.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtEmployee.LineIdleColor = Color.Gray;
                objInfoPayroll.txtEmployee.ForeColor = Color.White;
                objInfoPayroll.txtDUI.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtDUI.LineIdleColor = Color.Gray;
                objInfoPayroll.txtDUI.ForeColor = Color.White;
                objInfoPayroll.txtPossition.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtPossition.LineIdleColor = Color.Gray;
                objInfoPayroll.txtPossition.ForeColor = Color.White;
                objInfoPayroll.txtBankAccount.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtBankAccount.LineIdleColor = Color.Gray;
                objInfoPayroll.txtBankAccount.ForeColor = Color.White;
                objInfoPayroll.txtAffiliationNumber.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtAffiliationNumber.LineIdleColor = Color.Gray;
                objInfoPayroll.txtAffiliationNumber.ForeColor = Color.White;
                objInfoPayroll.dtpDate.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.dtpDate.ForeColor = Color.White;
                objInfoPayroll.dtpDate.IconColor = Color.White;
                objInfoPayroll.txtSalary.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtSalary.LineIdleColor = Color.Gray;
                objInfoPayroll.txtSalary.ForeColor = Color.White;
                objInfoPayroll.txtDaysWorked.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtDaysWorked.LineIdleColor = Color.Gray;
                objInfoPayroll.txtDaysWorked.ForeColor = Color.White;
                objInfoPayroll.txtDaySalary.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtDaySalary.LineIdleColor = Color.Gray;
                objInfoPayroll.txtDaySalary.ForeColor = Color.White;
                objInfoPayroll.txtGrossPay.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtGrossPay.LineIdleColor = Color.Gray;
                objInfoPayroll.txtGrossPay.ForeColor = Color.White;
                objInfoPayroll.txtBonus.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtBonus.LineIdleColor = Color.Gray;
                objInfoPayroll.txtBonus.ForeColor = Color.White;
                objInfoPayroll.txtISSS.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtISSS.LineIdleColor = Color.Gray;
                objInfoPayroll.txtISSS.ForeColor = Color.White;
                objInfoPayroll.txtAFP.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtAFP.LineIdleColor = Color.Gray;
                objInfoPayroll.txtAFP.ForeColor = Color.White;
                objInfoPayroll.txtRent.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtRent.LineIdleColor = Color.Gray;
                objInfoPayroll.txtRent.ForeColor = Color.White;
                objInfoPayroll.txtEmployeeDiscount.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtEmployeeDiscount.LineIdleColor = Color.Gray;
                objInfoPayroll.txtEmployeeDiscount.ForeColor = Color.White;
                objInfoPayroll.txtEmployerISSS.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtEmployerISSS.LineIdleColor = Color.Gray;
                objInfoPayroll.txtEmployerISSS.ForeColor = Color.White;
                objInfoPayroll.txtEmployerAFP.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtEmployerAFP.LineIdleColor = Color.Gray;
                objInfoPayroll.txtEmployerAFP.ForeColor = Color.White;
                objInfoPayroll.txtEmployerDiscount.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtEmployerDiscount.LineIdleColor = Color.Gray;
                objInfoPayroll.txtEmployerDiscount.ForeColor = Color.White;
                objInfoPayroll.txtChristmasBonus.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtChristmasBonus.LineIdleColor = Color.Gray;
                objInfoPayroll.txtChristmasBonus.ForeColor = Color.White;
                objInfoPayroll.txtPayrollStatus.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtPayrollStatus.LineIdleColor = Color.Gray;
                objInfoPayroll.txtPayrollStatus.ForeColor = Color.White;
                objInfoPayroll.txtNetSalary.BackColor = Color.FromArgb(60, 60, 60);
                objInfoPayroll.txtNetSalary.LineIdleColor = Color.Gray;
                objInfoPayroll.txtNetSalary.ForeColor = Color.White;
            }
        }

        public void DisableComponents()
        {
            objInfoPayroll.txtEmployee.Enabled = false;
            objInfoPayroll.txtDUI.Enabled = false;
            objInfoPayroll.txtPossition.Enabled = false;
            objInfoPayroll.txtBankAccount.Enabled = false;
            objInfoPayroll.txtAffiliationNumber.Enabled = false;
            objInfoPayroll.txtSalary.Enabled = false;
            objInfoPayroll.txtBonus.Enabled = false;
            objInfoPayroll.txtAFP.Enabled = false;
            objInfoPayroll.txtISSS.Enabled = false;
            objInfoPayroll.txtRent.Enabled = false;
            objInfoPayroll.txtNetSalary.Enabled=false;
            objInfoPayroll.txtEmployeeDiscount.Enabled = false;
            objInfoPayroll.dtpDate.Enabled =false;
            objInfoPayroll.txtEmployerISSS.Enabled = false;
            objInfoPayroll.txtEmployerAFP.Enabled = false;
            objInfoPayroll.txtEmployerDiscount.Enabled=false;
            objInfoPayroll.txtPayrollStatus.Enabled = false;
            objInfoPayroll.txtChristmasBonus.Enabled = false;
            objInfoPayroll.txtDaysWorked.Enabled = false;
            objInfoPayroll.txtDaySalary.Enabled = false;
            objInfoPayroll.txtGrossPay.Enabled = false;
        }
        public void CloseForm(object sender, EventArgs e)
        {
            objInfoPayroll.Close();
        }
    }
}