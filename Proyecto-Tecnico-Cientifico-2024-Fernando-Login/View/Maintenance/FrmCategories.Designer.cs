namespace PTC2024.View.Maintenance
{
    partial class FrmCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategories));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.dgvCategories = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.cmsCategorie = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeleteCategorie = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoBack = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtCategorie = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnAddCategorie = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.snack = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.cmsCategorie.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(40, 57);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(503, 35);
            this.bunifuSeparator1.TabIndex = 200;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(-1, 24);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(585, 40);
            this.lblTitle.TabIndex = 199;
            this.lblTitle.Text = "CATEGORÍAS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(44, 99);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(191, 18);
            this.lblText.TabIndex = 196;
            this.lblText.Text = "Nombre de la categoría:";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowCustomTheming = true;
            this.dgvCategories.AllowDrop = true;
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCategories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCategories.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.ContextMenuStrip = this.cmsCategorie;
            this.dgvCategories.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCategories.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCategories.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvCategories.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.CurrentTheme.GridColor = System.Drawing.Color.Silver;
            this.dgvCategories.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvCategories.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvCategories.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCategories.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvCategories.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCategories.CurrentTheme.Name = null;
            this.dgvCategories.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCategories.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCategories.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategories.EnableHeadersVisualStyles = false;
            this.dgvCategories.GridColor = System.Drawing.Color.Silver;
            this.dgvCategories.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.dgvCategories.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvCategories.HeaderForeColor = System.Drawing.Color.White;
            this.dgvCategories.Location = new System.Drawing.Point(40, 170);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCategories.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCategories.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCategories.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCategories.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dgvCategories.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvCategories.RowTemplate.Height = 50;
            this.dgvCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(503, 180);
            this.dgvCategories.TabIndex = 194;
            this.dgvCategories.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            // 
            // cmsCategorie
            // 
            this.cmsCategorie.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCategorie.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.cmsCategorie.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeleteCategorie});
            this.cmsCategorie.Name = "cmsEmployee";
            this.cmsCategorie.Size = new System.Drawing.Size(185, 30);
            // 
            // cmsDeleteCategorie
            // 
            this.cmsDeleteCategorie.Image = ((System.Drawing.Image)(resources.GetObject("cmsDeleteCategorie.Image")));
            this.cmsDeleteCategorie.Name = "cmsDeleteCategorie";
            this.cmsDeleteCategorie.Size = new System.Drawing.Size(184, 26);
            this.cmsDeleteCategorie.Text = "Eliminar categoría";
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
            this.btnGoBack.TabIndex = 198;
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoBack.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGoBack.TextMarginLeft = 0;
            this.btnGoBack.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnGoBack.UseDefaultRadiusAndThickness = true;
            // 
            // txtCategorie
            // 
            this.txtCategorie.AcceptsReturn = false;
            this.txtCategorie.AcceptsTab = false;
            this.txtCategorie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCategorie.AnimationSpeed = 200;
            this.txtCategorie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCategorie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCategorie.AutoSizeHeight = true;
            this.txtCategorie.BackColor = System.Drawing.Color.Transparent;
            this.txtCategorie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtCategorie.BackgroundImage")));
            this.txtCategorie.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtCategorie.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtCategorie.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtCategorie.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtCategorie.BorderRadius = 15;
            this.txtCategorie.BorderThickness = 1;
            this.txtCategorie.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtCategorie.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCategorie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategorie.DefaultFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategorie.DefaultText = "";
            this.txtCategorie.FillColor = System.Drawing.Color.White;
            this.txtCategorie.HideSelection = true;
            this.txtCategorie.IconLeft = null;
            this.txtCategorie.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategorie.IconPadding = 10;
            this.txtCategorie.IconRight = null;
            this.txtCategorie.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategorie.Lines = new string[0];
            this.txtCategorie.Location = new System.Drawing.Point(40, 120);
            this.txtCategorie.MaximumSize = new System.Drawing.Size(305, 32);
            this.txtCategorie.MaxLength = 30;
            this.txtCategorie.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCategorie.Modified = false;
            this.txtCategorie.Multiline = false;
            this.txtCategorie.Name = "txtCategorie";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCategorie.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtCategorie.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCategorie.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCategorie.OnIdleState = stateProperties4;
            this.txtCategorie.Padding = new System.Windows.Forms.Padding(3);
            this.txtCategorie.PasswordChar = '\0';
            this.txtCategorie.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtCategorie.PlaceholderText = "";
            this.txtCategorie.ReadOnly = false;
            this.txtCategorie.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCategorie.SelectedText = "";
            this.txtCategorie.SelectionLength = 0;
            this.txtCategorie.SelectionStart = 0;
            this.txtCategorie.ShortcutsEnabled = true;
            this.txtCategorie.Size = new System.Drawing.Size(305, 32);
            this.txtCategorie.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtCategorie.TabIndex = 195;
            this.txtCategorie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCategorie.TextMarginBottom = 0;
            this.txtCategorie.TextMarginLeft = 3;
            this.txtCategorie.TextMarginTop = 1;
            this.txtCategorie.TextPlaceholder = "";
            this.txtCategorie.UseSystemPasswordChar = false;
            this.txtCategorie.WordWrap = true;
            // 
            // btnAddCategorie
            // 
            this.btnAddCategorie.AllowAnimations = true;
            this.btnAddCategorie.AllowMouseEffects = true;
            this.btnAddCategorie.AllowToggling = false;
            this.btnAddCategorie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddCategorie.AnimationSpeed = 200;
            this.btnAddCategorie.AutoGenerateColors = false;
            this.btnAddCategorie.AutoRoundBorders = false;
            this.btnAddCategorie.AutoSizeLeftIcon = true;
            this.btnAddCategorie.AutoSizeRightIcon = true;
            this.btnAddCategorie.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCategorie.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCategorie.BackgroundImage")));
            this.btnAddCategorie.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCategorie.ButtonText = "Agregar categoría";
            this.btnAddCategorie.ButtonTextMarginLeft = 0;
            this.btnAddCategorie.ColorContrastOnClick = 45;
            this.btnAddCategorie.ColorContrastOnHover = 45;
            this.btnAddCategorie.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnAddCategorie.CustomizableEdges = borderEdges2;
            this.btnAddCategorie.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddCategorie.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddCategorie.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddCategorie.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddCategorie.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAddCategorie.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnAddCategorie.ForeColor = System.Drawing.Color.White;
            this.btnAddCategorie.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCategorie.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddCategorie.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddCategorie.IconMarginLeft = 11;
            this.btnAddCategorie.IconPadding = 10;
            this.btnAddCategorie.IconRightAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCategorie.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddCategorie.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddCategorie.IconSize = 25;
            this.btnAddCategorie.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.IdleBorderRadius = 15;
            this.btnAddCategorie.IdleBorderThickness = 1;
            this.btnAddCategorie.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAddCategorie.IdleIconLeftImage")));
            this.btnAddCategorie.IdleIconRightImage = null;
            this.btnAddCategorie.IndicateFocus = false;
            this.btnAddCategorie.Location = new System.Drawing.Point(360, 110);
            this.btnAddCategorie.Name = "btnAddCategorie";
            this.btnAddCategorie.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddCategorie.OnDisabledState.BorderRadius = 15;
            this.btnAddCategorie.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCategorie.OnDisabledState.BorderThickness = 1;
            this.btnAddCategorie.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddCategorie.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddCategorie.OnDisabledState.IconLeftImage = null;
            this.btnAddCategorie.OnDisabledState.IconRightImage = null;
            this.btnAddCategorie.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddCategorie.onHoverState.BorderRadius = 15;
            this.btnAddCategorie.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCategorie.onHoverState.BorderThickness = 1;
            this.btnAddCategorie.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddCategorie.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddCategorie.onHoverState.IconLeftImage = null;
            this.btnAddCategorie.onHoverState.IconRightImage = null;
            this.btnAddCategorie.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.OnIdleState.BorderRadius = 15;
            this.btnAddCategorie.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCategorie.OnIdleState.BorderThickness = 1;
            this.btnAddCategorie.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddCategorie.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAddCategorie.OnIdleState.IconLeftImage")));
            this.btnAddCategorie.OnIdleState.IconRightImage = null;
            this.btnAddCategorie.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.OnPressedState.BorderRadius = 15;
            this.btnAddCategorie.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCategorie.OnPressedState.BorderThickness = 1;
            this.btnAddCategorie.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCategorie.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddCategorie.OnPressedState.IconLeftImage = null;
            this.btnAddCategorie.OnPressedState.IconRightImage = null;
            this.btnAddCategorie.Size = new System.Drawing.Size(183, 42);
            this.btnAddCategorie.TabIndex = 203;
            this.btnAddCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCategorie.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddCategorie.TextMarginLeft = 0;
            this.btnAddCategorie.TextPadding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.btnAddCategorie.UseDefaultRadiusAndThickness = true;
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
            // FrmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(583, 443);
            this.Controls.Add(this.btnAddCategorie);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtCategorie);
            this.Controls.Add(this.dgvCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCategories";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.cmsCategorie.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGoBack;
        public Bunifu.UI.WinForms.BunifuTextBox txtCategorie;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvCategories;
        public System.Windows.Forms.ContextMenuStrip cmsCategorie;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteCategorie;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddCategorie;
        public Bunifu.UI.WinForms.BunifuSnackbar snack;
        public Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblText;
    }
}