﻿namespace Paint
{
    using System;
    using System.Drawing;
    using System.IO;
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
            (string, string, Image) result = (string.Empty, string.Empty, null);
            if (sender.ToString() == OpenFileMenuItem.Text)
            {
                result = OpenFileSystem.OpenImage();
                if (result.Item3 != null)
                {
                    PaintMenuStrip.Items.Add(_fileNameSystem.NewFile(result.Item2));
                }
            }
            else
            {
                PaintMenuStrip.Items.Add(_fileNameSystem.NewFile());
            }

            if (sender.ToString() != OpenFileMenuItem.Text
                || (sender.ToString() == OpenFileMenuItem.Text && result.Item3 != null))
            {
                PaintMenuStrip.Items[PaintMenuStrip.Items.Count - 1].Name = _fileNameSystem.CurrentFile;
                PaintMenuStrip.Items[PaintMenuStrip.Items.Count - 1].Click += FileMenuItem_Click;
                HighlightMenuItem(_fileNameSystem.LastFile, _fileNameSystem.CurrentFile);
                Picture picture = new Picture(result.Item3);
                picture.Text = _fileNameSystem.CurrentFile;
                picture.GotFocus += ChangePicture;
                picture.Closing += RemoveMenuItem;
                picture.MdiParent = this;
                picture.SavePath = result.Item1;
                picture.Show();
                if (picture.WindowState == FormWindowState.Maximized)
                {
                    PaintMenuStrip.Items[0].Image = Properties.Resources.CanvasIcon;
                }
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

                    case true when sender.ToString() == SepiaToolStripMenuItem.Text:
                        {
                            childPaintForm.ApplySepiaEffect();
                            break;
                        }

                    case true when sender.ToString() == NegativeToolStripMenuItem.Text:
                        {
                            childPaintForm.ApplyNegativeEffect();
                            break;
                        }

                    case true when sender.ToString() == JitterToolStripMenuItem.Text:
                        {
                            childPaintForm.ApplyJitterEffect();
                            break;
                        }

                    case true when sender.ToString() == WaweToolStripMenuItem.Text:
                        {
                            childPaintForm.ApplyWaterWaveEffect();
                            break;
                        }

                    case true when sender.ToString() == PixellateToolStripMenuItem.Text:
                        {
                            childPaintForm.ApplyConvolutionEffect();
                            break;
                        }
                }

                childPaintForm.IsChanged = true;
                childPaintForm.Refresh();
            }
        }

        private void FlipRotateButton_Click(object sender, EventArgs e)
        {
            Picture childPaintForm = ActiveMdiChild as Picture;
            Control button = (Control)sender;
            if (childPaintForm != null)
            {
                switch (true)
                {
                    case true when button.Name == ClockwiseRotateButton.Name:
                        {
                            childPaintForm.RotateClockwise();
                            break;
                        }
                    case true when button.Name == CounterClockwiseRotateButton.Name:
                        {
                            childPaintForm.RotateCounterClockwise();
                            break;
                        }

                    case true when button.Name == HorizontalFlipButton.Name:
                        {
                            childPaintForm.FlipHorizontal();
                            break;
                        }

                    case true when button.Name == VerticalFlipButton.Name:
                        {
                            childPaintForm.FlipVertical();
                            break;
                        }
                }

                childPaintForm.Refresh();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form mdiChild in MdiChildren)
            {
                mdiChild.Close();
            }

            Close();
        }

        public void SaveFileAs_Click(object sender, EventArgs e)
        {
            var picture = ActiveMdiChild as Picture;
            if (picture != null)
            {
                var dialog = new SaveFileDialog
                                 {
                                     Title = "Сохранение изображения",
                                     Filter =
                                         "Bitmap (*.bmp)|*.bmp|JP2EG (*.jpeg)|*.jpeg|PNG (*.png)|*.png",
                                     CheckPathExists = true
                                 };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picture.SavePath = Path.GetFullPath(dialog.FileName);
                    picture.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf("\\") + 2);
                    _fileNameSystem.RenameFile(picture.Text);
                    picture.Save();
                }
            }
        }

        public void SaveFileMenuItem_Click(object sender, EventArgs e)
        {
            var picture = ActiveMdiChild as Picture;
            if (picture != null)
            {
                if (picture.SavePath == string.Empty)
                {
                    var dialog = new SaveFileDialog
                                     {
                                         Title = "Сохранение изображения",
                                         Filter =
                                             "Bitmap (*.bmp)|*.bmp|JP2EG (*.jpeg)|*.jpeg|PNG (*.png)|*.png",
                                         CheckPathExists = true
                                     };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        picture.SavePath = Path.GetFullPath(dialog.FileName);
                        picture.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf("\\") + 2);
                        _fileNameSystem.RenameFile(picture.Text);
                        PaintMenuStrip.Items[PaintMenuStrip.Items.Count - 1].Text = picture.Text;
                        PaintMenuStrip.Items[PaintMenuStrip.Items.Count - 1].Name = picture.Text;
                        picture.Save();
                    }
                }
                else
                {
                    picture.Save();
                }
            }
        }
    }
}