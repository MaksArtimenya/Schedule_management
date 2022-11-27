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
            this.mainPage = mainPage;
        }

        private void SavingChanges()
        {
            List<Lesson> bufListOfLessons = new List<Lesson>();
            for (int i = 0; i < listBoxShowLessons.Items.Count; i++)
            {
                bufListOfLessons.Add(listBoxShowLessons.Items[i] as Lesson);
            }

            InternalData.Lessons = bufListOfLessons;
            InternalData.SaveLessons();
        }

        private void buttonSaveLesson_Click(object sender, EventArgs e)
        {
            if (textBoxNameOfLesson.Text == string.Empty || textBoxTeacherOfLesson.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля для добавления урока в список");
            }
            else if (CheckingLessons(new Lesson(textBoxNameOfLesson.Text, textBoxTeacherOfLesson.Text)))
            {
                MessageBox.Show("Данный урок уже существует");
            }
            else
            {
                if (groupBoxNewLesson.Text == "Новый урок")
                {
                    listBoxShowLessons.Items.Add(new Lesson(textBoxNameOfLesson.Text, textBoxTeacherOfLesson.Text));
                    SavingChanges();
                    buttonDontSaveLesson_Click(sender, e);
                }
                else
                {
                    InternalData.ChekingClassesForEditingLesson(listBoxShowLessons.Items[listBoxShowLessons.SelectedIndex] as Lesson, new Lesson(textBoxNameOfLesson.Text, textBoxTeacherOfLesson.Text));
                    listBoxShowLessons.Items[listBoxShowLessons.SelectedIndex] = new Lesson(textBoxNameOfLesson.Text, textBoxTeacherOfLesson.Text);
                    mainPage.UpdateAllListBoxes();
                    SavingChanges();
                    buttonDontSaveLesson_Click(sender, e);
                }
            }
        }

        private bool CheckingLessons(Lesson newLesson)
        {
            for (int i = 0; i < InternalData.Lessons.Count; i++)
            {
                if (newLesson == InternalData.Lessons[i] && i != listBoxShowLessons.SelectedIndex)
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonDontSaveLesson_Click(object sender, EventArgs e)
        {
            textBoxNameOfLesson.Clear();
            textBoxTeacherOfLesson.Clear();
            listBoxShowLessons.SelectedItems.Clear();
            groupBoxNewLesson.Text = "Новый урок";
            buttonRemoveLesson.Visible = false;
        }

        private void listBoxShowLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowLessons.SelectedIndex != -1)
            {
                groupBoxNewLesson.Text = "Редактировать урок";
                textBoxNameOfLesson.Text = (listBoxShowLessons.SelectedItem as Lesson).Name;
                textBoxTeacherOfLesson.Text = (listBoxShowLessons.SelectedItem as Lesson).Teacher;
                buttonRemoveLesson.Visible = true;
            }
        }

        private void buttonRemoveLesson_Click(object sender, EventArgs e)
        {
            InternalData.CheckingClassesForRemovingLesson(listBoxShowLessons.SelectedItem as Lesson);
            listBoxShowLessons.Items.Remove(listBoxShowLessons.SelectedItem);
            mainPage.UpdateAllListBoxes();
            SavingChanges();
            buttonDontSaveLesson_Click(sender, e);
        }
    }
}
