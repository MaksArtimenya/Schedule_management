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
        private MainPage mainPage;   //Объект типа MainPage

        public EditingLessonsForm(MainPage mainPage)
        {
            InitializeComponent();
            listBoxShowLessons.Items.AddRange(InternalData.Lessons.ToArray());
            this.mainPage = mainPage;
        }

        //Обработчик нажатия на кнопку "Сохранить"
        private void buttonSaveLesson_Click(object sender, EventArgs e)
        {
            /*if (textBoxNameOfLesson.Text == string.Empty || textBoxTeacherOfLesson.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля для добавления урока в список");
            }
            else if (CheckingLessons(new Lesson(textBoxNameOfLesson.Text, new Teacher(textBoxTeacherOfLesson.Text))))
            {
                MessageBox.Show("Данный урок уже существует");
            }
            else
            {
                if (groupBoxNewLesson.Text == "Новый урок")
                {
                    listBoxShowLessons.Items.Add(new Lesson(textBoxNameOfLesson.Text, new Teacher(textBoxTeacherOfLesson.Text)));
                    SavingChanges();
                    buttonDontSaveLesson_Click(sender, e);
                }
                else
                {
                    InternalData.ChekingClassesForEditingLesson((Lesson)listBoxShowLessons.Items[listBoxShowLessons.SelectedIndex], new Lesson(textBoxNameOfLesson.Text, new Teacher(textBoxTeacherOfLesson.Text)));
                    listBoxShowLessons.Items[listBoxShowLessons.SelectedIndex] = new Lesson(textBoxNameOfLesson.Text, new Teacher(textBoxTeacherOfLesson.Text));
                    mainPage.UpdateAllListBoxes();
                    SavingChanges();
                    buttonDontSaveLesson_Click(sender, e);
                }
            }*/
        }

        //Обработчик нажатия на кнопку "Не сохранять"
        private void buttonDontSaveLesson_Click(object sender, EventArgs e)
        {
            textBoxNameOfLesson.Clear();
            textBoxTeacherOfLesson.Clear();
            listBoxShowLessons.SelectedItems.Clear();
            groupBoxNewLesson.Text = "Новый урок";
            buttonRemoveLesson.Visible = false;
        }

        //Обработчик изменения индекса выбранного элемента в ListBox
        private void listBoxShowLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowLessons.SelectedIndex != -1)
            {
                groupBoxNewLesson.Text = "Редактировать урок";
                textBoxNameOfLesson.Text = ((Lesson)listBoxShowLessons.SelectedItem).Name;
                textBoxTeacherOfLesson.Text = InternalData.GetTeacherByID(((Lesson)listBoxShowLessons.SelectedItem).Id_Teacher).Name;
                buttonRemoveLesson.Visible = true;
            }
        }

        //Обработчик нажатия на кнопку "Удалить"
        private void buttonRemoveLesson_Click(object sender, EventArgs e)
        {
            /*InternalData.CheckingClassesForRemovingLesson((Lesson)listBoxShowLessons.SelectedItem);
            listBoxShowLessons.Items.Remove(listBoxShowLessons.SelectedItem);
            mainPage.UpdateAllListBoxes();
            SavingChanges();
            buttonDontSaveLesson_Click(sender, e);*/
        }

        //Обработчик нажатия на кнопку "Очистить список"
        private void buttonClearLessons_Click(object sender, EventArgs e)
        {
            InternalData.ClearLessons();
            buttonDontSaveLesson_Click(sender, e);
            listBoxShowLessons.Items.Clear();
        }



        //Вспомогательные методы:

        //Метод сохранения изменений
        private void SavingChanges()
        {
            List<Lesson> bufListOfLessons = new List<Lesson>();
            for (int i = 0; i < listBoxShowLessons.Items.Count; i++)
            {
                bufListOfLessons.Add((Lesson)listBoxShowLessons.Items[i]);
            }

            InternalData.Lessons = bufListOfLessons;
            //InternalData.SaveLessons();
        }

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
