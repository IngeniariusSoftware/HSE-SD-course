namespace Paint
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Picture : Form
    {
        public Picture()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
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
            DrawingSystem.SetBackgroundColor(pictureBox.BackColor);
            DrawingSystem.StartDrawing(e.Location);
        }
    }
}
