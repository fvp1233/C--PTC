using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ControllerInfoPayroll(FrmInfoPayroll Vista, string dui, string employee, string possition, double bonus, string bankAccount, int affiliationNumber,double salary, double grossPay, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, double christmasBonus, double issEmployer, double afpEmployer, double discountEmployer,string payrollStatus, int daysWorked, double daySalary)
        {
            objInfoPayroll = Vista;
            DisableComponents();
            ChargeValues(dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, grossPay, afp, isss, rent, netSalary, discountEmployee, issueDate, christmasBonus, issEmployer, afpEmployer, discountEmployer, payrollStatus, daysWorked, daySalary);
            objInfoPayroll.btnCancelar.Click += new EventHandler(CloseForm);
        }
        public void ChargeValues(string dui, string employee, string possition, double bonus, string bankAccount, int affiliationNumber, double salary,  double grossPay, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate,double christmasBonus, double issEmployer, double afpEmployer, double discountEmployer, string payrollStatus, int daysWorked, double daySalary)
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