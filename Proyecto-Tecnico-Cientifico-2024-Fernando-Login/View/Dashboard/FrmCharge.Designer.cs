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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCharge));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCharge = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btnGoBack = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnAddCharge = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtCharge = new Bunifu.UI.WinForms.BunifuTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBonus = new Bunifu.UI.WinForms.BunifuTextBox();
            this.cmsCharge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsUpdateCharge = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteCharge = new System.Windows.Forms.ToolStripMenuItem();
            this.txtId = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharge)).BeginInit();
            this.cmsCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 101;
            this.label2.Text = "Cargo";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 40);
            this.label1.TabIndex = 100;
            this.label1.Text = "CARGOS";
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
            this.dgvCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCharge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCharge.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvCharge.BackgroundColor = System.Drawing.Color.White;
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
            this.dgvCharge.Location = new System.Drawing.Point(56, 203);
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
            this.dgvCharge.Size = new System.Drawing.Size(676, 209);
            this.dgvCharge.TabIndex = 98;
            this.dgvCharge.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
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
            this.btnGoBack.Location = new System.Drawing.Point(331, 427);
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
            this.btnGoBack.TabIndex = 4;
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoBack.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGoBack.TextMarginLeft = 0;
            this.btnGoBack.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnGoBack.UseDefaultRadiusAndThickness = true;
            // 
            // btnAddCharge
            // 
            this.btnAddCharge.AllowAnimations = true;
            this.btnAddCharge.AllowMouseEffects = true;
            this.btnAddCharge.AllowToggling = false;
            this.btnAddCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddCharge.AnimationSpeed = 200;
            this.btnAddCharge.AutoGenerateColors = false;
            this.btnAddCharge.AutoRoundBorders = false;
            this.btnAddCharge.AutoSizeLeftIcon = true;
            this.btnAddCharge.AutoSizeRightIcon = true;
            this.btnAddCharge.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCharge.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCharge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCharge.BackgroundImage")));
            this.btnAddCharge.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCharge.ButtonText = "Confirmar";
            this.btnAddCharge.ButtonTextMarginLeft = 0;
            this.btnAddCharge.ColorContrastOnClick = 45;
            this.btnAddCharge.ColorContrastOnHover = 45;
            this.btnAddCharge.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnAddCharge.CustomizableEdges = borderEdges2;
            this.btnAddCharge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddCharge.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddCharge.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddCharge.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddCharge.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAddCharge.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCharge.ForeColor = System.Drawing.Color.White;
            this.btnAddCharge.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCharge.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddCharge.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddCharge.IconMarginLeft = 11;
            this.btnAddCharge.IconPadding = 10;
            this.btnAddCharge.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCharge.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddCharge.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddCharge.IconSize = 25;
            this.btnAddCharge.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCharge.IdleBorderRadius = 20;
            this.btnAddCharge.IdleBorderThickness = 1;
            this.btnAddCharge.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCharge.IdleIconLeftImage = null;
            this.btnAddCharge.IdleIconRightImage = null;
            this.btnAddCharge.IndicateFocus = false;
            this.btnAddCharge.Location = new System.Drawing.Point(594, 128);
            this.btnAddCharge.Name = "btnAddCharge";
            this.btnAddCharge.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddCharge.OnDisabledState.BorderRadius = 20;
            this.btnAddCharge.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCharge.OnDisabledState.BorderThickness = 1;
            this.btnAddCharge.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddCharge.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddCharge.OnDisabledState.IconLeftImage = null;
            this.btnAddCharge.OnDisabledState.IconRightImage = null;
            this.btnAddCharge.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddCharge.onHoverState.BorderRadius = 20;
            this.btnAddCharge.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCharge.onHoverState.BorderThickness = 1;
            this.btnAddCharge.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddCharge.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddCharge.onHoverState.IconLeftImage = null;
            this.btnAddCharge.onHoverState.IconRightImage = null;
            this.btnAddCharge.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCharge.OnIdleState.BorderRadius = 20;
            this.btnAddCharge.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCharge.OnIdleState.BorderThickness = 1;
            this.btnAddCharge.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddCharge.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddCharge.OnIdleState.IconLeftImage = null;
            this.btnAddCharge.OnIdleState.IconRightImage = null;
            this.btnAddCharge.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddCharge.OnPressedState.BorderRadius = 20;
            this.btnAddCharge.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddCharge.OnPressedState.BorderThickness = 1;
            this.btnAddCharge.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddCharge.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddCharge.OnPressedState.IconLeftImage = null;
            this.btnAddCharge.OnPressedState.IconRightImage = null;
            this.btnAddCharge.Size = new System.Drawing.Size(138, 52);
            this.btnAddCharge.TabIndex = 3;
            this.btnAddCharge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCharge.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddCharge.TextMarginLeft = 0;
            this.btnAddCharge.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddCharge.UseDefaultRadiusAndThickness = true;
            // 
            // txtCharge
            // 
            this.txtCharge.AcceptsReturn = false;
            this.txtCharge.AcceptsTab = false;
            this.txtCharge.AnimationSpeed = 200;
            this.txtCharge.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCharge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCharge.AutoSizeHeight = true;
            this.txtCharge.BackColor = System.Drawing.Color.Transparent;
            this.txtCharge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtCharge.BackgroundImage")));
            this.txtCharge.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtCharge.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtCharge.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtCharge.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtCharge.BorderRadius = 20;
            this.txtCharge.BorderThickness = 1;
            this.txtCharge.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCharge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCharge.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtCharge.DefaultText = "";
            this.txtCharge.FillColor = System.Drawing.Color.White;
            this.txtCharge.HideSelection = true;
            this.txtCharge.IconLeft = null;
            this.txtCharge.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCharge.IconPadding = 10;
            this.txtCharge.IconRight = null;
            this.txtCharge.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCharge.Lines = new string[0];
            this.txtCharge.Location = new System.Drawing.Point(66, 138);
            this.txtCharge.MaxLength = 32767;
            this.txtCharge.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCharge.Modified = false;
            this.txtCharge.Multiline = false;
            this.txtCharge.Name = "txtCharge";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCharge.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtCharge.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCharge.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCharge.OnIdleState = stateProperties4;
            this.txtCharge.Padding = new System.Windows.Forms.Padding(3);
            this.txtCharge.PasswordChar = '\0';
            this.txtCharge.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtCharge.PlaceholderText = "Enter text";
            this.txtCharge.ReadOnly = false;
            this.txtCharge.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCharge.SelectedText = "";
            this.txtCharge.SelectionLength = 0;
            this.txtCharge.SelectionStart = 0;
            this.txtCharge.ShortcutsEnabled = true;
            this.txtCharge.Size = new System.Drawing.Size(247, 39);
            this.txtCharge.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtCharge.TabIndex = 1;
            this.txtCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCharge.TextMarginBottom = 0;
            this.txtCharge.TextMarginLeft = 3;
            this.txtCharge.TextMarginTop = 1;
            this.txtCharge.TextPlaceholder = "Enter text";
            this.txtCharge.UseSystemPasswordChar = false;
            this.txtCharge.WordWrap = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 105;
            this.label3.Text = "Bono ";
            // 
            // txtBonus
            // 
            this.txtBonus.AcceptsReturn = false;
            this.txtBonus.AcceptsTab = false;
            this.txtBonus.AnimationSpeed = 200;
            this.txtBonus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBonus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBonus.AutoSizeHeight = true;
            this.txtBonus.BackColor = System.Drawing.Color.Transparent;
            this.txtBonus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBonus.BackgroundImage")));
            this.txtBonus.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtBonus.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtBonus.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtBonus.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtBonus.BorderRadius = 20;
            this.txtBonus.BorderThickness = 1;
            this.txtBonus.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtBonus.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBonus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBonus.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtBonus.DefaultText = "";
            this.txtBonus.FillColor = System.Drawing.Color.White;
            this.txtBonus.HideSelection = true;
            this.txtBonus.IconLeft = null;
            this.txtBonus.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBonus.IconPadding = 10;
            this.txtBonus.IconRight = null;
            this.txtBonus.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBonus.Lines = new string[0];
            this.txtBonus.Location = new System.Drawing.Point(319, 138);
            this.txtBonus.MaxLength = 32767;
            this.txtBonus.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBonus.Modified = false;
            this.txtBonus.Multiline = false;
            this.txtBonus.Name = "txtBonus";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBonus.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBonus.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBonus.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBonus.OnIdleState = stateProperties8;
            this.txtBonus.Padding = new System.Windows.Forms.Padding(3);
            this.txtBonus.PasswordChar = '\0';
            this.txtBonus.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBonus.PlaceholderText = "Enter text";
            this.txtBonus.ReadOnly = false;
            this.txtBonus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBonus.SelectedText = "";
            this.txtBonus.SelectionLength = 0;
            this.txtBonus.SelectionStart = 0;
            this.txtBonus.ShortcutsEnabled = true;
            this.txtBonus.Size = new System.Drawing.Size(247, 39);
            this.txtBonus.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtBonus.TabIndex = 2;
            this.txtBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBonus.TextMarginBottom = 0;
            this.txtBonus.TextMarginLeft = 3;
            this.txtBonus.TextMarginTop = 1;
            this.txtBonus.TextPlaceholder = "Enter text";
            this.txtBonus.UseSystemPasswordChar = false;
            this.txtBonus.WordWrap = true;
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
            stateProperties9.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtId.OnActiveState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtId.OnDisabledState = stateProperties10;
            stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties11.FillColor = System.Drawing.Color.Empty;
            stateProperties11.ForeColor = System.Drawing.Color.Empty;
            stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtId.OnHoverState = stateProperties11;
            stateProperties12.BorderColor = System.Drawing.Color.Silver;
            stateProperties12.FillColor = System.Drawing.Color.White;
            stateProperties12.ForeColor = System.Drawing.Color.Empty;
            stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtId.OnIdleState = stateProperties12;
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
            // FrmCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 485);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtBonus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnAddCharge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.dgvCharge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCharge";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharge)).EndInit();
            this.cmsCharge.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGoBack;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddCharge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public Bunifu.UI.WinForms.BunifuTextBox txtCharge;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvCharge;
        private System.Windows.Forms.Label label3;
        public Bunifu.UI.WinForms.BunifuTextBox txtBonus;
        public System.Windows.Forms.ContextMenuStrip cmsCharge;
        public System.Windows.Forms.ToolStripMenuItem cmsUpdateCharge;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteCharge;
        public Bunifu.UI.WinForms.BunifuTextBox txtId;
    }
}