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
        public ControllerUpdatePayroll(FrmUpdatePayroll Vista, int nP, string dui, string employee, double salary, string possition, double bonus, string bankAccount, int affiliationNumber, double afp, double isss, double rent, double netSalary,double discountEmployee, DateTime issueDate, string payrollStatus)
        {
            objUpdatePayroll = Vista;
            DisableComponents();
            ChargeValues(nP,dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, isss, afp, rent, netSalary,discountEmployee, issueDate, payrollStatus);
            objUpdatePayroll.Load += new EventHandler(ChargeStatus);
            objUpdatePayroll.btnConfirm.Click += new EventHandler(UpdatePayrollStatus);
            objUpdatePayroll.btnCancelar.Click += new EventHandler(CloseForm);
        }
        public void UpdatePayrollStatus(object sender, EventArgs e)
        {
            try
            {
                DAOUpdatePayroll daoUpdatePayroll = new DAOUpdatePayroll();
                daoUpdatePayroll.IdPayrollStatus = (int)objUpdatePayroll.cmbPayrollStatus.SelectedValue;
                daoUpdatePayroll.IdPayroll = int.Parse(objUpdatePayroll.txtIdPayroll.Text.Trim());
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
                    MessageBox.Show("Los datos no pudieron ser actualizados. Verifica los valores ingresados.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        //public void UpdatePayrollStatus(object sender, EventArgs e)
        //{
        //    DAOUpdatePayroll daoUpdatePayroll = new DAOUpdatePayroll();
        //    daoUpdatePayroll.IdPayrollStatus = (int)objUpdatePayroll.cmbPayrollStatus.SelectedValue;
        //    int value = daoUpdatePayroll.UpdatePayroll();
        //    if (value == 1)
        //    {
        //        MessageBox.Show("Los datos han sido actualizado exitosamente",
        //                        "Proceso completado",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Los datos no pudieron ser actualizados debido a un erroraso",
        //                       "Proceso interrumpido",
        //                       MessageBoxButtons.OK,
        //                       MessageBoxIcon.Error);
        //    }
        //}
        public void ChargeStatus(object sender, EventArgs e)
        {
            DAOUpdatePayroll objFill = new DAOUpdatePayroll();
            DataSet ds = objFill.FillStatus();
            objUpdatePayroll.cmbPayrollStatus.DataSource = ds.Tables["tbPayrollStatus"];
            objUpdatePayroll.cmbPayrollStatus.ValueMember = "IdPayrollStatus";
            objUpdatePayroll.cmbPayrollStatus.DisplayMember = "payrollStatus";
        }
        public void ChargeValues(int nP,string dui, string employee, double salary, string possition, double bonus, string bankAccount, int affiliationNumber, double afp, double isss, double rent, double netSalary,double discountEmployee, DateTime issueDate, string payrollStatus)
        {
            try
            {
                objUpdatePayroll.txtIdPayroll.Text = nP.ToString();
                objUpdatePayroll.txtEmployee.Text = employee;
                objUpdatePayroll.txtDUI.Text = dui;
                objUpdatePayroll.txtPossition.Text = possition;
                objUpdatePayroll.txtBankAccount.Text = bankAccount;
                objUpdatePayroll.txtAffiliationNumber.Text = affiliationNumber.ToString();
                objUpdatePayroll.txtSalary.Text = salary.ToString();
                objUpdatePayroll.txtBonus.Text = bonus.ToString();
                objUpdatePayroll.txtISSS.Text = isss.ToString();
                objUpdatePayroll.txtAFP.Text = afp.ToString();
                objUpdatePayroll.txtRent.Text = rent.ToString();
                objUpdatePayroll.txtNetSalary.Text = netSalary.ToString();
                objUpdatePayroll.txtEmployeeDiscount.Text = discountEmployee.ToString();
                objUpdatePayroll.dtpDate.Value = issueDate;
                objUpdatePayroll.cmbPayrollStatus.Text = payrollStatus.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DisableComponents()
        {
            objUpdatePayroll.txtIdPayroll.Visible = false;
            objUpdatePayroll.txtIdPayroll.Enabled = false;
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
