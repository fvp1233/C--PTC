﻿namespace PTC2024.View.Clientes
{
    partial class FrmUploadCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUploadCustomers));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
<<<<<<< Updated upstream
            this.dtFecha = new Bunifu.UI.WinForms.BunifuDatePicker();
=======
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
>>>>>>> Stashed changes
            this.txtNombres = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dpTipoCliente = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
<<<<<<< Updated upstream
            this.txtLastNames = new Bunifu.Framework.UI.BunifuMaterialTextbox();
=======
            this.bunifuMaterialTextbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
>>>>>>> Stashed changes
            this.txtDui = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTelefono = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtDireccion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.BtnAgregarEmpleado = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.BtnCancelar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(266, 53);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(221, 17);
            this.bunifuCustomLabel2.TabIndex = 113;
            this.bunifuCustomLabel2.Text = "Actualice la información que desee";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(218, 21);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(318, 32);
            this.bunifuCustomLabel1.TabIndex = 112;
            this.bunifuCustomLabel1.Text = "ACTUALIZAR CLIENTE";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(79, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(608, 35);
            this.bunifuSeparator1.TabIndex = 190;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
<<<<<<< Updated upstream
            // dtFecha
            // 
            this.dtFecha.BackColor = System.Drawing.Color.LightGray;
            this.dtFecha.BorderColor = System.Drawing.Color.Silver;
            this.dtFecha.BorderRadius = 1;
            this.dtFecha.Color = System.Drawing.Color.Silver;
            this.dtFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtFecha.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtFecha.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtFecha.DisabledColor = System.Drawing.Color.Gray;
            this.dtFecha.DisplayWeekNumbers = false;
            this.dtFecha.DPHeight = 0;
            this.dtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha.FillDatePicker = false;
            this.dtFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFecha.ForeColor = System.Drawing.Color.Black;
            this.dtFecha.Icon = ((System.Drawing.Image)(resources.GetObject("dtFecha.Icon")));
            this.dtFecha.IconColor = System.Drawing.Color.DimGray;
            this.dtFecha.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtFecha.LeftTextMargin = 5;
            this.dtFecha.Location = new System.Drawing.Point(386, 192);
            this.dtFecha.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(330, 32);
            this.dtFecha.TabIndex = 189;
            this.dtFecha.Value = new System.DateTime(2024, 7, 13, 16, 30, 0, 0);
=======
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.LightGray;
            this.bunifuDatePicker1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.BorderRadius = 1;
            this.bunifuDatePicker1.Color = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.DimGray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(386, 192);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(4, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(330, 32);
            this.bunifuDatePicker1.TabIndex = 189;
            this.bunifuDatePicker1.Value = new System.DateTime(2024, 7, 13, 16, 30, 0, 0);
>>>>>>> Stashed changes
            // 
            // txtNombres
            // 
            this.txtNombres.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNombres.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombres.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNombres.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombres.HintForeColor = System.Drawing.Color.Empty;
            this.txtNombres.HintText = "";
            this.txtNombres.isPassword = false;
            this.txtNombres.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtNombres.LineIdleColor = System.Drawing.Color.Gray;
            this.txtNombres.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtNombres.LineThickness = 3;
            this.txtNombres.Location = new System.Drawing.Point(48, 130);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(330, 31);
            this.txtNombres.TabIndex = 175;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(383, 366);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(115, 16);
            this.bunifuCustomLabel8.TabIndex = 188;
            this.bunifuCustomLabel8.Text = "Tipo de cliente:";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(45, 110);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(74, 16);
            this.bunifuCustomLabel3.TabIndex = 174;
            this.bunifuCustomLabel3.Text = "Nombres:";
            // 
            // dpTipoCliente
            // 
<<<<<<< Updated upstream
            this.dpTipoCliente.BackColor = System.Drawing.Color.Transparent;
            this.dpTipoCliente.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dpTipoCliente.BorderColor = System.Drawing.Color.Silver;
            this.dpTipoCliente.BorderRadius = 1;
            this.dpTipoCliente.Color = System.Drawing.Color.Silver;
            this.dpTipoCliente.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dpTipoCliente.DisabledBackColor = System.Drawing.Color.Silver;
            this.dpTipoCliente.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dpTipoCliente.DisabledColor = System.Drawing.Color.Silver;
            this.dpTipoCliente.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dpTipoCliente.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.dpTipoCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dpTipoCliente.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dpTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpTipoCliente.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dpTipoCliente.FillDropDown = true;
            this.dpTipoCliente.FillIndicator = false;
            this.dpTipoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dpTipoCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dpTipoCliente.ForeColor = System.Drawing.Color.Black;
            this.dpTipoCliente.FormattingEnabled = true;
            this.dpTipoCliente.Icon = null;
            this.dpTipoCliente.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dpTipoCliente.IndicatorColor = System.Drawing.Color.Black;
            this.dpTipoCliente.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dpTipoCliente.IndicatorThickness = 2;
            this.dpTipoCliente.IsDropdownOpened = false;
            this.dpTipoCliente.ItemBackColor = System.Drawing.Color.Silver;
            this.dpTipoCliente.ItemBorderColor = System.Drawing.Color.Silver;
            this.dpTipoCliente.ItemForeColor = System.Drawing.Color.Black;
            this.dpTipoCliente.ItemHeight = 26;
            this.dpTipoCliente.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.dpTipoCliente.ItemHighLightForeColor = System.Drawing.Color.White;
            this.dpTipoCliente.ItemTopMargin = 3;
            this.dpTipoCliente.Location = new System.Drawing.Point(386, 386);
            this.dpTipoCliente.Name = "dpTipoCliente";
            this.dpTipoCliente.Size = new System.Drawing.Size(330, 32);
            this.dpTipoCliente.TabIndex = 187;
            this.dpTipoCliente.Text = null;
            this.dpTipoCliente.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dpTipoCliente.TextLeftMargin = 5;
=======
            this.bunifuDropdown1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.bunifuDropdown1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuDropdown1.BorderRadius = 1;
            this.bunifuDropdown1.Color = System.Drawing.Color.Silver;
            this.bunifuDropdown1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown1.DisabledBackColor = System.Drawing.Color.Silver;
            this.bunifuDropdown1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuDropdown1.DisabledColor = System.Drawing.Color.Silver;
            this.bunifuDropdown1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bunifuDropdown1.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.bunifuDropdown1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.bunifuDropdown1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown1.FillDropDown = true;
            this.bunifuDropdown1.FillIndicator = false;
            this.bunifuDropdown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.FormattingEnabled = true;
            this.bunifuDropdown1.Icon = null;
            this.bunifuDropdown1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown1.IndicatorColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown1.IndicatorThickness = 2;
            this.bunifuDropdown1.IsDropdownOpened = false;
            this.bunifuDropdown1.ItemBackColor = System.Drawing.Color.Silver;
            this.bunifuDropdown1.ItemBorderColor = System.Drawing.Color.Silver;
            this.bunifuDropdown1.ItemForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.ItemHeight = 26;
            this.bunifuDropdown1.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemTopMargin = 3;
            this.bunifuDropdown1.Location = new System.Drawing.Point(386, 386);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.Size = new System.Drawing.Size(330, 32);
            this.bunifuDropdown1.TabIndex = 187;
            this.bunifuDropdown1.Text = null;
            this.bunifuDropdown1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown1.TextLeftMargin = 5;
>>>>>>> Stashed changes
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(45, 173);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(35, 16);
            this.bunifuCustomLabel6.TabIndex = 176;
            this.bunifuCustomLabel6.Text = "DUI:";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(383, 110);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(76, 16);
            this.bunifuCustomLabel4.TabIndex = 186;
            this.bunifuCustomLabel4.Text = "Apellidos:";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(383, 174);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(157, 16);
            this.bunifuCustomLabel5.TabIndex = 177;
            this.bunifuCustomLabel5.Text = "Fecha de nacimiento:";
            // 
<<<<<<< Updated upstream
            // txtLastNames
            // 
            this.txtLastNames.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLastNames.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastNames.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtLastNames.ForeColor = System.Drawing.Color.DimGray;
            this.txtLastNames.HintForeColor = System.Drawing.Color.Empty;
            this.txtLastNames.HintText = "";
            this.txtLastNames.isPassword = false;
            this.txtLastNames.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtLastNames.LineIdleColor = System.Drawing.Color.Gray;
            this.txtLastNames.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtLastNames.LineThickness = 3;
            this.txtLastNames.Location = new System.Drawing.Point(386, 130);
            this.txtLastNames.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastNames.Name = "txtLastNames";
            this.txtLastNames.Size = new System.Drawing.Size(330, 31);
            this.txtLastNames.TabIndex = 185;
            this.txtLastNames.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
=======
            // bunifuMaterialTextbox1
            // 
            this.bunifuMaterialTextbox1.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMaterialTextbox1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox1.HintText = "";
            this.bunifuMaterialTextbox1.isPassword = false;
            this.bunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.bunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.Gray;
            this.bunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.bunifuMaterialTextbox1.LineThickness = 3;
            this.bunifuMaterialTextbox1.Location = new System.Drawing.Point(386, 130);
            this.bunifuMaterialTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
            this.bunifuMaterialTextbox1.Size = new System.Drawing.Size(330, 31);
            this.bunifuMaterialTextbox1.TabIndex = 185;
            this.bunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
>>>>>>> Stashed changes
            // 
            // txtDui
            // 
            this.txtDui.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDui.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDui.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtDui.ForeColor = System.Drawing.Color.DimGray;
            this.txtDui.HintForeColor = System.Drawing.Color.Empty;
            this.txtDui.HintText = "";
            this.txtDui.isPassword = false;
            this.txtDui.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDui.LineIdleColor = System.Drawing.Color.Gray;
            this.txtDui.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDui.LineThickness = 3;
            this.txtDui.Location = new System.Drawing.Point(48, 193);
            this.txtDui.Margin = new System.Windows.Forms.Padding(4);
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(330, 31);
            this.txtDui.TabIndex = 178;
            this.txtDui.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.HintForeColor = System.Drawing.Color.Empty;
            this.txtEmail.HintText = "";
            this.txtEmail.isPassword = false;
            this.txtEmail.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtEmail.LineIdleColor = System.Drawing.Color.Gray;
            this.txtEmail.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtEmail.LineThickness = 3;
            this.txtEmail.Location = new System.Drawing.Point(48, 322);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(668, 31);
            this.txtEmail.TabIndex = 184;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(45, 237);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(78, 16);
            this.bunifuCustomLabel7.TabIndex = 179;
            this.bunifuCustomLabel7.Text = "Dirección:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelefono.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTelefono.ForeColor = System.Drawing.Color.DimGray;
            this.txtTelefono.HintForeColor = System.Drawing.Color.Empty;
            this.txtTelefono.HintText = "";
            this.txtTelefono.isPassword = false;
            this.txtTelefono.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtTelefono.LineIdleColor = System.Drawing.Color.Gray;
            this.txtTelefono.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtTelefono.LineThickness = 3;
            this.txtTelefono.Location = new System.Drawing.Point(48, 387);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(330, 31);
            this.txtTelefono.TabIndex = 183;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDireccion.HintForeColor = System.Drawing.Color.Empty;
            this.txtDireccion.HintText = "";
            this.txtDireccion.isPassword = false;
            this.txtDireccion.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDireccion.LineIdleColor = System.Drawing.Color.Gray;
            this.txtDireccion.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDireccion.LineThickness = 3;
            this.txtDireccion.Location = new System.Drawing.Point(48, 257);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(668, 31);
            this.txtDireccion.TabIndex = 180;
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(45, 302);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(48, 16);
            this.bunifuCustomLabel9.TabIndex = 182;
            this.bunifuCustomLabel9.Text = "Email:";
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(45, 367);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(71, 16);
            this.bunifuCustomLabel10.TabIndex = 181;
            this.bunifuCustomLabel10.Text = "Teléfono:";
            // 
            // BtnAgregarEmpleado
            // 
            this.BtnAgregarEmpleado.AllowAnimations = true;
            this.BtnAgregarEmpleado.AllowMouseEffects = true;
            this.BtnAgregarEmpleado.AllowToggling = false;
            this.BtnAgregarEmpleado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAgregarEmpleado.AnimationSpeed = 200;
            this.BtnAgregarEmpleado.AutoGenerateColors = false;
            this.BtnAgregarEmpleado.AutoRoundBorders = false;
            this.BtnAgregarEmpleado.AutoSizeLeftIcon = true;
            this.BtnAgregarEmpleado.AutoSizeRightIcon = true;
            this.BtnAgregarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarEmpleado.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAgregarEmpleado.BackgroundImage")));
            this.BtnAgregarEmpleado.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnAgregarEmpleado.ButtonText = "Actualizar";
            this.BtnAgregarEmpleado.ButtonTextMarginLeft = 0;
            this.BtnAgregarEmpleado.ColorContrastOnClick = 45;
            this.BtnAgregarEmpleado.ColorContrastOnHover = 45;
            this.BtnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnAgregarEmpleado.CustomizableEdges = borderEdges1;
            this.BtnAgregarEmpleado.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnAgregarEmpleado.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAgregarEmpleado.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAgregarEmpleado.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAgregarEmpleado.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.BtnAgregarEmpleado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarEmpleado.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarEmpleado.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregarEmpleado.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAgregarEmpleado.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnAgregarEmpleado.IconMarginLeft = 11;
            this.BtnAgregarEmpleado.IconPadding = 10;
            this.BtnAgregarEmpleado.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarEmpleado.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAgregarEmpleado.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnAgregarEmpleado.IconSize = 25;
            this.BtnAgregarEmpleado.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.IdleBorderRadius = 20;
            this.BtnAgregarEmpleado.IdleBorderThickness = 1;
            this.BtnAgregarEmpleado.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.IdleIconLeftImage = null;
            this.BtnAgregarEmpleado.IdleIconRightImage = null;
            this.BtnAgregarEmpleado.IndicateFocus = false;
            this.BtnAgregarEmpleado.Location = new System.Drawing.Point(387, 455);
            this.BtnAgregarEmpleado.Name = "BtnAgregarEmpleado";
            this.BtnAgregarEmpleado.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAgregarEmpleado.OnDisabledState.BorderRadius = 20;
            this.BtnAgregarEmpleado.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnAgregarEmpleado.OnDisabledState.BorderThickness = 1;
            this.BtnAgregarEmpleado.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAgregarEmpleado.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAgregarEmpleado.OnDisabledState.IconLeftImage = null;
            this.BtnAgregarEmpleado.OnDisabledState.IconRightImage = null;
            this.BtnAgregarEmpleado.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnAgregarEmpleado.onHoverState.BorderRadius = 20;
            this.BtnAgregarEmpleado.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnAgregarEmpleado.onHoverState.BorderThickness = 1;
            this.BtnAgregarEmpleado.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnAgregarEmpleado.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregarEmpleado.onHoverState.IconLeftImage = null;
            this.BtnAgregarEmpleado.onHoverState.IconRightImage = null;
            this.BtnAgregarEmpleado.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.OnIdleState.BorderRadius = 20;
            this.BtnAgregarEmpleado.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnAgregarEmpleado.OnIdleState.BorderThickness = 1;
            this.BtnAgregarEmpleado.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnAgregarEmpleado.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarEmpleado.OnIdleState.IconLeftImage = null;
            this.BtnAgregarEmpleado.OnIdleState.IconRightImage = null;
            this.BtnAgregarEmpleado.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnAgregarEmpleado.OnPressedState.BorderRadius = 20;
            this.BtnAgregarEmpleado.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnAgregarEmpleado.OnPressedState.BorderThickness = 1;
            this.BtnAgregarEmpleado.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnAgregarEmpleado.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarEmpleado.OnPressedState.IconLeftImage = null;
            this.BtnAgregarEmpleado.OnPressedState.IconRightImage = null;
            this.BtnAgregarEmpleado.Size = new System.Drawing.Size(151, 52);
            this.BtnAgregarEmpleado.TabIndex = 173;
            this.BtnAgregarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAgregarEmpleado.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnAgregarEmpleado.TextMarginLeft = 0;
            this.BtnAgregarEmpleado.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnAgregarEmpleado.UseDefaultRadiusAndThickness = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AllowAnimations = true;
            this.BtnCancelar.AllowMouseEffects = true;
            this.BtnCancelar.AllowToggling = false;
            this.BtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancelar.AnimationSpeed = 200;
            this.BtnCancelar.AutoGenerateColors = false;
            this.BtnCancelar.AutoRoundBorders = false;
            this.BtnCancelar.AutoSizeLeftIcon = true;
            this.BtnCancelar.AutoSizeRightIcon = true;
            this.BtnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.BackgroundImage")));
            this.BtnCancelar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCancelar.ButtonText = "Regresar";
            this.BtnCancelar.ButtonTextMarginLeft = 0;
            this.BtnCancelar.ColorContrastOnClick = 45;
            this.BtnCancelar.ColorContrastOnHover = 45;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.BtnCancelar.CustomizableEdges = borderEdges2;
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnCancelar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnCancelar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnCancelar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnCancelar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnCancelar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnCancelar.IconMarginLeft = 11;
            this.BtnCancelar.IconPadding = 10;
            this.BtnCancelar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnCancelar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnCancelar.IconSize = 25;
            this.BtnCancelar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnCancelar.IdleBorderRadius = 20;
            this.BtnCancelar.IdleBorderThickness = 1;
            this.BtnCancelar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnCancelar.IdleIconLeftImage = null;
            this.BtnCancelar.IdleIconRightImage = null;
            this.BtnCancelar.IndicateFocus = false;
            this.BtnCancelar.Location = new System.Drawing.Point(228, 455);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnCancelar.OnDisabledState.BorderRadius = 20;
            this.BtnCancelar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCancelar.OnDisabledState.BorderThickness = 1;
            this.BtnCancelar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnCancelar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnCancelar.OnDisabledState.IconLeftImage = null;
            this.BtnCancelar.OnDisabledState.IconRightImage = null;
            this.BtnCancelar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnCancelar.onHoverState.BorderRadius = 20;
            this.BtnCancelar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCancelar.onHoverState.BorderThickness = 1;
            this.BtnCancelar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnCancelar.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelar.onHoverState.IconLeftImage = null;
            this.BtnCancelar.onHoverState.IconRightImage = null;
            this.BtnCancelar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnCancelar.OnIdleState.BorderRadius = 20;
            this.BtnCancelar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCancelar.OnIdleState.BorderThickness = 1;
            this.BtnCancelar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.BtnCancelar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.OnIdleState.IconLeftImage = null;
            this.BtnCancelar.OnIdleState.IconRightImage = null;
            this.BtnCancelar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnCancelar.OnPressedState.BorderRadius = 20;
            this.BtnCancelar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCancelar.OnPressedState.BorderThickness = 1;
            this.BtnCancelar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.BtnCancelar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.OnPressedState.IconLeftImage = null;
            this.BtnCancelar.OnPressedState.IconRightImage = null;
            this.BtnCancelar.Size = new System.Drawing.Size(151, 52);
            this.BtnCancelar.TabIndex = 172;
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnCancelar.TextMarginLeft = 0;
            this.BtnCancelar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnCancelar.UseDefaultRadiusAndThickness = true;
            // 
            // FrmUploadCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 536);
            this.Controls.Add(this.bunifuSeparator1);
<<<<<<< Updated upstream
            this.Controls.Add(this.dtFecha);
=======
            this.Controls.Add(this.bunifuDatePicker1);
>>>>>>> Stashed changes
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.bunifuCustomLabel8);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.dpTipoCliente);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.bunifuCustomLabel5);
<<<<<<< Updated upstream
            this.Controls.Add(this.txtLastNames);
=======
            this.Controls.Add(this.bunifuMaterialTextbox1);
>>>>>>> Stashed changes
            this.Controls.Add(this.txtDui);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.bunifuCustomLabel7);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.bunifuCustomLabel9);
            this.Controls.Add(this.bunifuCustomLabel10);
            this.Controls.Add(this.BtnAgregarEmpleado);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUploadCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModificarCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
<<<<<<< Updated upstream
        public Bunifu.UI.WinForms.BunifuDatePicker dtFecha;
=======
        public Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtNombres;
>>>>>>> Stashed changes
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
<<<<<<< Updated upstream
=======
        private Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtDui;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtEmail;
>>>>>>> Stashed changes
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTelefono;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtDireccion;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnAgregarEmpleado;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnCancelar;
<<<<<<< Updated upstream
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtNombres;
        public Bunifu.UI.WinForms.BunifuDropdown dpTipoCliente;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtLastNames;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtDui;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtEmail;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtTelefono;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtDireccion;
=======
>>>>>>> Stashed changes
    }
}