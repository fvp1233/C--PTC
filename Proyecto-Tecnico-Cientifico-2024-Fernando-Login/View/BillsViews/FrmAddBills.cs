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
using System.Web.UI.WebControls;
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
        public FrmAddBills(int accions, int id, string companyName, string NIT, string NRC, string customer, string serviceName, float discount, float subtoralPay, float totalPay, string methodP, DateTime startDate, DateTime FinalDate,DateTime Dateissued, string employee, string statusBill)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions, id, companyName, NIT, NRC, customer, serviceName, discount, subtoralPay, totalPay, methodP, startDate, FinalDate, Dateissued,employee, statusBill);
        }
        public FrmAddBills(int accions, int id, string IdServices1, float Price1)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills (this, accions, id, IdServices1, Price1);
        }

    }
}
