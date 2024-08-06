using PTC2024.Controller.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Empleados
{
    public partial class FrmEmployees : Form
    {
        public FrmEmployees()
        {
            InitializeComponent();
            //CONSTRUCTOR DEL FORMULARIO
            ControllerEmployees objEmployees = new ControllerEmployees(this);
        }

        
    }
}
