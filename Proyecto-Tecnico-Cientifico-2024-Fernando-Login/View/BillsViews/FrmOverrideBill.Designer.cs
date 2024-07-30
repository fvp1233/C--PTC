namespace PTC2024.View.BillsViews
{
    partial class FrmOverrideBill
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
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtRazónsocial = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(286, 108);
            this.bunifuCustomLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(348, 40);
            this.bunifuCustomLabel1.TabIndex = 111;
            this.bunifuCustomLabel1.Text = "Anulación de factura";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(127, 181);
            this.bunifuCustomLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(703, 20);
            this.bunifuCustomLabel2.TabIndex = 112;
            this.bunifuCustomLabel2.Text = "Se solicita ingresar la contraseña de administrador para continuar con el proceso" +
    " de anulación";
            // 
            // txtRazónsocial
            // 
            this.txtRazónsocial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRazónsocial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRazónsocial.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtRazónsocial.ForeColor = System.Drawing.Color.DimGray;
            this.txtRazónsocial.HintForeColor = System.Drawing.Color.Empty;
            this.txtRazónsocial.HintText = "";
            this.txtRazónsocial.isPassword = false;
            this.txtRazónsocial.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtRazónsocial.LineIdleColor = System.Drawing.Color.Gray;
            this.txtRazónsocial.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtRazónsocial.LineThickness = 3;
            this.txtRazónsocial.Location = new System.Drawing.Point(131, 275);
            this.txtRazónsocial.Margin = new System.Windows.Forms.Padding(5);
            this.txtRazónsocial.Name = "txtRazónsocial";
            this.txtRazónsocial.Size = new System.Drawing.Size(699, 38);
            this.txtRazónsocial.TabIndex = 113;
            this.txtRazónsocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(369, 236);
            this.bunifuCustomLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(167, 19);
            this.bunifuCustomLabel3.TabIndex = 114;
            this.bunifuCustomLabel3.Text = "Ingresar contraseña";
            // 
            // FrmOverrideBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 493);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.txtRazónsocial);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOverrideBill";
            this.Text = "FrmOverrideBill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtRazónsocial;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
    }
}