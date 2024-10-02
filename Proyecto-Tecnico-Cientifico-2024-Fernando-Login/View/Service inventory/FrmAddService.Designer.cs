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
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.lblAddService = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblInformation = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblCategory = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblDescription = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblAmount = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.cmbCategoryS = new Bunifu.UI.WinForms.BunifuDropdown();
            this.btnAddService = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtAmount = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtDescriptionS = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtNameS = new Bunifu.UI.WinForms.BunifuTextBox();
            this.SuspendLayout();
            // 
            // lblAddService
            // 
            this.lblAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddService.Location = new System.Drawing.Point(0, 22);
            this.lblAddService.Name = "lblAddService";
            this.lblAddService.Size = new System.Drawing.Size(454, 29);
            this.lblAddService.TabIndex = 32;
            this.lblAddService.Text = "AGREGAR SERVICIO";
            this.lblAddService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblInformation
            // 
            this.lblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.Location = new System.Drawing.Point(2, 50);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(449, 17);
            this.lblInformation.TabIndex = 57;
            this.lblInformation.Text = "Ingrese en cada campo la información solicitada:";
            this.lblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(61, 287);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(79, 16);
            this.lblCategory.TabIndex = 62;
            this.lblCategory.Text = "Categoría:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(61, 174);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(94, 16);
            this.lblDescription.TabIndex = 60;
            this.lblDescription.Text = "Descripción:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(61, 114);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 16);
            this.lblName.TabIndex = 58;
            this.lblName.Text = "Nombre:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(61, 346);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(53, 16);
            this.lblAmount.TabIndex = 64;
            this.lblAmount.Text = "Monto:";
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
            // cmbCategoryS
            // 
            this.cmbCategoryS.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategoryS.BackgroundColor = System.Drawing.Color.LightGray;
            this.cmbCategoryS.BorderColor = System.Drawing.Color.Silver;
            this.cmbCategoryS.BorderRadius = 1;
            this.cmbCategoryS.Color = System.Drawing.Color.Silver;
            this.cmbCategoryS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCategoryS.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbCategoryS.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbCategoryS.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbCategoryS.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbCategoryS.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbCategoryS.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbCategoryS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategoryS.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbCategoryS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryS.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbCategoryS.FillDropDown = true;
            this.cmbCategoryS.FillIndicator = false;
            this.cmbCategoryS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoryS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoryS.ForeColor = System.Drawing.Color.Black;
            this.cmbCategoryS.FormattingEnabled = true;
            this.cmbCategoryS.Icon = null;
            this.cmbCategoryS.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbCategoryS.IndicatorColor = System.Drawing.Color.DimGray;
            this.cmbCategoryS.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbCategoryS.IndicatorThickness = 2;
            this.cmbCategoryS.IsDropdownOpened = false;
            this.cmbCategoryS.ItemBackColor = System.Drawing.Color.White;
            this.cmbCategoryS.ItemBorderColor = System.Drawing.Color.White;
            this.cmbCategoryS.ItemForeColor = System.Drawing.Color.Black;
            this.cmbCategoryS.ItemHeight = 26;
            this.cmbCategoryS.ItemHighLightColor = System.Drawing.Color.LightGray;
            this.cmbCategoryS.ItemHighLightForeColor = System.Drawing.Color.Black;
            this.cmbCategoryS.ItemTopMargin = 3;
            this.cmbCategoryS.Location = new System.Drawing.Point(64, 306);
            this.cmbCategoryS.Name = "cmbCategoryS";
            this.cmbCategoryS.Size = new System.Drawing.Size(331, 32);
            this.cmbCategoryS.TabIndex = 3;
            this.cmbCategoryS.Text = null;
            this.cmbCategoryS.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbCategoryS.TextLeftMargin = 5;
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
            this.btnAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnAddService.Location = new System.Drawing.Point(228, 431);
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
            this.btnAddService.TabIndex = 6;
            this.btnAddService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddService.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddService.TextMarginLeft = 0;
            this.btnAddService.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddService.UseDefaultRadiusAndThickness = true;
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
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnCancel.Location = new System.Drawing.Point(71, 431);
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
            this.btnCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnCancel.OnPressedState.BorderRadius = 20;
            this.btnCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnCancel.OnPressedState.BorderThickness = 1;
            this.btnCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnPressedState.IconLeftImage = null;
            this.btnCancel.OnPressedState.IconRightImage = null;
            this.btnCancel.Size = new System.Drawing.Size(151, 52);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancel.TextMarginLeft = 0;
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseDefaultRadiusAndThickness = true;
            // 
            // txtAmount
            // 
            this.txtAmount.AcceptsReturn = false;
            this.txtAmount.AcceptsTab = false;
            this.txtAmount.AnimationSpeed = 200;
            this.txtAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtAmount.AutoSizeHeight = true;
            this.txtAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAmount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtAmount.BackgroundImage")));
            this.txtAmount.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtAmount.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtAmount.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtAmount.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtAmount.BorderRadius = 1;
            this.txtAmount.BorderThickness = 3;
            this.txtAmount.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.DefaultText = "";
            this.txtAmount.FillColor = System.Drawing.Color.Gainsboro;
            this.txtAmount.HideSelection = true;
            this.txtAmount.IconLeft = null;
            this.txtAmount.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.IconPadding = 10;
            this.txtAmount.IconRight = null;
            this.txtAmount.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.Lines = new string[0];
            this.txtAmount.Location = new System.Drawing.Point(64, 365);
            this.txtAmount.MaximumSize = new System.Drawing.Size(330, 32);
            this.txtAmount.MaxLength = 12;
            this.txtAmount.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtAmount.Modified = false;
            this.txtAmount.Multiline = false;
            this.txtAmount.Name = "txtAmount";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtAmount.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtAmount.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtAmount.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Gray;
            stateProperties4.FillColor = System.Drawing.Color.Gainsboro;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtAmount.OnIdleState = stateProperties4;
            this.txtAmount.Padding = new System.Windows.Forms.Padding(3);
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.ReadOnly = false;
            this.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.ShortcutsEnabled = true;
            this.txtAmount.Size = new System.Drawing.Size(330, 32);
            this.txtAmount.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAmount.TextMarginBottom = 0;
            this.txtAmount.TextMarginLeft = 0;
            this.txtAmount.TextMarginTop = 0;
            this.txtAmount.TextPlaceholder = "";
            this.txtAmount.UseSystemPasswordChar = false;
            this.txtAmount.WordWrap = true;
            // 
            // txtDescriptionS
            // 
            this.txtDescriptionS.AcceptsReturn = false;
            this.txtDescriptionS.AcceptsTab = false;
            this.txtDescriptionS.AnimationSpeed = 200;
            this.txtDescriptionS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDescriptionS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDescriptionS.AutoSizeHeight = true;
            this.txtDescriptionS.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescriptionS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDescriptionS.BackgroundImage")));
            this.txtDescriptionS.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDescriptionS.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtDescriptionS.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtDescriptionS.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtDescriptionS.BorderRadius = 1;
            this.txtDescriptionS.BorderThickness = 3;
            this.txtDescriptionS.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtDescriptionS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescriptionS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescriptionS.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriptionS.DefaultText = "";
            this.txtDescriptionS.FillColor = System.Drawing.Color.Gainsboro;
            this.txtDescriptionS.HideSelection = true;
            this.txtDescriptionS.IconLeft = null;
            this.txtDescriptionS.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescriptionS.IconPadding = 10;
            this.txtDescriptionS.IconRight = null;
            this.txtDescriptionS.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescriptionS.Lines = new string[0];
            this.txtDescriptionS.Location = new System.Drawing.Point(64, 193);
            this.txtDescriptionS.MaxLength = 150;
            this.txtDescriptionS.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDescriptionS.Modified = false;
            this.txtDescriptionS.Multiline = true;
            this.txtDescriptionS.Name = "txtDescriptionS";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDescriptionS.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDescriptionS.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDescriptionS.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Gray;
            stateProperties8.FillColor = System.Drawing.Color.Gainsboro;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDescriptionS.OnIdleState = stateProperties8;
            this.txtDescriptionS.Padding = new System.Windows.Forms.Padding(3);
            this.txtDescriptionS.PasswordChar = '\0';
            this.txtDescriptionS.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDescriptionS.PlaceholderText = "";
            this.txtDescriptionS.ReadOnly = false;
            this.txtDescriptionS.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescriptionS.SelectedText = "";
            this.txtDescriptionS.SelectionLength = 0;
            this.txtDescriptionS.SelectionStart = 0;
            this.txtDescriptionS.ShortcutsEnabled = true;
            this.txtDescriptionS.Size = new System.Drawing.Size(330, 87);
            this.txtDescriptionS.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtDescriptionS.TabIndex = 2;
            this.txtDescriptionS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescriptionS.TextMarginBottom = 0;
            this.txtDescriptionS.TextMarginLeft = 0;
            this.txtDescriptionS.TextMarginTop = 0;
            this.txtDescriptionS.TextPlaceholder = "";
            this.txtDescriptionS.UseSystemPasswordChar = false;
            this.txtDescriptionS.WordWrap = true;
            // 
            // txtNameS
            // 
            this.txtNameS.AcceptsReturn = false;
            this.txtNameS.AcceptsTab = false;
            this.txtNameS.AnimationSpeed = 200;
            this.txtNameS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNameS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNameS.AutoSizeHeight = true;
            this.txtNameS.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNameS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtNameS.BackgroundImage")));
            this.txtNameS.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtNameS.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtNameS.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.txtNameS.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtNameS.BorderRadius = 1;
            this.txtNameS.BorderThickness = 3;
            this.txtNameS.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtNameS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNameS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameS.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameS.DefaultText = "";
            this.txtNameS.FillColor = System.Drawing.Color.Gainsboro;
            this.txtNameS.HideSelection = true;
            this.txtNameS.IconLeft = null;
            this.txtNameS.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameS.IconPadding = 10;
            this.txtNameS.IconRight = null;
            this.txtNameS.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameS.Lines = new string[0];
            this.txtNameS.Location = new System.Drawing.Point(64, 133);
            this.txtNameS.MaximumSize = new System.Drawing.Size(330, 32);
            this.txtNameS.MaxLength = 150;
            this.txtNameS.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtNameS.Modified = false;
            this.txtNameS.Multiline = false;
            this.txtNameS.Name = "txtNameS";
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtNameS.OnActiveState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtNameS.OnDisabledState = stateProperties10;
            stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            stateProperties11.FillColor = System.Drawing.Color.Empty;
            stateProperties11.ForeColor = System.Drawing.Color.Empty;
            stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtNameS.OnHoverState = stateProperties11;
            stateProperties12.BorderColor = System.Drawing.Color.Gray;
            stateProperties12.FillColor = System.Drawing.Color.Gainsboro;
            stateProperties12.ForeColor = System.Drawing.Color.Empty;
            stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtNameS.OnIdleState = stateProperties12;
            this.txtNameS.Padding = new System.Windows.Forms.Padding(3);
            this.txtNameS.PasswordChar = '\0';
            this.txtNameS.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNameS.PlaceholderText = "";
            this.txtNameS.ReadOnly = false;
            this.txtNameS.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNameS.SelectedText = "";
            this.txtNameS.SelectionLength = 0;
            this.txtNameS.SelectionStart = 0;
            this.txtNameS.ShortcutsEnabled = true;
            this.txtNameS.Size = new System.Drawing.Size(330, 32);
            this.txtNameS.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtNameS.TabIndex = 1;
            this.txtNameS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNameS.TextMarginBottom = 0;
            this.txtNameS.TextMarginLeft = 0;
            this.txtNameS.TextMarginTop = 0;
            this.txtNameS.TextPlaceholder = "";
            this.txtNameS.UseSystemPasswordChar = false;
            this.txtNameS.WordWrap = true;
            // 
            // FrmAddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 513);
            this.Controls.Add(this.txtNameS);
            this.Controls.Add(this.txtDescriptionS);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbCategoryS);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lblAddService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarServicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public Bunifu.UI.WinForms.BunifuDropdown cmbCategoryS;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddService;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnCancel;
        public Bunifu.UI.WinForms.BunifuTextBox txtAmount;
        public Bunifu.UI.WinForms.BunifuTextBox txtDescriptionS;
        public Bunifu.UI.WinForms.BunifuTextBox txtNameS;
        public Bunifu.Framework.UI.BunifuCustomLabel lblAddService;
        public Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public Bunifu.Framework.UI.BunifuCustomLabel lblInformation;
        public Bunifu.Framework.UI.BunifuCustomLabel lblCategory;
        public Bunifu.Framework.UI.BunifuCustomLabel lblDescription;
        public Bunifu.Framework.UI.BunifuCustomLabel lblName;
        public Bunifu.Framework.UI.BunifuCustomLabel lblAmount;
    }
}