namespace ClientSide.UI.Registration
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.RegistrationPanel = new System.Windows.Forms.Panel();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.BirthDayPicker = new System.Windows.Forms.DateTimePicker();
            this.BIrthDayLabel = new System.Windows.Forms.Label();
            this.SchoolTextBox = new System.Windows.Forms.TextBox();
            this.RegistrationProgressBar = new System.Windows.Forms.ProgressBar();
            this.RegistrationLabel = new System.Windows.Forms.Label();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.UnversityTextBox = new System.Windows.Forms.TextBox();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.PatronymicTextBox = new System.Windows.Forms.TextBox();
            this.MonkeyLogo = new System.Windows.Forms.PictureBox();
            this.RegistrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonkeyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // RegistrationPanel
            // 
            this.RegistrationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistrationPanel.Controls.Add(this.StatusComboBox);
            this.RegistrationPanel.Controls.Add(this.BirthDayPicker);
            this.RegistrationPanel.Controls.Add(this.BIrthDayLabel);
            this.RegistrationPanel.Controls.Add(this.SchoolTextBox);
            this.RegistrationPanel.Controls.Add(this.RegistrationProgressBar);
            this.RegistrationPanel.Controls.Add(this.RegistrationLabel);
            this.RegistrationPanel.Controls.Add(this.RegistrationButton);
            this.RegistrationPanel.Controls.Add(this.ReturnButton);
            this.RegistrationPanel.Controls.Add(this.NameTextBox);
            this.RegistrationPanel.Controls.Add(this.UnversityTextBox);
            this.RegistrationPanel.Controls.Add(this.GenderComboBox);
            this.RegistrationPanel.Controls.Add(this.SurnameTextBox);
            this.RegistrationPanel.Controls.Add(this.PatronymicTextBox);
            this.RegistrationPanel.Controls.Add(this.MonkeyLogo);
            this.RegistrationPanel.Location = new System.Drawing.Point(16, 12);
            this.RegistrationPanel.Name = "RegistrationPanel";
            this.RegistrationPanel.Size = new System.Drawing.Size(562, 447);
            this.RegistrationPanel.TabIndex = 24;
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.AccessibleDescription = "";
            this.StatusComboBox.AccessibleName = "Семейное положение";
            this.StatusComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusComboBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusComboBox.ForeColor = System.Drawing.Color.DarkGray;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Items.AddRange(new object[] {
            "Не в браке",
            "В браке"});
            this.StatusComboBox.Location = new System.Drawing.Point(310, 304);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(203, 30);
            this.StatusComboBox.TabIndex = 33;
            this.StatusComboBox.Text = "Семейное положение";

            // 
            // BirthDayPicker
            // 
            this.BirthDayPicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BirthDayPicker.CalendarForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BirthDayPicker.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.BirthDayPicker.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.BirthDayPicker.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BirthDayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthDayPicker.Location = new System.Drawing.Point(37, 305);
            this.BirthDayPicker.MaxDate = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
            this.BirthDayPicker.Name = "BirthDayPicker";
            this.BirthDayPicker.Size = new System.Drawing.Size(200, 29);
            this.BirthDayPicker.TabIndex = 29;
            this.BirthDayPicker.Value = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
            // 
            // BIrthDayLabel
            // 
            this.BIrthDayLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BIrthDayLabel.AutoSize = true;
            this.BIrthDayLabel.BackColor = System.Drawing.Color.Transparent;
            this.BIrthDayLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BIrthDayLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.BIrthDayLabel.Location = new System.Drawing.Point(33, 280);
            this.BIrthDayLabel.Name = "BIrthDayLabel";
            this.BIrthDayLabel.Size = new System.Drawing.Size(194, 22);
            this.BIrthDayLabel.TabIndex = 36;
            this.BIrthDayLabel.Text = "Ваша дата рождения";
            // 
            // SchoolTextBox
            // 
            this.SchoolTextBox.AccessibleDescription = "";
            this.SchoolTextBox.AccessibleName = "Школа";
            this.SchoolTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SchoolTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SchoolTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.SchoolTextBox.Location = new System.Drawing.Point(310, 88);
            this.SchoolTextBox.MaxLength = 16;
            this.SchoolTextBox.Name = "SchoolTextBox";
            this.SchoolTextBox.Size = new System.Drawing.Size(203, 29);
            this.SchoolTextBox.TabIndex = 30;
            this.SchoolTextBox.Text = "Школа";

            // 
            // RegistrationProgressBar
            // 
            this.RegistrationProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegistrationProgressBar.Location = new System.Drawing.Point(348, 368);
            this.RegistrationProgressBar.Maximum = 160;
            this.RegistrationProgressBar.Name = "RegistrationProgressBar";
            this.RegistrationProgressBar.Size = new System.Drawing.Size(134, 40);
            this.RegistrationProgressBar.TabIndex = 35;
            this.RegistrationProgressBar.Value = 20;
            // 
            // RegistrationLabel
            // 
            this.RegistrationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegistrationLabel.AutoSize = true;
            this.RegistrationLabel.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationLabel.Location = new System.Drawing.Point(109, 21);
            this.RegistrationLabel.Name = "RegistrationLabel";
            this.RegistrationLabel.Size = new System.Drawing.Size(338, 26);
            this.RegistrationLabel.TabIndex = 34;
            this.RegistrationLabel.Text = "Укажите ваши личные данные";
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegistrationButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.Location = new System.Drawing.Point(348, 368);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(134, 40);
            this.RegistrationButton.TabIndex = 33;
            this.RegistrationButton.Text = "Ок";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Visible = false;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReturnButton.Location = new System.Drawing.Point(62, 368);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(134, 40);
            this.ReturnButton.TabIndex = 34;
            this.ReturnButton.Text = "Назад";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.AccessibleDescription = "";
            this.NameTextBox.AccessibleName = "Ваше имя";
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.NameTextBox.Location = new System.Drawing.Point(37, 88);
            this.NameTextBox.MaxLength = 16;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(203, 29);
            this.NameTextBox.TabIndex = 26;
            this.NameTextBox.Text = "Ваше имя";

            // 
            // UnversityTextBox
            // 
            this.UnversityTextBox.AccessibleDescription = "";
            this.UnversityTextBox.AccessibleName = "Университет";
            this.UnversityTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnversityTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UnversityTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.UnversityTextBox.Location = new System.Drawing.Point(310, 158);
            this.UnversityTextBox.MaxLength = 16;
            this.UnversityTextBox.Name = "UnversityTextBox";
            this.UnversityTextBox.Size = new System.Drawing.Size(203, 29);
            this.UnversityTextBox.TabIndex = 31;
            this.UnversityTextBox.Text = "Университет";

            // 
            // GenderComboBox
            // 
            this.GenderComboBox.AccessibleDescription = "";
            this.GenderComboBox.AccessibleName = "Пол";
            this.GenderComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenderComboBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenderComboBox.ForeColor = System.Drawing.Color.DarkGray;
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.GenderComboBox.Location = new System.Drawing.Point(310, 228);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(203, 30);
            this.GenderComboBox.TabIndex = 32;
            this.GenderComboBox.Text = "Пол";

            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.AccessibleDescription = "";
            this.SurnameTextBox.AccessibleName = "Ваша фамилия";
            this.SurnameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SurnameTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.SurnameTextBox.Location = new System.Drawing.Point(37, 158);
            this.SurnameTextBox.MaxLength = 16;
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(203, 29);
            this.SurnameTextBox.TabIndex = 27;
            this.SurnameTextBox.Text = "Ваша фамилия";

            // 
            // PatronymicTextBox
            // 
            this.PatronymicTextBox.AccessibleDescription = "";
            this.PatronymicTextBox.AccessibleName = "Ваше отчество";
            this.PatronymicTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PatronymicTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PatronymicTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.PatronymicTextBox.Location = new System.Drawing.Point(37, 228);
            this.PatronymicTextBox.MaxLength = 16;
            this.PatronymicTextBox.Name = "PatronymicTextBox";
            this.PatronymicTextBox.Size = new System.Drawing.Size(203, 29);
            this.PatronymicTextBox.TabIndex = 28;
            this.PatronymicTextBox.Text = "Ваше отчество";

            // 
            // MonkeyLogo
            // 
            this.MonkeyLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MonkeyLogo.BackColor = System.Drawing.Color.Transparent;
            this.MonkeyLogo.Image = global::ClientSide.Properties.Resources.MonkeySitIcon;
            this.MonkeyLogo.Location = new System.Drawing.Point(37, 53);
            this.MonkeyLogo.Name = "MonkeyLogo";
            this.MonkeyLogo.Size = new System.Drawing.Size(64, 64);
            this.MonkeyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MonkeyLogo.TabIndex = 20;
            this.MonkeyLogo.TabStop = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 471);
            this.Controls.Add(this.RegistrationPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copycat";
            this.RegistrationPanel.ResumeLayout(false);
            this.RegistrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonkeyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox MonkeyLogo;
        private System.Windows.Forms.Panel RegistrationPanel;
        private System.Windows.Forms.DateTimePicker BirthDayPicker;
        private System.Windows.Forms.Label BIrthDayLabel;
        private System.Windows.Forms.TextBox SchoolTextBox;
        private System.Windows.Forms.ProgressBar RegistrationProgressBar;
        private System.Windows.Forms.Label RegistrationLabel;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox UnversityTextBox;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox PatronymicTextBox;
        private System.Windows.Forms.ComboBox StatusComboBox;
    }
}