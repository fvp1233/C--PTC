namespace PTC2024.View.InventarioServicios
{
    partial class FrmAddService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddService));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtDui = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtNombres = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuMaterialTextbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.comboTipoEmpleado = new Bunifu.UI.WinForms.BunifuDropdown();
            this.BtnAgregarEmpleado = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.BtnCancelar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(95, 22);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(256, 29);
            this.bunifuCustomLabel1.TabIndex = 32;
            this.bunifuCustomLabel1.Text = "AGREGAR SERVICIO";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(42, 70);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(368, 35);
            this.bunifuSeparator1.TabIndex = 56;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(85, 52);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(275, 15);
            this.bunifuCustomLabel2.TabIndex = 57;
            this.bunifuCustomLabel2.Text = "Ingrese en cada campo la información solicitada:";
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(61, 288);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(79, 16);
            this.bunifuCustomLabel8.TabIndex = 62;
            this.bunifuCustomLabel8.Text = "Categoría:";
            // 
            // txtDui
            // 
            this.txtDui.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDui.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDui.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDui.ForeColor = System.Drawing.Color.DimGray;
            this.txtDui.HintForeColor = System.Drawing.Color.Empty;
            this.txtDui.HintText = "";
            this.txtDui.isPassword = false;
            this.txtDui.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDui.LineIdleColor = System.Drawing.Color.Gray;
            this.txtDui.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDui.LineThickness = 3;
            this.txtDui.Location = new System.Drawing.Point(64, 197);
            this.txtDui.Margin = new System.Windows.Forms.Padding(4);
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(330, 82);
            this.txtDui.TabIndex = 61;
            this.txtDui.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(61, 177);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(95, 16);
            this.bunifuCustomLabel6.TabIndex = 60;
            this.bunifuCustomLabel6.Text = "Descripción:";
            // 
            // txtNombres
            // 
            this.txtNombres.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNombres.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNombres.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombres.HintForeColor = System.Drawing.Color.Empty;
            this.txtNombres.HintText = "";
            this.txtNombres.isPassword = false;
            this.txtNombres.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtNombres.LineIdleColor = System.Drawing.Color.Gray;
            this.txtNombres.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtNombres.LineThickness = 3;
            this.txtNombres.Location = new System.Drawing.Point(64, 134);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(330, 31);
            this.txtNombres.TabIndex = 59;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(61, 114);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(66, 16);
            this.bunifuCustomLabel3.TabIndex = 58;
            this.bunifuCustomLabel3.Text = "Nombre:";
            // 
            // bunifuMaterialTextbox1
            // 
            this.bunifuMaterialTextbox1.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bunifuMaterialTextbox1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox1.HintText = "";
            this.bunifuMaterialTextbox1.isPassword = false;
            this.bunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.bunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.Gray;
            this.bunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.bunifuMaterialTextbox1.LineThickness = 3;
            this.bunifuMaterialTextbox1.Location = new System.Drawing.Point(64, 367);
            this.bunifuMaterialTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
            this.bunifuMaterialTextbox1.Size = new System.Drawing.Size(330, 31);
            this.bunifuMaterialTextbox1.TabIndex = 65;
            this.bunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(61, 347);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(56, 16);
            this.bunifuCustomLabel4.TabIndex = 64;
            this.bunifuCustomLabel4.Text = "Monto:";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // comboTipoEmpleado
            // 
            this.comboTipoEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.comboTipoEmpleado.BackgroundColor = System.Drawing.Color.LightGray;
            this.comboTipoEmpleado.BorderColor = System.Drawing.Color.Silver;
            this.comboTipoEmpleado.BorderRadius = 1;
            this.comboTipoEmpleado.Color = System.Drawing.Color.Silver;
            this.comboTipoEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboTipoEmpleado.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.comboTipoEmpleado.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.comboTipoEmpleado.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.comboTipoEmpleado.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.comboTipoEmpleado.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.comboTipoEmpleado.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.comboTipoEmpleado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboTipoEmpleado.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.comboTipoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoEmpleado.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.comboTipoEmpleado.FillDropDown = true;
            this.comboTipoEmpleado.FillIndicator = false;
            this.comboTipoEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTipoEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoEmpleado.ForeColor = System.Drawing.Color.Black;
            this.comboTipoEmpleado.FormattingEnabled = true;
            this.comboTipoEmpleado.Icon = null;
            this.comboTipoEmpleado.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.comboTipoEmpleado.IndicatorColor = System.Drawing.Color.DimGray;
            this.comboTipoEmpleado.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.comboTipoEmpleado.IndicatorThickness = 2;
            this.comboTipoEmpleado.IsDropdownOpened = false;
            this.comboTipoEmpleado.ItemBackColor = System.Drawing.Color.White;
            this.comboTipoEmpleado.ItemBorderColor = System.Drawing.Color.White;
            this.comboTipoEmpleado.ItemForeColor = System.Drawing.Color.Black;
            this.comboTipoEmpleado.ItemHeight = 26;
            this.comboTipoEmpleado.ItemHighLightColor = System.Drawing.Color.LightGray;
            this.comboTipoEmpleado.ItemHighLightForeColor = System.Drawing.Color.Black;
            this.comboTipoEmpleado.ItemTopMargin = 3;
            this.comboTipoEmpleado.Location = new System.Drawing.Point(64, 307);
            this.comboTipoEmpleado.Name = "comboTipoEmpleado";
            this.comboTipoEmpleado.Size = new System.Drawing.Size(331, 32);
            this.comboTipoEmpleado.TabIndex = 92;
            this.comboTipoEmpleado.Text = null;
            this.comboTipoEmpleado.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.comboTipoEmpleado.TextLeftMargin = 5;
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
            this.BtnAgregarEmpleado.ButtonText = "Agregar";
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
            this.BtnAgregarEmpleado.Location = new System.Drawing.Point(227, 440);
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
            this.BtnAgregarEmpleado.TabIndex = 94;
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
            this.BtnCancelar.Location = new System.Drawing.Point(70, 440);
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
            this.BtnCancelar.TabIndex = 93;
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnCancelar.TextMarginLeft = 0;
            this.BtnCancelar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnCancelar.UseDefaultRadiusAndThickness = true;
            // 
            // FrmAddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 531);
            this.Controls.Add(this.BtnAgregarEmpleado);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.comboTipoEmpleado);
            this.Controls.Add(this.bunifuMaterialTextbox1);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.bunifuCustomLabel8);
            this.Controls.Add(this.txtDui);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "FrmAddService";
            this.Text = "FrmAgregarServicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtDui;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtNombres;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public Bunifu.UI.WinForms.BunifuDropdown comboTipoEmpleado;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnAgregarEmpleado;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnCancelar;
    }
}