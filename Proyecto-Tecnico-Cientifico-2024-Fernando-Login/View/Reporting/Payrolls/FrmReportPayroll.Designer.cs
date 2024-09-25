namespace PTC2024.View.Reporting.Payrolls
{
    partial class FrmReportPayroll
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Company = new PTC2024.View.Reporting.InfoCompany.DataSet_Company();
            this.tbBusinessInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbBusinessInfoTableAdapter = new PTC2024.View.Reporting.InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter();
            this.tbPayrollBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_payrollxsd = new PTC2024.View.Reporting.Payrolls.DataSet_payrollxsd();
            this.tbPayrollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbPayrollTableAdapter = new PTC2024.View.Reporting.Payrolls.DataSet_payrollxsdTableAdapters.tbPayrollTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPayrollBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_payrollxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPayrollBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbPayrollBindingSource1;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.tbBusinessInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PTC2024.View.Reporting.Payrolls.Report_singlepayroll.rdlc";
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
            // tbPayrollBindingSource1
            // 
            this.tbPayrollBindingSource1.DataMember = "tbPayroll";
            this.tbPayrollBindingSource1.DataSource = this.dataSet_payrollxsd;
            // 
            // dataSet_payrollxsd
            // 
            this.dataSet_payrollxsd.DataSetName = "DataSet_payrollxsd";
            this.dataSet_payrollxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbPayrollBindingSource
            // 
            this.tbPayrollBindingSource.DataMember = "tbPayroll";
            this.tbPayrollBindingSource.DataSource = this.dataSet_payrollxsd;
            // 
            // tbPayrollTableAdapter
            // 
            this.tbPayrollTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 757);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportPayroll";
            this.Text = "FrmReportPayroll";
            this.Load += new System.EventHandler(this.FrmReportPayroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPayrollBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_payrollxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPayrollBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_payrollxsd dataSet_payrollxsd;
        private System.Windows.Forms.BindingSource tbPayrollBindingSource;
        private DataSet_payrollxsdTableAdapters.tbPayrollTableAdapter tbPayrollTableAdapter;
        private System.Windows.Forms.BindingSource tbPayrollBindingSource1;
        private InfoCompany.DataSet_Company dataSet_Company;
        private System.Windows.Forms.BindingSource tbBusinessInfoBindingSource;
        private InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter tbBusinessInfoTableAdapter;
    }
}