namespace ClientSide.UI.People
{
    partial class PeopleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeopleForm));
            this.PeoplePanel = new System.Windows.Forms.Panel();
            this.PeopleSplitter = new System.Windows.Forms.Label();
            this.PeopleList = new System.Windows.Forms.ListView();
            this.ProfileImageList = new System.Windows.Forms.ImageList(this.components);
            this.PeopleLabel = new System.Windows.Forms.Label();
            this.PeoplePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PeoplePanel
            // 
            this.PeoplePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeoplePanel.BackColor = System.Drawing.Color.White;
            this.PeoplePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PeoplePanel.Controls.Add(this.PeopleLabel);
            this.PeoplePanel.Controls.Add(this.PeopleSplitter);
            this.PeoplePanel.Controls.Add(this.PeopleList);
            this.PeoplePanel.Location = new System.Drawing.Point(0, 0);
            this.PeoplePanel.Name = "PeoplePanel";
            this.PeoplePanel.Size = new System.Drawing.Size(787, 553);
            this.PeoplePanel.TabIndex = 2;
            // 
            // PeopleSplitter
            // 
            this.PeopleSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeopleSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PeopleSplitter.Location = new System.Drawing.Point(22, 42);
            this.PeopleSplitter.Name = "PeopleSplitter";
            this.PeopleSplitter.Size = new System.Drawing.Size(752, 1);
            this.PeopleSplitter.TabIndex = 47;
            // 
            // PeopleList
            // 
            this.PeopleList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PeopleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeopleList.AutoArrange = false;
            this.PeopleList.BackColor = System.Drawing.SystemColors.Window;
            this.PeopleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PeopleList.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeopleList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PeopleList.HideSelection = false;
            this.PeopleList.LabelWrap = false;
            this.PeopleList.Location = new System.Drawing.Point(57, 75);
            this.PeopleList.MultiSelect = false;
            this.PeopleList.Name = "PeopleList";
            this.PeopleList.Size = new System.Drawing.Size(667, 477);
            this.PeopleList.SmallImageList = this.ProfileImageList;
            this.PeopleList.TabIndex = 2;
            this.PeopleList.UseCompatibleStateImageBehavior = false;
            this.PeopleList.View = System.Windows.Forms.View.SmallIcon;
            this.PeopleList.ItemActivate += new System.EventHandler(this.PeopleList_ItemActivate);
            // 
            // ProfileImageList
            // 
            this.ProfileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ProfileImageList.ImageStream")));
            this.ProfileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ProfileImageList.Images.SetKeyName(0, "ProfileIcon.png");
            // 
            // PeopleLabel
            // 
            this.PeopleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeopleLabel.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeopleLabel.Location = new System.Drawing.Point(224, 5);
            this.PeopleLabel.Name = "PeopleLabel";
            this.PeopleLabel.Size = new System.Drawing.Size(300, 33);
            this.PeopleLabel.TabIndex = 48;
            this.PeopleLabel.Text = "Люди";
            this.PeopleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 553);
            this.Controls.Add(this.PeoplePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PeopleForm";
            this.Text = "PeopleForm";
            this.PeoplePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PeoplePanel;
        private System.Windows.Forms.ListView PeopleList;
        private System.Windows.Forms.ImageList ProfileImageList;
        private System.Windows.Forms.Label PeopleSplitter;
        public System.Windows.Forms.Label PeopleLabel;
    }
}