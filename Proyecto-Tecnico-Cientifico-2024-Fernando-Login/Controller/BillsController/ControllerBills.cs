using PTC2024.View.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.BillsViews;
using PTC2024.Model.DAO;
using PTC2024.Model.DTO;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerBills
    {
        FrmBills objFormBills;
        public ControllerBills(FrmBills View)
        {
            objFormBills = View;
            objFormBills.Load += new EventHandler(LoadDataBills);
            objFormBills.btnNewBills.Click += new EventHandler(AddBills);
            objFormBills.cmsBills.Click += new EventHandler(printBills);
            objFormBills.cmsBills.Click += new EventHandler(RectifyBills);
            objFormBills.cmsBills.Click += new EventHandler(OverrideBills);
        }
        public void LoadDataBills(object sender, EventArgs e)
        {
                ChargeData();
        }
        public void ChargeData()
        {
            DAOBills objBills = new DAOBills();
            DataSet ds = objBills.Bills();
            objFormBills.dgvBills.DataSource = ds.Tables["viewBills"];
        }
        public void printBills(object sender, EventArgs e)
        { 
            
        }
        public void AddBills(object sender, EventArgs e)
        {
            FrmAddBills newBill = new FrmAddBills(1);
            newBill.ShowDialog();   
        }
        public void RectifyBills(object sender, EventArgs e) 
        { 
            int pos = objFormBills.dgvBills.CurrentRow.Index;
            int id, NIT, NRC, serviceName, statusBill,customer, employee, methodP;
            string companyName;
            DateTime startDate, FinalDate, fiscalPeriod;
            Double discount, subtotalPay, totalPay;
            id = int.Parse(objFormBills.dgvBills[0, pos].Value.ToString());
            companyName= objFormBills.dgvBills[1,pos].Value.ToString();
            NIT = int.Parse(objFormBills.dgvBills[2, pos].Value.ToString());
            NRC = int.Parse(objFormBills.dgvBills[3, pos].Value.ToString());
            customer= int.Parse(objFormBills.dgvBills[3, pos].Value.ToString());
            serviceName = int.Parse(objFormBills.dgvBills[4,pos].Value.ToString());
            discount = double.Parse(objFormBills.dgvBills[6, pos].Value.ToString());
            subtotalPay = double.Parse(objFormBills.dgvBills[7, pos].Value.ToString());
            totalPay = double.Parse(objFormBills.dgvBills[8, pos].Value.ToString());
            methodP = int.Parse(objFormBills.dgvBills[9, pos].Value.ToString());
            startDate = DateTime.Parse(objFormBills.dgvBills[10, pos].Value.ToString());
            FinalDate = DateTime.Parse(objFormBills.dgvBills[11, pos].Value.ToString());
            employee = int.Parse(objFormBills.dgvBills[12, pos].Value.ToString());
            statusBill = int.Parse(objFormBills.dgvBills[13, pos].Value.ToString());
            fiscalPeriod = DateTime.Parse(objFormBills.dgvBills[14, pos].Value.ToString());

            FrmAddBills rectifyBill = new FrmAddBills(2, id, companyName, NIT, NRC, customer, serviceName, discount, subtotalPay, totalPay, methodP, startDate, FinalDate, employee, statusBill, fiscalPeriod);
                       
           rectifyBill.ShowDialog();
            ChargeData();
        
        }
        public void OverrideBills(object sender, EventArgs e)
        {
            FrmOverrideBill overrideBill = new FrmOverrideBill();
            overrideBill.ShowDialog();
        }
    }
}
