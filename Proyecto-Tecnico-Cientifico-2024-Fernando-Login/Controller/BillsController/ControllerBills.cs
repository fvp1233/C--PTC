using PTC2024.View.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.BillsViews;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerBills
    {
        FrmBills objFormBills;
        public ControllerBills(FrmBills View)
        {
            objFormBills = View;
            objFormBills.Load += new EventHandler(LoadDataBills);
            objFormBills.btnNewBills.Click += new EventHandler(NewBills);
            objFormBills.cmsBills.Click += new EventHandler(printBills);
            objFormBills.cmsBills.Click += new EventHandler(RectifyBills);
            objFormBills.cmsBills.Click += new EventHandler(OverrideBills);
        }
        public void LoadDataBills(object sender, EventArgs e)
        {

        }
        public void printBills(object sender, EventArgs e)
        { 
            
        }
        public void NewBills(object sender, EventArgs e)
        {
            FrmAddBills newBill = new FrmAddBills();
            newBill.ShowDialog();   
        }
        public void RectifyBills(object sender, EventArgs e) 
        { 
            FrmUpdateBill rectifyBill = new FrmUpdateBill();
            rectifyBill.ShowDialog();
        
        }
        public void OverrideBills(object sender, EventArgs e)
        {
            FrmOverrideBill overrideBill = new FrmOverrideBill();
            overrideBill.ShowDialog();
        }
    }
}
