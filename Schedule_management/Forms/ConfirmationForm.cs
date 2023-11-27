namespace Schedule_management
{
    public partial class ConfirmationForm : Form
    {
        private MainPage mainPage;

        public ConfirmationForm(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            mainPage.ClearScheduleAfterConfirmation();
            Close();
        }
    }
}
