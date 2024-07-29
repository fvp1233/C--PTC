using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller;
using PTC2024.Controller.EmployeesController;

namespace PTC2024.View.Empleados
{
    public partial class FrmUpdateEmployee : Form
    {
        public FrmUpdateEmployee()
        {
            InitializeComponent();
            ControllerUpdateEmployee objControl = new ControllerUpdateEmployee(this);
        }
    }
}
