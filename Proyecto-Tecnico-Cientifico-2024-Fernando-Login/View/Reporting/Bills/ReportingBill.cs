using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Reporting.Bills
{
    public partial class ReportingBill : Form
    {
        public ReportingBill()
        {
            InitializeComponent();
        }

        private void ReportingBill_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_RBills.tbBills' Puede moverla o quitarla según sea necesario.
            this.tbBillsTableAdapter.Fill_RB(this.dataSet_RBills.tbBills);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
