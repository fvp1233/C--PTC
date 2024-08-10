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
    public partial class FrmUpdateService : Form
    {
        public FrmUpdateService(int pos, int id, string cliente ,string nombre, string descripcion, double monto, string categoria)
        {
            InitializeComponent();
            ControllerUpdateService update = new ControllerUpdateService(this, pos, id, cliente, nombre, descripcion, monto, categoria);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

    }

}
