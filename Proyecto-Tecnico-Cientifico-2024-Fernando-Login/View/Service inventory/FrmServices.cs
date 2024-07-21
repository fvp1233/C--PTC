using PTC2024.Controller.ServicesController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.InventarioServicios
{
    public partial class FrmServices : Form
    {
        public FrmServices()
        {
            InitializeComponent();
            ControllerServices services = new ControllerServices(this);
        }
    }
}
