using PTC2024.Model.DAO.DashboardDAO;
using PTC2024.Model.DTO.DashboardDTO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.DashboardController
{
    internal class ControllerDashboard
    {
        FrmDashboard objDashboard;
        public ControllerDashboard(FrmDashboard View)
        {
            objDashboard = View;
            objDashboard.Load += new EventHandler(ChargeValues);
            objDashboard.btnConfirm.Click += new EventHandler(DtpSearch);
            objDashboard.btnFirstTrimester.Click += new EventHandler(FirstTrimester);
            objDashboard.btnSecondTrimester.Click += new EventHandler(SecondTrimester);
            objDashboard.btnThirdTrimester.Click += new EventHandler(ThirdTrimester);
            objDashboard.btnFourthTrimester.Click += new EventHandler(FourthTrimester);
        }
        public void ChargeValues(object sender, EventArgs e)
        {
            objDashboard.dtpEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            DAODashboard dAODashboard = new DAODashboard();
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
                dAODashboard.GetAnalisys();
                objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";
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
            bool refreshData = dAODashboard.LoadData(objDashboard.dtpStart.Value, objDashboard.dtpEnd.Value);
            if (refreshData == true)
            {
                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

                dAODashboard.GetAnalisys();
                objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";
                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetTopServices();
                objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                objDashboard.chrtTopServices.DataBind();
            }
        }
        public void FirstTrimester(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            int currentYear = DateTime.Now.Year;
            DateTime startDate = new DateTime(currentYear, 1, 1);
            DateTime endDate = new DateTime(currentYear, 3, 31);
            bool refreshData = dAODashboard.LoadData(startDate, endDate);
            if (refreshData == true)
            {
                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

                dAODashboard.GetAnalisys();
                objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";
                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetTopServices();
                objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                objDashboard.chrtTopServices.DataBind();
            }
        }
        public void SecondTrimester(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            int currentYear = DateTime.Now.Year;
            DateTime startDate = new DateTime(currentYear, 4, 1);
            DateTime endDate = new DateTime(currentYear, 6, 30);
            bool refreshData = dAODashboard.LoadData(startDate, endDate);
            if (refreshData == true)
            {
                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

                dAODashboard.GetAnalisys();
                objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";
                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetTopServices();
                objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                objDashboard.chrtTopServices.DataBind();
            }
        }
        public void ThirdTrimester(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            int currentYear = DateTime.Now.Year;
            DateTime startDate = new DateTime(currentYear, 7, 1);
            DateTime endDate = new DateTime(currentYear, 9, 30);
            bool refreshData = dAODashboard.LoadData(startDate, endDate);
            if (refreshData == true)
            {
                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

                dAODashboard.GetAnalisys();
                objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";
                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetTopServices();
                objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                objDashboard.chrtTopServices.DataBind();
            }
        }
        public void FourthTrimester(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            int currentYear = DateTime.Now.Year;
            DateTime startDate = new DateTime(currentYear, 10, 1);
            DateTime endDate = new DateTime(currentYear, 12, 31);
            bool refreshData = dAODashboard.LoadData(startDate, endDate);
            if (refreshData == true)
            {
                dAODashboard.TotalPay = dAODashboard.GetTotalIncome();
                objDashboard.lblTotalIncome.Text = $"${dAODashboard.TotalPay:N2}";

                dAODashboard.GetAnalisys();
                objDashboard.chartPayrolls.DataSource = dAODashboard.PayrollsList;
                objDashboard.chartPayrolls.Series[0].XValueMember = "Date";
                objDashboard.chartPayrolls.Series[0].YValueMembers = "TotalAmount";
                objDashboard.chartPayrolls.DataBind();

                dAODashboard.GetTopServices();
                objDashboard.chrtTopServices.DataSource = dAODashboard.TopServices;
                objDashboard.chrtTopServices.Series[0].XValueMember = "Key";
                objDashboard.chrtTopServices.Series[0].YValueMembers = "Value";
                objDashboard.chrtTopServices.DataBind();
            }
        }
    }
}
