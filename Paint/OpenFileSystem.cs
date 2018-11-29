namespace Paint
{
    using System.Drawing;
    using System.Windows.Forms;

    public static class OpenFileSystem
    {
        public static (string, string, Image) OpenImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Открытие изображения";
            dialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png";
            dialog.ShowDialog();
            if (dialog.FileName == "")
            {
                return (string.Empty, string.Empty, null);
            }
            else
            {
                return (dialog.FileName, dialog.SafeFileName, Image.FromFile(dialog.FileName));
            }
        }
    }
}