
namespace ClientSide.UI.People
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using ClientSide.Properties;
    using ClientSide.UI.MainPage;

    using UserManagement.Users;

    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
        }

        public void ShowPeople(List<PersonView> users)
        {
            if (users != null)
            {
                ProfileImageList.Images.Clear();
                ProfileImageList.Images.Add(Resources.ProfileIcon);
                PeopleList.Items.Clear();
                foreach (PersonView user in users)
                {
                    if (user.Avatar != null)
                    {
                        ProfileImageList.Images.Add(user.Avatar);
                    }

                    PeopleList.Items.Add(user.FullName, user.Avatar != null ? ProfileImageList.Images.Count - 1 : 0);
                    PeopleList.Items[PeopleList.Items.Count - 1].Tag = user.Login;
                }
            }
        }

        private void PeopleList_ItemActivate(object sender, EventArgs e)
        {
            ((MainPageForm)MdiParent).GeneratePage("HomeForm", (string)((ListView)sender).FocusedItem.Tag);
        }
    }
}