namespace Paint
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PaintPanel = new System.Windows.Forms.Panel();
            this.LabelColor = new System.Windows.Forms.Label();
            this.LabelSize = new System.Windows.Forms.Label();
            this.TrackBarSize = new System.Windows.Forms.TrackBar();
            this.ButtonColor = new System.Windows.Forms.Button();
            this.SplitterColor = new System.Windows.Forms.Splitter();
            this.SplitterSize = new System.Windows.Forms.Splitter();
            this.LabelFigures = new System.Windows.Forms.Label();
            this.Star = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.SplitterFigures = new System.Windows.Forms.Splitter();
            this.LoupeMinus = new System.Windows.Forms.Button();
            this.LoupePlus = new System.Windows.Forms.Button();
            this.Eraser = new System.Windows.Forms.Button();
            this.LabelTools = new System.Windows.Forms.Label();
            this.Pen = new System.Windows.Forms.Button();
            this.SplitterTools = new System.Windows.Forms.Splitter();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintMenuStrip = new System.Windows.Forms.MenuStrip();
            this.WindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CascadeWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DropWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSize)).BeginInit();
            this.PaintMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaintPanel
            // 
            this.PaintPanel.BackColor = System.Drawing.SystemColors.Control;
            this.PaintPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaintPanel.Controls.Add(this.LabelColor);
            this.PaintPanel.Controls.Add(this.LabelSize);
            this.PaintPanel.Controls.Add(this.TrackBarSize);
            this.PaintPanel.Controls.Add(this.ButtonColor);
            this.PaintPanel.Controls.Add(this.SplitterColor);
            this.PaintPanel.Controls.Add(this.SplitterSize);
            this.PaintPanel.Controls.Add(this.LabelFigures);
            this.PaintPanel.Controls.Add(this.Star);
            this.PaintPanel.Controls.Add(this.Ellipse);
            this.PaintPanel.Controls.Add(this.Line);
            this.PaintPanel.Controls.Add(this.Rectangle);
            this.PaintPanel.Controls.Add(this.SplitterFigures);
            this.PaintPanel.Controls.Add(this.LoupeMinus);
            this.PaintPanel.Controls.Add(this.LoupePlus);
            this.PaintPanel.Controls.Add(this.Eraser);
            this.PaintPanel.Controls.Add(this.LabelTools);
            this.PaintPanel.Controls.Add(this.Pen);
            this.PaintPanel.Controls.Add(this.SplitterTools);
            this.PaintPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaintPanel.Location = new System.Drawing.Point(0, 23);
            this.PaintPanel.Name = "PaintPanel";
            this.PaintPanel.Size = new System.Drawing.Size(1359, 91);
            this.PaintPanel.TabIndex = 4;
            // 
            // LabelColor
            // 
            this.LabelColor.AutoSize = true;
            this.LabelColor.Location = new System.Drawing.Point(767, 64);
            this.LabelColor.Name = "LabelColor";
            this.LabelColor.Size = new System.Drawing.Size(32, 13);
            this.LabelColor.TabIndex = 18;
            this.LabelColor.Text = "Цвет";
            // 
            // LabelSize
            // 
            this.LabelSize.AutoSize = true;
            this.LabelSize.Location = new System.Drawing.Point(605, 63);
            this.LabelSize.Name = "LabelSize";
            this.LabelSize.Size = new System.Drawing.Size(53, 13);
            this.LabelSize.TabIndex = 19;
            this.LabelSize.Text = "Толщина";
            // 
            // TrackBarSize
            // 
            this.TrackBarSize.Location = new System.Drawing.Point(540, 15);
            this.TrackBarSize.Maximum = 15;
            this.TrackBarSize.Minimum = 1;
            this.TrackBarSize.Name = "TrackBarSize";
            this.TrackBarSize.Size = new System.Drawing.Size(180, 45);
            this.TrackBarSize.TabIndex = 18;
            this.TrackBarSize.Value = 1;
            this.TrackBarSize.ValueChanged += new System.EventHandler(this.TrackBarSize_ValueChanged);
            // 
            // ButtonColor
            // 
            this.ButtonColor.BackColor = System.Drawing.Color.Black;
            this.ButtonColor.Location = new System.Drawing.Point(763, 10);
            this.ButtonColor.Name = "ButtonColor";
            this.ButtonColor.Size = new System.Drawing.Size(40, 40);
            this.ButtonColor.TabIndex = 17;
            this.ButtonColor.UseVisualStyleBackColor = false;
            this.ButtonColor.Click += new System.EventHandler(this.ButtonColor_Click);
            // 
            // SplitterColor
            // 
            this.SplitterColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitterColor.Enabled = false;
            this.SplitterColor.Location = new System.Drawing.Point(740, 0);
            this.SplitterColor.Name = "SplitterColor";
            this.SplitterColor.Size = new System.Drawing.Size(80, 87);
            this.SplitterColor.TabIndex = 17;
            this.SplitterColor.TabStop = false;
            // 
            // SplitterSize
            // 
            this.SplitterSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitterSize.Enabled = false;
            this.SplitterSize.Location = new System.Drawing.Point(520, 0);
            this.SplitterSize.Name = "SplitterSize";
            this.SplitterSize.Size = new System.Drawing.Size(220, 87);
            this.SplitterSize.TabIndex = 16;
            this.SplitterSize.TabStop = false;
            // 
            // LabelFigures
            // 
            this.LabelFigures.AutoSize = true;
            this.LabelFigures.Location = new System.Drawing.Point(364, 64);
            this.LabelFigures.Name = "LabelFigures";
            this.LabelFigures.Size = new System.Drawing.Size(48, 13);
            this.LabelFigures.TabIndex = 13;
            this.LabelFigures.Text = "Фигуры";
            // 
            // Star
            // 
            this.Star.Image = global::Paint.Properties.Resources.StarIcon;
            this.Star.Location = new System.Drawing.Point(340, 10);
            this.Star.Name = "Star";
            this.Star.Size = new System.Drawing.Size(40, 40);
            this.Star.TabIndex = 15;
            this.Star.UseVisualStyleBackColor = true;
            this.Star.Click += new System.EventHandler(this.Tool_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.Image = global::Paint.Properties.Resources.EllipseIcon;
            this.Ellipse.Location = new System.Drawing.Point(400, 10);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(40, 40);
            this.Ellipse.TabIndex = 12;
            this.Ellipse.UseVisualStyleBackColor = true;
            this.Ellipse.Click += new System.EventHandler(this.Tool_Click);
            // 
            // Line
            // 
            this.Line.Image = global::Paint.Properties.Resources.DiagonalIcon;
            this.Line.Location = new System.Drawing.Point(280, 10);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(40, 40);
            this.Line.TabIndex = 14;
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Tool_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.Image = global::Paint.Properties.Resources.RectangleIcon;
            this.Rectangle.Location = new System.Drawing.Point(460, 10);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(40, 40);
            this.Rectangle.TabIndex = 11;
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Tool_Click);
            // 
            // SplitterFigures
            // 
            this.SplitterFigures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitterFigures.Enabled = false;
            this.SplitterFigures.Location = new System.Drawing.Point(260, 0);
            this.SplitterFigures.Name = "SplitterFigures";
            this.SplitterFigures.Size = new System.Drawing.Size(260, 87);
            this.SplitterFigures.TabIndex = 11;
            this.SplitterFigures.TabStop = false;
            // 
            // LoupeMinus
            // 
            this.LoupeMinus.Image = global::Paint.Properties.Resources.LoupeMinusIcon;
            this.LoupeMinus.Location = new System.Drawing.Point(197, 10);
            this.LoupeMinus.Name = "LoupeMinus";
            this.LoupeMinus.Size = new System.Drawing.Size(40, 40);
            this.LoupeMinus.TabIndex = 8;
            this.LoupeMinus.UseVisualStyleBackColor = true;
            this.LoupeMinus.Click += new System.EventHandler(this.Tool_Click);
            // 
            // LoupePlus
            // 
            this.LoupePlus.Image = global::Paint.Properties.Resources.LoupePlusIcon;
            this.LoupePlus.Location = new System.Drawing.Point(138, 10);
            this.LoupePlus.Name = "LoupePlus";
            this.LoupePlus.Size = new System.Drawing.Size(40, 40);
            this.LoupePlus.TabIndex = 9;
            this.LoupePlus.UseVisualStyleBackColor = true;
            this.LoupePlus.Click += new System.EventHandler(this.Tool_Click);
            // 
            // Eraser
            // 
            this.Eraser.Image = global::Paint.Properties.Resources.EraserIcon;
            this.Eraser.Location = new System.Drawing.Point(80, 10);
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(40, 40);
            this.Eraser.TabIndex = 8;
            this.Eraser.UseVisualStyleBackColor = true;
            this.Eraser.Click += new System.EventHandler(this.Tool_Click);
            // 
            // LabelTools
            // 
            this.LabelTools.AutoSize = true;
            this.LabelTools.Location = new System.Drawing.Point(89, 64);
            this.LabelTools.Name = "LabelTools";
            this.LabelTools.Size = new System.Drawing.Size(76, 13);
            this.LabelTools.TabIndex = 6;
            this.LabelTools.Text = "Инструменты";
            // 
            // Pen
            // 
            this.Pen.Image = global::Paint.Properties.Resources.PenIcon;
            this.Pen.Location = new System.Drawing.Point(20, 10);
            this.Pen.Name = "Pen";
            this.Pen.Size = new System.Drawing.Size(40, 40);
            this.Pen.TabIndex = 0;
            this.Pen.UseVisualStyleBackColor = true;
            this.Pen.Click += new System.EventHandler(this.Tool_Click);
            // 
            // SplitterTools
            // 
            this.SplitterTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitterTools.Enabled = false;
            this.SplitterTools.Location = new System.Drawing.Point(0, 0);
            this.SplitterTools.Name = "SplitterTools";
            this.SplitterTools.Size = new System.Drawing.Size(260, 87);
            this.SplitterTools.TabIndex = 9;
            this.SplitterTools.TabStop = false;
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileMenuItem,
            this.OpenFileMenuItem,
            this.SaveFileAsMenuItem,
            this.SaveFileMenuItem,
            this.toolStripSeparator1,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileMenuItem.Size = new System.Drawing.Size(48, 19);
            this.FileMenuItem.Text = "Файл";
            // 
            // NewFileMenuItem
            // 
            this.NewFileMenuItem.Name = "NewFileMenuItem";
            this.NewFileMenuItem.Size = new System.Drawing.Size(162, 22);
            this.NewFileMenuItem.Text = "Новый";
            this.NewFileMenuItem.Click += new System.EventHandler(this.NewFileMenuItem_Click);
            // 
            // OpenFileMenuItem
            // 
            this.OpenFileMenuItem.Name = "OpenFileMenuItem";
            this.OpenFileMenuItem.Size = new System.Drawing.Size(162, 22);
            this.OpenFileMenuItem.Text = "Открыть…";
            // 
            // SaveFileAsMenuItem
            // 
            this.SaveFileAsMenuItem.Name = "SaveFileAsMenuItem";
            this.SaveFileAsMenuItem.Size = new System.Drawing.Size(162, 22);
            this.SaveFileAsMenuItem.Text = "Сохранить как…";
            // 
            // SaveFileMenuItem
            // 
            this.SaveFileMenuItem.Name = "SaveFileMenuItem";
            this.SaveFileMenuItem.Size = new System.Drawing.Size(162, 22);
            this.SaveFileMenuItem.Text = "Сохранить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ExitMenuItem.Text = "Выход";
            // 
            // PictureMenuItem
            // 
            this.PictureMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PictureMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.эффектToolStripMenuItem});
            this.PictureMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PictureMenuItem.Name = "PictureMenuItem";
            this.PictureMenuItem.Size = new System.Drawing.Size(70, 19);
            this.PictureMenuItem.Text = "Эффекты";
            // 
            // эффектToolStripMenuItem
            // 
            this.эффектToolStripMenuItem.Name = "эффектToolStripMenuItem";
            this.эффектToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.эффектToolStripMenuItem.Text = "Эффект";
            // 
            // PaintMenuStrip
            // 
            this.PaintMenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PaintMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.PaintMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.PictureMenuItem,
            this.WindowMenuItem});
            this.PaintMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.PaintMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.PaintMenuStrip.Name = "PaintMenuStrip";
            this.PaintMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PaintMenuStrip.Size = new System.Drawing.Size(1359, 23);
            this.PaintMenuStrip.TabIndex = 1;
            this.PaintMenuStrip.Text = "Меню";
            // 
            // WindowMenuItem
            // 
            this.WindowMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WindowMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CascadeWindowMenuItem,
            this.LeftWindowMenuItem,
            this.DropWindowMenuItem,
            this.OrderWindowMenuItem});
            this.WindowMenuItem.Name = "WindowMenuItem";
            this.WindowMenuItem.Size = new System.Drawing.Size(48, 19);
            this.WindowMenuItem.Text = "Окно";
            // 
            // CascadeWindowMenuItem
            // 
            this.CascadeWindowMenuItem.Name = "CascadeWindowMenuItem";
            this.CascadeWindowMenuItem.Size = new System.Drawing.Size(187, 22);
            this.CascadeWindowMenuItem.Text = "Каскадом";
            this.CascadeWindowMenuItem.Click += new System.EventHandler(this.ChangeWindowPosition_Click);
            // 
            // LeftWindowMenuItem
            // 
            this.LeftWindowMenuItem.Name = "LeftWindowMenuItem";
            this.LeftWindowMenuItem.Size = new System.Drawing.Size(187, 22);
            this.LeftWindowMenuItem.Text = "Слева направо";
            this.LeftWindowMenuItem.Click += new System.EventHandler(this.ChangeWindowPosition_Click);
            // 
            // DropWindowMenuItem
            // 
            this.DropWindowMenuItem.Name = "DropWindowMenuItem";
            this.DropWindowMenuItem.Size = new System.Drawing.Size(187, 22);
            this.DropWindowMenuItem.Text = "Сверху вниз";
            this.DropWindowMenuItem.Click += new System.EventHandler(this.ChangeWindowPosition_Click);
            // 
            // OrderWindowMenuItem
            // 
            this.OrderWindowMenuItem.Name = "OrderWindowMenuItem";
            this.OrderWindowMenuItem.Size = new System.Drawing.Size(187, 22);
            this.OrderWindowMenuItem.Text = "Упорядочить значки";
            this.OrderWindowMenuItem.Click += new System.EventHandler(this.ChangeWindowPosition_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1359, 603);
            this.Controls.Add(this.PaintPanel);
            this.Controls.Add(this.PaintMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.PaintMenuStrip;
            this.Name = "MainForm";
            this.Text = "Paint";
            this.PaintPanel.ResumeLayout(false);
            this.PaintPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSize)).EndInit();
            this.PaintMenuStrip.ResumeLayout(false);
            this.PaintMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PaintPanel;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PictureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффектToolStripMenuItem;
        private System.Windows.Forms.MenuStrip PaintMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem WindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CascadeWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeftWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DropWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrderWindowMenuItem;
        private System.Windows.Forms.Button Eraser;
        private System.Windows.Forms.Button Pen;
        private System.Windows.Forms.Splitter SplitterTools;
        private System.Windows.Forms.Label LabelTools;
        private System.Windows.Forms.Button LoupeMinus;
        private System.Windows.Forms.Button LoupePlus;
        private System.Windows.Forms.Label LabelColor;
        private System.Windows.Forms.Button ButtonColor;
        private System.Windows.Forms.Splitter SplitterSize;
        private System.Windows.Forms.Label LabelFigures;
        private System.Windows.Forms.Button Star;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Splitter SplitterFigures;
        private System.Windows.Forms.Splitter SplitterColor;
        private System.Windows.Forms.Label LabelSize;
        private System.Windows.Forms.TrackBar TrackBarSize;
    }
}

