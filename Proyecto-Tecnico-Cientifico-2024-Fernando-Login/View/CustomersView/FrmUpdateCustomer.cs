using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PTC2024.Controller.CustomersController;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PTC2024.View.Clientes
{
    public partial class FrmUploadCustomers : Form
    {
        public FrmUploadCustomers(int idClient,string dui, string names, string lastnames, string phone,string email, string address )
        {
            InitializeComponent();
            ControllerUpdateCustomers obj = new ControllerUpdateCustomers(this,  idClient, dui, names, lastnames,   phone,  email,  address );
            
        }
    }
}
