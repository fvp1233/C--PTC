using PTC2024.Controller.Helper;
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

namespace PTC2024.View.Service_inventory
{
    public partial class FrmAgendaServices : Form
    {
        public FrmAgendaServices()
        {
            InitializeComponent();

            ControllerAgendaService controller = new ControllerAgendaService(this);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

    }
}
