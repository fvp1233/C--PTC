using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Reporting.Service
{
    public partial class FrmReportServices : Form
    {
        public FrmReportServices()
        {
            InitializeComponent();
        }

        private void ReportServices_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Company.tbBusinessInfo' Puede moverla o quitarla según sea necesario.
            this.tbBusinessInfoTableAdapter.Fill(this.dataSet_Company.tbBusinessInfo);
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Servicexsd.tbServices' Puede moverla o quitarla según sea necesario.
            this.tbServicesTableAdapter.AllServices(this.dataSet_Servicexsd.tbServices);

            this.reportViewer1.RefreshReport();
        }
    }
}
