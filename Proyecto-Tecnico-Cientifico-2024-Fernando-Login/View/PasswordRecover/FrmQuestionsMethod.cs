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
using PTC2024.Controller.PasswordRecover;

namespace PTC2024.View.PasswordRecover
{
    public partial class FrmQuestionsMethod : Form
    {
        public FrmQuestionsMethod()
        {
            InitializeComponent();
            ControllerQuestionsMethod control = new ControllerQuestionsMethod(this);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
