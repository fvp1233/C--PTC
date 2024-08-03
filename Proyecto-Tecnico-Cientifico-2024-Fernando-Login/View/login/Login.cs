using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.LogInController;
using PTC2024.View.formularios.inicio;

namespace PTC2024.formularios.login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ControllerLogin control = new ControllerLogin(this);
        }

        public static implicit operator System.Web.UI.WebControls.Login(Login v)
        {
            throw new NotImplementedException();
        }
    }
}
