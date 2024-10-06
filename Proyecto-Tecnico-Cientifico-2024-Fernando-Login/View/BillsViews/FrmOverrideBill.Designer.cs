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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOverrideBill));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblSubTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblEnterPass = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnConfirm = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnback = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtPasswordBunifu = new Bunifu.UI.WinForms.BunifuTextBox();
            this.ShowPassword = new System.Windows.Forms.PictureBox();
            this.HidePassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(85, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(344, 32);
            this.lblTitle.TabIndex = 111;
            this.lblTitle.Text = "ANULACIÓN DE FACTURA";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSubTitle.Location = new System.Drawing.Point(33, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(450, 36);
            this.lblSubTitle.TabIndex = 112;
            this.lblSubTitle.Text = "Se solicita ingresar la contraseña de administrador para continuar con el proceso" +
    " de anulación";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnterPass
            // 
            this.lblEnterPass.AutoSize = true;
            this.lblEnterPass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEnterPass.Location = new System.Drawing.Point(186, 136);
            this.lblEnterPass.Name = "lblEnterPass";
            this.lblEnterPass.Size = new System.Drawing.Size(138, 16);
            this.lblEnterPass.TabIndex = 114;
            this.lblEnterPass.Text = "Ingresar contraseña";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AllowAnimations = true;
            this.btnConfirm.AllowMouseEffects = true;
            this.btnConfirm.AllowToggling = false;
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirm.AnimationSpeed = 200;
            this.btnConfirm.AutoGenerateColors = false;
            this.btnConfirm.AutoRoundBorders = false;
            this.btnConfirm.AutoSizeLeftIcon = true;
            this.btnConfirm.AutoSizeRightIcon = true;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.ButtonText = "Confirmar";
            this.btnConfirm.ButtonTextMarginLeft = 0;
            this.btnConfirm.ColorContrastOnClick = 45;
            this.btnConfirm.ColorContrastOnHover = 45;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnConfirm.CustomizableEdges = borderEdges1;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirm.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnConfirm.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnConfirm.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirm.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnConfirm.IconMarginLeft = 11;
            this.btnConfirm.IconPadding = 10;
            this.btnConfirm.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirm.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnConfirm.IconSize = 25;
            this.btnConfirm.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnConfirm.IdleBorderRadius = 20;
            this.btnConfirm.IdleBorderThickness = 1;
            this.btnConfirm.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnConfirm.IdleIconLeftImage = null;
            this.btnConfirm.IdleIconRightImage = null;
            this.btnConfirm.IndicateFocus = false;
            this.btnConfirm.Location = new System.Drawing.Point(256, 226);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.OnDisabledState.BorderRadius = 20;
            this.btnConfirm.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.OnDisabledState.BorderThickness = 1;
            this.btnConfirm.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnConfirm.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnConfirm.OnDisabledState.IconLeftImage = null;
            this.btnConfirm.OnDisabledState.IconRightImage = null;
            this.btnConfirm.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnConfirm.onHoverState.BorderRadius = 20;
            this.btnConfirm.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.onHoverState.BorderThickness = 1;
            this.btnConfirm.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnConfirm.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.onHoverState.IconLeftImage = null;
            this.btnConfirm.onHoverState.IconRightImage = null;
            this.btnConfirm.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnConfirm.OnIdleState.BorderRadius = 20;
            this.btnConfirm.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.OnIdleState.BorderThickness = 1;
            this.btnConfirm.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnConfirm.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.OnIdleState.IconLeftImage = null;
            this.btnConfirm.OnIdleState.IconRightImage = null;
            this.btnConfirm.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnConfirm.OnPressedState.BorderRadius = 20;
            this.btnConfirm.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.OnPressedState.BorderThickness = 1;
            this.btnConfirm.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnConfirm.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.OnPressedState.IconLeftImage = null;
            this.btnConfirm.OnPressedState.IconRightImage = null;
            this.btnConfirm.Size = new System.Drawing.Size(135, 39);
            this.btnConfirm.TabIndex = 139;
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnConfirm.TextMarginLeft = 0;
            this.btnConfirm.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnConfirm.UseDefaultRadiusAndThickness = true;
            // 
            // btnback
            // 
            this.btnback.AllowAnimations = true;
            this.btnback.AllowMouseEffects = true;
            this.btnback.AllowToggling = false;
            this.btnback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnback.AnimationSpeed = 200;
            this.btnback.AutoGenerateColors = false;
            this.btnback.AutoRoundBorders = false;
            this.btnback.AutoSizeLeftIcon = true;
            this.btnback.AutoSizeRightIcon = true;
            this.btnback.BackColor = System.Drawing.Color.Transparent;
            this.btnback.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnback.BackgroundImage")));
            this.btnback.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnback.ButtonText = "Regresar";
            this.btnback.ButtonTextMarginLeft = 0;
            this.btnback.ColorContrastOnClick = 45;
            this.btnback.ColorContrastOnHover = 45;
            this.btnback.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnback.CustomizableEdges = borderEdges2;
            this.btnback.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnback.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnback.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnback.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnback.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnback.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnback.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnback.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnback.IconMarginLeft = 11;
            this.btnback.IconPadding = 10;
            this.btnback.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnback.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnback.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnback.IconSize = 25;
            this.btnback.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnback.IdleBorderRadius = 20;
            this.btnback.IdleBorderThickness = 1;
            this.btnback.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnback.IdleIconLeftImage = null;
            this.btnback.IdleIconRightImage = null;
            this.btnback.IndicateFocus = false;
            this.btnback.Location = new System.Drawing.Point(120, 226);
            this.btnback.Name = "btnback";
            this.btnback.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnback.OnDisabledState.BorderRadius = 20;
            this.btnback.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnback.OnDisabledState.BorderThickness = 1;
            this.btnback.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnback.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnback.OnDisabledState.IconLeftImage = null;
            this.btnback.OnDisabledState.IconRightImage = null;
            this.btnback.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnback.onHoverState.BorderRadius = 20;
            this.btnback.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnback.onHoverState.BorderThickness = 1;
            this.btnback.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnback.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnback.onHoverState.IconLeftImage = null;
            this.btnback.onHoverState.IconRightImage = null;
            this.btnback.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnback.OnIdleState.BorderRadius = 20;
            this.btnback.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnback.OnIdleState.BorderThickness = 1;
            this.btnback.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnback.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnback.OnIdleState.IconLeftImage = null;
            this.btnback.OnIdleState.IconRightImage = null;
            this.btnback.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnback.OnPressedState.BorderRadius = 20;
            this.btnback.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnback.OnPressedState.BorderThickness = 1;
            this.btnback.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnback.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnback.OnPressedState.IconLeftImage = null;
            this.btnback.OnPressedState.IconRightImage = null;
            this.btnback.Size = new System.Drawing.Size(130, 39);
            this.btnback.TabIndex = 140;
            this.btnback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnback.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnback.TextMarginLeft = 0;
            this.btnback.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnback.UseDefaultRadiusAndThickness = true;
            // 
            // txtPasswordBunifu
            // 
            this.txtPasswordBunifu.AcceptsReturn = false;
            this.txtPasswordBunifu.AcceptsTab = false;
            this.txtPasswordBunifu.AnimationSpeed = 200;
            this.txtPasswordBunifu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPasswordBunifu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPasswordBunifu.AutoSizeHeight = true;
            this.txtPasswordBunifu.BackColor = System.Drawing.Color.Transparent;
            this.txtPasswordBunifu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPasswordBunifu.BackgroundImage")));
            this.txtPasswordBunifu.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtPasswordBunifu.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtPasswordBunifu.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtPasswordBunifu.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtPasswordBunifu.BorderRadius = 20;
            this.txtPasswordBunifu.BorderThickness = 1;
            this.txtPasswordBunifu.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtPasswordBunifu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPasswordBunifu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPasswordBunifu.DefaultFont = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordBunifu.DefaultText = "";
            this.txtPasswordBunifu.FillColor = System.Drawing.Color.White;
            this.txtPasswordBunifu.HideSelection = true;
            this.txtPasswordBunifu.IconLeft = null;
            this.txtPasswordBunifu.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPasswordBunifu.IconPadding = 10;
            this.txtPasswordBunifu.IconRight = null;
            this.txtPasswordBunifu.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPasswordBunifu.Lines = new string[0];
            this.txtPasswordBunifu.Location = new System.Drawing.Point(77, 155);
            this.txtPasswordBunifu.MaxLength = 32767;
            this.txtPasswordBunifu.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPasswordBunifu.Modified = false;
            this.txtPasswordBunifu.Multiline = false;
            this.txtPasswordBunifu.Name = "txtPasswordBunifu";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPasswordBunifu.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPasswordBunifu.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPasswordBunifu.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPasswordBunifu.OnIdleState = stateProperties4;
            this.txtPasswordBunifu.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txtPasswordBunifu.PasswordChar = '\0';
            this.txtPasswordBunifu.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPasswordBunifu.PlaceholderText = "";
            this.txtPasswordBunifu.ReadOnly = false;
            this.txtPasswordBunifu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPasswordBunifu.SelectedText = "";
            this.txtPasswordBunifu.SelectionLength = 0;
            this.txtPasswordBunifu.SelectionStart = 0;
            this.txtPasswordBunifu.ShortcutsEnabled = true;
            this.txtPasswordBunifu.Size = new System.Drawing.Size(358, 45);
            this.txtPasswordBunifu.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtPasswordBunifu.TabIndex = 141;
            this.txtPasswordBunifu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPasswordBunifu.TextMarginBottom = 0;
            this.txtPasswordBunifu.TextMarginLeft = 3;
            this.txtPasswordBunifu.TextMarginTop = 1;
            this.txtPasswordBunifu.TextPlaceholder = "";
            this.txtPasswordBunifu.UseSystemPasswordChar = false;
            this.txtPasswordBunifu.WordWrap = true;
            // 
            // ShowPassword
            // 
            this.ShowPassword.BackColor = System.Drawing.Color.White;
            this.ShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowPassword.Image = ((System.Drawing.Image)(resources.GetObject("ShowPassword.Image")));
            this.ShowPassword.Location = new System.Drawing.Point(394, 164);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(30, 30);
            this.ShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPassword.TabIndex = 142;
            this.ShowPassword.TabStop = false;
            // 
            // HidePassword
            // 
            this.HidePassword.BackColor = System.Drawing.Color.White;
            this.HidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HidePassword.Image = ((System.Drawing.Image)(resources.GetObject("HidePassword.Image")));
            this.HidePassword.Location = new System.Drawing.Point(394, 164);
            this.HidePassword.Name = "HidePassword";
            this.HidePassword.Size = new System.Drawing.Size(30, 30);
            this.HidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HidePassword.TabIndex = 143;
            this.HidePassword.TabStop = false;
            // 
            // FrmOverrideBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(517, 301);
            this.Controls.Add(this.HidePassword);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.txtPasswordBunifu);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblEnterPass);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmOverrideBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOverrideBill";
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnConfirm;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnback;
        public Bunifu.UI.WinForms.BunifuTextBox txtPasswordBunifu;
        public System.Windows.Forms.PictureBox ShowPassword;
        public System.Windows.Forms.PictureBox HidePassword;
        public Bunifu.Framework.UI.BunifuCustomLabel lblTitle;
        public Bunifu.Framework.UI.BunifuCustomLabel lblSubTitle;
        public Bunifu.Framework.UI.BunifuCustomLabel lblEnterPass;
    }
}