using PTC2024.Controller.PayrollsController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.EmployeeViews
{
    public partial class FrmPermissions : Form
    {
        public FrmPermissions()
        {
            InitializeComponent();
            ControllerPermission objPermission = new ControllerPermission(this);
        }
    }
}
