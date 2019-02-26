
namespace ClientSide.UI.Аuthentication
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using ClientSide.Properties;
    using ClientSide.UI.MainPage;
    using ClientSide.UI.SignUp;

    using Datagrams;

    using UserManagement.Users;

    public partial class АuthenticationForm : Form
    {
        private bool _isLocked;

        private bool _isConnected;

        private SignUpForm _signUpForm;

        private MainPageForm _mainPageForm;

        public АuthenticationForm()
        {
            InitializeComponent();
            Bind();
            TestConnection();
        }

        private void Bind()
        {
            ServerTextBox.DataBindings.Add("Text", Client.Instance, "ServerAddress");
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = '*';
            Logo.Image.Dispose();
            Logo.Image = Resources.MonkeyPasswordLogo;

            if (PasswordTextBox.ForeColor == Color.DarkGray)
            {
                PasswordTextBox.Text = string.Empty;
                PasswordTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            Logo.Image.Dispose();
            Logo.Image = Resources.MonkeyHelloLogo;

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.ForeColor = Color.DarkGray;
                PasswordTextBox.Text = PasswordTextBox.AccessibleName;
                PasswordTextBox.PasswordChar = char.MinValue;
            }
            else
            {
                PasswordTextBox.PasswordChar = '*';
            }
        }

        private void LoginTextBox_Enter(object sender, EventArgs e)
        {
            if (LoginTextBox.ForeColor == Color.DarkGray)
            {
                LoginTextBox.Text = string.Empty;
                LoginTextBox.ForeColor = Color.Black;
            }
        }

        private void LoginTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                LoginTextBox.ForeColor = Color.DarkGray;
                LoginTextBox.Text = LoginTextBox.AccessibleName;
            }

            Logo.Image.Dispose();
            Logo.Image = Resources.MonkeyHelloLogo;
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (LoginTextBox.ForeColor != Color.DarkGray && PasswordTextBox.ForeColor != Color.DarkGray
                                                         && !string.IsNullOrWhiteSpace(LoginTextBox.Text)
                                                         && !string.IsNullOrWhiteSpace(PasswordTextBox.Text)
                                                         && _isConnected)
            {
                LogInButton.Enabled = true;
                LoginTextBox.ForeColor = Color.Black;
                PasswordTextBox.ForeColor = Color.Black;
            }
            else
            {
                if (LoginTextBox.Text.ToLower() == "debug")
                {
                    SettingsButton.Visible = true;
                }
                else
                {
                    ServerTextBox.Visible = false;
                    SettingsButton.Visible = false;
                }

                LogInButton.Enabled = false;
            }
        }

        private async void TestConnection()
        {
            _isLocked = true;
            ConnectionStatusLogo.Image = Resources.ConnectionIcon;
            _isConnected = await Task.Run(() => Client.Instance.CheckConnection());
            ConnectionStatusLogo.Image = _isConnected ? Resources.AcceptIcon : Resources.ErrorIcon;
            _isLocked = false;
            RegistrationButton.Enabled = _isConnected;
            CheckInput();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ServerTextBox.Visible = !ServerTextBox.Visible;
        }

        private void ReconnectButton_Click(object sender, EventArgs e)
        {
            if (!_isLocked)
            {
                RegistrationButton.Enabled = false;
                LogInButton.Enabled = false;
                TestConnection();
            }
        }

        private void Logo_MouseUp(object sender, MouseEventArgs e)
        {
            if (PasswordTextBox.PasswordChar == char.MinValue && PasswordTextBox.ForeColor != Color.DarkGray)
            {
                PasswordTextBox.PasswordChar = '*';
                Logo.Image.Dispose();
                Logo.Image = Resources.MonkeyPasswordLogo;
            }
        }

        private void Logo_MouseDown(object sender, MouseEventArgs e)
        {
            if (PasswordTextBox.PasswordChar == '*' && PasswordTextBox.ForeColor != Color.DarkGray
                                                    && PasswordTextBox.Focused)
            {
                PasswordTextBox.PasswordChar = char.MinValue;
                Logo.Image.Dispose();
                Logo.Image = Resources.MonkeyHelloLogo;
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            Datagram datagram = Client.Instance.GetAnswer(
                new Datagram(LoginTextBox.Text, Guid.Empty, "authentication", "user", PasswordTextBox.Text));
            if (datagram?.Action == "success")
            {
                var token = (Guid)datagram.Data;
                datagram = Client.Instance.GetAnswer(
                    new Datagram(LoginTextBox.Text, token, "get", "user", LoginTextBox.Text));
                if (datagram?.Action == "success")
                {
                    Client.Instance.Token = token;
                    try
                    {
                        Client.Instance.User = (IUser)datagram.Data;
                        Close();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    LoginTextBox.ForeColor = Color.Red;
                    PasswordTextBox.ForeColor = Color.Red;
                }
            }
            else
            {
                LoginTextBox.ForeColor = Color.Red;
                PasswordTextBox.ForeColor = Color.Red;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (_signUpForm == null || _signUpForm.IsDisposed)
            {
                _signUpForm = new SignUpForm();
                _signUpForm.Owner = this;
                _signUpForm.Closed += (obj, ev) => { Show(); };
            }

            Hide();
            _signUpForm.Show();
        }
    }
}