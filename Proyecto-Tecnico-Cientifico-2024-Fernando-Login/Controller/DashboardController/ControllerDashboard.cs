using System.Data;
using System.Windows.Forms;
using PTC2024.Model.DAO.BillsDAO;
using PTC2024.Model.DAO.DashboardDAO;
using PTC2024.Model.DTO.DashboardDTO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Controller.Helper;
using System.IO;
using System.Drawing;
using PTC2024.View.formularios.inicio;
using System.Windows.Forms.DataVisualization.Charting;

namespace PTC2024.Controller.DashboardController
{
    internal class ControllerDashboard
    {
        FrmDashboard objDashboard;
        StartMenu objStartMenu;
        public ControllerDashboard(FrmDashboard View)
        {
            objDashboard = View;
            objDashboard.Load += new EventHandler(ChargeValues);
            objDashboard.Load += new EventHandler(LoadDataBills);
            objDashboard.btnConfirm.Click += new EventHandler(DtpSearch);
        }
        public void ChargeValues(object sender, EventArgs e)
        {
            objDashboard.dtpEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            DAODashboard dAODashboard = new DAODashboard();
            ValidateDays();
            YearRadialGauge();
            CaptureDay();
            bool refreshData = dAODashboard.LoadData(objDashboard.dtpStart.Value, objDashboard.dtpEnd.Value);
            if (refreshData == true)
            {
                ChargeData();

                dAODashboard.NumberEmployee = dAODashboard.GetNumberEmployee();
                objDashboard.lblCantEmployee.Text = dAODashboard.NumberEmployee.ToString();

                dAODashboard.NumberServices = dAODashboard.GetNumberServices();
                objDashboard.lblServices.Text = dAODashboard.NumberServices.ToString();

                dAODashboard.NumberCostumers = dAODashboard.GetNumberCustomer();
                objDashboard.lblCustomers.Text = dAODashboard.NumberCostumers.ToString();

                dAODashboard.NumberBills = dAODashboard.GetNumberBills();
                objDashboard.lblBills.Text = dAODashboard.NumberBills.ToString();

                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";
                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetAnalisys();
                //objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].ChartArea = "ChartArea1";
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";

                dAODashboard.GetSecondAnalisys();
                //objDashboard.chartPayrolls.DataSource = dAODashboard.IncomeList;
                objDashboard.chartPayrolls.Series[1].ChartArea = "ChartArea1";
                objDashboard.chartPayrolls.Series[1].XValueMember = "DateIn";
                objDashboard.chartPayrolls.Series[1].YValueMembers = "TotalIncome";

                objDashboard.chartPayrolls.Series[0].Points.DataBindXY(dAODashboard.PayrollsList, "Date", dAODashboard.PayrollsList, "TotalAmount");
                objDashboard.chartPayrolls.Series[1].Points.DataBindXY(dAODashboard.IncomeList, "DateIn", dAODashboard.IncomeList, "TotalIncome");

                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetTopServices();
                objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                objDashboard.chrtTopServices.DataBind();
            }
        }
        public void DtpSearch(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            ValidateDays();
            bool refreshData = dAODashboard.LoadData(objDashboard.dtpStart.Value, objDashboard.dtpEnd.Value);
            if (ValidateDaysEvent() == true)
            {
                if (refreshData == true)
                {
                    dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                    objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

                    ChargeData();
                    dAODashboard.GetAnalisys();
                    //objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                    objDashboard.chartPayrolls.Series[0].ChartArea = "ChartArea1";
                    objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                    objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";

                    dAODashboard.GetSecondAnalisys();
                    //objDashboard.chartPayrolls.DataSource = dAODashboard.IncomeList;
                    objDashboard.chartPayrolls.Series[1].ChartArea = "ChartArea1";
                    objDashboard.chartPayrolls.Series[1].XValueMember = "DateIn";
                    objDashboard.chartPayrolls.Series[1].YValueMembers = "TotalIncome";

                    objDashboard.chartPayrolls.Series[0].Points.DataBindXY(dAODashboard.PayrollsList, "Date", dAODashboard.PayrollsList, "TotalAmount");
                    objDashboard.chartPayrolls.Series[1].Points.DataBindXY(dAODashboard.IncomeList, "DateIn", dAODashboard.IncomeList, "TotalIncome");

                    objDashboard.chartPayrolls.DataBind();

                    dAODashboard.GetTopServices();
                    objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                    objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                    objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                    objDashboard.chrtTopServices.DataBind();
                }
            }
        }
        public void LoadDataBills(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            bool refreshData = dAODashboard.LoadData(objDashboard.dtpStart.Value, objDashboard.dtpEnd.Value);
            if (refreshData == true)
            {
                ChargeData();
            }
            if (Properties.Settings.Default.darkMode == true)
            {
                objDashboard.BackColor = Color.FromArgb(18, 18, 18);
                objDashboard.lblTitle.ForeColor = Color.White;
                objDashboard.dtpStart.BackColor = Color.FromArgb(45, 45, 45);
                objDashboard.dtpStart.ForeColor = Color.White;
                objDashboard.dtpEnd.BackColor = Color.FromArgb(45, 45, 45);
                objDashboard.dtpEnd.ForeColor = Color.White;
                objDashboard.btnConfirm.OnIdleState.BorderColor = Color.FromArgb(0, 102, 204);
                objDashboard.btnConfirm.OnIdleState.FillColor = Color.FromArgb(0, 102, 204);
                objDashboard.panel1.PanelColor = Color.FromArgb(30, 30, 30);
                objDashboard.panel2.PanelColor = Color.FromArgb(30, 30, 30);
                objDashboard.panel3.PanelColor = Color.FromArgb(30, 30, 30);
                objDashboard.panel4.PanelColor = Color.FromArgb(30, 30, 30);
                objDashboard.lblEmployee.ForeColor = Color.White;
                objDashboard.lblCantEmployee.ForeColor = Color.White;
                objDashboard.lblBill.ForeColor = Color.White;
                objDashboard.lblBills.ForeColor = Color.White;
                objDashboard.lblService.ForeColor = Color.White;
                objDashboard.lblServices.ForeColor = Color.White;
                objDashboard.lblCustom.ForeColor = Color.White;
                objDashboard.lblCustomers.ForeColor = Color.White;
                objDashboard.lblRevenue.ForeColor = Color.White;
                objDashboard.lblTotalIncome.ForeColor = Color.White;
                objDashboard.lblAudits.ForeColor = Color.White;
                objDashboard.dgvAudits.BackgroundColor = Color.FromArgb(45, 45, 45);
                objDashboard.dgvAudits.HeaderBackColor = Color.LightSlateGray;
                objDashboard.dgvAudits.GridColor = Color.FromArgb(45, 45, 45);
                objDashboard.dgvAudits.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                objDashboard.dgvAudits.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
                objDashboard.chartPayrolls.Titles[0].ForeColor = Color.White;
                objDashboard.chartPayrolls.Legends[0].ForeColor = Color.White;
                objDashboard.chrtTopServices.Titles[0].ForeColor = Color.White;
                objDashboard.chrtTopServices.Legends[0].ForeColor = Color.White;
                objDashboard.lblTime.ForeColor = Color.White;
                objDashboard.rgYearProgress.ForeColor = Color.White;
                objDashboard.panelEmployees.BackgroundColor = Color.FromArgb(45, 45, 45);
                objDashboard.panelBills.BackgroundColor = Color.FromArgb(45, 45, 45);
                objDashboard.panelServices.BackgroundColor = Color.FromArgb(45, 45, 45);
                objDashboard.panelCustom.BackgroundColor = Color.FromArgb(45, 45, 45);
                objDashboard.panelIn.BackgroundColor = Color.FromArgb(45, 45, 45);
                objDashboard.btnConfirm.IdleFillColor = Color.FromArgb(0, 102, 204);
                objDashboard.chartPayrolls.ChartAreas[0].BackColor = Color.FromArgb(45, 45, 45);
            }
        }
        public void ChargeData()
        {
            DAODashboard dAODashboard = new DAODashboard();
            bool refreshData = dAODashboard.LoadData(objDashboard.dtpStart.Value, objDashboard.dtpEnd.Value);
            if (refreshData == true)
            {
                DataSet ds = dAODashboard.GetAudits();
                //Llenando el datagridview
                objDashboard.dgvAudits.DataSource = ds.Tables["tbAudits"];
                objDashboard.dgvAudits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                objDashboard.dgvAudits.Columns[0].Visible = false;
            }

        }
        public void YearRadialGauge()
        {
            DateTime actualDay = DateTime.Now;

            DateTime firstDay = new DateTime(actualDay.Year, 1, 1);
            DateTime lastDay = new DateTime(actualDay.Year, 12, 31);

            int totalDays = (lastDay - firstDay).Days + 1;
            int days = (actualDay - firstDay).Days;

            objDashboard.rgYearProgress.Minimum = 1;
            objDashboard.rgYearProgress.Maximum = totalDays;

            objDashboard.rgYearProgress.ValueByTransition = days;

            objDashboard.rgYearProgress.WarningMark = totalDays / 2;

            objDashboard.rgYearProgress.Prefix = " Día ";

            objDashboard.rgYearProgress.ShowRangeLabels = true;
            objDashboard.rgYearProgress.ShowValueLabel = true;

            objDashboard.rgYearProgress.ValueLabelColor = Color.Black;
        }
        public void ValidateDays()
        {
            int currentYear = DateTime.Now.Year;
            objDashboard.dtpEnd.MaxDate = new DateTime(currentYear, 12, 31);
            objDashboard.dtpStart.MaxDate = new DateTime(currentYear, 12, 31);
        }
        public void CaptureDay()
        {
            DateTime currentHour = DateTime.Now;
            if (currentHour.Hour >= 12 && currentHour.Hour < 18)
            {
                objDashboard.lblTime.Text = $"Buenas tardes, {SessionVar.Username}";
            }
            else if (currentHour.Hour >= 5 && currentHour.Hour <= 11)
            {
                objDashboard.lblTime.Text = $"Buenos días, {SessionVar.Username}";
            }
            else
            {
                objDashboard.lblTime.Text = $"Buenas noches, {SessionVar.Username}";
            }
        }
        public bool ValidateDaysEvent()
        {
            StartMenu objStart = new StartMenu(SessionVar.Username);
            objStartMenu = objStart;
            if (objDashboard.dtpStart.Value > objDashboard.dtpEnd.Value)
            {
                objStartMenu.snackBar.Show(objStartMenu, $"La fecha de inicio no puede ser mayor a la fecha final ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                return false;
            }
            else if (objDashboard.dtpEnd.Value < objDashboard.dtpStart.Value)
            {
                objStartMenu.snackBar.Show(objStartMenu, $"La fecha final no puede ser menor a la fecha inicial ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
