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
            this.txtDescripcion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtNombres = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtMonto = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.comboTipoEmpleado = new Bunifu.UI.WinForms.BunifuDropdown();
            this.btnAddService = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
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
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.HintForeColor = System.Drawing.Color.Empty;
            this.txtDescripcion.HintText = "";
            this.txtDescripcion.isPassword = false;
            this.txtDescripcion.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDescripcion.LineIdleColor = System.Drawing.Color.Gray;
            this.txtDescripcion.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDescripcion.LineThickness = 3;
            this.txtDescripcion.Location = new System.Drawing.Point(64, 197);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(330, 82);
            this.txtDescripcion.TabIndex = 61;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMonto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtMonto.ForeColor = System.Drawing.Color.DimGray;
            this.txtMonto.HintForeColor = System.Drawing.Color.Empty;
            this.txtMonto.HintText = "";
            this.txtMonto.isPassword = false;
            this.txtMonto.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtMonto.LineIdleColor = System.Drawing.Color.Gray;
            this.txtMonto.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtMonto.LineThickness = 3;
            this.txtMonto.Location = new System.Drawing.Point(64, 367);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(330, 31);
            this.txtMonto.TabIndex = 65;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            // btnAddService
            // 
            this.btnAddService.AllowAnimations = true;
            this.btnAddService.AllowMouseEffects = true;
            this.btnAddService.AllowToggling = false;
            this.btnAddService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddService.AnimationSpeed = 200;
            this.btnAddService.AutoGenerateColors = false;
            this.btnAddService.AutoRoundBorders = false;
            this.btnAddService.AutoSizeLeftIcon = true;
            this.btnAddService.AutoSizeRightIcon = true;
            this.btnAddService.BackColor = System.Drawing.Color.Transparent;
            this.btnAddService.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddService.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddService.BackgroundImage")));
            this.btnAddService.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddService.ButtonText = "Agregar";
            this.btnAddService.ButtonTextMarginLeft = 0;
            this.btnAddService.ColorContrastOnClick = 45;
            this.btnAddService.ColorContrastOnHover = 45;
            this.btnAddService.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAddService.CustomizableEdges = borderEdges1;
            this.btnAddService.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddService.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddService.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddService.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddService.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAddService.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddService.ForeColor = System.Drawing.Color.White;
            this.btnAddService.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddService.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddService.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddService.IconMarginLeft = 11;
            this.btnAddService.IconPadding = 10;
            this.btnAddService.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddService.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddService.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddService.IconSize = 25;
            this.btnAddService.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddService.IdleBorderRadius = 20;
            this.btnAddService.IdleBorderThickness = 1;
            this.btnAddService.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddService.IdleIconLeftImage = null;
            this.btnAddService.IdleIconRightImage = null;
            this.btnAddService.IndicateFocus = false;
            this.btnAddService.Location = new System.Drawing.Point(227, 440);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddService.OnDisabledState.BorderRadius = 20;
            this.btnAddService.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddService.OnDisabledState.BorderThickness = 1;
            this.btnAddService.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddService.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddService.OnDisabledState.IconLeftImage = null;
            this.btnAddService.OnDisabledState.IconRightImage = null;
            this.btnAddService.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddService.onHoverState.BorderRadius = 20;
            this.btnAddService.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddService.onHoverState.BorderThickness = 1;
            this.btnAddService.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddService.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddService.onHoverState.IconLeftImage = null;
            this.btnAddService.onHoverState.IconRightImage = null;
            this.btnAddService.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddService.OnIdleState.BorderRadius = 20;
            this.btnAddService.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddService.OnIdleState.BorderThickness = 1;
            this.btnAddService.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btnAddService.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddService.OnIdleState.IconLeftImage = null;
            this.btnAddService.OnIdleState.IconRightImage = null;
            this.btnAddService.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddService.OnPressedState.BorderRadius = 20;
            this.btnAddService.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddService.OnPressedState.BorderThickness = 1;
            this.btnAddService.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnAddService.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddService.OnPressedState.IconLeftImage = null;
            this.btnAddService.OnPressedState.IconRightImage = null;
            this.btnAddService.Size = new System.Drawing.Size(151, 52);
            this.btnAddService.TabIndex = 94;
            this.btnAddService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddService.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddService.TextMarginLeft = 0;
            this.btnAddService.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddService.UseDefaultRadiusAndThickness = true;
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
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.comboTipoEmpleado);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.bunifuCustomLabel8);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "FrmAddService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarServicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public Bunifu.UI.WinForms.BunifuDropdown comboTipoEmpleado;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddService;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnCancelar;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtNombres;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtDescripcion;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtMonto;
    }
}