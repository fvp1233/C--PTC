﻿using PTC2024.Controller.Employees;
using PTC2024.Controller.EmployeesController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Empleados
{
    public partial class FrmViewPayrolls : Form
    {
        public FrmViewPayrolls()
        {
            InitializeComponent();
            ControllerViewPayrolls objViewPayrorll = new ControllerViewPayrolls(this);
        }
    }
}
