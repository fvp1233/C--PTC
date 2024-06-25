namespace PTC2024.formularios.login
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.dataLogin = new System.Windows.Forms.Panel();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtContraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.Label();
            this.logoLogin = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.logoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLogin
            // 
            this.dataLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(33)))));
            this.dataLogin.Controls.Add(this.linkLabel);
            this.dataLogin.Controls.Add(this.btnLogin);
            this.dataLogin.Controls.Add(this.txtPassword);
            this.dataLogin.Controls.Add(this.txtUser);
            this.dataLogin.Controls.Add(this.pictureBox2);
            this.dataLogin.Controls.Add(this.pictureBox3);
            this.dataLogin.Controls.Add(this.txtContraseña);
            this.dataLogin.Controls.Add(this.txtUsuario);
            this.dataLogin.Controls.Add(this.txtLogin);
            this.dataLogin.Location = new System.Drawing.Point(-2, -4);
            this.dataLogin.Margin = new System.Windows.Forms.Padding(6);
            this.dataLogin.Name = "dataLogin";
            this.dataLogin.Size = new System.Drawing.Size(964, 858);
            this.dataLogin.TabIndex = 0;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.White;
            this.linkLabel.Location = new System.Drawing.Point(368, 568);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(239, 25);
            this.linkLabel.TabIndex = 11;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "¿Olvidó su contraseña?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(53)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogin.Location = new System.Drawing.Point(308, 681);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(324, 88);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(174, 450);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(636, 24);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "Contraseña";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(174, 279);
            this.txtUser.Margin = new System.Windows.Forms.Padding(6);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(636, 24);
            this.txtUser.TabIndex = 7;
            this.txtUser.Text = "Usuario";
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(94, 279);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(94, 450);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 47);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // txtContraseña
            // 
            this.txtContraseña.AutoSize = true;
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtContraseña.Location = new System.Drawing.Point(66, 365);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(92, 20);
            this.txtContraseña.TabIndex = 4;
            this.txtContraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AutoSize = true;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUsuario.Location = new System.Drawing.Point(66, 202);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(64, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Text = "Usuario";
            // 
            // txtLogin
            // 
            this.txtLogin.AutoSize = true;
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtLogin.Location = new System.Drawing.Point(366, 71);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(124, 39);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.Text = "LOGIN";
            // 
            // logoLogin
            // 
            this.logoLogin.Controls.Add(this.pictureBox1);
            this.logoLogin.Location = new System.Drawing.Point(960, 2);
            this.logoLogin.Margin = new System.Windows.Forms.Padding(6);
            this.logoLogin.Name = "logoLogin";
            this.logoLogin.Size = new System.Drawing.Size(640, 852);
            this.logoLogin.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 846);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.logoLogin);
            this.Controls.Add(this.dataLogin);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.dataLogin.ResumeLayout(false);
            this.dataLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.logoLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dataLogin;
        private System.Windows.Forms.FlowLayoutPanel logoLogin;
        private System.Windows.Forms.Label txtLogin;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtContraseña;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkLabel;
    }
}