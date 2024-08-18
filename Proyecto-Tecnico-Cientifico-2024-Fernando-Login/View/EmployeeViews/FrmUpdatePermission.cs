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
    public partial class FrmUpdatePermission : Form
    {
        public FrmUpdatePermission(int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP)
        {
            InitializeComponent();
            ControllerUpdatePermission objPermission = new ControllerUpdatePermission(this, idEmployee, idPermission, start, end, context, status, typeP);
        }
    }
}
