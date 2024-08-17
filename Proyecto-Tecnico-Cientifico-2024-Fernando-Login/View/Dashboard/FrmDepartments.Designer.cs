﻿namespace PTC2024.View.Dashboard
{
    partial class FrmDepartments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartments));
            this.dgvDepartments = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.txtDepartment = new Bunifu.UI.WinForms.BunifuTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddDepartment = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnGoBack = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.cmsDepartment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeleteDepartment = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.cmsDepartment.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.AllowCustomTheming = true;
            this.dgvDepartments.AllowDrop = true;
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDepartments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDepartments.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepartments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDepartments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvDepartments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.ContextMenuStrip = this.cmsDepartment;
            this.dgvDepartments.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDepartments.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDepartments.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDepartments.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.CurrentTheme.GridColor = System.Drawing.Color.Silver;
            this.dgvDepartments.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvDepartments.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvDepartments.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDepartments.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvDepartments.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDepartments.CurrentTheme.Name = null;
            this.dgvDepartments.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDepartments.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDepartments.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepartments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepartments.EnableHeadersVisualStyles = false;
            this.dgvDepartments.GridColor = System.Drawing.Color.Silver;
            this.dgvDepartments.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvDepartments.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvDepartments.HeaderForeColor = System.Drawing.Color.White;
            this.dgvDepartments.Location = new System.Drawing.Point(54, 206);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDepartments.RowHeadersVisible = false;
            this.dgvDepartments.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDepartments.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDepartments.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDepartments.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDepartments.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvDepartments.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDepartments.RowTemplate.Height = 50;
            this.dgvDepartments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(503, 209);
            this.dgvDepartments.TabIndex = 2;
            this.dgvDepartments.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            // 
            // txtDepartment
            // 
            this.txtDepartment.AcceptsReturn = false;
            this.txtDepartment.AcceptsTab = false;
            this.txtDepartment.AnimationSpeed = 200;
            this.txtDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDepartment.AutoSizeHeight = true;
            this.txtDepartment.BackColor = System.Drawing.Color.Transparent;
            this.txtDepartment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDepartment.BackgroundImage")));
            this.txtDepartment.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtDepartment.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtDepartment.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtDepartment.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtDepartment.BorderRadius = 20;
            this.txtDepartment.BorderThickness = 1;
            this.txtDepartment.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDepartment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartment.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtDepartment.DefaultText = "";
            this.txtDepartment.FillColor = System.Drawing.Color.White;
            this.txtDepartment.HideSelection = true;
            this.txtDepartment.IconLeft = null;
            this.txtDepartment.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartment.IconPadding = 10;
            this.txtDepartment.IconRight = null;
            this.txtDepartment.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartment.Lines = new string[0];
            this.txtDepartment.Location = new System.Drawing.Point(64, 141);
            this.txtDepartment.MaxLength = 32767;
            this.txtDepartment.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDepartment.Modified = false;
            this.txtDepartment.Multiline = false;
            this.txtDepartment.Name = "txtDepartment";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepartment.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDepartment.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepartment.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepartment.OnIdleState = stateProperties4;
            this.txtDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.txtDepartment.PasswordChar = '\0';
            this.txtDepartment.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDepartment.PlaceholderText = "Enter text";
            this.txtDepartment.ReadOnly = false;
            this.txtDepartment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDepartment.SelectedText = "";
            this.txtDepartment.SelectionLength = 0;
            this.txtDepartment.SelectionStart = 0;
            this.txtDepartment.ShortcutsEnabled = true;
            this.txtDepartment.Size = new System.Drawing.Size(273, 39);
            this.txtDepartment.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtDepartment.TabIndex = 3;
            this.txtDepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDepartment.TextMarginBottom = 0;
            this.txtDepartment.TextMarginLeft = 3;
            this.txtDepartment.TextMarginTop = 1;
            this.txtDepartment.TextPlaceholder = "Enter text";
            this.txtDepartment.UseSystemPasswordChar = false;
            this.txtDepartment.WordWrap = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "DEPARTAMENTOS";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Departamento";
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.AllowAnimations = true;
            this.btnAddDepartment.AllowMouseEffects = true;
            this.btnAddDepartment.AllowToggling = false;
            this.btnAddDepartment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddDepartment.AnimationSpeed = 200;
            this.btnAddDepartment.AutoGenerateColors = false;
            this.btnAddDepartment.AutoRoundBorders = false;
            this.btnAddDepartment.AutoSizeLeftIcon = true;
            this.btnAddDepartment.AutoSizeRightIcon = true;
            this.btnAddDepartment.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDepartment.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddDepartment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDepartment.BackgroundImage")));
            this.btnAddDepartment.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddDepartment.ButtonText = "Agregar departamento";
            this.btnAddDepartment.ButtonTextMarginLeft = 0;
            this.btnAddDepartment.ColorContrastOnClick = 45;
            this.btnAddDepartment.ColorContrastOnHover = 45;
            this.btnAddDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAddDepartment.CustomizableEdges = borderEdges1;
            this.btnAddDepartment.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddDepartment.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddDepartment.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddDepartment.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddDepartment.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAddDepartment.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDepartment.ForeColor = System.Drawing.Color.White;
            this.btnAddDepartment.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDepartment.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddDepartment.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddDepartment.IconMarginLeft = 11;
            this.btnAddDepartment.IconPadding = 10;
            this.btnAddDepartment.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddDepartment.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddDepartment.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddDepartment.IconSize = 25;
            this.btnAddDepartment.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddDepartment.IdleBorderRadius = 20;
            this.btnAddDepartment.IdleBorderThickness = 1;
            this.btnAddDepartment.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddDepartment.IdleIconLeftImage = null;
            this.btnAddDepartment.IdleIconRightImage = null;
            this.btnAddDepartment.IndicateFocus = false;
            this.btnAddDepartment.Location = new System.Drawing.Point(359, 133);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddDepartment.OnDisabledState.BorderRadius = 20;
            this.btnAddDepartment.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddDepartment.OnDisabledState.BorderThickness = 1;
            this.btnAddDepartment.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddDepartment.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddDepartment.OnDisabledState.IconLeftImage = null;
            this.btnAddDepartment.OnDisabledState.IconRightImage = null;
            this.btnAddDepartment.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddDepartment.onHoverState.BorderRadius = 20;
            this.btnAddDepartment.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddDepartment.onHoverState.BorderThickness = 1;
            this.btnAddDepartment.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddDepartment.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddDepartment.onHoverState.IconLeftImage = null;
            this.btnAddDepartment.onHoverState.IconRightImage = null;
            this.btnAddDepartment.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddDepartment.OnIdleState.BorderRadius = 20;
            this.btnAddDepartment.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddDepartment.OnIdleState.BorderThickness = 1;
            this.btnAddDepartment.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddDepartment.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddDepartment.OnIdleState.IconLeftImage = null;
            this.btnAddDepartment.OnIdleState.IconRightImage = null;
            this.btnAddDepartment.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddDepartment.OnPressedState.BorderRadius = 20;
            this.btnAddDepartment.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddDepartment.OnPressedState.BorderThickness = 1;
            this.btnAddDepartment.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddDepartment.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddDepartment.OnPressedState.IconLeftImage = null;
            this.btnAddDepartment.OnPressedState.IconRightImage = null;
            this.btnAddDepartment.Size = new System.Drawing.Size(187, 52);
            this.btnAddDepartment.TabIndex = 94;
            this.btnAddDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddDepartment.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddDepartment.TextMarginLeft = 0;
            this.btnAddDepartment.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddDepartment.UseDefaultRadiusAndThickness = true;
            // 
            // btnGoBack
            // 
            this.btnGoBack.AllowAnimations = true;
            this.btnGoBack.AllowMouseEffects = true;
            this.btnGoBack.AllowToggling = false;
            this.btnGoBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGoBack.AnimationSpeed = 200;
            this.btnGoBack.AutoGenerateColors = false;
            this.btnGoBack.AutoRoundBorders = false;
            this.btnGoBack.AutoSizeLeftIcon = true;
            this.btnGoBack.AutoSizeRightIcon = true;
            this.btnGoBack.BackColor = System.Drawing.Color.Transparent;
            this.btnGoBack.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGoBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGoBack.BackgroundImage")));
            this.btnGoBack.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGoBack.ButtonText = "Regresar";
            this.btnGoBack.ButtonTextMarginLeft = 0;
            this.btnGoBack.ColorContrastOnClick = 45;
            this.btnGoBack.ColorContrastOnHover = 45;
            this.btnGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnGoBack.CustomizableEdges = borderEdges2;
            this.btnGoBack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGoBack.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGoBack.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGoBack.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGoBack.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnGoBack.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnGoBack.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnGoBack.IconMarginLeft = 11;
            this.btnGoBack.IconPadding = 10;
            this.btnGoBack.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoBack.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnGoBack.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnGoBack.IconSize = 25;
            this.btnGoBack.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGoBack.IdleBorderRadius = 20;
            this.btnGoBack.IdleBorderThickness = 1;
            this.btnGoBack.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGoBack.IdleIconLeftImage = null;
            this.btnGoBack.IdleIconRightImage = null;
            this.btnGoBack.IndicateFocus = false;
            this.btnGoBack.Location = new System.Drawing.Point(242, 430);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGoBack.OnDisabledState.BorderRadius = 20;
            this.btnGoBack.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGoBack.OnDisabledState.BorderThickness = 1;
            this.btnGoBack.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGoBack.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGoBack.OnDisabledState.IconLeftImage = null;
            this.btnGoBack.OnDisabledState.IconRightImage = null;
            this.btnGoBack.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGoBack.onHoverState.BorderRadius = 20;
            this.btnGoBack.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGoBack.onHoverState.BorderThickness = 1;
            this.btnGoBack.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGoBack.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnGoBack.onHoverState.IconLeftImage = null;
            this.btnGoBack.onHoverState.IconRightImage = null;
            this.btnGoBack.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGoBack.OnIdleState.BorderRadius = 20;
            this.btnGoBack.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGoBack.OnIdleState.BorderThickness = 1;
            this.btnGoBack.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnGoBack.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.OnIdleState.IconLeftImage = null;
            this.btnGoBack.OnIdleState.IconRightImage = null;
            this.btnGoBack.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGoBack.OnPressedState.BorderRadius = 20;
            this.btnGoBack.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGoBack.OnPressedState.BorderThickness = 1;
            this.btnGoBack.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnGoBack.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.OnPressedState.IconLeftImage = null;
            this.btnGoBack.OnPressedState.IconRightImage = null;
            this.btnGoBack.Size = new System.Drawing.Size(151, 52);
            this.btnGoBack.TabIndex = 97;
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoBack.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGoBack.TextMarginLeft = 0;
            this.btnGoBack.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnGoBack.UseDefaultRadiusAndThickness = true;
            // 
            // cmsDepartment
            // 
            this.cmsDepartment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsDepartment.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.cmsDepartment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeleteDepartment});
            this.cmsDepartment.Name = "cmsEmployee";
            this.cmsDepartment.Size = new System.Drawing.Size(213, 30);
            // 
            // cmsDeleteDepartment
            // 
            this.cmsDeleteDepartment.Image = ((System.Drawing.Image)(resources.GetObject("cmsDeleteDepartment.Image")));
            this.cmsDeleteDepartment.Name = "cmsDeleteDepartment";
            this.cmsDeleteDepartment.Size = new System.Drawing.Size(212, 26);
            this.cmsDeleteDepartment.Text = "Eliminar departamento";
            // 
            // FrmDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 485);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnAddDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.dgvDepartments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDepartments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDepartments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.cmsDepartment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuDataGridView dgvDepartments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddDepartment;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGoBack;
        public Bunifu.UI.WinForms.BunifuTextBox txtDepartment;
        public System.Windows.Forms.ContextMenuStrip cmsDepartment;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteDepartment;
    }
}