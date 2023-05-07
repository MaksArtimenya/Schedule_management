namespace Schedule_management
{
    public partial class MainPage : Form
    {
        private List<ListBox> listBoxes = new List<ListBox>();
        public Lesson changeableLesson = new Lesson(string.Empty, -1);
        public int indexOfSelectedLesson = -1;
        private bool isAutomaticallyChangeSelectedIndexes = false;

        public MainPage()
        {
            InitializeComponent();
            AddingListBoxesToList();
            UpdateAllListBoxes();
            ChangeLabelWelcomeText();
            CheckingTypeOfUser();


            comboBoxTeachers.Items.AddRange(InternalData.Teachers.ToArray());
            comboBoxTeachers.Items.Insert(0, new Teacher(string.Empty));
        }

        private void CheckingTypeOfUser()
        {
            switch (InternalData.User.TypeOfUser)
            {
                case 0:
                    for (int i = 0; i < listBoxes.Count; i++)
                    {
                        listBoxes[i].SelectedIndexChanged += new EventHandler(listBoxesSelectedIndexChanged);
                    }
                    break;
                case 1:
                    for (int i = 0; i < listBoxes.Count; i++)
                    {
                        listBoxes[i].SelectedIndexChanged += new EventHandler(listBoxesSelectedIndexChangedForTeacher);
                    }

                    buttonShowEditingLessonsForm.Enabled = false;
                    buttonClearSchedule.Enabled = false;
                    break;
                case 2:
                    for (int i = 0; i < listBoxes.Count; i++)
                    {
                        listBoxes[i].SelectedIndexChanged += new EventHandler(listBoxesSelectedIndexChangedForGuest);
                    }

                    buttonShowEditingLessonsForm.Enabled = false;
                    buttonClearSchedule.Enabled = false;
                    comboBoxTeachers.Enabled = false;
                    break;
            }
        }

        private void ChangeLabelWelcomeText()
        {
            switch (InternalData.User.TypeOfUser)
            {
                case 0:
                    labelWelcome.Text = $"�� ����� ���: {InternalData.User.Name.Trim()} (�������������)";
                    break;
                case 1:
                    labelWelcome.Text = $"�� ����� ���: {InternalData.User.Name.Trim()} (�������)";
                    break;
                case 2:
                    labelWelcome.Text = $"�� ����� ���: {InternalData.User.Name.Trim()} (�����)";
                    break;
            }
        }

        private void buttonShowEditingLessonsForm_Click(object sender, EventArgs e)
        {
            new EditingLessonsForm(this).ShowDialog();
        }

        private void buttonClearSchedule_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirmationForm = new ConfirmationForm(this);
            confirmationForm.ShowDialog();
        }

        private void listBoxesSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!isAutomaticallyChangeSelectedIndexes)
            {
                if (sender is null)
                {
                    return;
                }

                if (((ListBox)sender).SelectedIndex != -1)
                {
                    InternalData.IndexOfSelectedDay = GetIndexOfSelectedListBox(sender);
                    InternalData.IndexOfSelectedLesson = ((ListBox)sender).SelectedIndex;
                    changeableLesson = (Lesson)((ListBox)sender).SelectedItem;
                    indexOfSelectedLesson = ((ListBox)sender).SelectedIndex;
                    SelectLessonForm selectLessonForm = new SelectLessonForm(this);
                    selectLessonForm.SetShowedLessonOnInitialize(((Lesson)((ListBox)sender).SelectedItem).Name, InternalData.GetTeacherByID(((Lesson)((ListBox)sender).SelectedItem).Id_Teacher).Name);
                    selectLessonForm.ShowDialog();
                    ((ListBox)sender).SelectedItems.Clear();
                }
            }
        }

        private void listBoxesSelectedIndexChangedForTeacher(object? sender, EventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            if (!isAutomaticallyChangeSelectedIndexes)
            {
                UpdateAllListBoxes();
                comboBoxTeachers.SelectedIndex = 0;
            }
        }

        private void listBoxesSelectedIndexChangedForGuest(object? sender, EventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            ((ListBox)sender).SelectedIndex = -1;
        }

        private void comboBoxTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAllListBoxes();
            if (comboBoxTeachers.SelectedIndex != 0 && comboBoxTeachers.SelectedIndex != -1)
            {
                isAutomaticallyChangeSelectedIndexes = true;
                List<Lesson> lessons = InternalData.GetLessonsByTeacher((Teacher)comboBoxTeachers.SelectedItem);
                for (int i = 0; i < listBoxes.Count; i++)
                {
                    for (int j = 0; j < listBoxes[i].Items.Count; j++)
                    {
                        for (int k = 0; k < lessons.Count; k++)
                        {
                            if (((Lesson)listBoxes[i].Items[j]).Equals(lessons[k]))
                            {
                                listBoxes[i].SelectedItems.Add(listBoxes[i].Items[j]);
                            }
                        }
                    }
                }
                isAutomaticallyChangeSelectedIndexes = false;
            }
        }



        //��������������� ������:

        //����� ��������� ������� ������������� ������� ListBox �� ������
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

        //����� ���������� �������� ListBox � ������
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

        //����� ���������� ���������� �� ���� �������� ListBox
        public void UpdateAllListBoxes()
        {
            for (int i = 0; i < listBoxes.Count; i++)
            {
                listBoxes[i].SelectedItems.Clear();
                listBoxes[i].Items.Clear();

                List<Lesson> lessons = new List<Lesson>();
                for (int j = 0; j < InternalData.countOfLessons; j++)
                {
                    int id_Lesson = InternalData.CheckingSchedule((i % InternalData.countOfClasses) + 1, (i / InternalData.countOfClasses) + 1, j + 1);
                    lessons.Add(InternalData.GetLessonByID(id_Lesson));
                }

                listBoxes[i].Items.AddRange(lessons.ToArray());
            }
        }

        //����� ���������� ���������� �� ����������� ListBox
        public void UpdateListBoxByIndex()
        {
            listBoxes[InternalData.IndexOfSelectedDay].SelectedItems.Clear();
            listBoxes[InternalData.IndexOfSelectedDay].Items.Clear();

            List<Lesson> lessons = new List<Lesson>();
            for (int j = 0; j < InternalData.countOfLessons; j++)
            {
                int id_Lesson = InternalData.CheckingSchedule((InternalData.IndexOfSelectedDay % InternalData.countOfClasses) + 1, (InternalData.IndexOfSelectedDay / InternalData.countOfClasses) + 1, j + 1);
                lessons.Add(InternalData.GetLessonByID(id_Lesson));
            }

            listBoxes[InternalData.IndexOfSelectedDay].Items.AddRange(lessons.ToArray());
        }

        //����� ������� ���������� ����� �������������
        public void ClearScheduleAfterConfirmation()
        {
            InternalData.ClearSchedule();
            UpdateAllListBoxes();
        }

        
    }
}