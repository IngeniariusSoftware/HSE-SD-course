namespace ClientSide.UI.Аuthentication
{
    partial class АuthenticationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(АuthenticationForm));
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.RegistrationPanel = new System.Windows.Forms.Panel();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Registrea = new System.Windows.Forms.Panel();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ReconnectButton = new System.Windows.Forms.Button();
            this.ConnectionStatusLogo = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.RegistrationPanel.SuspendLayout();
            this.Registrea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionStatusLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.AccessibleName = "Ваш логин";
            this.LoginTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.LoginTextBox.Location = new System.Drawing.Point(105, 175);
            this.LoginTextBox.MaxLength = 16;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(203, 29);
            this.LoginTextBox.TabIndex = 0;
            this.LoginTextBox.Text = "Ваш логин";
            this.LoginTextBox.TextChanged += new System.EventHandler(this.LoginTextBox_TextChanged);
            this.LoginTextBox.Enter += new System.EventHandler(this.LoginTextBox_Enter);
            this.LoginTextBox.Leave += new System.EventHandler(this.LoginTextBox_Leave);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.AccessibleName = "Пароль";
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PasswordTextBox.Location = new System.Drawing.Point(105, 236);
            this.PasswordTextBox.MaxLength = 16;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(203, 29);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.Text = "Пароль";
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.PasswordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // LogInButton
            // 
            this.LogInButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LogInButton.Enabled = false;
            this.LogInButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LogInButton.Font = new System.Drawing.Font("Broadway", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogInButton.ForeColor = System.Drawing.Color.Black;
            this.LogInButton.Location = new System.Drawing.Point(125, 285);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(123, 31);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.Text = "Войти";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // RegistrationPanel
            // 
            this.RegistrationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RegistrationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistrationPanel.Controls.Add(this.RegistrationButton);
            this.RegistrationPanel.Controls.Add(this.label1);
            this.RegistrationPanel.Location = new System.Drawing.Point(48, 390);
            this.RegistrationPanel.Name = "RegistrationPanel";
            this.RegistrationPanel.Size = new System.Drawing.Size(419, 164);
            this.RegistrationPanel.TabIndex = 6;
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegistrationButton.Enabled = false;
            this.RegistrationButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RegistrationButton.Font = new System.Drawing.Font("Broadway", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.Location = new System.Drawing.Point(139, 90);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(146, 31);
            this.RegistrationButton.TabIndex = 7;
            this.RegistrationButton.Text = "Регистрация";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(100, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Впервые в Copycat?";
            // 
            // Registrea
            // 
            this.Registrea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Registrea.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Registrea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Registrea.Controls.Add(this.ServerTextBox);
            this.Registrea.Controls.Add(this.SettingsButton);
            this.Registrea.Controls.Add(this.ReconnectButton);
            this.Registrea.Controls.Add(this.ConnectionStatusLogo);
            this.Registrea.Controls.Add(this.LogInButton);
            this.Registrea.Controls.Add(this.PasswordTextBox);
            this.Registrea.Controls.Add(this.Logo);
            this.Registrea.Controls.Add(this.LoginTextBox);
            this.Registrea.Location = new System.Drawing.Point(48, 28);
            this.Registrea.Name = "Registrea";
            this.Registrea.Size = new System.Drawing.Size(419, 363);
            this.Registrea.TabIndex = 7;
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ServerTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerTextBox.ForeColor = System.Drawing.Color.Black;
            this.ServerTextBox.Location = new System.Drawing.Point(105, 326);
            this.ServerTextBox.MaxLength = 25;
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(203, 29);
            this.ServerTextBox.TabIndex = 13;
            this.ServerTextBox.Text = "127.0.0.1:904";
            this.ServerTextBox.Visible = false;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SettingsButton.BackColor = System.Drawing.SystemColors.Control;
            this.SettingsButton.BackgroundImage = global::ClientSide.Properties.Resources.ConnectionSettingsIcon;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.Location = new System.Drawing.Point(308, 287);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(31, 31);
            this.SettingsButton.TabIndex = 12;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Visible = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ReconnectButton
            // 
            this.ReconnectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReconnectButton.BackgroundImage = global::ClientSide.Properties.Resources.ReconnectIcon;
            this.ReconnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReconnectButton.Location = new System.Drawing.Point(263, 285);
            this.ReconnectButton.Name = "ReconnectButton";
            this.ReconnectButton.Size = new System.Drawing.Size(31, 31);
            this.ReconnectButton.TabIndex = 10;
            this.ReconnectButton.UseVisualStyleBackColor = true;
            this.ReconnectButton.Click += new System.EventHandler(this.ReconnectButton_Click);
            // 
            // ConnectionStatusLogo
            // 
            this.ConnectionStatusLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectionStatusLogo.Image = global::ClientSide.Properties.Resources.ConnectionIcon;
            this.ConnectionStatusLogo.Location = new System.Drawing.Point(327, 58);
            this.ConnectionStatusLogo.Name = "ConnectionStatusLogo";
            this.ConnectionStatusLogo.Size = new System.Drawing.Size(52, 50);
            this.ConnectionStatusLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ConnectionStatusLogo.TabIndex = 8;
            this.ConnectionStatusLogo.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::ClientSide.Properties.Resources.MonkeyHelloLogo;
            this.Logo.Location = new System.Drawing.Point(148, 31);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(124, 117);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 3;
            this.Logo.TabStop = false;
            this.Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Logo_MouseDown);
            this.Logo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Logo_MouseUp);
            // 
            // АuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 577);
            this.Controls.Add(this.Registrea);
            this.Controls.Add(this.RegistrationPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(537, 616);
            this.Name = "АuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copycat";
            this.RegistrationPanel.ResumeLayout(false);
            this.RegistrationPanel.PerformLayout();
            this.Registrea.ResumeLayout(false);
            this.Registrea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionStatusLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel RegistrationPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Registrea;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.PictureBox ConnectionStatusLogo;
        private System.Windows.Forms.Button ReconnectButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.TextBox ServerTextBox;
    }
}

