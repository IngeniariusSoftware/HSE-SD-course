
namespace ClientSide.UI.Home
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using ClientSide.Mapping;

    using Datagrams;

    using UserManagement.Users;

    public partial class HomeForm : Form
    {
        public HomeForm(IUser user)
        {
            InitializeComponent();
            ShowInformation(user);
        }

        public void ShowInformation(IUser user)
        {
            ChangeFriend.Visible = false;
            if (user != null)
            {
                if (user.Avatar != null)
                {
                    UserPictureBox.Image = user.Avatar;
                }
                else
                {
                    UserPictureBox.Image = UserPictureBox.BackgroundImage;
                }

                if (user.Login != Client.Instance.User.Login)
                {
                    Datagram data = Client.Instance.GetAnswer(
                        new Datagram(
                            Client.Instance.User.Login,
                            Client.Instance.Token,
                            "get",
                            "friends",
                            Client.Instance.User.Login));

                    if (data?.Action == "success")
                    {
                        try
                        {
                            var friends = (List<PersonView>)data.Data;
                            if (friends.FirstOrDefault(x => x.Login == user.Login) != null)
                            {
                                ChangeFriend.Text = "Удалить из друзей";
                            }
                            else
                            {
                                ChangeFriend.Text = "Добавить в друзья";
                            }

                            ChangeFriend.Visible = true;
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }

                ChangeFriend.AccessibleDescription = user.Login;
                FullNameTextValue.Text = user.FullName;
                BirthDateTextValue.Text = user.BirthDate.ToLongDateString();
                AgeTextValue.Text = user.Age.ToString();
                StatusTextValue.Text = Mapper.StatusToString(user.MaritalStatus);
                GennderTextValue.Text = Mapper.GenderToString(user.Gender);
                SchoolTextValue.Text = user.School;
                UniversityTextValue.Text = user.University;
            }
        }

        private void UserPictureBox_Click(object sender, EventArgs e)
        {
            if (!ChangeFriend.Visible)
            {
                var openImageDialog = new OpenFileDialog();
                openImageDialog.Filter = "Файлы изображений|*.jpg;*.bmp;*.png";
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fileStream = new FileStream(openImageDialog.FileName, FileMode.Open);
                        var image = Image.FromStream(fileStream).GetThumbnailImage(64, 64, (() => true), IntPtr.Zero);
                        fileStream.Close();
                        UserPictureBox.Image.Dispose();
                        UserPictureBox.Image = image;
                        IUser newUser = new User(
                            Client.Instance.User.Login,
                            Client.Instance.User.Name,
                            Client.Instance.User.Surname,
                            Client.Instance.User.Patronymic,
                            Client.Instance.User.BirthDate,
                            Client.Instance.User.Gender,
                            Client.Instance.User.MaritalStatus,
                            Client.Instance.User.University,
                            Client.Instance.User.School,
                            null,
                            (Bitmap)image);

                        var datagram = Client.Instance.GetAnswer(
                            new Datagram(Client.Instance.User.Login, Client.Instance.Token, "update", "user", newUser));

                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }
            }
        }

        private void ChangeFriend_Click(object sender, EventArgs e)
        {
            Datagram datagram = null;
            if (ChangeFriend.Text == "Удалить из друзей")
            {
                try
                {
                    datagram = Client.Instance.GetAnswer(
                        new Datagram(
                            Client.Instance.User.Login,
                            Client.Instance.Token,
                            "remove",
                            "friend",
                            ChangeFriend.AccessibleDescription));
                }
                catch (Exception)
                {
                    // ignored
                }

                if (datagram?.Action == "success")
                {
                    ChangeFriend.Text = "Добавить в друзья";
                }
            }
            else
            {
                try
                {
                    datagram = Client.Instance.GetAnswer(
                        new Datagram(
                            Client.Instance.User.Login,
                            Client.Instance.Token,
                            "add",
                            "friend",
                            ChangeFriend.AccessibleDescription));
                }
                catch (Exception)
                {
                    // ignored
                }

                if (datagram?.Action == "success")
                {
                    ChangeFriend.Text = "Удалить из друзей";
                }
            }
        }
    }
}