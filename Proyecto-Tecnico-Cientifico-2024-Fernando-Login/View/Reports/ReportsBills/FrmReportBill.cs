using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Reports.ReportsBill
{
    public partial class FrmReportBill : Form
    {
        public FrmReportBill()
        {
            InitializeComponent();
        }

        private void FrmReportBill_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
