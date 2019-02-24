namespace ClientSide.UI.Edit
{
    partial class EditForm
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
            this.EditPanel = new System.Windows.Forms.Panel();
            this.EditButton = new System.Windows.Forms.Button();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.BirthDayPicker = new System.Windows.Forms.DateTimePicker();
            this.SchoolTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.UniversityTextBox = new System.Windows.Forms.TextBox();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.PatronymicTextBox = new System.Windows.Forms.TextBox();
            this.MonkeyLogo = new System.Windows.Forms.PictureBox();
            this.EditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonkeyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EditPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditPanel.Controls.Add(this.EditButton);
            this.EditPanel.Controls.Add(this.StatusComboBox);
            this.EditPanel.Controls.Add(this.BirthDayPicker);
            this.EditPanel.Controls.Add(this.SchoolTextBox);
            this.EditPanel.Controls.Add(this.NameTextBox);
            this.EditPanel.Controls.Add(this.UniversityTextBox);
            this.EditPanel.Controls.Add(this.GenderComboBox);
            this.EditPanel.Controls.Add(this.SurnameTextBox);
            this.EditPanel.Controls.Add(this.PatronymicTextBox);
            this.EditPanel.Controls.Add(this.MonkeyLogo);
            this.EditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditPanel.Location = new System.Drawing.Point(0, 0);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(787, 553);
            this.EditPanel.TabIndex = 0;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditButton.BackColor = System.Drawing.Color.White;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EditButton.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditButton.Location = new System.Drawing.Point(280, 467);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(200, 40);
            this.EditButton.TabIndex = 43;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.AccessibleDescription = "";
            this.StatusComboBox.AccessibleName = "Семейное положение";
            this.StatusComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusComboBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusComboBox.ForeColor = System.Drawing.Color.Black;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Items.AddRange(new object[] {
            "Не в браке",
            "В браке"});
            this.StatusComboBox.Location = new System.Drawing.Point(422, 366);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(270, 33);
            this.StatusComboBox.TabIndex = 42;
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
            this.BirthDayPicker.Location = new System.Drawing.Point(72, 367);
            this.BirthDayPicker.MaxDate = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
            this.BirthDayPicker.Name = "BirthDayPicker";
            this.BirthDayPicker.Size = new System.Drawing.Size(267, 29);
            this.BirthDayPicker.TabIndex = 38;
            this.BirthDayPicker.Value = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
            // 
            // SchoolTextBox
            // 
            this.SchoolTextBox.AccessibleDescription = "";
            this.SchoolTextBox.AccessibleName = "Школа";
            this.SchoolTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SchoolTextBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SchoolTextBox.ForeColor = System.Drawing.Color.Black;
            this.SchoolTextBox.Location = new System.Drawing.Point(419, 65);
            this.SchoolTextBox.MaxLength = 16;
            this.SchoolTextBox.Name = "SchoolTextBox";
            this.SchoolTextBox.Size = new System.Drawing.Size(270, 33);
            this.SchoolTextBox.TabIndex = 39;
            this.SchoolTextBox.Text = "Школа";
            // 
            // NameTextBox
            // 
            this.NameTextBox.AccessibleDescription = "";
            this.NameTextBox.AccessibleName = "Ваше имя";
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameTextBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.Location = new System.Drawing.Point(69, 65);
            this.NameTextBox.MaxLength = 16;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(270, 33);
            this.NameTextBox.TabIndex = 35;
            this.NameTextBox.Text = "Ваше имя";
            // 
            // UniversityTextBox
            // 
            this.UniversityTextBox.AccessibleDescription = "";
            this.UniversityTextBox.AccessibleName = "Университет";
            this.UniversityTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UniversityTextBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UniversityTextBox.ForeColor = System.Drawing.Color.Black;
            this.UniversityTextBox.Location = new System.Drawing.Point(419, 163);
            this.UniversityTextBox.MaxLength = 16;
            this.UniversityTextBox.Name = "UniversityTextBox";
            this.UniversityTextBox.Size = new System.Drawing.Size(270, 33);
            this.UniversityTextBox.TabIndex = 40;
            this.UniversityTextBox.Text = "Университет";
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.AccessibleDescription = "";
            this.GenderComboBox.AccessibleName = "Пол";
            this.GenderComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenderComboBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenderComboBox.ForeColor = System.Drawing.Color.Black;
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.GenderComboBox.Location = new System.Drawing.Point(422, 263);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(270, 33);
            this.GenderComboBox.TabIndex = 41;
            this.GenderComboBox.Text = "Пол";
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.AccessibleDescription = "";
            this.SurnameTextBox.AccessibleName = "Ваша фамилия";
            this.SurnameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SurnameTextBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameTextBox.ForeColor = System.Drawing.Color.Black;
            this.SurnameTextBox.Location = new System.Drawing.Point(69, 163);
            this.SurnameTextBox.MaxLength = 16;
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(270, 33);
            this.SurnameTextBox.TabIndex = 36;
            this.SurnameTextBox.Text = "Ваша фамилия";
            // 
            // PatronymicTextBox
            // 
            this.PatronymicTextBox.AccessibleDescription = "";
            this.PatronymicTextBox.AccessibleName = "Ваше отчество";
            this.PatronymicTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PatronymicTextBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PatronymicTextBox.ForeColor = System.Drawing.Color.Black;
            this.PatronymicTextBox.Location = new System.Drawing.Point(72, 263);
            this.PatronymicTextBox.MaxLength = 16;
            this.PatronymicTextBox.Name = "PatronymicTextBox";
            this.PatronymicTextBox.Size = new System.Drawing.Size(270, 33);
            this.PatronymicTextBox.TabIndex = 37;
            this.PatronymicTextBox.Text = "Ваше отчество";
            // 
            // MonkeyLogo
            // 
            this.MonkeyLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MonkeyLogo.BackColor = System.Drawing.Color.Transparent;
            this.MonkeyLogo.Image = global::ClientSide.Properties.Resources.MonkeySitIcon;
            this.MonkeyLogo.Location = new System.Drawing.Point(72, 332);
            this.MonkeyLogo.Name = "MonkeyLogo";
            this.MonkeyLogo.Size = new System.Drawing.Size(64, 64);
            this.MonkeyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MonkeyLogo.TabIndex = 34;
            this.MonkeyLogo.TabStop = false;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 553);
            this.Controls.Add(this.EditPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonkeyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.DateTimePicker BirthDayPicker;
        private System.Windows.Forms.TextBox SchoolTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox UniversityTextBox;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox PatronymicTextBox;
        private System.Windows.Forms.PictureBox MonkeyLogo;
    }
}