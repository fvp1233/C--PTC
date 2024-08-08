using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller;
using PTC2024.Controller.Helper;

namespace PTC2024.View.Empleados
{
    public partial class FrmAddEmployee : Form
    {
        public FrmAddEmployee()
        {
            InitializeComponent();
            ControllerAddEmployee objControl = new ControllerAddEmployee(this);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
    }
}
