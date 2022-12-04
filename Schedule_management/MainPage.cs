namespace Schedule_management
{
    public partial class MainPage : Form
    {
        private List<ListBox> listBoxes = new List<ListBox>();   //Список объектов типа ListBox

        public MainPage()
        {
            InitializeComponent();
            AddingListBoxesToList();
            UpdateAllListBoxes();

            //Задание обработчика события SelectedIndexChanged для всех объектов типа ListBox
            for (int i = 0; i < listBoxes.Count; i++)
            {
                listBoxes[i].SelectedIndexChanged += new EventHandler(listBoxesSelectedIndexChanged);
            }
        }

        //Обработчик нажатия на кнопку "Список уроков"
        private void buttonShowEditingLessonsForm_Click(object sender, EventArgs e)
        {
            new EditingLessonsForm(this).ShowDialog();
        }

        //Обработчик нажатия на кнопку "Сохранить расписание"
        private void buttonSaveClasses_Click(object sender, EventArgs e)
        {
            InternalData.SaveClasses();
            MessageBox.Show("Распиcание сохранено!");
        }

        //Обработчик нажатия на кнопку "Стереть расписание"
        private void buttonClearSchedule_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirmationForm = new ConfirmationForm(this);
            confirmationForm.ShowDialog();
        }

        //Обработчик изменения индекса выбранного элемента в объекта типа ListBox
        private void listBoxesSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            if (((ListBox)sender).SelectedIndex != -1)
            {
                InternalData.IndexOfSelectedDay = GetIndexOfSelectedListBox(sender);
                InternalData.IndexOfSelectedLesson = ((ListBox)sender).SelectedIndex;
                SelectLessonForm selectLessonForm = new SelectLessonForm(this);
                selectLessonForm.SetShowedLessonOnInitialize(((Lesson)((ListBox)sender).SelectedItem).Name, ((Lesson)((ListBox)sender).SelectedItem).Teacher.Name);
                selectLessonForm.ShowDialog();
                ((ListBox)sender).SelectedItems.Clear();
            }
        }



        //Вспомогательные методы:

        //Метод получения индекса определенного объекта ListBox из списка
        private int GetIndexOfSelectedListBox(object sender)
        {
            for (int i = 0; i < listBoxes.Count; i++)
            {
                if (Equals(listBoxes[i], sender))
                {
                    return i;
                }
            }

            return -1;
        }

        //Метод добавления объектов ListBox в список
        private void AddingListBoxesToList()
        {
            listBoxes.Add(listBox1_1);
            listBoxes.Add(listBox1_2);
            listBoxes.Add(listBox1_3);
            listBoxes.Add(listBox1_4);
            listBoxes.Add(listBox1_5);
            listBoxes.Add(listBox1_6);
            listBoxes.Add(listBox1_7);
            listBoxes.Add(listBox1_8);
            listBoxes.Add(listBox1_9);
            listBoxes.Add(listBox1_10);
            listBoxes.Add(listBox1_11);
            listBoxes.Add(listBox2_1);
            listBoxes.Add(listBox2_2);
            listBoxes.Add(listBox2_3);
            listBoxes.Add(listBox2_4);
            listBoxes.Add(listBox2_5);
            listBoxes.Add(listBox2_6);
            listBoxes.Add(listBox2_7);
            listBoxes.Add(listBox2_8);
            listBoxes.Add(listBox2_9);
            listBoxes.Add(listBox2_10);
            listBoxes.Add(listBox2_11);
            listBoxes.Add(listBox3_1);
            listBoxes.Add(listBox3_2);
            listBoxes.Add(listBox3_3);
            listBoxes.Add(listBox3_4);
            listBoxes.Add(listBox3_5);
            listBoxes.Add(listBox3_6);
            listBoxes.Add(listBox3_7);
            listBoxes.Add(listBox3_8);
            listBoxes.Add(listBox3_9);
            listBoxes.Add(listBox3_10);
            listBoxes.Add(listBox3_11);
            listBoxes.Add(listBox4_1);
            listBoxes.Add(listBox4_2);
            listBoxes.Add(listBox4_3);
            listBoxes.Add(listBox4_4);
            listBoxes.Add(listBox4_5);
            listBoxes.Add(listBox4_6);
            listBoxes.Add(listBox4_7);
            listBoxes.Add(listBox4_8);
            listBoxes.Add(listBox4_9);
            listBoxes.Add(listBox4_10);
            listBoxes.Add(listBox4_11);
            listBoxes.Add(listBox5_1);
            listBoxes.Add(listBox5_2);
            listBoxes.Add(listBox5_3);
            listBoxes.Add(listBox5_4);
            listBoxes.Add(listBox5_5);
            listBoxes.Add(listBox5_6);
            listBoxes.Add(listBox5_7);
            listBoxes.Add(listBox5_8);
            listBoxes.Add(listBox5_9);
            listBoxes.Add(listBox5_10);
            listBoxes.Add(listBox5_11);
        }

        //Метод обновления информации на всех объектах ListBox
        public void UpdateAllListBoxes()
        {
            for (int i = 0; i < listBoxes.Count; i++)
            {
                listBoxes[i].SelectedItems.Clear();
                listBoxes[i].Items.Clear();
                listBoxes[i].Items.AddRange(InternalData.ClassList[i % InternalData.countOfClasses].Days[i / InternalData.countOfClasses].Lessons.ToArray());
            }
        }

        //Метод обновления информации на определённом ListBox
        public void UpdateListBoxByIndex()
        {
            listBoxes[InternalData.IndexOfSelectedDay].SelectedItems.Clear();
            listBoxes[InternalData.IndexOfSelectedDay].Items.Clear();
            listBoxes[InternalData.IndexOfSelectedDay].Items.AddRange(InternalData.ClassList[InternalData.IndexOfSelectedDay % InternalData.countOfClasses].
                Days[InternalData.IndexOfSelectedDay / InternalData.countOfClasses].Lessons.ToArray());
        }

        //Метод очистки расписания после подтверждения
        public void ClearScheduleAfterConfirmation()
        {
            InternalData.ClearSchedule();
            UpdateAllListBoxes();
        }
    }
}