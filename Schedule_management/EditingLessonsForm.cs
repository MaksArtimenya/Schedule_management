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
    public partial class EditingLessonsForm : Form
    {
        private MainPage mainPage;

        public EditingLessonsForm(MainPage mainPage)
        {
            InitializeComponent();
            listBoxShowLessons.Items.AddRange(InternalData.Lessons.ToArray());
            comboBoxTeacherOfLesson.Items.AddRange(InternalData.Teachers.ToArray());
            this.mainPage = mainPage;
        }

        private void buttonSaveLesson_Click(object sender, EventArgs e)
        {
            if (textBoxNameOfLesson.Text == string.Empty || comboBoxTeacherOfLesson.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля для добавления урока в список");
            }
            else if (CheckingLessons(new Lesson(textBoxNameOfLesson.Text, ((Teacher)comboBoxTeacherOfLesson.SelectedItem).Id)))
            {
                MessageBox.Show("Данный урок уже существует");
            }
            else
            {
                if (groupBoxNewLesson.Text == "Новый урок")
                {
                    InternalData.AddLesson(new Lesson(textBoxNameOfLesson.Text, ((Teacher)comboBoxTeacherOfLesson.SelectedItem).Id));
                    buttonDontSaveLesson_Click(sender, e);
                }
                else
                {
                    InternalData.EditLesson((Lesson)listBoxShowLessons.SelectedItem, new Lesson(textBoxNameOfLesson.Text, ((Teacher)comboBoxTeacherOfLesson.SelectedItem).Id));
                    mainPage.UpdateAllListBoxes();
                    buttonDontSaveLesson_Click(sender, e);
                }
            }
        }

        private void buttonDontSaveLesson_Click(object sender, EventArgs e)
        {
            textBoxNameOfLesson.Clear();
            comboBoxTeacherOfLesson.SelectedIndex = -1;
            listBoxShowLessons.SelectedItems.Clear();
            InternalData.GetLessonsFromDB();
            listBoxShowLessons.Items.Clear();
            listBoxShowLessons.Items.AddRange(InternalData.Lessons.ToArray());
            groupBoxNewLesson.Text = "Новый урок";
            buttonRemoveLesson.Visible = false;
        }

        private void listBoxShowLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowLessons.SelectedIndex != -1)
            {
                groupBoxNewLesson.Text = "Редактировать урок";
                textBoxNameOfLesson.Text = ((Lesson)listBoxShowLessons.SelectedItem).Name;
                comboBoxTeacherOfLesson.SelectedItem = InternalData.GetTeacherByID(((Lesson)listBoxShowLessons.SelectedItem).Id_Teacher);
                buttonRemoveLesson.Visible = true;
            }
        }

        private void buttonRemoveLesson_Click(object sender, EventArgs e)
        {
            InternalData.RemoveLesson((Lesson)listBoxShowLessons.SelectedItem);
            mainPage.UpdateAllListBoxes();
            buttonDontSaveLesson_Click(sender, e);
        }

        private void buttonClearLessons_Click(object sender, EventArgs e)
        {
            InternalData.ClearLessons();
            mainPage.UpdateAllListBoxes();
            buttonDontSaveLesson_Click(sender, e);
        }



        //Вспомогательные методы:

        //Метод проверки наличия урока в списке
        private bool CheckingLessons(Lesson newLesson)
        {
            for (int i = 0; i < InternalData.Lessons.Count; i++)
            {
                if (newLesson.Equals(InternalData.Lessons[i]) && i != listBoxShowLessons.SelectedIndex)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
