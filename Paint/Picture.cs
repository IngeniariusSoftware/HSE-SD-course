namespace Paint
{
    using System.Drawing;
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
            pictureBox.Image = DrawingSystem.Buffer;
            DrawingSystem.SetPaintRegionSize(pictureBox.Size);
            DrawingSystem.SetBackgroundColor(pictureBox.BackColor);
            DrawingSystem.StartDrawing(e.Location);
        }

        public void EffectBlur_Click()
        {
            pictureBox.BackgroundImage = EffectsSystem.BlurEffect.Apply((Bitmap)pictureBox.BackgroundImage);
        }

        public void EffectSharpness_Click()
        {
            pictureBox.BackgroundImage = EffectsSystem.SharpenEffect.Apply((Bitmap)pictureBox.BackgroundImage);
        }

        public void EffectMirrorX_Click()
        {
            pictureBox.BackgroundImage = EffectsSystem.MirrorXEffect.Apply((Bitmap)pictureBox.BackgroundImage);
        }

        public void EffectMirrorY_Click()
        {
            pictureBox.BackgroundImage = EffectsSystem.MirrorYEffect.Apply((Bitmap)pictureBox.BackgroundImage);
        }
    }
}
