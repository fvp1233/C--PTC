namespace PTC2024.View.Reporting.Service
{
    partial class FrmReportServices
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Company = new PTC2024.View.Reporting.InfoCompany.DataSet_Company();
            this.tbBusinessInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbBusinessInfoTableAdapter = new PTC2024.View.Reporting.InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter();
            this.tbServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Servicexsd = new PTC2024.View.Reporting.Service.DataSet_Servicexsd();
            this.tbServicesTableAdapter = new PTC2024.View.Reporting.Service.DataSet_ServicexsdTableAdapters.tbServicesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Servicexsd)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.tbServicesBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.tbBusinessInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PTC2024.View.Reporting.Service.Report_Services.rdlc";
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
            // tbServicesBindingSource
            // 
            this.tbServicesBindingSource.DataMember = "tbServices";
            this.tbServicesBindingSource.DataSource = this.dataSet_Servicexsd;
            // 
            // dataSet_Servicexsd
            // 
            this.dataSet_Servicexsd.DataSetName = "DataSet_Servicexsd";
            this.dataSet_Servicexsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbServicesTableAdapter
            // 
            this.tbServicesTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 757);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReportServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.ReportServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Servicexsd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Servicexsd dataSet_Servicexsd;
        private System.Windows.Forms.BindingSource tbServicesBindingSource;
        private DataSet_ServicexsdTableAdapters.tbServicesTableAdapter tbServicesTableAdapter;
        private InfoCompany.DataSet_Company dataSet_Company;
        private System.Windows.Forms.BindingSource tbBusinessInfoBindingSource;
        private InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter tbBusinessInfoTableAdapter;
    }
}