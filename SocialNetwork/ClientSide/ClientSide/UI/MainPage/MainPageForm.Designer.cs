namespace ClientSide.UI.MainPage
{
    partial class MainPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageForm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewsButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.PeopleButton = new System.Windows.Forms.Button();
            this.FollowerButton = new System.Windows.Forms.Button();
            this.FriendButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MenuPanel.BackColor = System.Drawing.Color.White;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.ExitButton);
            this.MenuPanel.Controls.Add(this.NewsButton);
            this.MenuPanel.Controls.Add(this.EditButton);
            this.MenuPanel.Controls.Add(this.PeopleButton);
            this.MenuPanel.Controls.Add(this.FollowerButton);
            this.MenuPanel.Controls.Add(this.FriendButton);
            this.MenuPanel.Controls.Add(this.HomeButton);
            this.MenuPanel.Location = new System.Drawing.Point(12, 12);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(181, 556);
            this.MenuPanel.TabIndex = 4;
            // 
            // PagePanel
            // 
            this.PagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PagePanel.BackColor = System.Drawing.Color.White;
            this.PagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PagePanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PagePanel.Location = new System.Drawing.Point(199, 12);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(787, 553);
            this.PagePanel.TabIndex = 5;
            this.PagePanel.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.AccessibleDescription = "EditForm";
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Image = global::ClientSide.Properties.Resources.ExitIcon;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(-1, 329);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(181, 56);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Tag = "";
            this.ExitButton.Text = "Выход      ";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NewsButton
            // 
            this.NewsButton.AccessibleDescription = "NewsForm";
            this.NewsButton.BackColor = System.Drawing.Color.White;
            this.NewsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewsButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewsButton.Image = global::ClientSide.Properties.Resources.NewsIcon;
            this.NewsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewsButton.Location = new System.Drawing.Point(-1, 54);
            this.NewsButton.Name = "NewsButton";
            this.NewsButton.Size = new System.Drawing.Size(181, 56);
            this.NewsButton.TabIndex = 7;
            this.NewsButton.Tag = "";
            this.NewsButton.Text = "Новости ";
            this.NewsButton.UseVisualStyleBackColor = false;
            this.NewsButton.Click += new System.EventHandler(this.PageButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.AccessibleDescription = "EditForm";
            this.EditButton.BackColor = System.Drawing.Color.White;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditButton.Location = new System.Drawing.Point(-1, 274);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(181, 56);
            this.EditButton.TabIndex = 6;
            this.EditButton.Tag = "";
            this.EditButton.Text = "Редактировать";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.PageButton_Click);
            // 
            // PeopleButton
            // 
            this.PeopleButton.AccessibleDescription = "PeopleForm";
            this.PeopleButton.BackColor = System.Drawing.Color.White;
            this.PeopleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PeopleButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeopleButton.Image = ((System.Drawing.Image)(resources.GetObject("PeopleButton.Image")));
            this.PeopleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PeopleButton.Location = new System.Drawing.Point(-1, 219);
            this.PeopleButton.Name = "PeopleButton";
            this.PeopleButton.Size = new System.Drawing.Size(181, 56);
            this.PeopleButton.TabIndex = 5;
            this.PeopleButton.Tag = "";
            this.PeopleButton.Text = "Люди      ";
            this.PeopleButton.UseVisualStyleBackColor = false;
            this.PeopleButton.Click += new System.EventHandler(this.PageButton_Click);
            // 
            // FollowerButton
            // 
            this.FollowerButton.AccessibleDescription = "FollowersForm";
            this.FollowerButton.BackColor = System.Drawing.Color.White;
            this.FollowerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FollowerButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FollowerButton.Image = ((System.Drawing.Image)(resources.GetObject("FollowerButton.Image")));
            this.FollowerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FollowerButton.Location = new System.Drawing.Point(-1, 164);
            this.FollowerButton.Name = "FollowerButton";
            this.FollowerButton.Size = new System.Drawing.Size(181, 56);
            this.FollowerButton.TabIndex = 4;
            this.FollowerButton.Tag = "";
            this.FollowerButton.Text = "Подписчики   ";
            this.FollowerButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FollowerButton.UseVisualStyleBackColor = false;
            this.FollowerButton.Click += new System.EventHandler(this.PageButton_Click);
            // 
            // FriendButton
            // 
            this.FriendButton.AccessibleDescription = "FriendsForm";
            this.FriendButton.BackColor = System.Drawing.Color.White;
            this.FriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FriendButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FriendButton.Image = ((System.Drawing.Image)(resources.GetObject("FriendButton.Image")));
            this.FriendButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FriendButton.Location = new System.Drawing.Point(-1, 109);
            this.FriendButton.Name = "FriendButton";
            this.FriendButton.Size = new System.Drawing.Size(181, 56);
            this.FriendButton.TabIndex = 3;
            this.FriendButton.Tag = "";
            this.FriendButton.Text = "Друзья   ";
            this.FriendButton.UseVisualStyleBackColor = false;
            this.FriendButton.Click += new System.EventHandler(this.PageButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.AccessibleDescription = "HomeForm";
            this.HomeButton.BackColor = System.Drawing.Color.White;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.Location = new System.Drawing.Point(-1, -1);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(181, 56);
            this.HomeButton.TabIndex = 2;
            this.HomeButton.Tag = "";
            this.HomeButton.Text = "Моя страница";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.PageButton_Click);
            // 
            // MainPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 580);
            this.Controls.Add(this.PagePanel);
            this.Controls.Add(this.MenuPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1017, 619);
            this.Name = "MainPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copycat";
            this.SizeChanged += new System.EventHandler(this.MainPageForm_SizeChanged);
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button PeopleButton;
        private System.Windows.Forms.Button FollowerButton;
        private System.Windows.Forms.Button FriendButton;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.Button NewsButton;
        private System.Windows.Forms.Button ExitButton;
    }
}