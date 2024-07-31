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
        public FrmAddBills()
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this);

        }
    }
}
