﻿using PTC2024.Controller.MaintenanceController;
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
    public partial class FrmMaintenance : Form
    {
        public FrmMaintenance()
        {
            InitializeComponent();
            ControllerMaintenance objMaintenance = new ControllerMaintenance(this);
        }
    }
}
