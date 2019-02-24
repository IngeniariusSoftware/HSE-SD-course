
namespace ClientSide.UI.News
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using ClientSide.UI.MainPage;

    using Datagrams;

    using UserManagement.Journaling;

    public partial class NewsForm : Form
    {
        public NewsForm()
        {
            InitializeComponent();
        }

        public void ShowNews(IJournal journal)
        {
            NewsImageList.Images.Clear();
            NewsList.Items.Clear();

            for (int i = journal.News.Count - 1; i > -1; i--)
            {
                switch (true)
                {
                    case true when journal.News[i].Value is Bitmap image:
                        {
                            NewsImageList.Images.Add(image);
                            NewsList.Items.Add(
                                $"      {journal.News[i].FullName} {journal.News[i]?.Info?.ToLower()} {journal.News[i].CreatingTime}",
                                NewsImageList.Images.Count - 1);

                            break;
                        }

                    case true when journal.News[i].Value is string message:
                        {
                            NewsList.Items.Add(
                                $"      {journal.News[i].FullName} {journal.News[i]?.Info?.ToLower()} {message} {journal.News[i].CreatingTime}");

                            break;
                        }
                }
            }
        }

        private void NewsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    Datagram datagram = Client.Instance.GetAnswer(
                        new Datagram(
                            Client.Instance.User.Login,
                            Client.Instance.Token,
                            "add",
                            "message",
                            NewsTextBox.Text));
                    NewsTextBox.Text = string.Empty;
                    if (datagram?.Action == "success")
                    {
                        ((MainPageForm)MdiParent).GeneratePage("NewsForm", Client.Instance.User.Login);
                    }
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }

        private void NewsTextBox_Enter(object sender, EventArgs e)
        {
            var inputElement = (Control)sender;
            if (inputElement.ForeColor == Color.DarkGray)
            {
                inputElement.Text = string.Empty;
                inputElement.ForeColor = Color.Black;
            }
        }

        private void NewsTextBox_Leave(object sender, EventArgs e)
        {
            var inputElement = (Control)sender;
            if (string.IsNullOrWhiteSpace(inputElement.Text))
            {
                inputElement.ForeColor = Color.DarkGray;
                inputElement.Text = inputElement.AccessibleDescription;
            }
        }

        private void AddImageButtonLogo_Click(object sender, EventArgs e)
        {
            var openImageDialog = new OpenFileDialog();
            openImageDialog.Filter = "Файлы изображений|*.jpg;*.bmp;*.png";
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileStream = new FileStream(openImageDialog.FileName, FileMode.Open);
                    var image = Image.FromStream(fileStream).GetThumbnailImage(48, 48, (() => true), IntPtr.Zero);
                    fileStream.Close();
                    Datagram datagram = Client.Instance.GetAnswer(
                        new Datagram(Client.Instance.User.Login, Client.Instance.Token, "add", "image", image));
                    NewsTextBox.Text = string.Empty;
                    if (datagram?.Action == "success")
                    {
                        ((MainPageForm)MdiParent).GeneratePage("NewsForm", Client.Instance.User.Login);
                    }
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }
    }
}