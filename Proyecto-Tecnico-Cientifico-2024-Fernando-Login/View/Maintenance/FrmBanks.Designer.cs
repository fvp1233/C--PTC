namespace PTC2024.View.Maintenance
{
    partial class FrmBanks
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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBanks));
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBanks = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btnGoBack = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtBank = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnAddBank = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.cmsBanks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeleteBank = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanks)).BeginInit();
            this.cmsBanks.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(40, 58);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(503, 35);
            this.bunifuSeparator1.TabIndex = 207;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 40);
            this.label1.TabIndex = 206;
            this.label1.Text = "BANCOS";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 204;
            this.label2.Text = "Nombre del banco:";
            // 
            // dgvBanks
            // 
            this.dgvBanks.AllowCustomTheming = true;
            this.dgvBanks.AllowDrop = true;
            this.dgvBanks.AllowUserToAddRows = false;
            this.dgvBanks.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBanks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBanks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvBanks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvBanks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBanks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBanks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBanks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvBanks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBanks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanks.ContextMenuStrip = this.cmsBanks;
            this.dgvBanks.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBanks.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBanks.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvBanks.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.CurrentTheme.GridColor = System.Drawing.Color.Silver;
            this.dgvBanks.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvBanks.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvBanks.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBanks.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvBanks.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBanks.CurrentTheme.Name = null;
            this.dgvBanks.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBanks.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBanks.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBanks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBanks.EnableHeadersVisualStyles = false;
            this.dgvBanks.GridColor = System.Drawing.Color.Silver;
            this.dgvBanks.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvBanks.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvBanks.HeaderForeColor = System.Drawing.Color.White;
            this.dgvBanks.Location = new System.Drawing.Point(40, 170);
            this.dgvBanks.Name = "dgvBanks";
            this.dgvBanks.ReadOnly = true;
            this.dgvBanks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBanks.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBanks.RowHeadersVisible = false;
            this.dgvBanks.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBanks.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBanks.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBanks.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBanks.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvBanks.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvBanks.RowTemplate.Height = 50;
            this.dgvBanks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBanks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanks.Size = new System.Drawing.Size(503, 180);
            this.dgvBanks.TabIndex = 202;
            this.dgvBanks.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
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
            this.btnGoBack.ButtonText = "Volver";
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
            this.btnGoBack.Location = new System.Drawing.Point(219, 373);
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
            this.btnGoBack.Size = new System.Drawing.Size(146, 46);
            this.btnGoBack.TabIndex = 205;
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoBack.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGoBack.TextMarginLeft = 0;
            this.btnGoBack.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnGoBack.UseDefaultRadiusAndThickness = true;
            // 
            // txtBank
            // 
            this.txtBank.AcceptsReturn = false;
            this.txtBank.AcceptsTab = false;
            this.txtBank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBank.AnimationSpeed = 200;
            this.txtBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBank.AutoSizeHeight = true;
            this.txtBank.BackColor = System.Drawing.Color.Transparent;
            this.txtBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBank.BackgroundImage")));
            this.txtBank.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtBank.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtBank.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtBank.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtBank.BorderRadius = 15;
            this.txtBank.BorderThickness = 1;
            this.txtBank.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBank.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBank.DefaultFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.DefaultText = "";
            this.txtBank.FillColor = System.Drawing.Color.White;
            this.txtBank.HideSelection = true;
            this.txtBank.IconLeft = null;
            this.txtBank.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBank.IconPadding = 10;
            this.txtBank.IconRight = null;
            this.txtBank.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBank.Lines = new string[0];
            this.txtBank.Location = new System.Drawing.Point(40, 120);
            this.txtBank.MaximumSize = new System.Drawing.Size(305, 32);
            this.txtBank.MaxLength = 40;
            this.txtBank.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBank.Modified = false;
            this.txtBank.Multiline = false;
            this.txtBank.Name = "txtBank";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBank.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBank.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBank.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBank.OnIdleState = stateProperties4;
            this.txtBank.Padding = new System.Windows.Forms.Padding(3);
            this.txtBank.PasswordChar = '\0';
            this.txtBank.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBank.PlaceholderText = "";
            this.txtBank.ReadOnly = false;
            this.txtBank.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBank.SelectedText = "";
            this.txtBank.SelectionLength = 0;
            this.txtBank.SelectionStart = 0;
            this.txtBank.ShortcutsEnabled = true;
            this.txtBank.Size = new System.Drawing.Size(305, 32);
            this.txtBank.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtBank.TabIndex = 203;
            this.txtBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBank.TextMarginBottom = 0;
            this.txtBank.TextMarginLeft = 3;
            this.txtBank.TextMarginTop = 1;
            this.txtBank.TextPlaceholder = "";
            this.txtBank.UseSystemPasswordChar = false;
            this.txtBank.WordWrap = true;
            // 
            // btnAddBank
            // 
            this.btnAddBank.AllowAnimations = true;
            this.btnAddBank.AllowMouseEffects = true;
            this.btnAddBank.AllowToggling = false;
            this.btnAddBank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddBank.AnimationSpeed = 200;
            this.btnAddBank.AutoGenerateColors = false;
            this.btnAddBank.AutoRoundBorders = false;
            this.btnAddBank.AutoSizeLeftIcon = true;
            this.btnAddBank.AutoSizeRightIcon = true;
            this.btnAddBank.BackColor = System.Drawing.Color.Transparent;
            this.btnAddBank.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddBank.BackgroundImage")));
            this.btnAddBank.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddBank.ButtonText = "Agregar banco";
            this.btnAddBank.ButtonTextMarginLeft = 0;
            this.btnAddBank.ColorContrastOnClick = 45;
            this.btnAddBank.ColorContrastOnHover = 45;
            this.btnAddBank.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnAddBank.CustomizableEdges = borderEdges2;
            this.btnAddBank.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddBank.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddBank.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddBank.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddBank.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAddBank.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnAddBank.ForeColor = System.Drawing.Color.White;
            this.btnAddBank.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBank.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddBank.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddBank.IconMarginLeft = 11;
            this.btnAddBank.IconPadding = 10;
            this.btnAddBank.IconRightAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBank.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddBank.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddBank.IconSize = 25;
            this.btnAddBank.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.IdleBorderRadius = 15;
            this.btnAddBank.IdleBorderThickness = 1;
            this.btnAddBank.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAddBank.IdleIconLeftImage")));
            this.btnAddBank.IdleIconRightImage = null;
            this.btnAddBank.IndicateFocus = false;
            this.btnAddBank.Location = new System.Drawing.Point(377, 110);
            this.btnAddBank.Name = "btnAddBank";
            this.btnAddBank.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddBank.OnDisabledState.BorderRadius = 15;
            this.btnAddBank.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddBank.OnDisabledState.BorderThickness = 1;
            this.btnAddBank.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddBank.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddBank.OnDisabledState.IconLeftImage = null;
            this.btnAddBank.OnDisabledState.IconRightImage = null;
            this.btnAddBank.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddBank.onHoverState.BorderRadius = 15;
            this.btnAddBank.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddBank.onHoverState.BorderThickness = 1;
            this.btnAddBank.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddBank.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddBank.onHoverState.IconLeftImage = null;
            this.btnAddBank.onHoverState.IconRightImage = null;
            this.btnAddBank.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.OnIdleState.BorderRadius = 15;
            this.btnAddBank.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddBank.OnIdleState.BorderThickness = 1;
            this.btnAddBank.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddBank.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAddCategorie.OnIdleState.IconLeftImage")));
            this.btnAddBank.OnIdleState.IconRightImage = null;
            this.btnAddBank.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.OnPressedState.BorderRadius = 15;
            this.btnAddBank.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddBank.OnPressedState.BorderThickness = 1;
            this.btnAddBank.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddBank.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddBank.OnPressedState.IconLeftImage = null;
            this.btnAddBank.OnPressedState.IconRightImage = null;
            this.btnAddBank.Size = new System.Drawing.Size(166, 42);
            this.btnAddBank.TabIndex = 208;
            this.btnAddBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBank.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddBank.TextMarginLeft = 0;
            this.btnAddBank.TextPadding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.btnAddBank.UseDefaultRadiusAndThickness = true;
            // 
            // cmsBanks
            // 
            this.cmsBanks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsBanks.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.cmsBanks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeleteBank});
            this.cmsBanks.Name = "cmsEmployee";
            this.cmsBanks.Size = new System.Drawing.Size(166, 30);
            // 
            // cmsDeleteBank
            // 
            this.cmsDeleteBank.Image = ((System.Drawing.Image)(resources.GetObject("cmsDeleteBank.Image")));
            this.cmsDeleteBank.Name = "cmsDeleteBank";
            this.cmsDeleteBank.Size = new System.Drawing.Size(165, 26);
            this.cmsDeleteBank.Text = "Eliminar banco";
            // 
            // FrmBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddBank);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.dgvBanks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBanks";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanks)).EndInit();
            this.cmsBanks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label1;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGoBack;
        private System.Windows.Forms.Label label2;
        public Bunifu.UI.WinForms.BunifuTextBox txtBank;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvBanks;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddBank;
        public System.Windows.Forms.ContextMenuStrip cmsBanks;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteBank;
    }
}