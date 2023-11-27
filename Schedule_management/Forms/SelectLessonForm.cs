using Schedule_management.Internal;
using Schedule_management.Objects;

namespace Schedule_management
{
    public partial class SelectLessonForm : Form
    {
        private MainPage mainPage;

        public SelectLessonForm(MainPage mainPage)
        {
            InitializeComponent();
            listBoxShowAvaibleLessons.Items.AddRange(InternalData.Lessons.ToArray());
            listBoxShowAvaibleLessons.Items.Insert(0, new Lesson(string.Empty, -1));
            this.mainPage = mainPage;
        }

        private void listBoxShowAvaibleLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowAvaibleLessons.SelectedIndex != -1)
            {
                textBoxNameOfLesson.Text = ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Name;
                textBoxTeacherOfLesson.Text = InternalData.GetTeacherByID(((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id_Teacher).Name;
                buttonSaveSelectedLesson.Visible = true;
            }
        }

        private void buttonSaveSelectedLesson_Click(object sender, EventArgs e)
        {
            int nameOfClass;
            int numberOfDay;
            int numberOfLesson;

            if (InternalData.CheckingTeacher(InternalData.GetTeacherByID(((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id_Teacher), out nameOfClass, out numberOfDay, out numberOfLesson))
            {
                MessageBox.Show($"Этот преподаватель уже занят" + $"\nКласс: {nameOfClass}" + $"\nДень: {numberOfDay}"
                    + $"\nУрок: {numberOfLesson}");
            }
            else
            {
                if (mainPage.changeableLesson.Id != -1 && ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id == -1)
                {
                    InternalData.RemoveSchedule(new Schedule((InternalData.IndexOfSelectedDay % InternalData.countOfClasses) + 1,
                        (InternalData.IndexOfSelectedDay / InternalData.countOfClasses) + 1, mainPage.indexOfSelectedLesson + 1,
                        mainPage.changeableLesson.Id));
                }
                else if (mainPage.changeableLesson.Id == -1 && ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id != -1)
                {
                    InternalData.AddSchedule(new Schedule((InternalData.IndexOfSelectedDay % InternalData.countOfClasses) + 1,
                        (InternalData.IndexOfSelectedDay / InternalData.countOfClasses) + 1, mainPage.indexOfSelectedLesson + 1,
                        ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id));
                }
                else if (mainPage.changeableLesson.Id != -1 && ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id != -1 && 
                    mainPage.changeableLesson.Id != ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id)
                {
                    InternalData.EditSchedule(new Schedule((InternalData.IndexOfSelectedDay % InternalData.countOfClasses) + 1,
                        (InternalData.IndexOfSelectedDay / InternalData.countOfClasses) + 1, mainPage.indexOfSelectedLesson + 1,
                        mainPage.changeableLesson.Id), new Schedule((InternalData.IndexOfSelectedDay % InternalData.countOfClasses) + 1,
                        (InternalData.IndexOfSelectedDay / InternalData.countOfClasses) + 1, mainPage.indexOfSelectedLesson + 1,
                        ((Lesson)listBoxShowAvaibleLessons.SelectedItem).Id));
                }
                mainPage.UpdateListBoxByIndex();
                Close();
            }
        }



        //Вспомогательный метод:

        //Метод отображения выбранного урока на этапе инициализации
        public void SetShowedLessonOnInitialize(string name, string teacherName)
        {
            textBoxNameOfLesson.Text = name;
            textBoxTeacherOfLesson.Text = teacherName;
        }
    }
}
