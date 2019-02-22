
namespace ClientSide.UI.Registration
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using ClientSide.Mapping;

    using Datagrams;

    using UserManagement.Users;

    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            NameTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "Name");
            SurnameTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "Surname");
            PatronymicTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "Patronymic");
            SchoolTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "School");
            UnversityTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "University");
            BirthDayPicker.DataBindings.Add("Value", Client.Instance.LocalUser, "BirthDate");

            Subscribe();
        }

        private void Subscribe()
        {
            StatusComboBox.TextChanged += InputElement_TextChanged;
            StatusComboBox.Enter += InputElement_FocusEntered;
            StatusComboBox.Leave += InputComboBox_FocusLeaved;
            SchoolTextBox.TextChanged += InputElement_TextChanged;
            SchoolTextBox.Enter += InputElement_FocusEntered;
            SchoolTextBox.Leave += InputElement_FocusLeaved;
            NameTextBox.TextChanged += InputElement_TextChanged;
            NameTextBox.Enter += InputElement_FocusEntered;
            NameTextBox.Leave += InputElement_FocusLeaved;
            UnversityTextBox.TextChanged += InputElement_TextChanged;
            UnversityTextBox.Enter += InputElement_FocusEntered;
            UnversityTextBox.Leave += InputElement_FocusLeaved;
            GenderComboBox.TextChanged += InputElement_TextChanged;
            GenderComboBox.Enter += InputElement_FocusEntered;
            GenderComboBox.Leave += InputComboBox_FocusLeaved;
            SurnameTextBox.TextChanged += InputElement_TextChanged;
            SurnameTextBox.Enter += InputElement_FocusEntered;
            SurnameTextBox.Leave += InputElement_FocusLeaved;
            PatronymicTextBox.TextChanged += InputElement_TextChanged;
            PatronymicTextBox.Enter += InputElement_FocusEntered;
            PatronymicTextBox.Leave += InputElement_FocusLeaved;
        }

        private void InputElement_TextChanged(object sender, EventArgs e)
        {
            var inputElement = (Control)sender;

            if (string.IsNullOrWhiteSpace(inputElement.Text))
            {
                if (!string.IsNullOrWhiteSpace(inputElement.AccessibleDescription))
                {
                    RegistrationProgressBar.Visible = true;
                    RegistrationButton.Visible = false;
                    RegistrationProgressBar.Value = Math.Max(
                        RegistrationProgressBar.Value - 20,
                        RegistrationProgressBar.Minimum);
                    inputElement.AccessibleDescription = string.Empty;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(inputElement.AccessibleDescription)
                    && inputElement.ForeColor != Color.DarkGray)
                {
                    RegistrationProgressBar.Value = Math.Min(
                        RegistrationProgressBar.Value + 20,
                        RegistrationProgressBar.Maximum);
                    inputElement.AccessibleDescription = "ok";
                    if (RegistrationProgressBar.Value == RegistrationProgressBar.Maximum)
                    {
                        RegistrationProgressBar.Visible = false;
                        RegistrationButton.Visible = true;
                    }
                }
            }
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

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            Owner.Show();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Client.Instance.LocalUser.Gender = Mapper.StringToGender(GenderComboBox.Text);
            Client.Instance.LocalUser.MaritalStatus = Mapper.StringToStatus(StatusComboBox.Text);

            Datagram datagram = Client.Instance.GetAnswer(
                new Datagram(
                    Client.Instance.LocalUser.Login,
                    Guid.Empty,
                    "register",
                    "user",
                    Client.Instance.LocalUser));

            if (datagram?.Action == "success")
            {
                var token = (Guid)datagram.Data;
                datagram = Client.Instance.GetAnswer(
                    new Datagram(
                        Client.Instance.LocalUser.Login,
                        token,
                        "get",
                        "user",
                        Client.Instance.LocalUser.Login));
                if (datagram?.Action == "success")
                {
                    Client.Instance.Token = token;
                    try
                    {
                        Client.Instance.User = (IUser)datagram.Data;
                        Owner.Owner.Close();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
        }
    }
}
