namespace PTC2024.View.Empleados
{
    partial class ApartadoEmpleados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApartadoEmpleados));
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dataGriEmpleados = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.BtnRegresar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.BtnEliminarEmpleado = new Bunifu.Framework.UI.BunifuFlatButton();
            this.BtnActualizarEmpleado = new Bunifu.Framework.UI.BunifuFlatButton();
            this.BtnAgregarEmpleado = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(48, 54);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(252, 46);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "EMPLEADOS";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dataGriEmpleados
            // 
            this.dataGriEmpleados.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGriEmpleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGriEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGriEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGriEmpleados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGriEmpleados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGriEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGriEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGriEmpleados.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dataGriEmpleados.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGriEmpleados.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGriEmpleados.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataGriEmpleados.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGriEmpleados.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dataGriEmpleados.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGriEmpleados.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dataGriEmpleados.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dataGriEmpleados.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGriEmpleados.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dataGriEmpleados.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGriEmpleados.CurrentTheme.Name = null;
            this.dataGriEmpleados.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGriEmpleados.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGriEmpleados.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGriEmpleados.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataGriEmpleados.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGriEmpleados.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGriEmpleados.EnableHeadersVisualStyles = false;
            this.dataGriEmpleados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGriEmpleados.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGriEmpleados.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataGriEmpleados.HeaderForeColor = System.Drawing.Color.White;
            this.dataGriEmpleados.Location = new System.Drawing.Point(48, 140);
            this.dataGriEmpleados.Name = "dataGriEmpleados";
            this.dataGriEmpleados.RowHeadersVisible = false;
            this.dataGriEmpleados.RowTemplate.Height = 40;
            this.dataGriEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGriEmpleados.Size = new System.Drawing.Size(1082, 370);
            this.dataGriEmpleados.TabIndex = 1;
            this.dataGriEmpleados.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.ActiveBorderThickness = 1;
            this.BtnRegresar.ActiveCornerRadius = 20;
            this.BtnRegresar.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnRegresar.ActiveForecolor = System.Drawing.Color.White;
            this.BtnRegresar.ActiveLineColor = System.Drawing.Color.White;
            this.BtnRegresar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRegresar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnRegresar.BackgroundImage")));
            this.BtnRegresar.ButtonText = "Regresar";
            this.BtnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegresar.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegresar.ForeColor = System.Drawing.Color.White;
            this.BtnRegresar.IdleBorderThickness = 1;
            this.BtnRegresar.IdleCornerRadius = 20;
            this.BtnRegresar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.BtnRegresar.IdleForecolor = System.Drawing.Color.White;
            this.BtnRegresar.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.BtnRegresar.Location = new System.Drawing.Point(949, 54);
            this.BtnRegresar.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(181, 41);
            this.BtnRegresar.TabIndex = 5;
            this.BtnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEliminarEmpleado
            // 
            this.BtnEliminarEmpleado.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnEliminarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnEliminarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEliminarEmpleado.BorderRadius = 7;
            this.BtnEliminarEmpleado.ButtonText = "Eliminar un empleado";
            this.BtnEliminarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEliminarEmpleado.DisabledColor = System.Drawing.Color.Gray;
            this.BtnEliminarEmpleado.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnEliminarEmpleado.Iconimage = ((System.Drawing.Image)(resources.GetObject("BtnEliminarEmpleado.Iconimage")));
            this.BtnEliminarEmpleado.Iconimage_right = null;
            this.BtnEliminarEmpleado.Iconimage_right_Selected = null;
            this.BtnEliminarEmpleado.Iconimage_Selected = null;
            this.BtnEliminarEmpleado.IconMarginLeft = 0;
            this.BtnEliminarEmpleado.IconMarginRight = 0;
            this.BtnEliminarEmpleado.IconRightVisible = true;
            this.BtnEliminarEmpleado.IconRightZoom = 0D;
            this.BtnEliminarEmpleado.IconVisible = true;
            this.BtnEliminarEmpleado.IconZoom = 60D;
            this.BtnEliminarEmpleado.IsTab = false;
            this.BtnEliminarEmpleado.Location = new System.Drawing.Point(736, 563);
            this.BtnEliminarEmpleado.Name = "BtnEliminarEmpleado";
            this.BtnEliminarEmpleado.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnEliminarEmpleado.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.BtnEliminarEmpleado.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnEliminarEmpleado.selected = false;
            this.BtnEliminarEmpleado.Size = new System.Drawing.Size(193, 59);
            this.BtnEliminarEmpleado.TabIndex = 10;
            this.BtnEliminarEmpleado.Text = "Eliminar un empleado";
            this.BtnEliminarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnEliminarEmpleado.Textcolor = System.Drawing.Color.White;
            this.BtnEliminarEmpleado.TextFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // BtnActualizarEmpleado
            // 
            this.BtnActualizarEmpleado.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnActualizarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnActualizarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnActualizarEmpleado.BorderRadius = 7;
            this.BtnActualizarEmpleado.ButtonText = "Actualizar un empleado";
            this.BtnActualizarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnActualizarEmpleado.DisabledColor = System.Drawing.Color.Gray;
            this.BtnActualizarEmpleado.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnActualizarEmpleado.Iconimage = ((System.Drawing.Image)(resources.GetObject("BtnActualizarEmpleado.Iconimage")));
            this.BtnActualizarEmpleado.Iconimage_right = null;
            this.BtnActualizarEmpleado.Iconimage_right_Selected = null;
            this.BtnActualizarEmpleado.Iconimage_Selected = null;
            this.BtnActualizarEmpleado.IconMarginLeft = 0;
            this.BtnActualizarEmpleado.IconMarginRight = 0;
            this.BtnActualizarEmpleado.IconRightVisible = true;
            this.BtnActualizarEmpleado.IconRightZoom = 0D;
            this.BtnActualizarEmpleado.IconVisible = true;
            this.BtnActualizarEmpleado.IconZoom = 60D;
            this.BtnActualizarEmpleado.IsTab = false;
            this.BtnActualizarEmpleado.Location = new System.Drawing.Point(496, 563);
            this.BtnActualizarEmpleado.Name = "BtnActualizarEmpleado";
            this.BtnActualizarEmpleado.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnActualizarEmpleado.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.BtnActualizarEmpleado.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnActualizarEmpleado.selected = false;
            this.BtnActualizarEmpleado.Size = new System.Drawing.Size(197, 59);
            this.BtnActualizarEmpleado.TabIndex = 9;
            this.BtnActualizarEmpleado.Text = "Actualizar un empleado";
            this.BtnActualizarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnActualizarEmpleado.Textcolor = System.Drawing.Color.White;
            this.BtnActualizarEmpleado.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // BtnAgregarEmpleado
            // 
            this.BtnAgregarEmpleado.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAgregarEmpleado.BorderRadius = 7;
            this.BtnAgregarEmpleado.ButtonText = "Agregar nuevo empleado";
            this.BtnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarEmpleado.DisabledColor = System.Drawing.Color.Gray;
            this.BtnAgregarEmpleado.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnAgregarEmpleado.Iconimage = ((System.Drawing.Image)(resources.GetObject("BtnAgregarEmpleado.Iconimage")));
            this.BtnAgregarEmpleado.Iconimage_right = null;
            this.BtnAgregarEmpleado.Iconimage_right_Selected = null;
            this.BtnAgregarEmpleado.Iconimage_Selected = null;
            this.BtnAgregarEmpleado.IconMarginLeft = 0;
            this.BtnAgregarEmpleado.IconMarginRight = 0;
            this.BtnAgregarEmpleado.IconRightVisible = true;
            this.BtnAgregarEmpleado.IconRightZoom = 0D;
            this.BtnAgregarEmpleado.IconVisible = true;
            this.BtnAgregarEmpleado.IconZoom = 60D;
            this.BtnAgregarEmpleado.IsTab = false;
            this.BtnAgregarEmpleado.Location = new System.Drawing.Point(253, 563);
            this.BtnAgregarEmpleado.Name = "BtnAgregarEmpleado";
            this.BtnAgregarEmpleado.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.BtnAgregarEmpleado.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnAgregarEmpleado.selected = false;
            this.BtnAgregarEmpleado.Size = new System.Drawing.Size(197, 59);
            this.BtnAgregarEmpleado.TabIndex = 8;
            this.BtnAgregarEmpleado.Text = "Agregar nuevo empleado";
            this.BtnAgregarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAgregarEmpleado.Textcolor = System.Drawing.Color.White;
            this.BtnAgregarEmpleado.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ApartadoEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 688);
            this.Controls.Add(this.BtnEliminarEmpleado);
            this.Controls.Add(this.BtnActualizarEmpleado);
            this.Controls.Add(this.BtnAgregarEmpleado);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.dataGriEmpleados);
            this.Controls.Add(this.bunifuLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApartadoEmpleados";
            this.Text = "ApartadoEmpleados";
            ((System.ComponentModel.ISupportInitialize)(this.dataGriEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuDataGridView dataGriEmpleados;
        private Bunifu.Framework.UI.BunifuThinButton2 BtnRegresar;
        private Bunifu.Framework.UI.BunifuFlatButton BtnEliminarEmpleado;
        private Bunifu.Framework.UI.BunifuFlatButton BtnActualizarEmpleado;
        private Bunifu.Framework.UI.BunifuFlatButton BtnAgregarEmpleado;
    }
}