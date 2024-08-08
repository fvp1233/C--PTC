using PTC2024.Controller.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Alerts
{
    public partial class FrmDeleteAlert : Form
    {
        public FrmDeleteAlert()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
