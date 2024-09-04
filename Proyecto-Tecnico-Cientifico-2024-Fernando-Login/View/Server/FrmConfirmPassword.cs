using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Server;

namespace PTC2024.View.Server
{
    public partial class FrmConfirmPassword : Form
    {
        public FrmConfirmPassword()
        {
            InitializeComponent();
            ControllerCEOPassword objCEOPass = new ControllerCEOPassword(this);
        }
    }
}
