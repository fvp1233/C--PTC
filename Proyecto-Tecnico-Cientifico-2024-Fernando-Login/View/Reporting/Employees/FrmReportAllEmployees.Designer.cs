namespace PTC2024.View.Reporting.Employees
{
    partial class FrmReportAllEmployees
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
            this.dataSet1_Employeesxsd = new PTC2024.View.Reporting.Employees.DataSet1_Employeesxsd();
            this.tbEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbEmployeeTableAdapter = new PTC2024.View.Reporting.Employees.DataSet1_EmployeesxsdTableAdapters.tbEmployeeTableAdapter();
            this.dataSet_Company = new PTC2024.View.Reporting.InfoCompany.DataSet_Company();
            this.tbBusinessInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbBusinessInfoTableAdapter = new PTC2024.View.Reporting.InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1_Employeesxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbEmployeeBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.tbBusinessInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PTC2024.View.Reporting.Employees.Report_GeneralEmployee.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1072, 757);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1_Employeesxsd
            // 
            this.dataSet1_Employeesxsd.DataSetName = "DataSet1_Employeesxsd";
            this.dataSet1_Employeesxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbEmployeeBindingSource
            // 
            this.tbEmployeeBindingSource.DataMember = "tbEmployee";
            this.tbEmployeeBindingSource.DataSource = this.dataSet1_Employeesxsd;
            // 
            // tbEmployeeTableAdapter
            // 
            this.tbEmployeeTableAdapter.ClearBeforeFill = true;
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
            // FrmReportAllEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 757);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReportAllEmployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleados";
            this.Load += new System.EventHandler(this.FrmReportAllEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1_Employeesxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBusinessInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1_Employeesxsd dataSet1_Employeesxsd;
        private System.Windows.Forms.BindingSource tbEmployeeBindingSource;
        private DataSet1_EmployeesxsdTableAdapters.tbEmployeeTableAdapter tbEmployeeTableAdapter;
        private InfoCompany.DataSet_Company dataSet_Company;
        private System.Windows.Forms.BindingSource tbBusinessInfoBindingSource;
        private InfoCompany.DataSet_CompanyTableAdapters.tbBusinessInfoTableAdapter tbBusinessInfoTableAdapter;
    }
}