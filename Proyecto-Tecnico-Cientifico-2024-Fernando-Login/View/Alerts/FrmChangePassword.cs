using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Alerts;
using PTC2024.Controller.Helper;
using PTC2024.Controller.LogInController;

namespace PTC2024.View.Alerts
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword(string username)
        {
            InitializeComponent();
            ControllerChangePassword control = new ControllerChangePassword(this, username);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
