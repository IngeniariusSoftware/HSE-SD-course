namespace Paint
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class Picture : Form
    {
        public string SavePath = string.Empty;

        public bool IsChanged = false;

        public void Save()
        {
            pictureBox.BackgroundImage.Save(SavePath.Replace("png", "bmp"));
            IsChanged = false;
        }

        public Picture(Image image)
        {
            InitializeComponent();
            if (image != null)
            {
                pictureBox.Size = image.Size;
                pictureBox.BackgroundImage = image;
            }
            else
            {
                pictureBox.BackgroundImage = new Bitmap(pictureBox.Width, pictureBox.Height);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawingSystem.IsDrawing)
            {
                DrawingSystem.EndDrawing(pictureBox.BackgroundImage);
                pictureBox.Image = null;
                pictureBox.Refresh();
                IsChanged = true;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawingSystem.IsDrawing)
            {
                DrawingSystem.Drawing(e.Location);
                pictureBox.Refresh();
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            DrawingSystem.StartDrawing(e.Location, pictureBox);
        }

        public void ApplyGaussianBlurEffect()
        {
            EffectsSystem.GaussianBlurEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplyGaussianSharpenEffect()
        {
            EffectsSystem.GaussianSharpenEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplySepiaEffect()
        {
            EffectsSystem.SepiaEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplyNegativeEffect()
        {
            EffectsSystem.NegativeEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplyWaterWaveEffect()
        {
            pictureBox.Image = EffectsSystem.WaterWaveEffect.Apply((Bitmap)pictureBox.BackgroundImage);
            pictureBox.BackgroundImage.Dispose();
            pictureBox.BackgroundImage = (Image)pictureBox.Image.Clone();
            pictureBox.Image.Dispose();
            pictureBox.Image = null;
        }

        public void ApplyJitterEffect()
        {
            EffectsSystem.JitterEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplyConvolutionEffect()
        {
            EffectsSystem.ConvolutionEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void FlipVertical()
        {
            pictureBox?.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        public void FlipHorizontal()
        {
            pictureBox?.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        public void RotateClockwise()
        {
            if (pictureBox.BackgroundImage != null)
            {
                pictureBox.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Size = new Size(pictureBox.Size.Height, pictureBox.Size.Width);
                Size = new Size(Size.Height, Size.Width);
            }
        }

        public void RotateCounterClockwise()
        {
            if (pictureBox.BackgroundImage != null)
            {
                pictureBox.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox.Size = new Size(pictureBox.Size.Height, pictureBox.Size.Width);
                Size = new Size(Size.Height, Size.Width);
            }
        }

        private void Picture_ResizeEnd(object sender, System.EventArgs e)
        {
            DrawingSystem.Buffer?.Dispose();
            DrawingSystem.Buffer = (Bitmap)pictureBox.BackgroundImage.Clone();
            pictureBox.BackgroundImage.Dispose();
            pictureBox.BackgroundImage = new Bitmap(pictureBox.Width, pictureBox.Height);
            DrawingSystem.EndDrawing(pictureBox.BackgroundImage);
            IsChanged = true;
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (ResizingCursor.isResizeMode)
            {
                Cursor.Position = new Point(
                    Math.Max(
                        pictureBox.MinimumSize.Width + pictureBox.Location.X + ParentForm.Location.X + Location.X,
                        Math.Min(Cursor.Position.X, ParentForm.Location.X + Location.X + Size.Width - 6)),
                    Math.Max(
                        pictureBox.MinimumSize.Height + pictureBox.Location.Y + Location.Y + ParentForm.Location.Y
                        + ((MainForm)ParentForm).PaintPanel.Location.Y + 50
                        + ((MainForm)ParentForm).PaintPanel.Size.Height,
                        Math.Min(
                            Cursor.Position.Y,
                            ParentForm.Location.Y + Location.Y + Size.Height
                            + ((MainForm)ParentForm).PaintPanel.Location.Y + 50
                            + ((MainForm)ParentForm).PaintPanel.Size.Height)));
                switch (true)
                {
                    case true when Cursor.Current == Cursors.SizeWE:
                        {
                            pictureBox.Size = new Size(
                                Math.Max(pictureBox.MinimumSize.Width, e.X - pictureBox.Location.X),
                                pictureBox.Size.Height);
                            break;
                        }
                    case true when Cursor.Current == Cursors.SizeNS:
                        {
                            pictureBox.Size = new Size(
                                pictureBox.Size.Width,
                                Math.Max(pictureBox.MinimumSize.Height, e.Y - pictureBox.Location.Y));
                            break;
                        }
                    case true when Cursor.Current == Cursors.SizeNWSE:
                        {
                            pictureBox.Size = new Size(
                                Math.Max(pictureBox.MinimumSize.Width, e.X - pictureBox.Location.X),
                                Math.Max(pictureBox.MinimumSize.Height, e.Y - pictureBox.Location.Y));
                            break;
                        }
                }
            }
            else
            {
                ResizingCursor.CheckCursor(pictureBox.Location, pictureBox.Size, e.Location);
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (ResizingCursor.CheckCursor(pictureBox.Location, pictureBox.Size, e.Location))
            {
                ResizingCursor.isResizeMode = true;
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (ResizingCursor.isResizeMode)
            {
                ResizingCursor.isResizeMode = false;
                Picture_ResizeEnd(null, EventArgs.Empty);
            }
        }

        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsChanged)
            {
                var result = MessageBox.Show(
                    "Сохранить сделанные изменения?",
                    "Сохранить " + Text + "?",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ((MainForm)ParentForm).SaveFileMenuItem_Click(null, EventArgs.Empty);
                }
            }
        }
    }
}