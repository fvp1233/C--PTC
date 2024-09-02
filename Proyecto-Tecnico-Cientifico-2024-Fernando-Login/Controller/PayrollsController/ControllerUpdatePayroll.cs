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
        public ControllerUpdatePayroll(FrmUpdatePayroll Vista, int nP, string dui, string employee, double salary, string possition, double bonus, string bankAccount, string affiliationNumber, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, int daysWorkded, double daySalary, double grossPay, int hoursWorked, double hourSalary, int extraHours)
        {
            objUpdatePayroll = Vista;
            DisableComponents();
            ChargeValues(nP, dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, isss, afp, rent, netSalary, discountEmployee, issueDate, daysWorkded, daySalary, grossPay, hoursWorked, hourSalary, extraHours);
            objUpdatePayroll.btnConfirm.Click += new EventHandler(UpdatePayrollStatus);
            objUpdatePayroll.btnCancelar.Click += new EventHandler(CloseForm);
            objUpdatePayroll.txtHoursWorked.KeyPress += new KeyPressEventHandler(DaysWorked);
            objUpdatePayroll.txtDaysWorked.KeyPress += new KeyPressEventHandler(UpdateHoursWorked);

        }
        public void UpdatePayrollStatus(object sender, EventArgs e)
        {
            DAOUpdatePayroll daoUpdatePayroll = new DAOUpdatePayroll();
            if (int.Parse(objUpdatePayroll.txtDaysWorked.Text) <= 30 && int.Parse(objUpdatePayroll.txtDaysWorked.Text) >=0)
            {
                daoUpdatePayroll.DaysWorked = int.Parse(objUpdatePayroll.txtDaysWorked.Text.Trim());
                daoUpdatePayroll.DaySalary = double.Parse(objUpdatePayroll.txtDaySalary.Text.Trim());
                daoUpdatePayroll.HoursWorked = int.Parse(objUpdatePayroll.txtHoursWorked.Text.Trim());
                daoUpdatePayroll.HoursSalary = double.Parse(objUpdatePayroll.txtHourSalary.Text.Trim());
                daoUpdatePayroll.ExtraHours = int.Parse(objUpdatePayroll.txtExtraHours.Text.Trim());
                daoUpdatePayroll.IdPayroll = int.Parse(objUpdatePayroll.txtIdPayroll.Text.Trim());
                int value = daoUpdatePayroll.UpdatePayroll();
                if (value == 1)
                {
                    objUpdatePayroll.bunifuSnackbar1.Show(objUpdatePayroll, $"Los datos fueron actualizados de manera exitosa.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);

                }
                else
                {
                    objUpdatePayroll.bunifuSnackbar1.Show(objUpdatePayroll, $"¿Los datos no pudieron ser actualizados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

                }
                objUpdatePayroll.Close();
            }
            else
            {
                objUpdatePayroll.bunifuSnackbar1.Show(objUpdatePayroll, $"Los dias trabajados no pueden exceder los 30 dias", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
        }
        public void ChargeValues(int nP, string dui, string employee, double salary, string possition, double bonus, string bankAccount, string affiliationNumber, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, int daysWorked, double daySalary, double grossPay, int hoursWorked, double hourSalary, int extraHours)
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
                objUpdatePayroll.txtDaysWorked.Text = daysWorked.ToString();
                objUpdatePayroll.txtDaySalary.Text = daySalary.ToString();
                objUpdatePayroll.txtGrossPay.Text = grossPay.ToString();
                objUpdatePayroll.txtHoursWorked.Text = hoursWorked.ToString();
                objUpdatePayroll.txtHourSalary.Text = hourSalary.ToString();
                objUpdatePayroll.txtExtraHours.Text = extraHours.ToString();
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
            objUpdatePayroll.txtGrossPay.Enabled = false;
            objUpdatePayroll.txtDaySalary.Enabled = false;
            objUpdatePayroll.txtHourSalary.Enabled = false;

           
        }
        public void DaysWorked(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Obtén los valores actuales de horas y días trabajados
                int daysWorked = int.Parse(objUpdatePayroll.txtDaysWorked.Text.ToString());

                int hoursWorked = int.Parse(objUpdatePayroll.txtHoursWorked.Text.ToString());

                // Calcula la cantidad de días que deberían corresponder a las horas trabajadas actuales
                int calculatedDays = (int)(hoursWorked / 8);

                // Calcula la diferencia en días entre el valor actual y el nuevo cálculo
                int daysDifference = daysWorked - calculatedDays;

                // Solo actualiza los días trabajados si hay una reducción completa de 8 horas
                if (hoursWorked % 8 == 0)
                {
                    daysWorked = calculatedDays;
                }

                // Actualiza los valores en la interfaz de usuario
                objUpdatePayroll.txtDaysWorked.Text = daysWorked.ToString();
                objUpdatePayroll.txtHoursWorked.Text = hoursWorked.ToString();
            }
            catch (Exception)
            {

                objUpdatePayroll.bunifuSnackbar1.Show(objUpdatePayroll, $"Recuerda ingresar un valor valido para los dias trabajados.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }

        }
        public void UpdateHoursWorked(object sender, KeyPressEventArgs e)
        {
            // Verifica que el valor de los días trabajados sea un número válido
            int daysWorked;
            if (int.TryParse(objUpdatePayroll.txtDaysWorked.Text, out daysWorked))
            {
                // Calcula las horas trabajadas en base a los días trabajados
                int hoursWorked = daysWorked * 8;

                // Actualiza el campo de horas trabajadas en la interfaz
                objUpdatePayroll.txtHoursWorked.Text = hoursWorked.ToString();
            }
            else
            {

                objUpdatePayroll.bunifuSnackbar1.Show(objUpdatePayroll, $"Recuerda ingresar un valor valido para las horas trabajadas.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }
        }

        public void CloseForm(object sender, EventArgs e)
        {
            objUpdatePayroll.Close();

        }
    }
}
