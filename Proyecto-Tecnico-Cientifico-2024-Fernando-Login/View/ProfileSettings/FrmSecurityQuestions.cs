using PTC2024.Controller.Helper;
using PTC2024.Controller.ProfileController;
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
    public partial class FrmSecurityQuestions : Form
    {
        public FrmSecurityQuestions(string username)
        {
            InitializeComponent();
            ControllerSecurityQuestions control = new ControllerSecurityQuestions(this, username);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
