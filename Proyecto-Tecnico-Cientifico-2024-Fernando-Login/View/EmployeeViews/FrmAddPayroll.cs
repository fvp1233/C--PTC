﻿using PTC2024.Controller.EmployeesController;
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
    public partial class FrmAddPayroll : Form
    {
        public FrmAddPayroll()
        {
            InitializeComponent();
            ControllerAddPayroll objControllerAddPayroll = new ControllerAddPayroll(this);
        }
    }
}
