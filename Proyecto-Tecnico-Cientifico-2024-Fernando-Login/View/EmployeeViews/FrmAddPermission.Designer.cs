namespace PTC2024.View.EmployeeViews
{
    partial class FrmAddPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddPermission));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.lblSubTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.groupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.lblEmployeeName = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblText = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblStatusPerm = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.rtxtContext = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtIdEmployee = new Bunifu.UI.WinForms.BunifuTextBox();
            this.cmbTypePermission = new Bunifu.UI.WinForms.BunifuDropdown();
            this.lblTypePerm = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cmbStatusPermission = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblReason = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblEnd = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dtpEnd = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.lblStart = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dtpStart = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.lblEmployeeID = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnAddPermission = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
            this.bunifuSnackbar1 = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.Location = new System.Drawing.Point(-1, 44);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(861, 15);
            this.lblSubTitle.TabIndex = 109;
            this.lblSubTitle.Text = "Ingrese en cada campo la información solicitada";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuToolTip1.SetToolTip(this.lblSubTitle, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblSubTitle, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblSubTitle, "");
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(-1, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(861, 32);
            this.lblTitle.TabIndex = 108;
            this.lblTitle.Text = "AGREGAR PERMISO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuToolTip1.SetToolTip(this.lblTitle, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblTitle, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblTitle, "");
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.groupBox1.BorderRadius = 10;
            this.groupBox1.BorderThickness = 2;
            this.groupBox1.Controls.Add(this.lblEmployeeName);
            this.groupBox1.Controls.Add(this.lblText);
            this.groupBox1.Controls.Add(this.lblStatusPerm);
            this.groupBox1.Controls.Add(this.rtxtContext);
            this.groupBox1.Controls.Add(this.txtIdEmployee);
            this.groupBox1.Controls.Add(this.cmbTypePermission);
            this.groupBox1.Controls.Add(this.lblTypePerm);
            this.groupBox1.Controls.Add(this.cmbStatusPermission);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel11);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.lblEnd);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.lblStart);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.lblEmployeeID);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.groupBox1.LabelIndent = 10;
            this.groupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.groupBox1.Location = new System.Drawing.Point(18, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 353);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permiso";
            this.bunifuToolTip1.SetToolTip(this.groupBox1, "");
            this.bunifuToolTip1.SetToolTipIcon(this.groupBox1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.groupBox1, "");
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AllowParentOverrides = false;
            this.lblEmployeeName.AutoEllipsis = false;
            this.lblEmployeeName.AutoSize = false;
            this.lblEmployeeName.CursorType = null;
            this.lblEmployeeName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(22, 316);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblEmployeeName.Size = new System.Drawing.Size(777, 25);
            this.lblEmployeeName.TabIndex = 117;
            this.lblEmployeeName.Text = "nombreEmpleado";
            this.lblEmployeeName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmployeeName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuToolTip1.SetToolTip(this.lblEmployeeName, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblEmployeeName, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblEmployeeName, "");
            // 
            // lblText
            // 
            this.lblText.AllowParentOverrides = false;
            this.lblText.AutoEllipsis = false;
            this.lblText.AutoSize = false;
            this.lblText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblText.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(22, 294);
            this.lblText.Name = "lblText";
            this.lblText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblText.Size = new System.Drawing.Size(777, 25);
            this.lblText.TabIndex = 116;
            this.lblText.Text = "[EMPLEADO AL QUE SE LE ESTÁ CREANDO EL PERMISO]";
            this.lblText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblText.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuToolTip1.SetToolTip(this.lblText, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblText, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblText, "");
            // 
            // lblStatusPerm
            // 
            this.lblStatusPerm.AutoSize = true;
            this.lblStatusPerm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPerm.Location = new System.Drawing.Point(548, 30);
            this.lblStatusPerm.Name = "lblStatusPerm";
            this.lblStatusPerm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatusPerm.Size = new System.Drawing.Size(146, 16);
            this.lblStatusPerm.TabIndex = 115;
            this.lblStatusPerm.Text = "Estado del permiso:";
            this.bunifuToolTip1.SetToolTip(this.lblStatusPerm, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblStatusPerm, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblStatusPerm, "");
            // 
            // rtxtContext
            // 
            this.rtxtContext.AcceptsReturn = false;
            this.rtxtContext.AcceptsTab = false;
            this.rtxtContext.AnimationSpeed = 200;
            this.rtxtContext.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.rtxtContext.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.rtxtContext.AutoSizeHeight = true;
            this.rtxtContext.BackColor = System.Drawing.Color.Gainsboro;
            this.rtxtContext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rtxtContext.BackgroundImage")));
            this.rtxtContext.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.rtxtContext.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.rtxtContext.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.rtxtContext.BorderColorIdle = System.Drawing.Color.Gray;
            this.rtxtContext.BorderRadius = 1;
            this.rtxtContext.BorderThickness = 3;
            this.rtxtContext.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.rtxtContext.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.rtxtContext.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtContext.DefaultFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtContext.DefaultText = "";
            this.rtxtContext.FillColor = System.Drawing.Color.Gainsboro;
            this.rtxtContext.HideSelection = true;
            this.rtxtContext.IconLeft = null;
            this.rtxtContext.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtContext.IconPadding = 10;
            this.rtxtContext.IconRight = null;
            this.rtxtContext.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.rtxtContext.Lines = new string[0];
            this.rtxtContext.Location = new System.Drawing.Point(22, 188);
            this.rtxtContext.MaxLength = 300;
            this.rtxtContext.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtxtContext.Modified = false;
            this.rtxtContext.Multiline = true;
            this.rtxtContext.Name = "rtxtContext";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.rtxtContext.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.rtxtContext.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.rtxtContext.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Gray;
            stateProperties4.FillColor = System.Drawing.Color.Gainsboro;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.rtxtContext.OnIdleState = stateProperties4;
            this.rtxtContext.Padding = new System.Windows.Forms.Padding(3);
            this.rtxtContext.PasswordChar = '\0';
            this.rtxtContext.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.rtxtContext.PlaceholderText = "";
            this.rtxtContext.ReadOnly = false;
            this.rtxtContext.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.rtxtContext.SelectedText = "";
            this.rtxtContext.SelectionLength = 0;
            this.rtxtContext.SelectionStart = 0;
            this.rtxtContext.ShortcutsEnabled = true;
            this.rtxtContext.Size = new System.Drawing.Size(777, 84);
            this.rtxtContext.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.rtxtContext.TabIndex = 114;
            this.rtxtContext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rtxtContext.TextMarginBottom = 0;
            this.rtxtContext.TextMarginLeft = 0;
            this.rtxtContext.TextMarginTop = 0;
            this.rtxtContext.TextPlaceholder = "";
            this.bunifuToolTip1.SetToolTip(this.rtxtContext, "");
            this.bunifuToolTip1.SetToolTipIcon(this.rtxtContext, null);
            this.bunifuToolTip1.SetToolTipTitle(this.rtxtContext, "");
            this.rtxtContext.UseSystemPasswordChar = false;
            this.rtxtContext.WordWrap = true;
            // 
            // txtIdEmployee
            // 
            this.txtIdEmployee.AcceptsReturn = false;
            this.txtIdEmployee.AcceptsTab = false;
            this.txtIdEmployee.AnimationSpeed = 200;
            this.txtIdEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIdEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIdEmployee.AutoSizeHeight = true;
            this.txtIdEmployee.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdEmployee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtIdEmployee.BackgroundImage")));
            this.txtIdEmployee.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtIdEmployee.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtIdEmployee.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtIdEmployee.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtIdEmployee.BorderRadius = 1;
            this.txtIdEmployee.BorderThickness = 3;
            this.txtIdEmployee.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtIdEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIdEmployee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdEmployee.DefaultFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEmployee.DefaultText = "";
            this.txtIdEmployee.FillColor = System.Drawing.Color.Gainsboro;
            this.txtIdEmployee.HideSelection = true;
            this.txtIdEmployee.IconLeft = null;
            this.txtIdEmployee.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdEmployee.IconPadding = 10;
            this.txtIdEmployee.IconRight = null;
            this.txtIdEmployee.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdEmployee.Lines = new string[0];
            this.txtIdEmployee.Location = new System.Drawing.Point(22, 49);
            this.txtIdEmployee.MaximumSize = new System.Drawing.Size(330, 32);
            this.txtIdEmployee.MaxLength = 8;
            this.txtIdEmployee.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtIdEmployee.Modified = false;
            this.txtIdEmployee.Multiline = false;
            this.txtIdEmployee.Name = "txtIdEmployee";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtIdEmployee.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtIdEmployee.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtIdEmployee.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Gray;
            stateProperties8.FillColor = System.Drawing.Color.Gainsboro;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtIdEmployee.OnIdleState = stateProperties8;
            this.txtIdEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.txtIdEmployee.PasswordChar = '\0';
            this.txtIdEmployee.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtIdEmployee.PlaceholderText = "";
            this.txtIdEmployee.ReadOnly = false;
            this.txtIdEmployee.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIdEmployee.SelectedText = "";
            this.txtIdEmployee.SelectionLength = 0;
            this.txtIdEmployee.SelectionStart = 0;
            this.txtIdEmployee.ShortcutsEnabled = true;
            this.txtIdEmployee.Size = new System.Drawing.Size(252, 32);
            this.txtIdEmployee.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtIdEmployee.TabIndex = 113;
            this.txtIdEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIdEmployee.TextMarginBottom = 0;
            this.txtIdEmployee.TextMarginLeft = 0;
            this.txtIdEmployee.TextMarginTop = 0;
            this.txtIdEmployee.TextPlaceholder = "";
            this.bunifuToolTip1.SetToolTip(this.txtIdEmployee, "Presione la tecla ENTER después de ingresar el ID.");
            this.bunifuToolTip1.SetToolTipIcon(this.txtIdEmployee, null);
            this.bunifuToolTip1.SetToolTipTitle(this.txtIdEmployee, "IMPORTANTE");
            this.txtIdEmployee.UseSystemPasswordChar = false;
            this.txtIdEmployee.WordWrap = true;
            // 
            // cmbTypePermission
            // 
            this.cmbTypePermission.BackColor = System.Drawing.Color.Transparent;
            this.cmbTypePermission.BackgroundColor = System.Drawing.Color.LightGray;
            this.cmbTypePermission.BorderColor = System.Drawing.Color.Silver;
            this.cmbTypePermission.BorderRadius = 1;
            this.cmbTypePermission.Color = System.Drawing.Color.Silver;
            this.cmbTypePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTypePermission.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbTypePermission.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbTypePermission.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbTypePermission.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbTypePermission.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbTypePermission.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbTypePermission.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTypePermission.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbTypePermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypePermission.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbTypePermission.FillDropDown = true;
            this.cmbTypePermission.FillIndicator = false;
            this.cmbTypePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTypePermission.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypePermission.ForeColor = System.Drawing.Color.Black;
            this.cmbTypePermission.FormattingEnabled = true;
            this.cmbTypePermission.Icon = null;
            this.cmbTypePermission.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbTypePermission.IndicatorColor = System.Drawing.Color.DimGray;
            this.cmbTypePermission.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbTypePermission.IndicatorThickness = 2;
            this.cmbTypePermission.IsDropdownOpened = false;
            this.cmbTypePermission.ItemBackColor = System.Drawing.Color.White;
            this.cmbTypePermission.ItemBorderColor = System.Drawing.Color.White;
            this.cmbTypePermission.ItemForeColor = System.Drawing.Color.Black;
            this.cmbTypePermission.ItemHeight = 26;
            this.cmbTypePermission.ItemHighLightColor = System.Drawing.Color.LightGray;
            this.cmbTypePermission.ItemHighLightForeColor = System.Drawing.Color.Black;
            this.cmbTypePermission.ItemTopMargin = 3;
            this.cmbTypePermission.Location = new System.Drawing.Point(281, 49);
            this.cmbTypePermission.Name = "cmbTypePermission";
            this.cmbTypePermission.Size = new System.Drawing.Size(260, 32);
            this.cmbTypePermission.TabIndex = 52;
            this.cmbTypePermission.Text = null;
            this.cmbTypePermission.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbTypePermission.TextLeftMargin = 5;
            this.bunifuToolTip1.SetToolTip(this.cmbTypePermission, "");
            this.bunifuToolTip1.SetToolTipIcon(this.cmbTypePermission, null);
            this.bunifuToolTip1.SetToolTipTitle(this.cmbTypePermission, "");
            // 
            // lblTypePerm
            // 
            this.lblTypePerm.AutoSize = true;
            this.lblTypePerm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypePerm.Location = new System.Drawing.Point(282, 30);
            this.lblTypePerm.Name = "lblTypePerm";
            this.lblTypePerm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTypePerm.Size = new System.Drawing.Size(124, 16);
            this.lblTypePerm.TabIndex = 53;
            this.lblTypePerm.Text = "Tipo de permiso:";
            this.bunifuToolTip1.SetToolTip(this.lblTypePerm, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblTypePerm, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblTypePerm, "");
            // 
            // cmbStatusPermission
            // 
            this.cmbStatusPermission.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatusPermission.BackgroundColor = System.Drawing.Color.LightGray;
            this.cmbStatusPermission.BorderColor = System.Drawing.Color.Silver;
            this.cmbStatusPermission.BorderRadius = 1;
            this.cmbStatusPermission.Color = System.Drawing.Color.Silver;
            this.cmbStatusPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatusPermission.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbStatusPermission.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbStatusPermission.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbStatusPermission.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbStatusPermission.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbStatusPermission.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbStatusPermission.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatusPermission.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbStatusPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusPermission.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbStatusPermission.FillDropDown = true;
            this.cmbStatusPermission.FillIndicator = false;
            this.cmbStatusPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatusPermission.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusPermission.ForeColor = System.Drawing.Color.Black;
            this.cmbStatusPermission.FormattingEnabled = true;
            this.cmbStatusPermission.Icon = null;
            this.cmbStatusPermission.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbStatusPermission.IndicatorColor = System.Drawing.Color.DimGray;
            this.cmbStatusPermission.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbStatusPermission.IndicatorThickness = 2;
            this.cmbStatusPermission.IsDropdownOpened = false;
            this.cmbStatusPermission.ItemBackColor = System.Drawing.Color.White;
            this.cmbStatusPermission.ItemBorderColor = System.Drawing.Color.White;
            this.cmbStatusPermission.ItemForeColor = System.Drawing.Color.Black;
            this.cmbStatusPermission.ItemHeight = 26;
            this.cmbStatusPermission.ItemHighLightColor = System.Drawing.Color.LightGray;
            this.cmbStatusPermission.ItemHighLightForeColor = System.Drawing.Color.Black;
            this.cmbStatusPermission.ItemTopMargin = 3;
            this.cmbStatusPermission.Location = new System.Drawing.Point(549, 49);
            this.cmbStatusPermission.Name = "cmbStatusPermission";
            this.cmbStatusPermission.Size = new System.Drawing.Size(250, 32);
            this.cmbStatusPermission.TabIndex = 50;
            this.cmbStatusPermission.Text = null;
            this.cmbStatusPermission.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbStatusPermission.TextLeftMargin = 5;
            this.bunifuToolTip1.SetToolTip(this.cmbStatusPermission, "");
            this.bunifuToolTip1.SetToolTipIcon(this.cmbStatusPermission, null);
            this.bunifuToolTip1.SetToolTipTitle(this.cmbStatusPermission, "");
            // 
            // bunifuCustomLabel11
            // 
            this.bunifuCustomLabel11.AutoSize = true;
            this.bunifuCustomLabel11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel11.Location = new System.Drawing.Point(331, -29);
            this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
            this.bunifuCustomLabel11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuCustomLabel11.Size = new System.Drawing.Size(142, 16);
            this.bunifuCustomLabel11.TabIndex = 51;
            this.bunifuCustomLabel11.Text = "Estado de permiso:";
            this.bunifuToolTip1.SetToolTip(this.bunifuCustomLabel11, "");
            this.bunifuToolTip1.SetToolTipIcon(this.bunifuCustomLabel11, null);
            this.bunifuToolTip1.SetToolTipTitle(this.bunifuCustomLabel11, "");
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(23, 169);
            this.lblReason.Name = "lblReason";
            this.lblReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReason.Size = new System.Drawing.Size(60, 16);
            this.lblReason.TabIndex = 44;
            this.lblReason.Text = "Motivo:";
            this.bunifuToolTip1.SetToolTip(this.lblReason, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblReason, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblReason, "");
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(425, 100);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblEnd.Size = new System.Drawing.Size(33, 16);
            this.lblEnd.TabIndex = 42;
            this.lblEnd.Text = "Fin:";
            this.bunifuToolTip1.SetToolTip(this.lblEnd, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblEnd, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblEnd, "");
            // 
            // dtpEnd
            // 
            this.dtpEnd.BackColor = System.Drawing.Color.LightGray;
            this.dtpEnd.BorderColor = System.Drawing.Color.Silver;
            this.dtpEnd.BorderRadius = 1;
            this.dtpEnd.Color = System.Drawing.Color.Silver;
            this.dtpEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpEnd.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtpEnd.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtpEnd.DisabledColor = System.Drawing.Color.Gray;
            this.dtpEnd.DisplayWeekNumbers = false;
            this.dtpEnd.DPHeight = 0;
            this.dtpEnd.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpEnd.FillDatePicker = false;
            this.dtpEnd.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.ForeColor = System.Drawing.Color.Black;
            this.dtpEnd.Icon = ((System.Drawing.Image)(resources.GetObject("dtpEnd.Icon")));
            this.dtpEnd.IconColor = System.Drawing.Color.DimGray;
            this.dtpEnd.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtpEnd.LeftTextMargin = 5;
            this.dtpEnd.Location = new System.Drawing.Point(426, 119);
            this.dtpEnd.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(373, 32);
            this.dtpEnd.TabIndex = 41;
            this.bunifuToolTip1.SetToolTip(this.dtpEnd, "");
            this.bunifuToolTip1.SetToolTipIcon(this.dtpEnd, null);
            this.bunifuToolTip1.SetToolTipTitle(this.dtpEnd, "");
            this.dtpEnd.Value = new System.DateTime(2024, 7, 13, 16, 30, 0, 0);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(23, 100);
            this.lblStart.Name = "lblStart";
            this.lblStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStart.Size = new System.Drawing.Size(49, 16);
            this.lblStart.TabIndex = 40;
            this.lblStart.Text = "Inicio:";
            this.bunifuToolTip1.SetToolTip(this.lblStart, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblStart, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblStart, "");
            // 
            // dtpStart
            // 
            this.dtpStart.BackColor = System.Drawing.Color.LightGray;
            this.dtpStart.BorderColor = System.Drawing.Color.Silver;
            this.dtpStart.BorderRadius = 1;
            this.dtpStart.Color = System.Drawing.Color.Silver;
            this.dtpStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpStart.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtpStart.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtpStart.DisabledColor = System.Drawing.Color.Gray;
            this.dtpStart.DisplayWeekNumbers = false;
            this.dtpStart.DPHeight = 0;
            this.dtpStart.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpStart.FillDatePicker = false;
            this.dtpStart.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.ForeColor = System.Drawing.Color.Black;
            this.dtpStart.Icon = ((System.Drawing.Image)(resources.GetObject("dtpStart.Icon")));
            this.dtpStart.IconColor = System.Drawing.Color.DimGray;
            this.dtpStart.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtpStart.LeftTextMargin = 5;
            this.dtpStart.Location = new System.Drawing.Point(22, 119);
            this.dtpStart.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(398, 32);
            this.dtpStart.TabIndex = 39;
            this.bunifuToolTip1.SetToolTip(this.dtpStart, "");
            this.bunifuToolTip1.SetToolTipIcon(this.dtpStart, null);
            this.bunifuToolTip1.SetToolTipTitle(this.dtpStart, "");
            this.dtpStart.Value = new System.DateTime(2024, 7, 13, 16, 30, 0, 0);
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeID.Location = new System.Drawing.Point(23, 30);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(124, 16);
            this.lblEmployeeID.TabIndex = 35;
            this.lblEmployeeID.Text = "ID del empleado:";
            this.bunifuToolTip1.SetToolTip(this.lblEmployeeID, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblEmployeeID, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblEmployeeID, "");
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.AllowAnimations = true;
            this.btnAddPermission.AllowMouseEffects = true;
            this.btnAddPermission.AllowToggling = false;
            this.btnAddPermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddPermission.AnimationSpeed = 200;
            this.btnAddPermission.AutoGenerateColors = false;
            this.btnAddPermission.AutoRoundBorders = false;
            this.btnAddPermission.AutoSizeLeftIcon = true;
            this.btnAddPermission.AutoSizeRightIcon = true;
            this.btnAddPermission.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPermission.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddPermission.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPermission.BackgroundImage")));
            this.btnAddPermission.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddPermission.ButtonText = "Agregar";
            this.btnAddPermission.ButtonTextMarginLeft = 0;
            this.btnAddPermission.ColorContrastOnClick = 45;
            this.btnAddPermission.ColorContrastOnHover = 45;
            this.btnAddPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAddPermission.CustomizableEdges = borderEdges1;
            this.btnAddPermission.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddPermission.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddPermission.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddPermission.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddPermission.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAddPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPermission.ForeColor = System.Drawing.Color.White;
            this.btnAddPermission.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPermission.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddPermission.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddPermission.IconMarginLeft = 11;
            this.btnAddPermission.IconPadding = 10;
            this.btnAddPermission.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPermission.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddPermission.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddPermission.IconSize = 25;
            this.btnAddPermission.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddPermission.IdleBorderRadius = 20;
            this.btnAddPermission.IdleBorderThickness = 1;
            this.btnAddPermission.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddPermission.IdleIconLeftImage = null;
            this.btnAddPermission.IdleIconRightImage = null;
            this.btnAddPermission.IndicateFocus = false;
            this.btnAddPermission.Location = new System.Drawing.Point(435, 446);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddPermission.OnDisabledState.BorderRadius = 20;
            this.btnAddPermission.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddPermission.OnDisabledState.BorderThickness = 1;
            this.btnAddPermission.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddPermission.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddPermission.OnDisabledState.IconLeftImage = null;
            this.btnAddPermission.OnDisabledState.IconRightImage = null;
            this.btnAddPermission.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddPermission.onHoverState.BorderRadius = 20;
            this.btnAddPermission.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddPermission.onHoverState.BorderThickness = 1;
            this.btnAddPermission.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddPermission.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddPermission.onHoverState.IconLeftImage = null;
            this.btnAddPermission.onHoverState.IconRightImage = null;
            this.btnAddPermission.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddPermission.OnIdleState.BorderRadius = 20;
            this.btnAddPermission.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddPermission.OnIdleState.BorderThickness = 1;
            this.btnAddPermission.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddPermission.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddPermission.OnIdleState.IconLeftImage = null;
            this.btnAddPermission.OnIdleState.IconRightImage = null;
            this.btnAddPermission.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddPermission.OnPressedState.BorderRadius = 20;
            this.btnAddPermission.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddPermission.OnPressedState.BorderThickness = 1;
            this.btnAddPermission.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddPermission.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddPermission.OnPressedState.IconLeftImage = null;
            this.btnAddPermission.OnPressedState.IconRightImage = null;
            this.btnAddPermission.Size = new System.Drawing.Size(151, 52);
            this.btnAddPermission.TabIndex = 112;
            this.btnAddPermission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddPermission.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddPermission.TextMarginLeft = 0;
            this.btnAddPermission.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuToolTip1.SetToolTip(this.btnAddPermission, "");
            this.bunifuToolTip1.SetToolTipIcon(this.btnAddPermission, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnAddPermission, "");
            this.btnAddPermission.UseDefaultRadiusAndThickness = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowAnimations = true;
            this.btnCancel.AllowMouseEffects = true;
            this.btnCancel.AllowToggling = false;
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.AnimationSpeed = 200;
            this.btnCancel.AutoGenerateColors = false;
            this.btnCancel.AutoRoundBorders = false;
            this.btnCancel.AutoSizeLeftIcon = true;
            this.btnCancel.AutoSizeRightIcon = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCancel.ButtonText = "Volver";
            this.btnCancel.ButtonTextMarginLeft = 0;
            this.btnCancel.ColorContrastOnClick = 45;
            this.btnCancel.ColorContrastOnHover = 45;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnCancel.CustomizableEdges = borderEdges2;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancel.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCancel.IconMarginLeft = 11;
            this.btnCancel.IconPadding = 10;
            this.btnCancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCancel.IconSize = 25;
            this.btnCancel.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.IdleBorderRadius = 20;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.IdleIconLeftImage = null;
            this.btnCancel.IdleIconRightImage = null;
            this.btnCancel.IndicateFocus = false;
            this.btnCancel.Location = new System.Drawing.Point(278, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancel.OnDisabledState.BorderRadius = 20;
            this.btnCancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCancel.OnDisabledState.BorderThickness = 1;
            this.btnCancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancel.OnDisabledState.IconLeftImage = null;
            this.btnCancel.OnDisabledState.IconRightImage = null;
            this.btnCancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnCancel.onHoverState.BorderRadius = 20;
            this.btnCancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCancel.onHoverState.BorderThickness = 1;
            this.btnCancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnCancel.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.onHoverState.IconLeftImage = null;
            this.btnCancel.onHoverState.IconRightImage = null;
            this.btnCancel.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.OnIdleState.BorderRadius = 20;
            this.btnCancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCancel.OnIdleState.BorderThickness = 1;
            this.btnCancel.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnIdleState.IconLeftImage = null;
            this.btnCancel.OnIdleState.IconRightImage = null;
            this.btnCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.OnPressedState.BorderRadius = 20;
            this.btnCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCancel.OnPressedState.BorderThickness = 1;
            this.btnCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnPressedState.IconLeftImage = null;
            this.btnCancel.OnPressedState.IconRightImage = null;
            this.btnCancel.Size = new System.Drawing.Size(151, 52);
            this.btnCancel.TabIndex = 111;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancel.TextMarginLeft = 0;
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuToolTip1.SetToolTip(this.btnCancel, "");
            this.bunifuToolTip1.SetToolTipIcon(this.btnCancel, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnCancel, "");
            this.btnCancel.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuToolTip1
            // 
            this.bunifuToolTip1.Active = true;
            this.bunifuToolTip1.AlignTextWithTitle = false;
            this.bunifuToolTip1.AllowAutoClose = false;
            this.bunifuToolTip1.AllowFading = true;
            this.bunifuToolTip1.AutoCloseDuration = 5000;
            this.bunifuToolTip1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuToolTip1.BorderColor = System.Drawing.Color.Gainsboro;
            this.bunifuToolTip1.ClickToShowDisplayControl = false;
            this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
            this.bunifuToolTip1.DisplayControl = null;
            this.bunifuToolTip1.EntryAnimationSpeed = 500;
            this.bunifuToolTip1.ExitAnimationSpeed = 200;
            this.bunifuToolTip1.GenerateAutoCloseDuration = false;
            this.bunifuToolTip1.IconMargin = 6;
            this.bunifuToolTip1.InitialDelay = 0;
            this.bunifuToolTip1.Name = "bunifuToolTip1";
            this.bunifuToolTip1.Opacity = 1D;
            this.bunifuToolTip1.OverrideToolTipTitles = false;
            this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
            this.bunifuToolTip1.ReshowDelay = 100;
            this.bunifuToolTip1.ShowAlways = true;
            this.bunifuToolTip1.ShowBorders = false;
            this.bunifuToolTip1.ShowIcons = true;
            this.bunifuToolTip1.ShowShadows = true;
            this.bunifuToolTip1.Tag = null;
            this.bunifuToolTip1.TextFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuToolTip1.TextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuToolTip1.TextMargin = 2;
            this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Black;
            this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
            this.bunifuToolTip1.ToolTipTitle = null;
            // 
            // bunifuSnackbar1
            // 
            this.bunifuSnackbar1.AllowDragging = false;
            this.bunifuSnackbar1.AllowMultipleViews = true;
            this.bunifuSnackbar1.ClickToClose = true;
            this.bunifuSnackbar1.DoubleClickToClose = true;
            this.bunifuSnackbar1.DurationAfterIdle = 3000;
            this.bunifuSnackbar1.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.ErrorOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.bunifuSnackbar1.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.bunifuSnackbar1.ErrorOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.FadeCloseIcon = false;
            this.bunifuSnackbar1.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.bunifuSnackbar1.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.InformationOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.bunifuSnackbar1.InformationOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.Margin = 10;
            this.bunifuSnackbar1.MaximumSize = new System.Drawing.Size(0, 0);
            this.bunifuSnackbar1.MaximumViews = 7;
            this.bunifuSnackbar1.MessageRightMargin = 15;
            this.bunifuSnackbar1.MessageTopMargin = 0;
            this.bunifuSnackbar1.MinimumSize = new System.Drawing.Size(0, 0);
            this.bunifuSnackbar1.ShowBorders = false;
            this.bunifuSnackbar1.ShowCloseIcon = false;
            this.bunifuSnackbar1.ShowIcon = true;
            this.bunifuSnackbar1.ShowShadows = true;
            this.bunifuSnackbar1.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.SuccessOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.bunifuSnackbar1.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.bunifuSnackbar1.SuccessOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.ViewsMargin = 7;
            this.bunifuSnackbar1.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.WarningOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.WarningOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.bunifuSnackbar1.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.bunifuSnackbar1.WarningOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.ZoomCloseIcon = true;
            // 
            // FrmAddPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(860, 514);
            this.Controls.Add(this.btnAddPermission);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddPermission";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public Bunifu.UI.WinForms.BunifuDatePicker dtpStart;
        public Bunifu.UI.WinForms.BunifuDatePicker dtpEnd;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddPermission;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnCancel;
        public Bunifu.UI.WinForms.BunifuDropdown cmbTypePermission;
        public Bunifu.UI.WinForms.BunifuDropdown cmbStatusPermission;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel11;
        public Bunifu.UI.WinForms.BunifuTextBox txtIdEmployee;
        public Bunifu.UI.WinForms.BunifuTextBox rtxtContext;
        private Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
        public Bunifu.UI.WinForms.BunifuLabel lblEmployeeName;
        public Bunifu.UI.WinForms.BunifuSnackbar bunifuSnackbar1;
        public Bunifu.UI.WinForms.BunifuGroupBox groupBox1;
        public Bunifu.Framework.UI.BunifuCustomLabel lblSubTitle;
        public Bunifu.Framework.UI.BunifuCustomLabel lblTitle;
        public Bunifu.Framework.UI.BunifuCustomLabel lblEmployeeID;
        public Bunifu.Framework.UI.BunifuCustomLabel lblStart;
        public Bunifu.Framework.UI.BunifuCustomLabel lblEnd;
        public Bunifu.Framework.UI.BunifuCustomLabel lblReason;
        public Bunifu.Framework.UI.BunifuCustomLabel lblTypePerm;
        public Bunifu.Framework.UI.BunifuCustomLabel lblStatusPerm;
        public Bunifu.UI.WinForms.BunifuLabel lblText;
    }
}