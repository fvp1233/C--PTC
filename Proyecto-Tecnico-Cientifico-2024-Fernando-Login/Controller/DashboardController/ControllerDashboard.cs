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
            if (currentHour.Hour >= 12 && currentHour.Hour < 15)
            {
                objDashboard.lblTime.Text = "Buenas tardes, buen provecho";
            }
            else if (currentHour.Hour >= 15 && currentHour.Hour < 18)
            {
                objDashboard.lblTime.Text = "Buenas tardes";
            }
            else if (currentHour.Hour >= 5 && currentHour.Hour <= 11)
            {
                objDashboard.lblTime.Text = "Buenos días";
            }
            else
            {
                objDashboard.lblTime.Text = "Buenas noches";
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
