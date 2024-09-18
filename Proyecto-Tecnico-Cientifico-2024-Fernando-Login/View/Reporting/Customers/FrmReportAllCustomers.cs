using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Reporting.Customers
{
    public partial class FrmReportAllCustomers : Form
    {
        public FrmReportAllCustomers()
        {
            InitializeComponent();
        }

        private void FrmReportAllCustomers_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Company.tbBusinessInfo' Puede moverla o quitarla según sea necesario.
            this.tbBusinessInfoTableAdapter.Fill(this.dataSet_Company.tbBusinessInfo);
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Customers.tbCustomer' Puede moverla o quitarla según sea necesario.
            this.tbCustomerTableAdapter.AllCustomers(this.dataSet_Customers.tbCustomer);

            this.reportViewer1.RefreshReport();
        }
    }
}
