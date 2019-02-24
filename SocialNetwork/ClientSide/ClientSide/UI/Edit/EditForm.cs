
namespace ClientSide.UI.Edit
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using ClientSide.Mapping;
    using ClientSide.UI.MainPage;

    using Datagrams;

    using UserManagement.Users;

    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();

            NameTextBox.Text = Client.Instance.User.Name;
            SurnameTextBox.Text = Client.Instance.User.Surname;
            PatronymicTextBox.Text = Client.Instance.User.Patronymic;
            BirthDayPicker.Value = Client.Instance.User.BirthDate;
            GenderComboBox.Text = Mapper.GenderToString(Client.Instance.User.Gender);
            StatusComboBox.Text = Mapper.StatusToString(Client.Instance.User.MaritalStatus);
            SchoolTextBox.Text = Client.Instance.User.School;
            UniversityTextBox.Text = Client.Instance.User.University;


            SchoolTextBox.TextChanged += InputEductaion_TextChanged;
            UniversityTextBox.TextChanged += InputEductaion_TextChanged;
            NameTextBox.TextChanged += InputFullName_TextChanged;
            SurnameTextBox.TextChanged += InputFullName_TextChanged;
            PatronymicTextBox.TextChanged += InputFullName_TextChanged;
            BirthDayPicker.MaxDate = DateTime.Now.AddYears(-14);
        }

        private void InputElement_FocusEntered(object sender, EventArgs e)
        {
            var inputElement = (Control)sender;
            MonkeyLogo.Location = inputElement.Location - new Size(0, MonkeyLogo.Size.Height / 2 + 4);
            if (inputElement.ForeColor == Color.DarkGray)
            {
                inputElement.Text = string.Empty;
                inputElement.ForeColor = Color.Black;
            }
        }

        private void InputElement_FocusLeaved(object sender, EventArgs e)
        {
            var inputElement = (Control)sender;
            if (string.IsNullOrWhiteSpace(inputElement.Text))
            {
                inputElement.ForeColor = Color.DarkGray;
                inputElement.Text = inputElement.AccessibleName;
            }
        }

        private void InputFullName_TextChanged(object sender, EventArgs e)
        {
            var educationRegex = new Regex("[^A-Za-zА-Яа-я ]");
            var inputElement = (Control)sender;
            inputElement.Text = educationRegex.Replace(inputElement.Text, string.Empty);
        }

        private void InputComboBox_FocusLeaved(object sender, EventArgs e)
        {
            var inputComboBox = (ComboBox)sender;
            if (!inputComboBox.Items.Contains(inputComboBox.Text))
            {
                inputComboBox.Text = string.Empty;
                inputComboBox.ForeColor = Color.DarkGray;
                inputComboBox.Text = inputComboBox.AccessibleName;
            }
        }

        private void InputEductaion_TextChanged(object sender, EventArgs e)
        {
            var educationRegex = new Regex("[^A-Za-zА-Яа-я0-9 ]");
            var inputElement = (Control)sender;
            inputElement.Text = educationRegex.Replace(inputElement.Text, string.Empty);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            Owner.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            IUser newUser = new User(
                Client.Instance.User.Login,
                NameTextBox.Text,
                SurnameTextBox.Text,
                PatronymicTextBox.Text,
                BirthDayPicker.Value,
                Mapper.StringToGender(GenderComboBox.Text),
                Mapper.StringToStatus(StatusComboBox.Text),
                UniversityTextBox.Text,
                SchoolTextBox.Text);
            Datagram datagram = Client.Instance.GetAnswer(
                new Datagram(Client.Instance.User.Login, Client.Instance.Token, "update", "user", newUser));
            if (datagram?.Action == "success")
            {
                Client.Instance.User = newUser;
                ((MainPageForm)MdiParent).GeneratePage("HomeForm", Client.Instance.User.Login);
            }
        }
    }
}