namespace Paint
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public partial class Picture : Form
    {
        public Picture()
        {
            InitializeComponent();
            pictureBox.BackgroundImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            DrawingSystem.EndDrawing(pictureBox.BackgroundImage);
            pictureBox.Refresh();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawingSystem.IsDrawing)
            {
                DrawingSystem.Drawing(e.Location);
                pictureBox.Invalidate();
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

    }
}
