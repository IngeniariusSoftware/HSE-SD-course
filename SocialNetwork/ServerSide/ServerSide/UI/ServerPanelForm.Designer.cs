namespace ServerSide.UI
{
    partial class ServerPanelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerPanelForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.MenuTab = new System.Windows.Forms.TabPage();
            this.CommandLog = new System.Windows.Forms.TextBox();
            this.CommandWriter = new System.Windows.Forms.TextBox();
            this.LogLogo = new System.Windows.Forms.PictureBox();
            this.LabelIlogState = new System.Windows.Forms.Label();
            this.MessageHandlerLogo = new System.Windows.Forms.PictureBox();
            this.LabelMessageHandlerState = new System.Windows.Forms.Label();
            this.MessageSenderLogo = new System.Windows.Forms.PictureBox();
            this.LabelMessageSenderState = new System.Windows.Forms.Label();
            this.ConnectionLogo = new System.Windows.Forms.PictureBox();
            this.LabelConnectionReceiverState = new System.Windows.Forms.Label();
            this.ServerLogo = new System.Windows.Forms.PictureBox();
            this.LabelServerState = new System.Windows.Forms.Label();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.LogWriter = new System.Windows.Forms.TextBox();
            this.ConsoleLog = new System.Windows.Forms.RichTextBox();
            this.MainTab.SuspendLayout();
            this.MenuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageHandlerLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageSenderLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerLogo)).BeginInit();
            this.LogTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.MenuTab);
            this.MainTab.Controls.Add(this.LogTab);
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.HotTrack = true;
            this.MainTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.Multiline = true;
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Drawing.Point(30, 4);
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1246, 565);
            this.MainTab.TabIndex = 0;
            // 
            // MenuTab
            // 
            this.MenuTab.BackColor = System.Drawing.Color.LightGray;
            this.MenuTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MenuTab.Controls.Add(this.CommandLog);
            this.MenuTab.Controls.Add(this.CommandWriter);
            this.MenuTab.Controls.Add(this.LogLogo);
            this.MenuTab.Controls.Add(this.LabelIlogState);
            this.MenuTab.Controls.Add(this.MessageHandlerLogo);
            this.MenuTab.Controls.Add(this.LabelMessageHandlerState);
            this.MenuTab.Controls.Add(this.MessageSenderLogo);
            this.MenuTab.Controls.Add(this.LabelMessageSenderState);
            this.MenuTab.Controls.Add(this.ConnectionLogo);
            this.MenuTab.Controls.Add(this.LabelConnectionReceiverState);
            this.MenuTab.Controls.Add(this.ServerLogo);
            this.MenuTab.Controls.Add(this.LabelServerState);
            this.MenuTab.Location = new System.Drawing.Point(4, 24);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Padding = new System.Windows.Forms.Padding(20);
            this.MenuTab.Size = new System.Drawing.Size(1238, 537);
            this.MenuTab.TabIndex = 0;
            this.MenuTab.Text = "Меню";
            // 
            // CommandLog
            // 
            this.CommandLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CommandLog.BackColor = System.Drawing.SystemColors.Desktop;
            this.CommandLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CommandLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandLog.Location = new System.Drawing.Point(607, 19);
            this.CommandLog.MaxLength = 0;
            this.CommandLog.Multiline = true;
            this.CommandLog.Name = "CommandLog";
            this.CommandLog.ReadOnly = true;
            this.CommandLog.Size = new System.Drawing.Size(610, 330);
            this.CommandLog.TabIndex = 12;
            this.CommandLog.Text = " Командная строка. Введите команду для управления сервером...";
            // 
            // CommandWriter
            // 
            this.CommandWriter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CommandWriter.AutoCompleteCustomSource.AddRange(new string[] {
            "start"});
            this.CommandWriter.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CommandWriter.Location = new System.Drawing.Point(607, 350);
            this.CommandWriter.MaxLength = 128;
            this.CommandWriter.Name = "CommandWriter";
            this.CommandWriter.Size = new System.Drawing.Size(610, 26);
            this.CommandWriter.TabIndex = 11;
            this.CommandWriter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandWriter_KeyPress);
            // 
            // LogLogo
            // 
            this.LogLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogLogo.Image = global::ServerSide.Properties.Resources.LogOffIcon;
            this.LogLogo.InitialImage = null;
            this.LogLogo.Location = new System.Drawing.Point(82, 216);
            this.LogLogo.Name = "LogLogo";
            this.LogLogo.Size = new System.Drawing.Size(32, 32);
            this.LogLogo.TabIndex = 9;
            this.LogLogo.TabStop = false;
            // 
            // LabelIlogState
            // 
            this.LabelIlogState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelIlogState.AutoSize = true;
            this.LabelIlogState.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelIlogState.Location = new System.Drawing.Point(10, 219);
            this.LabelIlogState.Name = "LabelIlogState";
            this.LabelIlogState.Size = new System.Drawing.Size(64, 28);
            this.LabelIlogState.TabIndex = 8;
            this.LabelIlogState.Text = "Лог:";
            // 
            // MessageHandlerLogo
            // 
            this.MessageHandlerLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MessageHandlerLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessageHandlerLogo.Image = global::ServerSide.Properties.Resources.DatabaseOffIcon;
            this.MessageHandlerLogo.InitialImage = null;
            this.MessageHandlerLogo.Location = new System.Drawing.Point(349, 122);
            this.MessageHandlerLogo.Name = "MessageHandlerLogo";
            this.MessageHandlerLogo.Size = new System.Drawing.Size(32, 32);
            this.MessageHandlerLogo.TabIndex = 7;
            this.MessageHandlerLogo.TabStop = false;
            // 
            // LabelMessageHandlerState
            // 
            this.LabelMessageHandlerState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelMessageHandlerState.AutoSize = true;
            this.LabelMessageHandlerState.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMessageHandlerState.Location = new System.Drawing.Point(10, 125);
            this.LabelMessageHandlerState.Name = "LabelMessageHandlerState";
            this.LabelMessageHandlerState.Size = new System.Drawing.Size(350, 28);
            this.LabelMessageHandlerState.TabIndex = 6;
            this.LabelMessageHandlerState.Text = "Обработка сообщений и БД: ";
            // 
            // MessageSenderLogo
            // 
            this.MessageSenderLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MessageSenderLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessageSenderLogo.Image = global::ServerSide.Properties.Resources.HandlerOffIcon;
            this.MessageSenderLogo.InitialImage = null;
            this.MessageSenderLogo.Location = new System.Drawing.Point(275, 169);
            this.MessageSenderLogo.Name = "MessageSenderLogo";
            this.MessageSenderLogo.Size = new System.Drawing.Size(32, 32);
            this.MessageSenderLogo.TabIndex = 5;
            this.MessageSenderLogo.TabStop = false;
            // 
            // LabelMessageSenderState
            // 
            this.LabelMessageSenderState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelMessageSenderState.AutoSize = true;
            this.LabelMessageSenderState.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMessageSenderState.Location = new System.Drawing.Point(10, 171);
            this.LabelMessageSenderState.Name = "LabelMessageSenderState";
            this.LabelMessageSenderState.Size = new System.Drawing.Size(259, 28);
            this.LabelMessageSenderState.TabIndex = 4;
            this.LabelMessageSenderState.Text = "Отправка сообщений:";
            // 
            // ConnectionLogo
            // 
            this.ConnectionLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectionLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectionLogo.Image = global::ServerSide.Properties.Resources.ConnectionOffIcon;
            this.ConnectionLogo.InitialImage = null;
            this.ConnectionLogo.Location = new System.Drawing.Point(184, 74);
            this.ConnectionLogo.Name = "ConnectionLogo";
            this.ConnectionLogo.Size = new System.Drawing.Size(32, 32);
            this.ConnectionLogo.TabIndex = 3;
            this.ConnectionLogo.TabStop = false;
            // 
            // LabelConnectionReceiverState
            // 
            this.LabelConnectionReceiverState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelConnectionReceiverState.AutoSize = true;
            this.LabelConnectionReceiverState.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelConnectionReceiverState.Location = new System.Drawing.Point(10, 74);
            this.LabelConnectionReceiverState.Name = "LabelConnectionReceiverState";
            this.LabelConnectionReceiverState.Size = new System.Drawing.Size(168, 28);
            this.LabelConnectionReceiverState.TabIndex = 2;
            this.LabelConnectionReceiverState.Text = "Подключения:";
            // 
            // ServerLogo
            // 
            this.ServerLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ServerLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ServerLogo.Image = global::ServerSide.Properties.Resources.ServerOffIcon;
            this.ServerLogo.InitialImage = null;
            this.ServerLogo.Location = new System.Drawing.Point(119, 22);
            this.ServerLogo.Name = "ServerLogo";
            this.ServerLogo.Size = new System.Drawing.Size(32, 32);
            this.ServerLogo.TabIndex = 1;
            this.ServerLogo.TabStop = false;
            // 
            // LabelServerState
            // 
            this.LabelServerState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelServerState.AutoSize = true;
            this.LabelServerState.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelServerState.Location = new System.Drawing.Point(10, 25);
            this.LabelServerState.Name = "LabelServerState";
            this.LabelServerState.Size = new System.Drawing.Size(103, 28);
            this.LabelServerState.TabIndex = 0;
            this.LabelServerState.Text = "Сервер:";
            // 
            // LogTab
            // 
            this.LogTab.BackColor = System.Drawing.Color.Transparent;
            this.LogTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogTab.Controls.Add(this.LogWriter);
            this.LogTab.Controls.Add(this.ConsoleLog);
            this.LogTab.Location = new System.Drawing.Point(4, 24);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(1238, 537);
            this.LogTab.TabIndex = 1;
            this.LogTab.Text = "Лог";
            // 
            // LogWriter
            // 
            this.LogWriter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogWriter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogWriter.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogWriter.Location = new System.Drawing.Point(2, 513);
            this.LogWriter.MaxLength = 256;
            this.LogWriter.Name = "LogWriter";
            this.LogWriter.Size = new System.Drawing.Size(1230, 26);
            this.LogWriter.TabIndex = 1;
            this.LogWriter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogWriter_KeyPress);
            // 
            // ConsoleLog
            // 
            this.ConsoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleLog.BackColor = System.Drawing.SystemColors.Desktop;
            this.ConsoleLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleLog.ForeColor = System.Drawing.Color.LightGray;
            this.ConsoleLog.Location = new System.Drawing.Point(0, 0);
            this.ConsoleLog.Name = "ConsoleLog";
            this.ConsoleLog.ReadOnly = true;
            this.ConsoleLog.Size = new System.Drawing.Size(1233, 512);
            this.ConsoleLog.TabIndex = 0;
            this.ConsoleLog.Text = "";
            // 
            // ServerPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1246, 565);
            this.Controls.Add(this.MainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1262, 604);
            this.Name = "ServerPanelForm";
            this.Text = "Сервер";
            this.MainTab.ResumeLayout(false);
            this.MenuTab.ResumeLayout(false);
            this.MenuTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageHandlerLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageSenderLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerLogo)).EndInit();
            this.LogTab.ResumeLayout(false);
            this.LogTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage MenuTab;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.TextBox LogWriter;
        private System.Windows.Forms.Label LabelServerState;
        private System.Windows.Forms.Label LabelIlogState;
        private System.Windows.Forms.Label LabelMessageHandlerState;
        private System.Windows.Forms.Label LabelMessageSenderState;
        private System.Windows.Forms.Label LabelConnectionReceiverState;
        private System.Windows.Forms.TextBox CommandWriter;
        private System.Windows.Forms.TextBox CommandLog;
        public System.Windows.Forms.PictureBox ServerLogo;
        public System.Windows.Forms.PictureBox LogLogo;
        public System.Windows.Forms.PictureBox MessageHandlerLogo;
        public System.Windows.Forms.PictureBox MessageSenderLogo;
        public System.Windows.Forms.PictureBox ConnectionLogo;
        public System.Windows.Forms.RichTextBox ConsoleLog;
    }
}

