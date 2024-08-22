using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.CustomersView
{
    public partial class FrmCustomersInfo : Form
    {
        public FrmCustomersInfo(int customer,string names, string lastnames, string DUI, string address, string email,string phone)
        {
            InitializeComponent();
        }
    }
}
