using PTC2024.Controller.BillsController;
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
    public partial class PrintBill : Form
    {
        int BillId;
        private DataSet reportDataSet;
        public PrintBill(int billId)
        {
            InitializeComponent();
            BillId = billId;
            this.reportDataSet = reportDataSet;
        }

        private void PrintBill_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_detalle.tbBillDataS' Puede moverla o quitarla según sea necesario.
            this.tbBillDataSTableAdapter.Fill(this.dataSet_detalle.tbBillDataS);
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Company.tbBusinessInfo' Puede moverla o quitarla según sea necesario.
            this.tbBusinessInfoTableAdapter.Fill(this.dataSet_Company.tbBusinessInfo);
            // TODO: esta línea de código carga datos en la tabla 'dataSet_RBills.tbBills' Puede moverla o quitarla según sea necesario.
            this.tbBillsTableAdapter.PrintBill(this.dataSet_RBills.tbBills, BillId);
            // Filtrar los servicios que no han sido eliminados
            

            this.reportViewer1.RefreshReport();
        }
    }
}
