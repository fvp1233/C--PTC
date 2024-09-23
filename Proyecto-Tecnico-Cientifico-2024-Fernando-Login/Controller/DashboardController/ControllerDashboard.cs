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
            if (refreshData == true)
            {
                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

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
        public void LoadDataBills(object sender, EventArgs e)
        {
            ChargeData();
        }
        public void ChargeData()
        {
            DAOBills dAOBills = new DAOBills();
            DataSet ds = dAOBills.Bills();
            //Llenando el datagridview
            objDashboard.dgvBills.DataSource = ds.Tables["viewBill"];
            objDashboard.dgvBills.Columns[0].DividerWidth = 1;
            objDashboard.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            objDashboard.dgvBills.Columns[2].Visible = false;
            objDashboard.dgvBills.Columns[3].Visible = false;
            objDashboard.dgvBills.Columns[5].Visible = false;
            objDashboard.dgvBills.Columns[6].Visible = false;
            objDashboard.dgvBills.Columns[7].Visible = false;
            objDashboard.dgvBills.Columns[8].Visible = false;
            objDashboard.dgvBills.Columns[9].Visible = false;
            objDashboard.dgvBills.Columns[10].Visible = false;
            objDashboard.dgvBills.Columns[12].Visible = false;


            //objFormBills.dgvBills.Columns[12].Visible = false;
            objDashboard.dgvBills.Columns[13].Visible = false;
            objDashboard.dgvBills.Columns[15].Visible = false;
            objDashboard.dgvBills.Columns[14].Visible = false;
            objDashboard.dgvBills.Columns[16].Visible = false;
            objDashboard.dgvBills.Columns[17].Visible = false;
            objDashboard.dgvBills.Columns[18].Visible = false;
            objDashboard.dgvBills.Columns[19].Visible = false;

        }
        public void YearRadialGauge()
        {
            DateTime actualDay = DateTime.Now;

            DateTime firstDay = new DateTime(actualDay.Year, 1, 1);
            DateTime lastDay = new DateTime(actualDay.Year, 12, 31);

            int totalDays = (lastDay - firstDay).Days+1; 
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
            if (currentHour.Hour >=12 && currentHour.Hour < 15)
            {
                objDashboard.lblTime.Text = "Buenas tardes, buen provecho";
            }
            else if(currentHour.Hour >= 15 && currentHour.Hour < 18)
            {
                objDashboard.lblTime.Text = "Buenas tardes";
            }
            else if(currentHour.Hour >=5 && currentHour.Hour <= 11)
            {
                objDashboard.lblTime.Text = "Buenos días";
            }
            else
            {
                objDashboard.lblTime.Text = "Buenas noches";
            }
        }
    }
}
