namespace PTC2024.View.Reporting.Bills
{
    partial class PrintBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Company = new PTC2024.View.Reporting.InfoCompany.DataSet_Company();
            this.tbBusinessInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbBusinessInfoTableAdapter = new PTC2024.View.Reporting.InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter();
            this.tbBillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_RBills = new PTC2024.View.Reporting.Bills.DataSet_RBills();
            this.tbBillsTableAdapter = new PTC2024.View.Reporting.Bills.DataSet_RBillsTableAdapters.tbBillsTableAdapter();
            this.dataSet_detalle = new PTC2024.View.Reporting.Bills.DataSet_detalle();
            this.tbBillDataSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbBillDataSTableAdapter = new PTC2024.View.Reporting.Bills.DataSet_detalleTableAdapters.tbBillDataSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_RBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_detalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBillDataSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbBillsBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.tbBusinessInfoBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.tbBillDataSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PTC2024.View.Reporting.Bills.Report_PrintB.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1072, 757);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_Company
            // 
            this.dataSet_Company.DataSetName = "DataSet_Company";
            this.dataSet_Company.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbBusinessInfoBindingSource
            // 
            this.tbBusinessInfoBindingSource.DataMember = "tbBusinessInfo";
            this.tbBusinessInfoBindingSource.DataSource = this.dataSet_Company;
            // 
            // tbBusinessInfoTableAdapter
            // 
            this.tbBusinessInfoTableAdapter.ClearBeforeFill = true;
            // 
            // tbBillsBindingSource
            // 
            this.tbBillsBindingSource.DataMember = "tbBills";
            this.tbBillsBindingSource.DataSource = this.dataSet_RBills;
            // 
            // dataSet_RBills
            // 
            this.dataSet_RBills.DataSetName = "DataSet_RBills";
            this.dataSet_RBills.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbBillsTableAdapter
            // 
            this.tbBillsTableAdapter.ClearBeforeFill = true;
            // 
            // dataSet_detalle
            // 
            this.dataSet_detalle.DataSetName = "DataSet_detalle";
            this.dataSet_detalle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbBillDataSBindingSource
            // 
            this.tbBillDataSBindingSource.DataMember = "tbBillDataS";
            this.tbBillDataSBindingSource.DataSource = this.dataSet_detalle;
            // 
            // tbBillDataSTableAdapter
            // 
            this.tbBillDataSTableAdapter.ClearBeforeFill = true;
            // 
            // PrintBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 757);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PrintBill";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.PrintBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_RBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_detalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBillDataSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_RBills dataSet_RBills;
        private System.Windows.Forms.BindingSource tbBillsBindingSource;
        private DataSet_RBillsTableAdapters.tbBillsTableAdapter tbBillsTableAdapter;
        private InfoCompany.DataSet_Company dataSet_Company;
        private System.Windows.Forms.BindingSource tbBusinessInfoBindingSource;
        private InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter tbBusinessInfoTableAdapter;
        private DataSet_detalle dataSet_detalle;
        private System.Windows.Forms.BindingSource tbBillDataSBindingSource;
        private DataSet_detalleTableAdapters.tbBillDataSTableAdapter tbBillDataSTableAdapter;
    }
}