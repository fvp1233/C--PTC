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

namespace PTC2024.Controller.DashboardController
{
    internal class ControllerDashboard
    {
        FrmDashboard objDashboard;
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
            YearRadialGauge();
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

            int totalDays = (lastDay - firstDay).Days; 
            int days = (actualDay - firstDay).Days; 

            objDashboard.rgYearProgress.Minimum = 1;
            objDashboard.rgYearProgress.Maximum = totalDays;

            objDashboard.rgYearProgress.ValueByTransition = days;

            objDashboard.rgYearProgress.WarningMark = totalDays / 2;

            objDashboard.rgYearProgress.Suffix = " día";

            objDashboard.rgYearProgress.ShowRangeLabels = true;
            objDashboard.rgYearProgress.ShowValueLabel = true;

            objDashboard.rgYearProgress.ValueLabelColor = Color.Black;
        }



    }
}
