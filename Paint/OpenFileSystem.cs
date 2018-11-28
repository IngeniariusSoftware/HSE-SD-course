namespace Paint
{
    using System.Drawing;
    using System.Windows.Forms;

    public static class OpenFileSystem
    {
        public static (string, Image) OpenImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Открытие изображения";
            dialog.Filter = "Изображение|*.png;*.gif;*.tif;*.jpg;*.bpm";
            dialog.ShowDialog();
            if (dialog.FileName == "")
            {
                return (string.Empty, null);
            }
            else
            {
                return (dialog.SafeFileName, Image.FromFile(dialog.FileName));
            }
        }
    }
}