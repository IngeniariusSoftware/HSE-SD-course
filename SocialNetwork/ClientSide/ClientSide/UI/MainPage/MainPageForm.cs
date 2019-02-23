
namespace ClientSide.UI.MainPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using ClientSide.UI.Edit;
    using ClientSide.UI.Home;
    using ClientSide.UI.News;
    using ClientSide.UI.People;

    using Datagrams;

    using UserManagement.Journaling;
    using UserManagement.Users;

    public partial class MainPageForm : Form
    {
        private Form _currentPage;

        public MainPageForm()
        {
            InitializeComponent();
            GeneratePage("HomeForm", Client.Instance.User.Login);
        }

        public void GeneratePage(string formName, string login)
        {
            Form newPage = null;
            switch (formName)
            {
                case "HomeForm":
                    {
                        Datagram data = Client.Instance.GetAnswer(
                            new Datagram(Client.Instance.User.Login, Client.Instance.Token, "get", "user", login));

                        if (data?.Action == "success")
                        {
                            try
                            {
                                var user = (IUser)data.Data;
                                if (Client.Instance.User.Login == login)
                                {
                                    Client.Instance.User = user;
                                }

                                newPage = MdiChildren.FirstOrDefault(x => x is HomeForm);
                                if (newPage == null)
                                {
                                    newPage = new HomeForm(Client.Instance.User);
                                    newPage.MdiParent = this;
                                    newPage.VisibleChanged += (sender, args) =>
                                        {
                                            ((Control)newPage).Location = PagePanel.Location;
                                        };
                                }
                                else
                                {
                                    ((HomeForm)newPage).ShowInformation(user);
                                }
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        break;
                    }

                case "FriendsForm":
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
                                newPage = MdiChildren.FirstOrDefault(x => x is PeopleForm);
                                if (newPage == null)
                                {
                                    newPage = new PeopleForm { MdiParent = this };
                                    newPage.VisibleChanged += (sender, args) =>
                                        {
                                            ((Control)newPage).Location = PagePanel.Location;
                                        };
                                }

                                ((PeopleForm)newPage).PeopleLabel.Text = "Друзья";
                                ((PeopleForm)newPage).ShowPeople(friends);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        break;
                    }

                case "FollowersForm":
                    {
                        Datagram data = Client.Instance.GetAnswer(
                            new Datagram(
                                Client.Instance.User.Login,
                                Client.Instance.Token,
                                "get",
                                "followers",
                                Client.Instance.User.Login));

                        if (data?.Action == "success")
                        {
                            try
                            {
                                var followers = (List<PersonView>)data.Data;
                                newPage = MdiChildren.FirstOrDefault(x => x is PeopleForm);
                                if (newPage == null)
                                {
                                    newPage = new PeopleForm { MdiParent = this };
                                    newPage.VisibleChanged += (sender, args) =>
                                        {
                                            ((Control)newPage).Location = PagePanel.Location;
                                        };
                                }

                                ((PeopleForm)newPage).PeopleLabel.Text = "Подписчики";
                                ((PeopleForm)newPage).ShowPeople(followers);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        break;
                    }

                case "NewsForm":
                    {
                        Datagram data = Client.Instance.GetAnswer(
                            new Datagram(
                                Client.Instance.User.Login,
                                Client.Instance.Token,
                                "get",
                                "news",
                                Client.Instance.User.Login));

                        if (data?.Action == "success")
                        {
                            try
                            {
                                var news = (IJournal)data.Data;
                                newPage = MdiChildren.FirstOrDefault(x => x is NewsForm);
                                if (newPage == null)
                                {
                                    newPage = new NewsForm { MdiParent = this };
                                    newPage.VisibleChanged += (sender, args) =>
                                        {
                                            ((Control)newPage).Location = PagePanel.Location;
                                        };
                                }

                                ((NewsForm)newPage).ShowNews(news);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        break;
                    }

                case "PeopleForm":
                    {
                        Datagram data = Client.Instance.GetAnswer(
                            new Datagram(
                                Client.Instance.User.Login,
                                Client.Instance.Token,
                                "get",
                                "people",
                                Client.Instance.User.Login));

                        if (data?.Action == "success")
                        {
                            try
                            {
                                var people = (List<PersonView>)data.Data;
                                newPage = MdiChildren.FirstOrDefault(x => x is PeopleForm);
                                if (newPage == null)
                                {
                                    newPage = new PeopleForm { MdiParent = this };
                                    newPage.VisibleChanged += (sender, args) =>
                                        {
                                            ((Control)newPage).Location = PagePanel.Location;
                                        };
                                }

                                ((PeopleForm)newPage).PeopleLabel.Text = "Люди";
                                ((PeopleForm)newPage).ShowPeople(people);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        break;
                    }

                case "EditForm":
                    {
                        newPage = MdiChildren.FirstOrDefault(x => x is EditForm);
                        if (newPage == null)
                        {
                            newPage = new EditForm { MdiParent = this };
                            newPage.VisibleChanged += (sender, args) =>
                                {
                                    ((Control)newPage).Location = PagePanel.Location;
                                };
                        }

                        break;
                    }
            }

            if (newPage != null)
            {
                _currentPage?.Hide();
                _currentPage = newPage;
                newPage.Size = PagePanel.Size;
                newPage.Show();
            }
        }

        private void PageButton_Click(object sender, EventArgs e)
        {
            GeneratePage(((Control)sender).AccessibleDescription, Client.Instance.User.Login);
        }

        private void MainPageForm_SizeChanged(object sender, EventArgs e)
        {
            if (_currentPage != null)
            {
                _currentPage.Size = PagePanel.Size;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}