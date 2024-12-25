using OfficeOpenXml;
using OfficeOpenXml.Style;
using Schedule_management.Forms;
using Schedule_management.Internal;
using Schedule_management.Objects;

namespace Schedule_management
{
    public partial class MainPage : Form
    {
        private List<ListBox> listBoxes = new List<ListBox>();
        public Lesson changeableLesson = new Lesson(string.Empty, -1);
        public int indexOfSelectedLesson = -1;
        private bool isAutomaticallyChangeSelectedIndexes = false;
        private bool checkConnection = true;

        public MainPage()
        {
            InitializeComponent();
            AddingListBoxesToList();
            FixListBoxesSelecting();
            UpdateAllListBoxes();
            ChangeLabelWelcomeText();
            CheckingTypeOfUser();
            UpdateTeachers();

            Task.Run(CheckingConnection);
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
                    buttonToEditTeachers.Enabled = false;
                    buttonReports.Enabled = false;
                    break;
                case 2:
                    for (int i = 0; i < listBoxes.Count; i++)
                    {
                        listBoxes[i].SelectedIndexChanged += new EventHandler(listBoxesSelectedIndexChangedForGuest);
                    }

                    buttonShowEditingLessonsForm.Enabled = false;
                    buttonClearSchedule.Enabled = false;
                    comboBoxTeachers.Enabled = false;
                    buttonToEditTeachers.Enabled = false;
                    buttonReports.Enabled = false;
                    break;
            }
        }

        private void ChangeLabelWelcomeText()
        {
            switch (InternalData.User.TypeOfUser)
            {
                case 0:
                    labelWelcome.Text = $"Вы вошли как: {InternalData.User.Name.Trim()} (Администратор)";
                    break;
                case 1:
                    labelWelcome.Text = $"Вы вошли как: {InternalData.User.Name.Trim()} (Учитель)";
                    break;
                case 2:
                    labelWelcome.Text = $"Вы вошли как: {InternalData.User.Name.Trim()} (Гость)";
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
            isAutomaticallyChangeSelectedIndexes = true;
            UpdateAllListBoxes();
            if (comboBoxTeachers.SelectedIndex != 0 && comboBoxTeachers.SelectedIndex != -1)
            {
                List<Lesson> lessons = InternalData.GetLessonsByTeacher((Teacher)comboBoxTeachers.SelectedItem);
                for (int i = 0; i < listBoxes.Count; i++)
                {
                    for (int j = 0; j < listBoxes[i].Items.Count; j++)
                    {
                        for (int k = 0; k < lessons.Count; k++)
                        {
                            if (((Lesson)listBoxes[i].Items[j]).Equals(lessons[k]))
                            {
                                //listBoxes[i].SelectedItems.Add(listBoxes[i].Items[j]);
                                listBoxes[i].SetSelected(j, true);
                            }
                        }
                    }
                }
            }
            isAutomaticallyChangeSelectedIndexes = false;
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkConnection = false;
            InternalData.DisconnectFromServer();
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

        private void FixListBoxesSelecting()
        {
            foreach (ListBox box in listBoxes)
            {
                box.SelectionMode = SelectionMode.MultiExtended;
            }
        }

        //Метод обновления информации на всех объектах ListBox
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

        //Метод обновления информации на определённом ListBox
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

        //Метод очистки расписания после подтверждения
        public void ClearScheduleAfterConfirmation()
        {
            InternalData.ClearSchedule();
            UpdateAllListBoxes();
        }

        private async Task CheckingConnection()
        {
            while (checkConnection)
            {
                InternalData.TestingConnection();
                if (!InternalData.IsConnected)
                {
                    InternalData.ReconnectToServer();
                }

                await Task.Delay(3000);
            }
        }

        private void timerForErrorLabel_Tick(object sender, EventArgs e)
        {
            if (InternalData.IsConnected)
            {
                labelError.Visible = false;
                progressBarReconnect.Visible = false;
            }
            else
            {
                labelError.Visible = true;
                progressBarReconnect.Visible = true;
            }
        }

        private void buttonToEditTeachers_Click(object sender, EventArgs e)
        {
            new EditingTeachersForm(this).ShowDialog();
        }

        public void UpdateTeachers()
        {
            comboBoxTeachers.Items.Clear();
            comboBoxTeachers.Items.AddRange(InternalData.Teachers.ToArray());
            comboBoxTeachers.Items.Insert(0, new Teacher(string.Empty, string.Empty, -1, -1, -1));
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            new ReportsForm().ShowDialog();
        }

        private void buttonSaveSchedule_Click(object sender, EventArgs e)
        {
            GenerateScheduleFile();
        }

        public void GenerateScheduleFile()
        {
            try
            {
                List<Schedule> scheduleList = InternalData.ScheduleList;
                List<Teacher> teachers = InternalData.Teachers;
                List<Lesson> lessons = InternalData.Lessons;
                saveFileDialog1.FileName = $"Расписание {DateTime.Now.ToString("dd-MM-yyyy HH-mm")}.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Расписание");

                        // Заголовки классов
                        for (int i = 1; i <= 11; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = $"{i} класс";
                            worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells[1, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                        }

                        // Заголовки дней недели
                        string[] daysOfWeek = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
                        for (int i = 0; i < daysOfWeek.Length; i++)
                        {
                            worksheet.Cells[i * 9 + 2, 1].Value = daysOfWeek[i];
                            worksheet.Cells[i * 9 + 2, 1, i * 9 + 9, 1].Merge = true;
                            worksheet.Cells[i * 9 + 2, 1, i * 9 + 9, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells[i * 9 + 2, 1, i * 9 + 9, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            worksheet.Cells[i * 9 + 2, 1, i * 9 + 9, 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                        }

                        // Заполнение расписания
                        foreach (var schedule in scheduleList)
                        {
                            var lesson = lessons.Find(l => l.Id == schedule.Id_Lesson);
                            int row = (schedule.Number_Of_Day - 1) * 9 + schedule.Number_Of_Lesson + 1;
                            int col = schedule.Number_Of_Class + 1;

                            worksheet.Cells[row, col].Value = lesson.Name.Trim();
                            worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }

                        // Форматирование ячеек
                        for (int i = 2; i <= 46; i++)
                        {
                            for (int j = 2; j <= 12; j++)
                            {
                                worksheet.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                        }

                        // Установка ширины столбцов
                        worksheet.Column(1).Width = 20; // Увеличение ширины столбца с названиями дней
                        for (int i = 2; i <= 12; i++)
                        {
                            worksheet.Column(i).Width = 25; // Увеличение ширины столбцов с уроками
                        }

                        // Рамка вокруг пересечений дней и классов
                        for (int i = 0; i < daysOfWeek.Length; i++)
                        {
                            for (int j = 1; j <= 11; j++)
                            {
                                worksheet.Cells[i * 9 + 2, j + 1, i * 9 + 9, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                            }
                        }

                        // Рамка вокруг всего расписания
                        worksheet.Cells[1, 1, 46, 12].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                        // Сохранение файла
                        FileInfo file = new FileInfo(filePath);
                        package.SaveAs(file);
                        MessageBox.Show($"Файл сохранен\nПуть: {filePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
