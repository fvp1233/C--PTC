using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Helper;
using PTC2024.Controller.MaintenanceController;

namespace PTC2024.View.Maintenance
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
            ControllerBanks control = new ControllerBanks(this);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
