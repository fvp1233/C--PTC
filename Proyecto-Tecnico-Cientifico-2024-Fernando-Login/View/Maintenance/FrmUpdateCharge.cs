using PTC2024.Controller.MaintenanceController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Dashboard
{
    public partial class FrmUpdateCharge : Form
    {
        public FrmUpdateCharge(int id, string name, double bonus)
        {
            InitializeComponent();
            ControllerUpdateCharge objController = new ControllerUpdateCharge(this, id, name, bonus);
        }
    }
}
