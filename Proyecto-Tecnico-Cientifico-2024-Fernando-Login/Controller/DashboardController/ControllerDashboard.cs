using PTC2024.Model.DAO.DashboardDAO;
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
            objDashboard.btnConfirm.Click += new EventHandler(ChargeValues);
        }
        public void ChargeValues(object sender, EventArgs e)
        {
            DAODashboard dAODashboard = new DAODashboard();
            var refreshData = dAODashboard.LoadData(objDashboard.dtpStart.Value, objDashboard.dtpEnd.Value);
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
            }

        }
    }
}
