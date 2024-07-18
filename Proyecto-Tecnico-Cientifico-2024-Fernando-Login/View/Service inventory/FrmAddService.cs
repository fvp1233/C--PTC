using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.ServicesController;

namespace PTC2024.View.InventarioServicios
{
    public partial class FrmAddService : Form
    {
        public FrmAddService()
        {
            InitializeComponent();
            ControllerAddService objController = new ControllerAddService(this);
        }

    }
}
