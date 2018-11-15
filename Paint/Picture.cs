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

        public void ApplyMirrorXEffect()
        {
            EffectsSystem.MirrorXEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplyMirrorYEffect()
        {
            EffectsSystem.MirrorYEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplySepiaEffect()
        {
            EffectsSystem.SepiaEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
        }

        public void ApplySimpleSkeletonizationEffect()
        {
            EffectsSystem.SimpleSkeletonizationEffect.ApplyInPlace((Bitmap)pictureBox.BackgroundImage);
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
