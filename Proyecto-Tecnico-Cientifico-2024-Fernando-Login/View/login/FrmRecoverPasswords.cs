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
        }
    }
}
