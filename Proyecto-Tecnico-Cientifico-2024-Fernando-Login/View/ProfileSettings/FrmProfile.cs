﻿using PTC2024.Controller.ProfileController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.ProfileSettings
{
    public partial class FrmProfile : Form
    {
        public FrmProfile()
        {
            InitializeComponent();
            ControllerProfile objProfile = new ControllerProfile(this);
        }
    }
}
