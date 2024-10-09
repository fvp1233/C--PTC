using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Controller.Alerts;
using System.Windows.Forms;

namespace PTC2024.View.Alerts
{
    public partial class FrmConfirmPayment : Form
    {
        public FrmConfirmPayment()
        {
            InitializeComponent();
            ControllerConfirmPayment objConfirm = new ControllerConfirmPayment(this);
        }
    }
}
