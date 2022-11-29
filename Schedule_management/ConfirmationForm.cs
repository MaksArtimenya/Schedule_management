using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule_management
{
    public partial class ConfirmationForm : Form
    {
        private MainPage mainPage;   //Объект типа MainPage

        public ConfirmationForm(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
        }

        //Обработчик нажатия на кнопку "Нет"
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Обработчик нажатия на кнопку "Да"
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            mainPage.ClearScheduleAfterConfirmation();
            Close();
        }
    }
}
