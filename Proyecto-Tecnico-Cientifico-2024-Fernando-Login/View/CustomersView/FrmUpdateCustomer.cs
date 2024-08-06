using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.CustomersController;
using PTC2024.Controller.EmployeesController;

namespace PTC2024.View.Clientes
{
    public partial class FrmUploadCustomers : Form
    {
            //Constructor del formulario updateEmployees
            public FrmUploadCustomers(int IdCustomer, int DUI, string names, string lastNames,  string phone, string email, string address, int IdTypeC)
            {
                InitializeComponent();
                ControllerCustomers objControl = new ControllerUpdateCustomers(this, IdCustomer,DUI, names, lastNames, phone, email,  address, IdTypeC);
            }
        }
    }

