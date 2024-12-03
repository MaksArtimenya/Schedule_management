using Schedule_management.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule_management.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void buttonSaveReport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = $"{comboBoxTypeOfReport.Text}.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, labelReport.Text);
            }
        }

        private void comboBoxTypeOfReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSaveReport.Enabled = true;
            switch (comboBoxTypeOfReport.SelectedIndex)
            {
                case 0:
                    CreateTeachersWorkloadReport();
                    break;
                case 1:
                    CreateClassesWorkloadReport();
                    break;
            }
        }

        private void CreateTeachersWorkloadReport()
        {
            int[] GetWorkloadOfTeacher(List<Lesson> lessons)
            {
                int[] result = new int[] { 0, 0, 0, 0, 0, 0 };
                foreach (Schedule schedule in Internal.InternalData.ScheduleList)
                {
                    foreach (Lesson lesson in lessons)
                    {
                        if (schedule.Id_Lesson == lesson.Id)
                        {
                            result[0] += 1;
                            result[schedule.Number_Of_Day] += 1;
                            break;
                        }
                    }
                }

                return result;
            }
            labelReport.Text = $"ОТЧЕТ О НАГРУЗКЕ ПРЕПОДАВАТЕЛЕЙ\n{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}\n\n\n";
            foreach (Teacher teacher in Internal.InternalData.Teachers)
            {
                int[] workload = GetWorkloadOfTeacher(Internal.InternalData.GetLessonsByTeacher(teacher));
                labelReport.Text += $"{teacher.Name.Trim()} (Общая нагрузка: {workload[0]})" +
                    $"\n*Понедельник: {workload[1]}" +
                    $"\n*Вторник: {workload[2]}" +
                    $"\n*Среда: {workload[3]}" +
                    $"\n*Четверг: {workload[4]}" +
                    $"\n*Пятница: {workload[5]}" +
                    $"\n-------------------------------------------\n\n";
            }
        }

        private void CreateClassesWorkloadReport()
        {
            void GetWorklodOfClasses(int numberOfClass, out int[] workloadByDays, out List<int> worklodByLessons)
            {
                workloadByDays = new int[] { 0, 0, 0, 0, 0, 0 };
                worklodByLessons = new List<int>();
                foreach (Lesson lesson in  Internal.InternalData.Lessons)
                {
                    worklodByLessons.Add(0);
                }

                foreach (Schedule schedule in Internal.InternalData.ScheduleList)
                {
                    if (schedule.Number_Of_Class == numberOfClass)
                    {
                        workloadByDays[0] += 1;
                        workloadByDays[schedule.Number_Of_Day] += 1;
                        for (int i = 0; i < Internal.InternalData.Lessons.Count; i++)
                        {
                            if (schedule.Id_Lesson == Internal.InternalData.Lessons[i].Id)
                            {
                                worklodByLessons[i] += 1;
                                break;
                            }
                        }
                    }
                }
            }
            labelReport.Text = $"ОТЧЕТ О ЗАНЯТОСТИ ОБУЧАЮЩИХСЯ\n{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}\n\n\n";
            for (int i = 1; i <= Internal.InternalData.countOfClasses; i++)
            {
                int[] workloadByDays;
                List<int> worklodByLessons;
                GetWorklodOfClasses(i, out workloadByDays, out worklodByLessons);
                labelReport.Text += $"{i} класс (Общее кол-во занятий: {workloadByDays[0]})" +
                    $"\nКол-во занятий по дням" +
                    $"\n*Понедельник: {workloadByDays[1]}" +
                    $"\n*Вторник: {workloadByDays[2]}" +
                    $"\n*Среда: {workloadByDays[3]}" +
                    $"\n*Четверг: {workloadByDays[4]}" +
                    $"\n*Пятница: {workloadByDays[5]}\n" +
                    $"\nКол-во занятий по предметам";
                for (int j = 0; j < Internal.InternalData.Lessons.Count; j++)
                {
                    if (worklodByLessons[j] != 0)
                    {
                        labelReport.Text += $"\n-{Internal.InternalData.Lessons[j].Name.Trim()}: {worklodByLessons[j]}";
                    }
                }

                labelReport.Text += "\n-------------------------------------------\n\n";
            }
        }
    }
}
