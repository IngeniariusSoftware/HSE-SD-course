namespace ClientSide.UI.Home
{
    partial class HomeForm
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
            this.UserPanel = new System.Windows.Forms.Panel();
            this.ChangeFriend = new System.Windows.Forms.Label();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.BirthDateTextValue = new System.Windows.Forms.Label();
            this.StatusTextValue = new System.Windows.Forms.Label();
            this.GennderTextValue = new System.Windows.Forms.Label();
            this.AgeTextValue = new System.Windows.Forms.Label();
            this.UniversityTextValue = new System.Windows.Forms.Label();
            this.SchoolTextValue = new System.Windows.Forms.Label();
            this.UniversityLabel = new System.Windows.Forms.Label();
            this.SchoolLabel = new System.Windows.Forms.Label();
            this.EducationLabel = new System.Windows.Forms.Label();
            this.EducationSplitter = new System.Windows.Forms.Label();
            this.AgelLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.FullNameSplitter = new System.Windows.Forms.Label();
            this.BirthDayLabel = new System.Windows.Forms.Label();
            this.FullNameTextValue = new System.Windows.Forms.Label();
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserPanel
            // 
            this.UserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserPanel.Controls.Add(this.ChangeFriend);
            this.UserPanel.Controls.Add(this.UserPictureBox);
            this.UserPanel.Controls.Add(this.BirthDateTextValue);
            this.UserPanel.Controls.Add(this.StatusTextValue);
            this.UserPanel.Controls.Add(this.GennderTextValue);
            this.UserPanel.Controls.Add(this.AgeTextValue);
            this.UserPanel.Controls.Add(this.UniversityTextValue);
            this.UserPanel.Controls.Add(this.SchoolTextValue);
            this.UserPanel.Controls.Add(this.UniversityLabel);
            this.UserPanel.Controls.Add(this.SchoolLabel);
            this.UserPanel.Controls.Add(this.EducationLabel);
            this.UserPanel.Controls.Add(this.EducationSplitter);
            this.UserPanel.Controls.Add(this.AgelLabel);
            this.UserPanel.Controls.Add(this.GenderLabel);
            this.UserPanel.Controls.Add(this.StatusLabel);
            this.UserPanel.Controls.Add(this.FullNameSplitter);
            this.UserPanel.Controls.Add(this.BirthDayLabel);
            this.UserPanel.Controls.Add(this.FullNameTextValue);
            this.UserPanel.Location = new System.Drawing.Point(0, 0);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(787, 553);
            this.UserPanel.TabIndex = 0;
            // 
            // ChangeFriend
            // 
            this.ChangeFriend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChangeFriend.AutoSize = true;
            this.ChangeFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeFriend.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ChangeFriend.Location = new System.Drawing.Point(168, 116);
            this.ChangeFriend.Name = "ChangeFriend";
            this.ChangeFriend.Size = new System.Drawing.Size(132, 17);
            this.ChangeFriend.TabIndex = 59;
            this.ChangeFriend.Text = "Добавить в друзья";
            this.ChangeFriend.Click += new System.EventHandler(this.ChangeFriend_Click);
            // 
            // UserPictureBox
            // 
            this.UserPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserPictureBox.BackgroundImage = global::ClientSide.Properties.Resources.ProfileIcon;
            this.UserPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserPictureBox.Image = global::ClientSide.Properties.Resources.ProfileIcon;
            this.UserPictureBox.Location = new System.Drawing.Point(17, 14);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(128, 128);
            this.UserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPictureBox.TabIndex = 58;
            this.UserPictureBox.TabStop = false;
            this.UserPictureBox.Click += new System.EventHandler(this.UserPictureBox_Click);
            // 
            // BirthDateTextValue
            // 
            this.BirthDateTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BirthDateTextValue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BirthDateTextValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BirthDateTextValue.Location = new System.Drawing.Point(272, 183);
            this.BirthDateTextValue.Name = "BirthDateTextValue";
            this.BirthDateTextValue.Size = new System.Drawing.Size(300, 27);
            this.BirthDateTextValue.TabIndex = 57;
            this.BirthDateTextValue.Text = "1 января 1999 г.";
            // 
            // StatusTextValue
            // 
            this.StatusTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusTextValue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusTextValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatusTextValue.Location = new System.Drawing.Point(272, 238);
            this.StatusTextValue.Name = "StatusTextValue";
            this.StatusTextValue.Size = new System.Drawing.Size(300, 27);
            this.StatusTextValue.TabIndex = 56;
            this.StatusTextValue.Text = "Не в браке";
            // 
            // GennderTextValue
            // 
            this.GennderTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GennderTextValue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GennderTextValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GennderTextValue.Location = new System.Drawing.Point(272, 289);
            this.GennderTextValue.Name = "GennderTextValue";
            this.GennderTextValue.Size = new System.Drawing.Size(300, 27);
            this.GennderTextValue.TabIndex = 55;
            this.GennderTextValue.Text = "Мужской";
            // 
            // AgeTextValue
            // 
            this.AgeTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgeTextValue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgeTextValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AgeTextValue.Location = new System.Drawing.Point(272, 338);
            this.AgeTextValue.Name = "AgeTextValue";
            this.AgeTextValue.Size = new System.Drawing.Size(300, 27);
            this.AgeTextValue.TabIndex = 54;
            this.AgeTextValue.Text = "32";
            // 
            // UniversityTextValue
            // 
            this.UniversityTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UniversityTextValue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UniversityTextValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UniversityTextValue.Location = new System.Drawing.Point(272, 479);
            this.UniversityTextValue.Name = "UniversityTextValue";
            this.UniversityTextValue.Size = new System.Drawing.Size(300, 27);
            this.UniversityTextValue.TabIndex = 53;
            this.UniversityTextValue.Text = "НИУ ВШЭ";
            // 
            // SchoolTextValue
            // 
            this.SchoolTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SchoolTextValue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SchoolTextValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SchoolTextValue.Location = new System.Drawing.Point(272, 430);
            this.SchoolTextValue.Name = "SchoolTextValue";
            this.SchoolTextValue.Size = new System.Drawing.Size(300, 27);
            this.SchoolTextValue.TabIndex = 52;
            this.SchoolTextValue.Text = "146";
            // 
            // UniversityLabel
            // 
            this.UniversityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UniversityLabel.AutoSize = true;
            this.UniversityLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UniversityLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UniversityLabel.Location = new System.Drawing.Point(12, 479);
            this.UniversityLabel.Name = "UniversityLabel";
            this.UniversityLabel.Size = new System.Drawing.Size(147, 27);
            this.UniversityLabel.TabIndex = 51;
            this.UniversityLabel.Text = "Университет:";
            // 
            // SchoolLabel
            // 
            this.SchoolLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SchoolLabel.AutoSize = true;
            this.SchoolLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SchoolLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SchoolLabel.Location = new System.Drawing.Point(12, 430);
            this.SchoolLabel.Name = "SchoolLabel";
            this.SchoolLabel.Size = new System.Drawing.Size(88, 27);
            this.SchoolLabel.TabIndex = 50;
            this.SchoolLabel.Text = "Школа:";
            // 
            // EducationLabel
            // 
            this.EducationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EducationLabel.AutoSize = true;
            this.EducationLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EducationLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EducationLabel.Location = new System.Drawing.Point(10, 383);
            this.EducationLabel.Name = "EducationLabel";
            this.EducationLabel.Size = new System.Drawing.Size(146, 27);
            this.EducationLabel.TabIndex = 49;
            this.EducationLabel.Text = "Образование";
            // 
            // EducationSplitter
            // 
            this.EducationSplitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EducationSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EducationSplitter.Location = new System.Drawing.Point(171, 400);
            this.EducationSplitter.Name = "EducationSplitter";
            this.EducationSplitter.Size = new System.Drawing.Size(580, 1);
            this.EducationSplitter.TabIndex = 48;
            // 
            // AgelLabel
            // 
            this.AgelLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgelLabel.AutoSize = true;
            this.AgelLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgelLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AgelLabel.Location = new System.Drawing.Point(12, 338);
            this.AgelLabel.Name = "AgelLabel";
            this.AgelLabel.Size = new System.Drawing.Size(99, 27);
            this.AgelLabel.TabIndex = 47;
            this.AgelLabel.Text = "Возраст:";
            // 
            // GenderLabel
            // 
            this.GenderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenderLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GenderLabel.Location = new System.Drawing.Point(12, 289);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(59, 27);
            this.GenderLabel.TabIndex = 46;
            this.GenderLabel.Text = "Пол:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StatusLabel.Location = new System.Drawing.Point(12, 238);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(238, 27);
            this.StatusLabel.TabIndex = 45;
            this.StatusLabel.Text = "Семейное положение:";
            // 
            // FullNameSplitter
            // 
            this.FullNameSplitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FullNameSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FullNameSplitter.Location = new System.Drawing.Point(11, 158);
            this.FullNameSplitter.Name = "FullNameSplitter";
            this.FullNameSplitter.Size = new System.Drawing.Size(740, 1);
            this.FullNameSplitter.TabIndex = 44;
            // 
            // BirthDayLabel
            // 
            this.BirthDayLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BirthDayLabel.AutoSize = true;
            this.BirthDayLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BirthDayLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BirthDayLabel.Location = new System.Drawing.Point(11, 183);
            this.BirthDayLabel.Name = "BirthDayLabel";
            this.BirthDayLabel.Size = new System.Drawing.Size(177, 27);
            this.BirthDayLabel.TabIndex = 43;
            this.BirthDayLabel.Text = "День рождения:";
            // 
            // FullNameTextValue
            // 
            this.FullNameTextValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FullNameTextValue.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullNameTextValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FullNameTextValue.Location = new System.Drawing.Point(165, 60);
            this.FullNameTextValue.Name = "FullNameTextValue";
            this.FullNameTextValue.Size = new System.Drawing.Size(474, 33);
            this.FullNameTextValue.TabIndex = 42;
            this.FullNameTextValue.Text = "Имя Фамилия Отчество";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 553);
            this.Controls.Add(this.UserPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "CopyCat";
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private System.Windows.Forms.Label BirthDateTextValue;
        private System.Windows.Forms.Label StatusTextValue;
        private System.Windows.Forms.Label GennderTextValue;
        private System.Windows.Forms.Label AgeTextValue;
        private System.Windows.Forms.Label UniversityTextValue;
        private System.Windows.Forms.Label SchoolTextValue;
        private System.Windows.Forms.Label UniversityLabel;
        private System.Windows.Forms.Label SchoolLabel;
        private System.Windows.Forms.Label EducationLabel;
        private System.Windows.Forms.Label EducationSplitter;
        private System.Windows.Forms.Label AgelLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label FullNameSplitter;
        private System.Windows.Forms.Label BirthDayLabel;
        private System.Windows.Forms.Label FullNameTextValue;
        private System.Windows.Forms.Label ChangeFriend;
        private System.Windows.Forms.TextBox textBox2;
    }
}