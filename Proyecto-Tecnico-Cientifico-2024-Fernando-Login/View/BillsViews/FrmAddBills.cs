using PTC2024.Controller;
using PTC2024.Controller.BillsController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Facturacion
{
    public partial class FrmAddBills : Form
    {
        public FrmAddBills(int accions)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions);

        }
        public FrmAddBills( int accions, int id, string companyName, int NIT, int NRC, int customer, int serviceName, double discount, double subtoralPay, double totalPay, int methodP, DateTime startDate, DateTime FinalDate, int employee, int statusBill, DateTime fiscalPeriod)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions, id, companyName, NIT, NRC, customer, serviceName, discount, subtoralPay, totalPay, methodP, startDate, FinalDate, employee, statusBill, fiscalPeriod);
        }
    }
}
