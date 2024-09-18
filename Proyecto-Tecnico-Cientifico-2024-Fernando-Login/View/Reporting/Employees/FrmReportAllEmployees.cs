using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Reporting.Employees
{
    public partial class FrmReportAllEmployees : Form
    {
        public FrmReportAllEmployees()
        {
            InitializeComponent();
        }

        private void FrmReportAllEmployees_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Company.tbBusinessInfo' Puede moverla o quitarla según sea necesario.
            this.tbBusinessInfoTableAdapter.Fill(this.dataSet_Company.tbBusinessInfo);
            // TODO: esta línea de código carga datos en la tabla 'dataSet1_Employeesxsd.tbEmployee' Puede moverla o quitarla según sea necesario.
            this.tbEmployeeTableAdapter.AllEmployees(this.dataSet1_Employeesxsd.tbEmployee);

            this.reportViewer1.RefreshReport();
        }
    }
}
