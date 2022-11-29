namespace Schedule_management
{
    public partial class MainPage : Form
    {
        private List<ListBox> listBoxes = new List<ListBox>();

        public MainPage()
        {
            InitializeComponent();
            AddingListBoxesToList();
            UpdateAllListBoxes();
            for (int i = 0; i < listBoxes.Count; i++)
            {
                listBoxes[i].SelectedIndexChanged += new EventHandler(listBoxesSelectedIndexChanged);
            }
        }

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

        public void UpdateAllListBoxes()
        {
            for (int i = 0; i < listBoxes.Count; i++)
            {
                listBoxes[i].SelectedItems.Clear();
                listBoxes[i].Items.Clear();
                listBoxes[i].Items.AddRange(InternalData.ClassList[i % InternalData.countOfClasses].Days[i / InternalData.countOfClasses].lessons.ToArray());
            }
        }

        public void UpdateListBoxByIndex()
        {
            listBoxes[InternalData.IndexOfSelectedDay].SelectedItems.Clear();
            listBoxes[InternalData.IndexOfSelectedDay].Items.Clear();
            listBoxes[InternalData.IndexOfSelectedDay].Items.AddRange(InternalData.ClassList[InternalData.IndexOfSelectedDay % InternalData.countOfClasses].
                Days[InternalData.IndexOfSelectedDay / InternalData.countOfClasses].lessons.ToArray());
        }

        private void buttonShowEditingLessonsForm_Click(object sender, EventArgs e)
        {
            new EditingLessonsForm(this).ShowDialog();
        }

        private void listBoxesSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedIndex != -1)
            {
                InternalData.IndexOfSelectedDay = GetIndexOfSelectedListBox(sender);
                InternalData.IndexOfSelectedLesson = (sender as ListBox).SelectedIndex;
                SelectLessonForm selectLessonForm = new SelectLessonForm(this);
                selectLessonForm.SetShowedLessonOnInitialize(((sender as ListBox).SelectedItem as Lesson).Name, ((sender as ListBox).SelectedItem as Lesson).Teacher);
                selectLessonForm.ShowDialog();
                (sender as ListBox).SelectedItems.Clear();
            }
        }

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

        private void buttonSaveClasses_Click(object sender, EventArgs e)
        {
            InternalData.SaveClasses();
            MessageBox.Show("Распиcание сохранено!");
        }

        private void buttonClearSchedule_Click(object sender, EventArgs e)
        {
            InternalData.ClearSchedule();
            UpdateAllListBoxes();
        }
    }
}