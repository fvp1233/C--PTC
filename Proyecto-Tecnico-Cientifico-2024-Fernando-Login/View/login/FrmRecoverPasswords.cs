using PTC2024.Controller.Helper;
using PTC2024.Controller.LogInController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.login
{
    public partial class FrmRecoverPasswords : Form
    {
        public FrmRecoverPasswords()
        {
            InitializeComponent();
            ControllerRecoverPassword objController = new ControllerRecoverPassword(this);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
