namespace PTC2024.View.Alerts
{
    partial class ProgressBarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBarForm));
            this.progressBar = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.lblStatus = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.AllowAnimations = false;
            this.progressBar.Animation = 0;
            this.progressBar.AnimationSpeed = 220;
            this.progressBar.AnimationStep = 10;
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.progressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progressBar.BackgroundImage")));
            this.progressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.progressBar.BorderRadius = 9;
            this.progressBar.BorderThickness = 1;
            this.progressBar.Location = new System.Drawing.Point(95, 27);
            this.progressBar.Maximum = 100;
            this.progressBar.MaximumValue = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.MinimumValue = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.progressBar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.progressBar.ProgressColorLeft = System.Drawing.Color.DodgerBlue;
            this.progressBar.ProgressColorRight = System.Drawing.Color.DodgerBlue;
            this.progressBar.Size = new System.Drawing.Size(363, 38);
            this.progressBar.TabIndex = 0;
            this.progressBar.Value = 50;
            this.progressBar.ValueByTransition = 50;
            // 
            // lblStatus
            // 
            this.lblStatus.AllowParentOverrides = false;
            this.lblStatus.AutoEllipsis = false;
            this.lblStatus.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(243, 71);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(69, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "bunifuLabel1";
            this.lblStatus.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblStatus.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 133);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Name = "ProgressBarForm";
            this.Text = "ProgressBarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuProgressBar progressBar;
        public Bunifu.UI.WinForms.BunifuLabel lblStatus;
    }
}