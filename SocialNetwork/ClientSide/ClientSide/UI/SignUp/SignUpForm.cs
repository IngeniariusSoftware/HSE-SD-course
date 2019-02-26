
namespace ClientSide.UI.SignUp
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using ClientSide.UI.Registration;

    using Datagrams;

    using UserManagement;
    using UserManagement.Users;

    public partial class SignUpForm : Form
    {
        private RegistrationForm _registrationForm;

        public SignUpForm()
        {
            InitializeComponent();

            Client.Instance.LocalUser = new User(
                string.Empty,
                "Имя",
                "Фамилия",
                "Отчество",
                DateTime.Now.AddYears(-14),
                Gender.Female,
                MaritalStatus.Single,
                "Университет",
                "Школа",
                "Пароль");
            Bind();
            Subscribe();
        }

        private void Bind()
        {
            LoginTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "Login");
            PasswordTextBox.DataBindings.Add("Text", Client.Instance.LocalUser, "Password");
        }

        private void Subscribe()
        {
            LoginTextBox.TextChanged += CheckLogin;
            LoginTextBox.Enter += InputElement_FocusEntered;
            LoginTextBox.Leave += InputElement_FocusLeaved;

            PasswordTextBox.Enter += InputPassword_FocusEntered;
            PasswordTextBox.Enter += InputElement_FocusEntered;
            PasswordTextBox.Leave += InputPassword_FocusLeaved;
            PasswordTextBox.Leave += InputElement_FocusLeaved;
            PasswordTextBox.TextChanged += ConfirmPassword;

            PasswordConfirmTextBox.Enter += InputPassword_FocusEntered;
            PasswordConfirmTextBox.Enter += InputElement_FocusEntered;
            PasswordConfirmTextBox.Leave += InputPassword_FocusLeaved;
            PasswordConfirmTextBox.Leave += InputElement_FocusLeaved;
            PasswordConfirmTextBox.TextChanged += ConfirmPassword;

        }

        private void InputElement_FocusEntered(object sender, EventArgs e)
        {
            var inputElement = (Control)sender;
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

        private void InputPassword_FocusEntered(object sender, EventArgs e)
        {
            var inputElement = (TextBox)sender;
            if (inputElement.ForeColor == Color.DarkGray)
            {
                inputElement.PasswordChar = '*';
            }
        }

        private void InputPassword_FocusLeaved(object sender, EventArgs e)
        {
            var inputElement = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(inputElement.Text))
            {
                inputElement.PasswordChar = char.MinValue;
            }
        }

        private void InputElement_TextChanged(object sender, EventArgs e)
        {
            var educationRegex = new Regex("[^A-Za-zА-Яа-я0-9 ]");
            var inputElement = (Control)sender;
            inputElement.Text = educationRegex.Replace(inputElement.Text, string.Empty);
        }

        private void ConfirmPassword(object sender, EventArgs e)
        {
            if (PasswordTextBox.ForeColor != Color.DarkGray)
            {
                if (PasswordConfirmTextBox.ForeColor != Color.DarkGray)
                {
                    if (PasswordConfirmTextBox.Text == PasswordTextBox.Text)
                    {
                        PasswordConfirmTextBox.ForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        PasswordConfirmTextBox.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                if (PasswordConfirmTextBox.ForeColor != Color.DarkGray)
                {
                    PasswordConfirmTextBox.ForeColor = Color.Black;
                }
            }

            CheckLoginPassword();
        }

        private void CheckLoginPassword()
        {
            if (PasswordConfirmTextBox.ForeColor == Color.ForestGreen && LoginTextBox.ForeColor == Color.ForestGreen)
            {
                ContinueButton.Enabled = true;
            }
            else
            {
                ContinueButton.Enabled = false;
            }
        }

        private void CheckLogin(object sender, EventArgs e)
        {
            if (LoginTextBox.ForeColor != Color.DarkGray)
            {
                LoginTextBox.ForeColor = Color.Black;
            }

            LoginCheckTimer.Stop();
            LoginCheckTimer.Start();
        }

        private void LoginCheckTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text) && LoginTextBox.ForeColor != Color.DarkGray)
            {
                if (Client.Instance.GetAnswer(new Datagram(null, Guid.Empty, "check", "login", LoginTextBox.Text))
                        ?.Action == "free")
                {
                    LoginTextBox.ForeColor = Color.ForestGreen;
                }
                else
                {
                    LoginTextBox.ForeColor = Color.Red;
                }

                CheckLoginPassword();
            }

            LoginCheckTimer.Stop();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (_registrationForm == null || _registrationForm.IsDisposed)
            {
                _registrationForm = new RegistrationForm();
                _registrationForm.Owner = this;
                _registrationForm.Closed += (obj, ev) => { Show(); };
            }

            Hide();
            _registrationForm.Show();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            Owner.Show();
        }
    }
}