namespace PTC2024.View.Dashboard
{
    partial class FrmCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCharge));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmsCharge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsUpdateCharge = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteCharge = new System.Windows.Forms.ToolStripMenuItem();
            this.txtId = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnGoBack = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.dgvCharge = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.snack = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.lblText = new System.Windows.Forms.Label();
            this.cmsCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharge)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(736, 40);
            this.lblTitle.TabIndex = 100;
            this.lblTitle.Text = "PUESTOS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsCharge
            // 
            this.cmsCharge.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCharge.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.cmsCharge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsUpdateCharge,
            this.cmsDeleteCharge});
            this.cmsCharge.Name = "cmsEmployee";
            this.cmsCharge.Size = new System.Drawing.Size(174, 56);
            // 
            // cmsUpdateCharge
            // 
            this.cmsUpdateCharge.Image = ((System.Drawing.Image)(resources.GetObject("cmsUpdateCharge.Image")));
            this.cmsUpdateCharge.Name = "cmsUpdateCharge";
            this.cmsUpdateCharge.Size = new System.Drawing.Size(173, 26);
            this.cmsUpdateCharge.Text = "Actualizar cargo";
            // 
            // cmsDeleteCharge
            // 
            this.cmsDeleteCharge.Image = ((System.Drawing.Image)(resources.GetObject("cmsDeleteCharge.Image")));
            this.cmsDeleteCharge.Name = "cmsDeleteCharge";
            this.cmsDeleteCharge.Size = new System.Drawing.Size(173, 26);
            this.cmsDeleteCharge.Text = "Eliminar cargo";
            this.cmsDeleteCharge.Visible = false;
            // 
            // txtId
            // 
            this.txtId.AcceptsReturn = false;
            this.txtId.AcceptsTab = false;
            this.txtId.AnimationSpeed = 200;
            this.txtId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtId.AutoSizeHeight = true;
            this.txtId.BackColor = System.Drawing.Color.Transparent;
            this.txtId.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtId.BackgroundImage")));
            this.txtId.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtId.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtId.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtId.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtId.BorderRadius = 1;
            this.txtId.BorderThickness = 1;
            this.txtId.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtId.DefaultText = "";
            this.txtId.FillColor = System.Drawing.Color.White;
            this.txtId.HideSelection = true;
            this.txtId.IconLeft = null;
            this.txtId.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.IconPadding = 10;
            this.txtId.IconRight = null;
            this.txtId.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.Lines = new string[0];
            this.txtId.Location = new System.Drawing.Point(0, -2);
            this.txtId.MaxLength = 32767;
            this.txtId.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtId.Modified = false;
            this.txtId.Multiline = false;
            this.txtId.Name = "txtId";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtId.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtId.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtId.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtId.OnIdleState = stateProperties4;
            this.txtId.Padding = new System.Windows.Forms.Padding(3);
            this.txtId.PasswordChar = '\0';
            this.txtId.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtId.PlaceholderText = "Enter text";
            this.txtId.ReadOnly = false;
            this.txtId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtId.SelectedText = "";
            this.txtId.SelectionLength = 0;
            this.txtId.SelectionStart = 0;
            this.txtId.ShortcutsEnabled = true;
            this.txtId.Size = new System.Drawing.Size(107, 39);
            this.txtId.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtId.TabIndex = 107;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtId.TextMarginBottom = 0;
            this.txtId.TextMarginLeft = 3;
            this.txtId.TextMarginTop = 1;
            this.txtId.TextPlaceholder = "Enter text";
            this.txtId.UseSystemPasswordChar = false;
            this.txtId.WordWrap = true;
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
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnGoBack.CustomizableEdges = borderEdges1;
            this.btnGoBack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGoBack.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGoBack.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGoBack.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGoBack.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnGoBack.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnGoBack.Location = new System.Drawing.Point(289, 394);
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
            this.btnGoBack.Size = new System.Drawing.Size(151, 44);
            this.btnGoBack.TabIndex = 111;
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoBack.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGoBack.TextMarginLeft = 0;
            this.btnGoBack.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnGoBack.UseDefaultRadiusAndThickness = true;
            // 
            // dgvCharge
            // 
            this.dgvCharge.AllowCustomTheming = true;
            this.dgvCharge.AllowDrop = true;
            this.dgvCharge.AllowUserToAddRows = false;
            this.dgvCharge.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCharge.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCharge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCharge.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvCharge.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCharge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCharge.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCharge.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCharge.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCharge.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharge.ContextMenuStrip = this.cmsCharge;
            this.dgvCharge.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCharge.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCharge.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvCharge.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.CurrentTheme.GridColor = System.Drawing.Color.Silver;
            this.dgvCharge.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvCharge.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvCharge.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCharge.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvCharge.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCharge.CurrentTheme.Name = null;
            this.dgvCharge.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCharge.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCharge.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCharge.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCharge.EnableHeadersVisualStyles = false;
            this.dgvCharge.GridColor = System.Drawing.Color.Silver;
            this.dgvCharge.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvCharge.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvCharge.HeaderForeColor = System.Drawing.Color.White;
            this.dgvCharge.Location = new System.Drawing.Point(40, 124);
            this.dgvCharge.Name = "dgvCharge";
            this.dgvCharge.ReadOnly = true;
            this.dgvCharge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCharge.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCharge.RowHeadersVisible = false;
            this.dgvCharge.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCharge.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCharge.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCharge.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCharge.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCharge.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvCharge.RowTemplate.Height = 50;
            this.dgvCharge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCharge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCharge.Size = new System.Drawing.Size(654, 252);
            this.dgvCharge.TabIndex = 112;
            this.dgvCharge.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(40, 46);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(654, 35);
            this.bunifuSeparator1.TabIndex = 191;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // snack
            // 
            this.snack.AllowDragging = false;
            this.snack.AllowMultipleViews = true;
            this.snack.ClickToClose = true;
            this.snack.DoubleClickToClose = true;
            this.snack.DurationAfterIdle = 3000;
            this.snack.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.ErrorOptions.ActionBorderRadius = 1;
            this.snack.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.snack.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.snack.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.snack.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.snack.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.snack.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.snack.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.snack.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.snack.ErrorOptions.IconLeftMargin = 12;
            this.snack.FadeCloseIcon = false;
            this.snack.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.snack.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.InformationOptions.ActionBorderRadius = 1;
            this.snack.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.snack.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.snack.InformationOptions.BackColor = System.Drawing.Color.White;
            this.snack.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.snack.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.snack.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.snack.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.snack.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.snack.InformationOptions.IconLeftMargin = 12;
            this.snack.Margin = 10;
            this.snack.MaximumSize = new System.Drawing.Size(0, 0);
            this.snack.MaximumViews = 7;
            this.snack.MessageRightMargin = 15;
            this.snack.MessageTopMargin = 0;
            this.snack.MinimumSize = new System.Drawing.Size(0, 0);
            this.snack.ShowBorders = false;
            this.snack.ShowCloseIcon = false;
            this.snack.ShowIcon = true;
            this.snack.ShowShadows = true;
            this.snack.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.SuccessOptions.ActionBorderRadius = 1;
            this.snack.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.snack.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.snack.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.snack.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.snack.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.snack.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.snack.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.snack.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.snack.SuccessOptions.IconLeftMargin = 12;
            this.snack.ViewsMargin = 7;
            this.snack.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.snack.WarningOptions.ActionBorderRadius = 1;
            this.snack.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.snack.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.snack.WarningOptions.BackColor = System.Drawing.Color.White;
            this.snack.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.snack.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.snack.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.snack.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.snack.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.snack.WarningOptions.IconLeftMargin = 12;
            this.snack.ZoomCloseIcon = true;
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(0, 87);
            this.lblText.Margin = new System.Windows.Forms.Padding(25, 0, 3, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(736, 19);
            this.lblText.TabIndex = 192;
            this.lblText.Text = "Haga click derecho sobre una cargo para mas opciones";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 459);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.dgvCharge);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCharge";
            this.cmsCharge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ContextMenuStrip cmsCharge;
        public System.Windows.Forms.ToolStripMenuItem cmsUpdateCharge;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteCharge;
        public Bunifu.UI.WinForms.BunifuTextBox txtId;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGoBack;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvCharge;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public Bunifu.UI.WinForms.BunifuSnackbar snack;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblText;
    }
}