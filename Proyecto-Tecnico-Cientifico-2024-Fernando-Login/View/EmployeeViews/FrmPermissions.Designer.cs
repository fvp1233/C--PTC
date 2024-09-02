namespace PTC2024.View.EmployeeViews
{
    partial class FrmPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissions));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtEmployeeSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPermissions = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.cmsPermission = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsUpdatePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeletePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeletePermission = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnGeneratePermission = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.cmsPermission.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.13629F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.86371F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1131, 609);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.86666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.13334F));
            this.tableLayoutPanel2.Controls.Add(this.txtEmployeeSearch, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1125, 74);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtEmployeeSearch
            // 
            this.txtEmployeeSearch.AcceptsReturn = false;
            this.txtEmployeeSearch.AcceptsTab = false;
            this.txtEmployeeSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmployeeSearch.AnimationSpeed = 200;
            this.txtEmployeeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEmployeeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEmployeeSearch.AutoSizeHeight = true;
            this.txtEmployeeSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtEmployeeSearch.BackgroundImage")));
            this.txtEmployeeSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtEmployeeSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtEmployeeSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtEmployeeSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtEmployeeSearch.BorderRadius = 20;
            this.txtEmployeeSearch.BorderThickness = 1;
            this.txtEmployeeSearch.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtEmployeeSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmployeeSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeSearch.DefaultFont = new System.Drawing.Font("Century Gothic", 9.25F);
            this.txtEmployeeSearch.DefaultText = "";
            this.txtEmployeeSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtEmployeeSearch.ForeColor = System.Drawing.Color.White;
            this.txtEmployeeSearch.HideSelection = true;
            this.txtEmployeeSearch.IconLeft = null;
            this.txtEmployeeSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeSearch.IconPadding = 10;
            this.txtEmployeeSearch.IconRight = ((System.Drawing.Image)(resources.GetObject("txtEmployeeSearch.IconRight")));
            this.txtEmployeeSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeSearch.Lines = new string[0];
            this.txtEmployeeSearch.Location = new System.Drawing.Point(538, 17);
            this.txtEmployeeSearch.MaxLength = 32767;
            this.txtEmployeeSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEmployeeSearch.Modified = false;
            this.txtEmployeeSearch.Multiline = false;
            this.txtEmployeeSearch.Name = "txtEmployeeSearch";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtEmployeeSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtEmployeeSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtEmployeeSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtEmployeeSearch.OnIdleState = stateProperties4;
            this.txtEmployeeSearch.Padding = new System.Windows.Forms.Padding(3);
            this.txtEmployeeSearch.PasswordChar = '\0';
            this.txtEmployeeSearch.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtEmployeeSearch.PlaceholderText = "Buscar un empleado...";
            this.txtEmployeeSearch.ReadOnly = false;
            this.txtEmployeeSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmployeeSearch.SelectedText = "";
            this.txtEmployeeSearch.SelectionLength = 0;
            this.txtEmployeeSearch.SelectionStart = 0;
            this.txtEmployeeSearch.ShortcutsEnabled = true;
            this.txtEmployeeSearch.Size = new System.Drawing.Size(564, 39);
            this.txtEmployeeSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtEmployeeSearch.TabIndex = 10;
            this.txtEmployeeSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmployeeSearch.TextMarginBottom = 0;
            this.txtEmployeeSearch.TextMarginLeft = 3;
            this.txtEmployeeSearch.TextMarginTop = 1;
            this.txtEmployeeSearch.TextPlaceholder = "Buscar un empleado...";
            this.txtEmployeeSearch.UseSystemPasswordChar = false;
            this.txtEmployeeSearch.WordWrap = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(509, 68);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "PERMISOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(25, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Haga click derecho sobre una planilla para mas opciones";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.dgvPermissions, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 83);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.34004F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.65996F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1125, 523);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // dgvPermissions
            // 
            this.dgvPermissions.AllowCustomTheming = true;
            this.dgvPermissions.AllowDrop = true;
            this.dgvPermissions.AllowUserToAddRows = false;
            this.dgvPermissions.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPermissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermissions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvPermissions.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPermissions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPermissions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvPermissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissions.ContextMenuStrip = this.cmsPermission;
            this.dgvPermissions.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPermissions.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPermissions.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvPermissions.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.CurrentTheme.GridColor = System.Drawing.Color.Silver;
            this.dgvPermissions.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvPermissions.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvPermissions.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPermissions.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvPermissions.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPermissions.CurrentTheme.Name = null;
            this.dgvPermissions.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPermissions.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPermissions.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPermissions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPermissions.EnableHeadersVisualStyles = false;
            this.dgvPermissions.GridColor = System.Drawing.Color.Silver;
            this.dgvPermissions.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvPermissions.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvPermissions.HeaderForeColor = System.Drawing.Color.White;
            this.dgvPermissions.Location = new System.Drawing.Point(3, 125);
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.ReadOnly = true;
            this.dgvPermissions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPermissions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPermissions.RowHeadersVisible = false;
            this.dgvPermissions.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPermissions.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPermissions.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPermissions.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPermissions.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvPermissions.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvPermissions.RowTemplate.Height = 50;
            this.dgvPermissions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissions.Size = new System.Drawing.Size(1119, 395);
            this.dgvPermissions.TabIndex = 2;
            this.dgvPermissions.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            // 
            // cmsPermission
            // 
            this.cmsPermission.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsPermission.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.cmsPermission.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsUpdatePermission,
            this.cmsDeletePermission});
            this.cmsPermission.Name = "cmsPlanillas";
            this.cmsPermission.Size = new System.Drawing.Size(181, 56);
            // 
            // cmsUpdatePermission
            // 
            this.cmsUpdatePermission.Image = ((System.Drawing.Image)(resources.GetObject("cmsUpdatePermission.Image")));
            this.cmsUpdatePermission.Name = "cmsUpdatePermission";
            this.cmsUpdatePermission.Size = new System.Drawing.Size(180, 26);
            this.cmsUpdatePermission.Text = "Actualizar planilla";
            // 
            // cmsDeletePermission
            // 
            this.cmsDeletePermission.CheckOnClick = true;
            this.cmsDeletePermission.Image = ((System.Drawing.Image)(resources.GetObject("cmsDeletePermission.Image")));
            this.cmsDeletePermission.Name = "cmsDeletePermission";
            this.cmsDeletePermission.Size = new System.Drawing.Size(180, 26);
            this.cmsDeletePermission.Text = "Eliminar permiso";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.39622F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.60378F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel5.Controls.Add(this.btnDeletePermission, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnGeneratePermission, 4, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1119, 116);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // btnDeletePermission
            // 
            this.btnDeletePermission.AllowAnimations = true;
            this.btnDeletePermission.AllowMouseEffects = true;
            this.btnDeletePermission.AllowToggling = false;
            this.btnDeletePermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeletePermission.AnimationSpeed = 200;
            this.btnDeletePermission.AutoGenerateColors = false;
            this.btnDeletePermission.AutoRoundBorders = false;
            this.btnDeletePermission.AutoSizeLeftIcon = true;
            this.btnDeletePermission.AutoSizeRightIcon = true;
            this.btnDeletePermission.BackColor = System.Drawing.Color.Transparent;
            this.btnDeletePermission.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnDeletePermission.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletePermission.BackgroundImage")));
            this.btnDeletePermission.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDeletePermission.ButtonText = "Eliminar permiso";
            this.btnDeletePermission.ButtonTextMarginLeft = 0;
            this.btnDeletePermission.ColorContrastOnClick = 45;
            this.btnDeletePermission.ColorContrastOnHover = 45;
            this.btnDeletePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnDeletePermission.CustomizableEdges = borderEdges1;
            this.btnDeletePermission.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeletePermission.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDeletePermission.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDeletePermission.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDeletePermission.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnDeletePermission.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePermission.ForeColor = System.Drawing.Color.White;
            this.btnDeletePermission.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletePermission.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnDeletePermission.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnDeletePermission.IconMarginLeft = 11;
            this.btnDeletePermission.IconPadding = 10;
            this.btnDeletePermission.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletePermission.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnDeletePermission.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnDeletePermission.IconSize = 25;
            this.btnDeletePermission.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnDeletePermission.IdleBorderRadius = 20;
            this.btnDeletePermission.IdleBorderThickness = 1;
            this.btnDeletePermission.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnDeletePermission.IdleIconLeftImage = null;
            this.btnDeletePermission.IdleIconRightImage = null;
            this.btnDeletePermission.IndicateFocus = false;
            this.btnDeletePermission.Location = new System.Drawing.Point(706, 29);
            this.btnDeletePermission.Name = "btnDeletePermission";
            this.btnDeletePermission.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDeletePermission.OnDisabledState.BorderRadius = 20;
            this.btnDeletePermission.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDeletePermission.OnDisabledState.BorderThickness = 1;
            this.btnDeletePermission.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDeletePermission.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDeletePermission.OnDisabledState.IconLeftImage = null;
            this.btnDeletePermission.OnDisabledState.IconRightImage = null;
            this.btnDeletePermission.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnDeletePermission.onHoverState.BorderRadius = 20;
            this.btnDeletePermission.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDeletePermission.onHoverState.BorderThickness = 1;
            this.btnDeletePermission.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnDeletePermission.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnDeletePermission.onHoverState.IconLeftImage = null;
            this.btnDeletePermission.onHoverState.IconRightImage = null;
            this.btnDeletePermission.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnDeletePermission.OnIdleState.BorderRadius = 20;
            this.btnDeletePermission.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDeletePermission.OnIdleState.BorderThickness = 1;
            this.btnDeletePermission.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnDeletePermission.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnDeletePermission.OnIdleState.IconLeftImage = null;
            this.btnDeletePermission.OnIdleState.IconRightImage = null;
            this.btnDeletePermission.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnDeletePermission.OnPressedState.BorderRadius = 20;
            this.btnDeletePermission.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDeletePermission.OnPressedState.BorderThickness = 1;
            this.btnDeletePermission.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnDeletePermission.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnDeletePermission.OnPressedState.IconLeftImage = null;
            this.btnDeletePermission.OnPressedState.IconRightImage = null;
            this.btnDeletePermission.Size = new System.Drawing.Size(173, 58);
            this.btnDeletePermission.TabIndex = 97;
            this.btnDeletePermission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeletePermission.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDeletePermission.TextMarginLeft = 0;
            this.btnDeletePermission.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDeletePermission.UseDefaultRadiusAndThickness = true;
            // 
            // btnGeneratePermission
            // 
            this.btnGeneratePermission.AllowAnimations = true;
            this.btnGeneratePermission.AllowMouseEffects = true;
            this.btnGeneratePermission.AllowToggling = false;
            this.btnGeneratePermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGeneratePermission.AnimationSpeed = 200;
            this.btnGeneratePermission.AutoGenerateColors = false;
            this.btnGeneratePermission.AutoRoundBorders = false;
            this.btnGeneratePermission.AutoSizeLeftIcon = true;
            this.btnGeneratePermission.AutoSizeRightIcon = true;
            this.btnGeneratePermission.BackColor = System.Drawing.Color.Transparent;
            this.btnGeneratePermission.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGeneratePermission.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeneratePermission.BackgroundImage")));
            this.btnGeneratePermission.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGeneratePermission.ButtonText = "Generar permiso";
            this.btnGeneratePermission.ButtonTextMarginLeft = 0;
            this.btnGeneratePermission.ColorContrastOnClick = 45;
            this.btnGeneratePermission.ColorContrastOnHover = 45;
            this.btnGeneratePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnGeneratePermission.CustomizableEdges = borderEdges2;
            this.btnGeneratePermission.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGeneratePermission.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGeneratePermission.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGeneratePermission.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGeneratePermission.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnGeneratePermission.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePermission.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePermission.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneratePermission.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnGeneratePermission.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnGeneratePermission.IconMarginLeft = 11;
            this.btnGeneratePermission.IconPadding = 10;
            this.btnGeneratePermission.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneratePermission.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnGeneratePermission.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnGeneratePermission.IconSize = 25;
            this.btnGeneratePermission.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGeneratePermission.IdleBorderRadius = 20;
            this.btnGeneratePermission.IdleBorderThickness = 1;
            this.btnGeneratePermission.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGeneratePermission.IdleIconLeftImage = null;
            this.btnGeneratePermission.IdleIconRightImage = null;
            this.btnGeneratePermission.IndicateFocus = false;
            this.btnGeneratePermission.Location = new System.Drawing.Point(923, 29);
            this.btnGeneratePermission.Name = "btnGeneratePermission";
            this.btnGeneratePermission.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGeneratePermission.OnDisabledState.BorderRadius = 20;
            this.btnGeneratePermission.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGeneratePermission.OnDisabledState.BorderThickness = 1;
            this.btnGeneratePermission.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGeneratePermission.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGeneratePermission.OnDisabledState.IconLeftImage = null;
            this.btnGeneratePermission.OnDisabledState.IconRightImage = null;
            this.btnGeneratePermission.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGeneratePermission.onHoverState.BorderRadius = 20;
            this.btnGeneratePermission.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGeneratePermission.onHoverState.BorderThickness = 1;
            this.btnGeneratePermission.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGeneratePermission.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnGeneratePermission.onHoverState.IconLeftImage = null;
            this.btnGeneratePermission.onHoverState.IconRightImage = null;
            this.btnGeneratePermission.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGeneratePermission.OnIdleState.BorderRadius = 20;
            this.btnGeneratePermission.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGeneratePermission.OnIdleState.BorderThickness = 1;
            this.btnGeneratePermission.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGeneratePermission.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePermission.OnIdleState.IconLeftImage = null;
            this.btnGeneratePermission.OnIdleState.IconRightImage = null;
            this.btnGeneratePermission.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGeneratePermission.OnPressedState.BorderRadius = 20;
            this.btnGeneratePermission.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGeneratePermission.OnPressedState.BorderThickness = 1;
            this.btnGeneratePermission.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGeneratePermission.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePermission.OnPressedState.IconLeftImage = null;
            this.btnGeneratePermission.OnPressedState.IconRightImage = null;
            this.btnGeneratePermission.Size = new System.Drawing.Size(173, 58);
            this.btnGeneratePermission.TabIndex = 94;
            this.btnGeneratePermission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGeneratePermission.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGeneratePermission.TextMarginLeft = 0;
            this.btnGeneratePermission.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnGeneratePermission.UseDefaultRadiusAndThickness = true;
            // 
            // FrmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1131, 609);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPermissions";
            this.Text = "FrmMaternity";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.cmsPermission.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvPermissions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGeneratePermission;
        public System.Windows.Forms.ContextMenuStrip cmsPermission;
        public System.Windows.Forms.ToolStripMenuItem cmsUpdatePermission;
        public System.Windows.Forms.ToolStripMenuItem cmsDeletePermission;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnDeletePermission;
        public Bunifu.UI.WinForms.BunifuTextBox txtEmployeeSearch;
    }
}