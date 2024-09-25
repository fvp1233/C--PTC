using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Reporting.Payrolls
{
    public partial class FrmReportPayroll : Form
    {
        int IdPayroll;
        private DataSet reportDataSet;
        public FrmReportPayroll(int idPayroll)
        {
            InitializeComponent();
            IdPayroll = idPayroll;
        }

        private void FrmReportPayroll_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Company.tbBusinessInfo' Puede moverla o quitarla según sea necesario.
            this.tbBusinessInfoTableAdapter.Fill(this.dataSet_Company.tbBusinessInfo);
            // TODO: esta línea de código carga datos en la tabla 'dataSet_payrollxsd.tbPayroll' Puede moverla o quitarla según sea necesario.
            this.tbPayrollTableAdapter.Payrolls(this.dataSet_payrollxsd.tbPayroll);
            this.tbPayrollTableAdapter.Payroll(this.dataSet_payrollxsd.tbPayroll, IdPayroll );


            this.reportViewer1.RefreshReport();
           
        }
    }
}
