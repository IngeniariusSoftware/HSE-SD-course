namespace Paint
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private FileNameSystem _fileNameSystem;

        private ColorDialog _colorDialog;

        public MainForm()
        {
            InitializeComponent();
            _fileNameSystem = new FileNameSystem();
            PaintMenuStrip.Items.Add(new ToolStripSeparator());
        }

        private void HighlightMenuItem(string lastItem, string currentItem)
        {
            if (PaintMenuStrip.Items.ContainsKey(lastItem))
            {
                PaintMenuStrip.Items[lastItem].BackColor = Color.Transparent;
            }

            if (PaintMenuStrip.Items.ContainsKey(currentItem))
            {
                PaintMenuStrip.Items[currentItem].BackColor = Color.PowderBlue;
            }
        }

        private void NewFileMenuItem_Click(object sender, EventArgs e)
        {
            PaintMenuStrip.Items.Add(_fileNameSystem.NewFile());
            PaintMenuStrip.Items[PaintMenuStrip.Items.Count - 1].Name = _fileNameSystem.CurrentFile;
            PaintMenuStrip.Items[PaintMenuStrip.Items.Count - 1].Click += FileMenuItem_Click;
            HighlightMenuItem(_fileNameSystem.LastFile, _fileNameSystem.CurrentFile);
            Picture picture = new Picture();
            picture.Text = _fileNameSystem.CurrentFile;
            picture.GotFocus += ChangePicture;
            picture.Closing += RemoveMenuItem;
            picture.MdiParent = this;
            picture.Show();
            if (picture.WindowState == FormWindowState.Maximized)
            {
                PaintMenuStrip.Items[0].Image = Properties.Resources.CanvasIcon;
            }
        }

        private void FileMenuItem_Click(object sender, EventArgs e)
        {
            _fileNameSystem.ChangeFile(sender.ToString());
            HighlightMenuItem(_fileNameSystem.LastFile, _fileNameSystem.CurrentFile);
            if (_fileNameSystem.GetIndexFile(sender.ToString()) != -1)
            {
                MdiChildren[_fileNameSystem.GetIndexFile(sender.ToString())].Activate();
            }
        }

        private void RemoveMenuItem(object sender, EventArgs e)
        {
            Picture picture = (Picture)sender;
            _fileNameSystem.CloseFile(picture.Text);
            PaintMenuStrip.Items.RemoveByKey(picture.Text);
        }

        private void ChangePicture(object sender, EventArgs e)
        {
            _fileNameSystem.ChangeFile(((Picture)sender).Text);
            HighlightMenuItem(_fileNameSystem.LastFile, _fileNameSystem.CurrentFile);
        }

        private void ChangeWindowPosition_Click(object sender, EventArgs e)
        {
            switch (true)
            {
                case true when sender.ToString() == CascadeWindowMenuItem.Text:
                    {
                        LayoutMdi(MdiLayout.Cascade);
                        break;
                    }

                case true when sender.ToString() == LeftWindowMenuItem.Text:
                    {
                        LayoutMdi(MdiLayout.TileVertical);
                        break;
                    }

                case true when sender.ToString() == DropWindowMenuItem.Text:
                    {
                        LayoutMdi(MdiLayout.TileHorizontal);
                        break;
                    }

                case true when sender.ToString() == OrderWindowMenuItem.Text:
                    {
                        LayoutMdi(MdiLayout.ArrangeIcons);
                        break;
                    }
            }
        }

        private void Tool_Click(object sender, EventArgs e)
        {
            DrawingSystem.ChangeTool(((Button)sender).Name);
        }

        private void TrackBarSize_ValueChanged(object sender, EventArgs e)
        {
            DrawingSystem.ChangePenSize(((TrackBar)sender).Value);
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            _colorDialog = new ColorDialog();
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                ButtonColor.BackColor = _colorDialog.Color;
                DrawingSystem.ChangePenColor(_colorDialog.Color);
            }
        }

        private void EffectMenuItem_Click(object sender, EventArgs e)
        {
             Picture childPaintForm = ActiveMdiChild as Picture;
            if (childPaintForm != null)
            {
                switch (true)
                {
                    case true when sender.ToString() == BlurEffectMenuItem.Text:
                        {
                            childPaintForm.ApplyGaussianBlurEffect();
                            break;
                        }
                    case true when sender.ToString() == SharpnessEffectMenuItem.Text:
                        {
                            childPaintForm.ApplyGaussianSharpenEffect();
                            break;
                        }

                    case true when sender.ToString() == MirrorXEffectMenuItem.Text:
                        {
                            childPaintForm.ApplyMirrorXEffect();
                            break;
                        }

                    case true when sender.ToString() == MirrorYEffectMenuItem.Text:
                        {
                            childPaintForm.ApplyMirrorYEffect();
                            break;
                        }
                }

                childPaintForm.Refresh();
            }
        }
    }
}
