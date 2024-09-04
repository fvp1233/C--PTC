using PTC2024.Controller.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Server
{
    public partial class FrmServerConfiguration : Form
    {
        public FrmServerConfiguration()
        {
            InitializeComponent();
            ControllerServerConfiguration objServer = new ControllerServerConfiguration(this);
        }
    }
}
