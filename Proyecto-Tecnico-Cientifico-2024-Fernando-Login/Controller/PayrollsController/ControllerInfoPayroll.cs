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
        public ControllerInfoPayroll(FrmInfoPayroll Vista, string dui, string employee, string possition, double bonus, string backAccount, int affiliationNumber,double salary, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, double issEmployer, double afpEmployer, double discountEmployer )
        {
            objInfoPayroll = Vista;
            ChargeValues(dui, employee, possition, bonus, backAccount, affiliationNumber, salary, afp, isss, rent, netSalary, discountEmployee, issueDate, issEmployer, afpEmployer, discountEmployer);
            objInfoPayroll.btnCancelar.Click += new EventHandler(CloseForm);
        }
        public void ChargeValues(string dui, string employee, string possition, double bonus, string backAccount, int affiliationNumber, double salary, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, double issEmployer, double afpEmployer, double discountEmployer)
        {
            try
            {
                objInfoPayroll.txtEmployee.Text = employee;
                objInfoPayroll.txtDUI.Text = dui;
                objInfoPayroll.txtPossition.Text = possition;
                objInfoPayroll.txtBanckAccount.Text = backAccount;
                objInfoPayroll.txtAffiliationNumber.Text = affiliationNumber.ToString();
                objInfoPayroll.txtSalary.Text = salary.ToString();
                objInfoPayroll.txtAFP.Text = afp.ToString();
                objInfoPayroll.txtISSS.Text = isss.ToString();
                objInfoPayroll.txtRent.Text = rent.ToString();
                objInfoPayroll.txtNetSalary.Text = netSalary.ToString();
                objInfoPayroll.txtEmployeeDiscount.Text = discountEmployee.ToString();
                objInfoPayroll.dtpDate.Value = issueDate;
                objInfoPayroll.txtEmployerISS.Text = issEmployer.ToString();
                objInfoPayroll.txtEmployerAFP.Text = afpEmployer.ToString();
                objInfoPayroll.txtEmployerDiscount.Text = discountEmployer.ToString() ;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CloseForm(object sender, EventArgs e)
        {
            objInfoPayroll.Close();
        }
    }
}
