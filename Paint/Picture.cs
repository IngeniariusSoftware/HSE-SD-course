namespace Paint
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Picture : Form
    {
        public Picture()
        {
            InitializeComponent();
            pictureBox.BackgroundImage = new Bitmap(pictureBox.Width, pictureBox.Height);
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            DrawingSystem.EndDrawing(pictureBox.BackgroundImage);
            pictureBox.Image = null;
            pictureBox.Refresh();
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

        public void ApplyAdditiveNoiseEffect()
        {
            EffectsSystem.AdditiveNoiseEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
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
                Size = new Size(Size.Height, Size.Width);
            }
        }

        public void RotateCounterClockwise()
        {
            if (pictureBox.BackgroundImage != null)
            {
                pictureBox.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                Size = new Size(Size.Height, Size.Width);
            }
        }

        private void Picture_SizeChanged(object sender, System.EventArgs e)
        {
            DrawingSystem.Buffer?.Dispose();
            DrawingSystem.Buffer = (Bitmap)pictureBox.BackgroundImage.Clone();
            pictureBox.BackgroundImage.Dispose();
            pictureBox.BackgroundImage = new Bitmap(pictureBox.Width, pictureBox.Height);
            DrawingSystem.EndDrawing(pictureBox.BackgroundImage);
        }
    }
}
