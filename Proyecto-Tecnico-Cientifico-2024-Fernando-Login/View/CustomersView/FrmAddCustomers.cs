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

namespace PTC2024.View.Clientes
{
    public partial class FrmAddCustomers : Form
    {
        public FrmAddCustomers(int accion)
        {
            InitializeComponent();
            ControllerAddCustomers objControl = new ControllerAddCustomers(this, accion);
        }

        public FrmAddCustomers(int accion, int CustomerId,int DUI,string names, string lastnames, string phone , string address, string email, int typeC )
        {
            InitializeComponent() ;

            ControllerAddCustomers objControl = new ControllerAddCustomers(this, accion, CustomerId, DUI, names, lastnames, phone, address, email, typeC);
        }
    }
}
