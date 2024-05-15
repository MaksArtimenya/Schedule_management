using System.Net;
using Schedule_management.Internal;
using Schedule_management.Objects;

namespace Schedule_management
{
    public partial class SignInForm : Form
    {
        public IPEndPoint? IPEndPoint { get; set; }

        public SignInForm()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint = new IPEndPoint(IPAddress.Parse(textBoxIpAddress.Text), int.Parse(textBoxPort.Text));
                InternalData.GetUserFromServer(textBoxLogin.Text, textBoxPassword.Text, textBoxIpAddress.Text, textBoxPort.Text);
                if (!InternalData.User.Equals(new User(string.Empty, -1)))
                {
                    InternalData.Initialization();
                    new MainPage().ShowDialog();
                    textBoxLogin.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }

        private void CheckingTextBoxes()
        {
            try
            {
                IPAddress.Parse(textBoxIpAddress.Text);
                int.Parse(textBoxPort.Text);
                if (textBoxLogin.Text != string.Empty && textBoxPassword.Text != string.Empty && textBoxPort.Text.Length == 4)
                {
                    buttonSignIn.Enabled = true;
                }
                else
                {
                    buttonSignIn.Enabled = false;
                }
            }
            catch
            {
                buttonSignIn.Enabled = false;
            }
        }

        private void textBoxIpAddress_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }
    }
}
