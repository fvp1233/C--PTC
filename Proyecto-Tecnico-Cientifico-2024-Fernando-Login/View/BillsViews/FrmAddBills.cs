using PTC2024.Controller;
using PTC2024.Controller.BillsController;
using PTC2024.Controller.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PTC2024.View.Facturacion
{
    public partial class FrmAddBills : Form
    {
        internal object btnBack2;

        public FrmAddBills(int accions)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


        }
        public FrmAddBills(int accions, int id, string companyName, string NIT, string NRC, string customer, string serviceName, double Discount, double SubtotalPay, double TotalPay, string methodP, DateTime startDate, DateTime FinalDate,DateTime Dateissued, string employee, string statusBill, string CustomerDui, string CustomerPhone, string CustomerEmail)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions, id, companyName, NIT, NRC, customer, serviceName, Discount, SubtotalPay, TotalPay, methodP, startDate, FinalDate, Dateissued,employee, statusBill, CustomerDui, CustomerPhone, CustomerEmail);
        }
        public FrmAddBills(int accions, int id, string IdServices1, float Price1)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills (this, accions, id, IdServices1, Price1);
        }
    }
}
