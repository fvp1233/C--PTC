using PTC2024.Model.DAO.BillsDAO;
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
    internal class ControllerUpdatePayroll
    {
        FrmUpdatePayroll objUpdatePayroll;
        public ControllerUpdatePayroll(FrmUpdatePayroll Vista, string dui, string employee, string possition, double bonus, string bankAccount, int affiliationNumber, double salary, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, string payrollStatus)
        {
            objUpdatePayroll = Vista;
            DisableComponents();
            ChargeValues(dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, afp, isss, rent, netSalary, discountEmployee, issueDate, payrollStatus);
            objUpdatePayroll.Load += new EventHandler(ChargeStatus);
            objUpdatePayroll.btnConfirm.Click += new EventHandler(UpdatePayrollStatus);
            objUpdatePayroll.btnCancelar.Click += new EventHandler(CloseForm);
        }
        public void UpdatePayrollStatus(object sender, EventArgs e)
        {
            DAOUpdatePayroll daoUpdatePayroll = new DAOUpdatePayroll();
            daoUpdatePayroll.IdPayrollStatus = (int)objUpdatePayroll.cmbPayrollStatus.SelectedValue;
            int value = daoUpdatePayroll.UpdatePayroll();
            if (value == 1)
            {
                MessageBox.Show("Los datos han sido actualizado exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
                               "Proceso interrumpido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
        public void ChargeStatus(object sender, EventArgs e)
        {
            DAOUpdatePayroll objFill = new DAOUpdatePayroll();
            DataSet ds = objFill.FillStatus();
            objUpdatePayroll.cmbPayrollStatus.DataSource = ds.Tables["tbPayrollStatus"];
            objUpdatePayroll.cmbPayrollStatus.ValueMember = "IdPayrollStatus";
            objUpdatePayroll.cmbPayrollStatus.DisplayMember = "payrollStatus";
        }
        public void ChargeValues(string dui, string employee, string possition, double bonus, string bankAccount, int affiliationNumber, double salary, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, string payrollStatus)
        {
            try
            {
                objUpdatePayroll.txtEmployee.Text = employee;
                objUpdatePayroll.txtDUI.Text = dui;
                objUpdatePayroll.txtPossition.Text = possition;
                objUpdatePayroll.txtBankAccount.Text = bankAccount;
                objUpdatePayroll.txtAffiliationNumber.Text = affiliationNumber.ToString();
                objUpdatePayroll.txtSalary.Text = salary.ToString();
                objUpdatePayroll.txtBonus.Text = bonus.ToString();
                objUpdatePayroll.txtAFP.Text = afp.ToString();
                objUpdatePayroll.txtISSS.Text = isss.ToString();
                objUpdatePayroll.txtRent.Text = rent.ToString();
                objUpdatePayroll.txtNetSalary.Text = netSalary.ToString();
                objUpdatePayroll.txtEmployeeDiscount.Text = discountEmployee.ToString();
                objUpdatePayroll.dtpDate.Value = issueDate;
                //objUpdatePayroll.txtEmployerISSS.Text = issEmployer.ToString();
                //objUpdatePayroll.txtEmployerAFP.Text = afpEmployer.ToString();
                //objUpdatePayroll.txtEmployerDiscount.Text = discountEmployer.ToString();
                objUpdatePayroll.cmbPayrollStatus.Text = payrollStatus.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DisableComponents()
        {
            objUpdatePayroll.txtEmployee.Enabled = false;
            objUpdatePayroll.txtDUI.Enabled = false;
            objUpdatePayroll.txtPossition.Enabled = false;
            objUpdatePayroll.txtBankAccount.Enabled = false;
            objUpdatePayroll.txtAffiliationNumber.Enabled = false;
            objUpdatePayroll.txtSalary.Enabled = false;
            objUpdatePayroll.txtBonus.Enabled = false;
            objUpdatePayroll.txtAFP.Enabled = false;
            objUpdatePayroll.txtISSS.Enabled = false;
            objUpdatePayroll.txtRent.Enabled = false;
            objUpdatePayroll.txtNetSalary.Enabled = false;
            objUpdatePayroll.txtEmployeeDiscount.Enabled = false;
            objUpdatePayroll.dtpDate.Enabled = false;
            objUpdatePayroll.txtEmployerISSS.Enabled = false;
            objUpdatePayroll.txtEmployerAFP.Enabled = false;
            objUpdatePayroll.txtEmployerDiscount.Enabled = false;
        }
        public void CloseForm(object sender, EventArgs e)
        {
            objUpdatePayroll.Close();

        }
    }
}
