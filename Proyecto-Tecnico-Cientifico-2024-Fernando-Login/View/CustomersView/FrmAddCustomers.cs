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
using PTC2024.Controller.CustomersController;
using PTC2024.Controller.Helper;

namespace PTC2024.View.Clientes
{
    public partial class FrmAddCustomers : Form
    {
        public FrmAddCustomers()
        {
            InitializeComponent();
            ControllerAddCustomers objControl = new ControllerAddCustomers(this);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        
    }
}
