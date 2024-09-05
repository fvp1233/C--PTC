namespace PTC2024.View.Reporting.Bills
{
    partial class ReportingBill
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_RBills = new PTC2024.View.Reporting.Bills.DataSet_RBills();
            this.tbBillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbBillsTableAdapter = new PTC2024.View.Reporting.Bills.DataSet_RBillsTableAdapters.tbBillsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_RBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBillsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbBillsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PTC2024.View.Reporting.Bills.Report_Bill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1072, 757);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_RBills
            // 
            this.dataSet_RBills.DataSetName = "DataSet_RBills";
            this.dataSet_RBills.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbBillsBindingSource
            // 
            this.tbBillsBindingSource.DataMember = "tbBills";
            this.tbBillsBindingSource.DataSource = this.dataSet_RBills;
            // 
            // tbBillsTableAdapter
            // 
            this.tbBillsTableAdapter.ClearBeforeFill = true;
            // 
            // ReportingBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 757);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportingBill";
            this.Text = "ReportingBill";
            this.Load += new System.EventHandler(this.ReportingBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_RBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBillsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_RBills dataSet_RBills;
        private System.Windows.Forms.BindingSource tbBillsBindingSource;
        private DataSet_RBillsTableAdapters.tbBillsTableAdapter tbBillsTableAdapter;
    }
}