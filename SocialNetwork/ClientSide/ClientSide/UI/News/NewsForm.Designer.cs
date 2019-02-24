namespace ClientSide.UI.News
{
    partial class NewsForm
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
            this.components = new System.ComponentModel.Container();
            this.NewsList = new System.Windows.Forms.ListView();
            this.NewsImageList = new System.Windows.Forms.ImageList(this.components);
            this.NewsTextBox = new System.Windows.Forms.TextBox();
            this.CameraPanel = new System.Windows.Forms.Panel();
            this.NewsPanel = new System.Windows.Forms.Panel();
            this.NewsSplitter = new System.Windows.Forms.Label();
            this.NewsLabel = new System.Windows.Forms.Label();
            this.AddImageButtonLogo = new System.Windows.Forms.PictureBox();
            this.NewsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddImageButtonLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // NewsList
            // 
            this.NewsList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.NewsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsList.AutoArrange = false;
            this.NewsList.BackColor = System.Drawing.SystemColors.Window;
            this.NewsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewsList.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.NewsList.HideSelection = false;
            this.NewsList.LabelWrap = false;
            this.NewsList.Location = new System.Drawing.Point(27, 46);
            this.NewsList.MultiSelect = false;
            this.NewsList.Name = "NewsList";
            this.NewsList.Size = new System.Drawing.Size(733, 463);
            this.NewsList.SmallImageList = this.NewsImageList;
            this.NewsList.TabIndex = 0;
            this.NewsList.UseCompatibleStateImageBehavior = false;
            this.NewsList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // NewsImageList
            // 
            this.NewsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.NewsImageList.ImageSize = new System.Drawing.Size(128, 128);
            this.NewsImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // NewsTextBox
            // 
            this.NewsTextBox.AccessibleDescription = " Что у вас нового?";
            this.NewsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsTextBox.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewsTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.NewsTextBox.Location = new System.Drawing.Point(0, 0);
            this.NewsTextBox.MaxLength = 1024;
            this.NewsTextBox.Name = "NewsTextBox";
            this.NewsTextBox.Size = new System.Drawing.Size(749, 33);
            this.NewsTextBox.TabIndex = 1;
            this.NewsTextBox.Text = " Что у вас нового?";
            this.NewsTextBox.Enter += new System.EventHandler(this.NewsTextBox_Enter);
            this.NewsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewsTextBox_KeyPress);
            this.NewsTextBox.Leave += new System.EventHandler(this.NewsTextBox_Leave);
            // 
            // CameraPanel
            // 
            this.CameraPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraPanel.BackColor = System.Drawing.Color.White;
            this.CameraPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraPanel.Location = new System.Drawing.Point(748, 0);
            this.CameraPanel.Name = "CameraPanel";
            this.CameraPanel.Size = new System.Drawing.Size(39, 33);
            this.CameraPanel.TabIndex = 3;
            // 
            // NewsPanel
            // 
            this.NewsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsPanel.BackColor = System.Drawing.Color.White;
            this.NewsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewsPanel.Controls.Add(this.NewsSplitter);
            this.NewsPanel.Controls.Add(this.NewsLabel);
            this.NewsPanel.Controls.Add(this.NewsList);
            this.NewsPanel.Location = new System.Drawing.Point(0, 42);
            this.NewsPanel.Name = "NewsPanel";
            this.NewsPanel.Size = new System.Drawing.Size(787, 510);
            this.NewsPanel.TabIndex = 4;
            // 
            // NewsSplitter
            // 
            this.NewsSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewsSplitter.Location = new System.Drawing.Point(20, 40);
            this.NewsSplitter.Name = "NewsSplitter";
            this.NewsSplitter.Size = new System.Drawing.Size(752, 1);
            this.NewsSplitter.TabIndex = 46;
            // 
            // NewsLabel
            // 
            this.NewsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsLabel.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewsLabel.Location = new System.Drawing.Point(307, 4);
            this.NewsLabel.Name = "NewsLabel";
            this.NewsLabel.Size = new System.Drawing.Size(132, 33);
            this.NewsLabel.TabIndex = 5;
            this.NewsLabel.Text = "Новости";
            this.NewsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddImageButtonLogo
            // 
            this.AddImageButtonLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddImageButtonLogo.BackColor = System.Drawing.Color.White;
            this.AddImageButtonLogo.Image = global::ClientSide.Properties.Resources.CameraIcon;
            this.AddImageButtonLogo.Location = new System.Drawing.Point(753, 3);
            this.AddImageButtonLogo.Name = "AddImageButtonLogo";
            this.AddImageButtonLogo.Size = new System.Drawing.Size(28, 28);
            this.AddImageButtonLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddImageButtonLogo.TabIndex = 2;
            this.AddImageButtonLogo.TabStop = false;
            this.AddImageButtonLogo.Click += new System.EventHandler(this.AddImageButtonLogo_Click);
            // 
            // NewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(787, 553);
            this.Controls.Add(this.AddImageButtonLogo);
            this.Controls.Add(this.NewsTextBox);
            this.Controls.Add(this.CameraPanel);
            this.Controls.Add(this.NewsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewsForm";
            this.Text = "NewsForm";
            this.NewsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddImageButtonLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView NewsList;
        private System.Windows.Forms.ImageList NewsImageList;
        private System.Windows.Forms.TextBox NewsTextBox;
        private System.Windows.Forms.PictureBox AddImageButtonLogo;
        private System.Windows.Forms.Panel CameraPanel;
        private System.Windows.Forms.Panel NewsPanel;
        private System.Windows.Forms.Label NewsLabel;
        private System.Windows.Forms.Label NewsSplitter;
    }
}