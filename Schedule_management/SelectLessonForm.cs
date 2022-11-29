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
    public partial class SelectLessonForm : Form
    {
        private MainPage mainPage;   //Объект типа MainPage

        public SelectLessonForm(MainPage mainPage)
        {
            InitializeComponent();
            listBoxShowAvaibleLessons.Items.AddRange(InternalData.Lessons.ToArray());
            listBoxShowAvaibleLessons.Items.Insert(0, new Lesson(string.Empty, string.Empty));
            this.mainPage = mainPage;
        }

        //Обработчик изменения индекса выбранного элемента в ListBox
        private void listBoxShowAvaibleLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowAvaibleLessons.SelectedIndex != -1)
            {
                textBoxNameOfLesson.Text = ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Name;
                textBoxTeacherOfLesson.Text = ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Teacher;
                buttonSaveSelectedLesson.Visible = true;
            }
        }

        //Обработчик нажатия на кнопку "Сохранить"
        private void buttonSaveSelectedLesson_Click(object sender, EventArgs e)
        {
            string nameOfClass;
            int numberOfDay;
            int numberOfLesson;

            if (InternalData.CheckingTeacher(((Lesson)listBoxShowAvaibleLessons.SelectedItem).Teacher, out nameOfClass, out numberOfDay, out numberOfLesson))
            {
                MessageBox.Show($"Этот преподаватель уже занят" + $"\nКласс: {nameOfClass}" + $"\nДень: {numberOfDay}"
                    + $"\nУрок: {numberOfLesson}");
            }
            else
            {
                InternalData.ClassList[InternalData.IndexOfSelectedDay % InternalData.countOfClasses].Days[InternalData.IndexOfSelectedDay / InternalData.countOfClasses].Lessons[InternalData.IndexOfSelectedLesson] =
                (Lesson)listBoxShowAvaibleLessons.SelectedItem;
                mainPage.UpdateListBoxByIndex();
                Close();
            }
        }



        //Вспомогательный метод:

        //Метод отображения выбранного урока на этапе инициализации
        public void SetShowedLessonOnInitialize(string name, string teacher)
        {
            textBoxNameOfLesson.Text = name;
            textBoxTeacherOfLesson.Text = teacher;
        }
    }
}
