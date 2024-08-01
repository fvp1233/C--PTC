using PTC2024.View.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.BillsViews;
using System.ComponentModel.Design;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;
using PTC2024.Model.DTO;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerAddBills
    {
        FrmAddBills objAddBills;
        private int accions;
        public ControllerAddBills(FrmAddBills View, int accions)
        {
            objAddBills = View;
            this.accions = accions;

            chooseAccions();
            objAddBills.Load += new EventHandler(InitialCharge);

            objAddBills.btnAddBill.Click += new EventHandler(NewBill);
            objAddBills.btnBack.Click += new EventHandler(BackProcess);
        }
        public ControllerAddBills(FrmAddBills view, int accions, int id, string companyName, int NIT, int NRC, int customer, int serviceName, double discount, double subtoralPay, double totalPay, int methodP, DateTime startDate, DateTime FinalDate, int employee, int statusBill, DateTime fiscalPeriod)
        {
            objAddBills = view;
            this.accions = accions;

            objAddBills.Load += new EventHandler(InitialCharge);
            chooseAccions();
            ChargeValues(id, companyName, NIT, NRC, customer, discount, subtoralPay, totalPay, startDate, FinalDate, employee, fiscalPeriod);

            //objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
        }
        public void InitialCharge(object sender, EventArgs e)
        {
            DAOAddBills objBills = new DAOAddBills();
            DataSet dsMethodP = objBills.Methodp();
            objAddBills.comboMethodP.DataSource = dsMethodP.Tables["tbMethodP"];
            objAddBills.comboMethodP.DisplayMember = "PaymentMethod";
            objAddBills.comboMethodP.ValueMember = "IdmethodP";

            DataSet dsStatusBill = objBills.statusBill();
            objAddBills.comboStatusBill.DataSource = dsStatusBill.Tables["tbStatusBill"];
            objAddBills.comboStatusBill.DisplayMember = "billStatus";
            objAddBills.comboStatusBill.ValueMember = "IdStatusBill";

            DataSet dsServices = objBills.DataServices();
            objAddBills.comboServiceBill.DataSource = dsServices.Tables["tbServices"];
            objAddBills.comboServiceBill.DisplayMember = "serviceName";
            objAddBills.comboServiceBill.ValueMember = "IdServices";

        }
        public void chooseAccions()
        {
            if (accions == 1)
            {
                objAddBills.btnAddBill.Enabled = true;
                objAddBills.btnRectify.Enabled = false;
            }
            else if (accions == 2)
            {
                objAddBills.btnAddBill.Enabled = false;
                objAddBills.btnRectify.Enabled = true;
            }
        }
        public void NewBill(object sender, EventArgs e)
        {
            DAOAddBills daoNew = new DAOAddBills();
            daoNew.CompanyName = objAddBills.txtRazónsocial.Text.Trim();
            daoNew.NIT1 = int.Parse(objAddBills.txtNITCompany.ToString());
            daoNew.NRC1 = int.Parse(objAddBills.txtNRCompany.ToString());
            daoNew.Discount = int.Parse(objAddBills.txtDiscount.ToString());
            daoNew.SubtotalPay = int.Parse(objAddBills.txtSubTotal.ToString());
            daoNew.TotalPay = int.Parse(objAddBills.txtTotalPay.ToString());
            daoNew.StartDate = objAddBills.dtStartDate.Value.Date;
            daoNew.FinalDate1 = objAddBills.dtFinalDate.Value.Date;
            daoNew.Services = int.Parse(objAddBills.comboServiceBill.SelectedValue.ToString());
            daoNew.StatusBills = int.Parse(objAddBills.comboStatusBill.SelectedValue.ToString());
            daoNew.Customer = int.Parse(objAddBills.txtCustomerName.ToString());
            daoNew.Employee = int.Parse(objAddBills.txtEmployee.ToString());
            daoNew.MethodP = int.Parse(objAddBills.comboMethodP.SelectedValue.ToString());
            daoNew.FiscalPeriod = objAddBills.dtfiscalPeriod.Value.Date;

        }
        // public void RectifyBills()
        //{

        // }
        public void BackProcess(object sender, EventArgs e)
        {
            objAddBills.Close();
        }
        public void ChargeValues(int id, string companyName, int NIT, int NRC, int customer, double discount, double subtoralPay, double totalPay, DateTime startDate, DateTime FinalDate, int employee, DateTime fiscalPeriod)
        {
            objAddBills.txtRazónsocial.Text = companyName;
            objAddBills.txtNITCompany.Text = NIT.ToString();
            objAddBills.txtNRCompany.Text = NRC.ToString();
            objAddBills.txtCustomerName.Text = customer.ToString();
            objAddBills.txtDiscount.Text = discount.ToString();
            objAddBills.txtSubTotal.Text = subtoralPay.ToString();
            objAddBills.txtTotalPay.Text = totalPay.ToString();
            objAddBills.dtStartDate.Value = startDate;
            objAddBills.dtFinalDate.Value = FinalDate;
            objAddBills.dtfiscalPeriod.Value = fiscalPeriod;

        }
    }
}