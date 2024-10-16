﻿using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.BillsDAO;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using PTC2024.View.formularios.inicio;
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
    internal class ControllerUpdatePayroll
    {
        FrmUpdatePayroll objUpdatePayroll;
        StartMenu objStartForm;
        public ControllerUpdatePayroll(FrmUpdatePayroll Vista, int nP, string dui, string employee, double salary, string possition, double bonus, string bankAccount, string affiliationNumber, double afp, double isss, double rent, double netSalary, double discountEmployee, DateTime issueDate, int daysWorkded, double daySalary, double grossPay, int hoursWorked, double hourSalary, int extraHours)
        {
            objUpdatePayroll = Vista;
            DisableComponents();
            ChargeValues(nP, dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, isss, afp, rent, netSalary, discountEmployee, issueDate, daysWorkded, daySalary, grossPay, hoursWorked, hourSalary, extraHours);
            objUpdatePayroll.Load += new EventHandler(DarkMode);
            objUpdatePayroll.btnConfirm.Click += new EventHandler(UpdatePayrollStatus);
            objUpdatePayroll.btnCancelar.Click += new EventHandler(CloseForm);
            objUpdatePayroll.txtHoursWorked.TextChanged += new EventHandler(DaysWorked);
            objUpdatePayroll.txtDaysWorked.TextChanged += new EventHandler(UpdateHoursWorked);
            objUpdatePayroll.txtHoursWorked.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdatePayroll.txtDaysWorked.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdatePayroll.txtExtraHours.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdatePayroll.txtHoursWorked.TextChange += new EventHandler(HoursWorkedNum);
            objUpdatePayroll.txtDaysWorked.TextChange += new EventHandler(DaysWorkedNum);
            objUpdatePayroll.txtExtraHours.TextChange += new EventHandler(ExtraHoursNum);

        }

        public void DarkMode(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkMode == true)
            {
                objUpdatePayroll.BackColor = Color.FromArgb(30, 30, 30);
                objUpdatePayroll.lblTitle.ForeColor = Color.White;
                objUpdatePayroll.lblSubTitle.ForeColor = Color.White;
                objUpdatePayroll.bunifuGroupBox1.ForeColor = Color.White;
                objUpdatePayroll.bunifuGroupBox2.ForeColor = Color.White;
                objUpdatePayroll.txtEmployee.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtEmployee.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtEmployee.ForeColor = Color.White;
                objUpdatePayroll.txtDUI.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtDUI.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtDUI.ForeColor = Color.White;
                objUpdatePayroll.txtPossition.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtPossition.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtPossition.ForeColor = Color.White;
                objUpdatePayroll.txtBankAccount.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtBankAccount.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtBankAccount.ForeColor = Color.White;
                objUpdatePayroll.txtAffiliationNumber.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtAffiliationNumber.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtAffiliationNumber.ForeColor = Color.White;
                objUpdatePayroll.dtpDate.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.dtpDate.ForeColor = Color.White;
                objUpdatePayroll.dtpDate.IconColor = Color.White;
                objUpdatePayroll.txtSalary.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtSalary.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtSalary.ForeColor = Color.White;
                objUpdatePayroll.txtDaysWorked.FillColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtDaysWorked.BorderColorIdle = Color.Gray;
                objUpdatePayroll.txtDaysWorked.ForeColor = Color.White;
                objUpdatePayroll.txtDaySalary.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtDaySalary.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtDaySalary.ForeColor = Color.White;
                objUpdatePayroll.txtGrossPay.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtGrossPay.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtGrossPay.ForeColor = Color.White;
                objUpdatePayroll.txtBonus.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtBonus.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtBonus.ForeColor = Color.White;
                objUpdatePayroll.txtISSS.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtISSS.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtISSS.ForeColor = Color.White;
                objUpdatePayroll.txtAFP.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtAFP.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtAFP.ForeColor = Color.White;
                objUpdatePayroll.txtRent.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtRent.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtRent.ForeColor = Color.White;
                objUpdatePayroll.txtEmployeeDiscount.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtEmployeeDiscount.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtEmployeeDiscount.ForeColor = Color.White;
                //objUpdatePayroll.txtEmployerISSS.BackColor = Color.FromArgb(60, 60, 60);
                //objUpdatePayroll.txtEmployerISSS.LineIdleColor = Color.Gray;
                //objUpdatePayroll.txtEmployerISSS.ForeColor = Color.White;
                //objUpdatePayroll.txtEmployerAFP.BackColor = Color.FromArgb(60, 60, 60);
                //objUpdatePayroll.txtEmployerAFP.LineIdleColor = Color.Gray;
                //objUpdatePayroll.txtEmployerAFP.ForeColor = Color.White;
                //objUpdatePayroll.txtEmployerDiscount.BackColor = Color.FromArgb(60, 60, 60);
                //objUpdatePayroll.txtEmployerDiscount.LineIdleColor = Color.Gray;
                //objUpdatePayroll.txtEmployerDiscount.ForeColor = Color.White;
                //objUpdatePayroll.txtChristmasBonus.BackColor = Color.FromArgb(60, 60, 60);
                //objUpdatePayroll.txtChristmasBonus.LineIdleColor = Color.Gray;
                //objUpdatePayroll.txtChristmasBonus.ForeColor = Color.White;
                //objUpdatePayroll.txtPayrollStatus.BackColor = Color.FromArgb(60, 60, 60);
                //objUpdatePayroll.txtPayrollStatus.LineIdleColor = Color.Gray;
                //objUpdatePayroll.txtPayrollStatus.ForeColor = Color.White;
                objUpdatePayroll.txtNetSalary.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtNetSalary.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtNetSalary.ForeColor = Color.White;
                objUpdatePayroll.txtHourSalary.BackColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtHourSalary.LineIdleColor = Color.Gray;
                objUpdatePayroll.txtHourSalary.ForeColor = Color.White;
                objUpdatePayroll.txtDaysWorked.FillColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtDaysWorked.BorderColorIdle = Color.Gray;
                objUpdatePayroll.txtHoursWorked.FillColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtHoursWorked.BorderColorIdle = Color.Gray;
                objUpdatePayroll.txtExtraHours.FillColor = Color.FromArgb(60, 60, 60);
                objUpdatePayroll.txtExtraHours.BorderColorIdle = Color.Gray;
            }
        }

        public void UpdatePayrollStatus(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objUpdatePayroll.txtHoursWorked.Text.Trim()) || string.IsNullOrEmpty(objUpdatePayroll.txtDaysWorked.Text.Trim()) || string.IsNullOrEmpty(objUpdatePayroll.txtExtraHours.Text.Trim())))
            {
                DAOUpdatePayroll daoUpdatePayroll = new DAOUpdatePayroll();
                if (int.Parse(objUpdatePayroll.txtDaysWorked.Text) <= 30 && int.Parse(objUpdatePayroll.txtDaysWorked.Text) >= 0)
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
                        StartMenu objStart = new StartMenu(SessionVar.Username);
                        objStartForm = objStart;
                        objStartForm.snackBar.Show(objStartForm, $"Los datos fueron fueron actualizados exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                    }
                    else
                    {
                        StartMenu objStart = new StartMenu(SessionVar.Username);
                        objStartForm = objStart;
                        objStartForm.snackBar.Show(objStartForm, $"Los datos no pudieron ser actualizados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                    }
                    objUpdatePayroll.Close();
                }
                else
                {
                    StartMenu objStart = new StartMenu(SessionVar.Username);
                    objStartForm = objStart;
                    objStartForm.snackBar.Show(objStartForm, $"Los dias trabajados no pueden exceder los 30 días", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                }
            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Favor llenar todos los campos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
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
        public void DaysWorked(object sender, EventArgs e)
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

                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Recuerda ingresar un valor valido en los dias trabajados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }

        }
        public void UpdateHoursWorked(object sender, EventArgs e)
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

                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Recuerda ingresar un valor valido para las horas trabajadas", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
        }

        public void CloseForm(object sender, EventArgs e)
        {
            objUpdatePayroll.Close();

        }
        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
        public void DaysWorkedNum(object sender, EventArgs e)
        {
            int cursorPosition = objUpdatePayroll.txtDaysWorked.SelectionStart;
            string text = new string(objUpdatePayroll.txtDaysWorked.Text.Where(c => char.IsDigit(c)).ToArray());
            objUpdatePayroll.txtDaysWorked.Text = text;
            objUpdatePayroll.txtDaysWorked.SelectionStart = cursorPosition;
        }
        public void ExtraHoursNum(object sender, EventArgs e)
        {
            int cursorPosition = objUpdatePayroll.txtExtraHours.SelectionStart;
            string text = new string(objUpdatePayroll.txtExtraHours.Text.Where(c => char.IsDigit(c)).ToArray());
            objUpdatePayroll.txtExtraHours.Text = text;
            objUpdatePayroll.txtExtraHours.SelectionStart = cursorPosition;
        }
        public void HoursWorkedNum(object sender, EventArgs e)
        {
            int cursorPosition = objUpdatePayroll.txtHoursWorked.SelectionStart;
            string text = new string(objUpdatePayroll.txtHoursWorked.Text.Where(c => char.IsDigit(c)).ToArray());
            objUpdatePayroll.txtHoursWorked.Text = text;
            objUpdatePayroll.txtHoursWorked.SelectionStart = cursorPosition;
        }
    }
}
