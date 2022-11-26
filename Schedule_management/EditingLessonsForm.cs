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
        public EditingLessonsForm()
        {
            InitializeComponent();
            listBoxShowLessons.Items.AddRange(InternalData.Lessons.ToArray());
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
                    buttonDontSaveLesson_Click(sender, e);
                }
                else
                {
                    listBoxShowLessons.Items[listBoxShowLessons.SelectedIndex] = new Lesson(textBoxNameOfLesson.Text, textBoxTeacherOfLesson.Text);
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

        private void buttonSaveListOfLessons_Click(object sender, EventArgs e)
        {
            List<Lesson> bufListOfLessons = new List<Lesson>();
            for (int i = 0; i < listBoxShowLessons.Items.Count; i++)
            {
                bufListOfLessons.Add(listBoxShowLessons.Items[i] as Lesson);
            }

            InternalData.Lessons = bufListOfLessons;
            InternalData.SaveLessons();
            Close();
        }

        private void buttonRemoveLesson_Click(object sender, EventArgs e)
        {
            listBoxShowLessons.Items.Remove(listBoxShowLessons.SelectedItem);
            buttonDontSaveLesson_Click(sender, e);
        }
    }
}
