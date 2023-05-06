using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal static class InternalData
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=ScheduleDB;Integrated Security=true";

        /*private static readonly string lessonsFileName = "lessons.txt";   //Переменная имени файла, содержащего список уроков
        private static readonly string[] fileNamesOfClasses =
        {
            "class1.txt",
            "class2.txt",
            "class3.txt",
            "class4.txt",
            "class5.txt",
            "class6.txt",
            "class7.txt",
            "class8.txt",
            "class9.txt",
            "class10.txt",
            "class11.txt"
        };   //Массив имён файлов, содержащих классы
        private static readonly string separator = ".......";   //Переменная "разделитель" (используется в файлах для разделения информации)
        private static readonly string[] namesOfClasses =
        {
            "1 класс",
            "2 класс",
            "3 класс",
            "4 класс",
            "5 класс",
            "6 класс",
            "7 класс",
            "8 класс",
            "9 класс",
            "10 класс",
            "11 класс"
        };   //Массив имён классов*/
        public static readonly int countOfClasses = 11;   //Переменная "Кол-во классов"
        public static readonly int countOfLessons = 8;


        //public static List<Class> ClassList { get; set; } = new List<Class>();

        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public static List<Schedule> ScheduleList { get; set; } = new List<Schedule>();

        //Свойтсво "Индекс выбранного дня"
        public static int IndexOfSelectedDay { get; set; }

        //Свойство "Индекс выбранного урока"
        public static int IndexOfSelectedLesson { get; set; }

        //Метод "Инициализация"
        public static void Initialization()
        {
            GetLessonsFromDB();
            GetTeachersFromDB();
            GetScheduleListFromDB();
        }

        public static void GetLessonsFromDB()
        {
            try
            {
                string sqlExpression = "SELECT * FROM Lessons";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    Lessons.Clear();
                    while (reader.Read())
                    {
                        Lessons.Add(new Lesson(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddLesson(Lesson lesson)
        {
            try
            {
                string sqlExpression = $"INSERT INTO Lessons (Name, ID_Teacher) VALUES " +
                    $"('{lesson.Name}', {lesson.Id_Teacher})";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Added: {number}");
                    connection.Close();
                }

                GetLessonsFromDB();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void RemoveLesson(Lesson lesson)
        {
            Lessons.Remove(lesson);
            try
            {
                string sqlExpression = $"DELETE FROM Lessons WHERE ID_Lesson = {lesson.Id}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Removed: {number}");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void EditLesson(Lesson oldLesson, Lesson newLesson)
        {
            try
            {
                string sqlExpression = $"UPDATE Lessons SET Name = {newLesson.Name}, ID_Teacher = {newLesson.Id_Teacher} " +
                    $"WHERE ID_Lesson = {oldLesson.Id}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Updated: {number}");
                    connection.Close();
                }

                GetLessonsFromDB();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetTeachersFromDB()
        {
            try
            {
                string sqlExpression = "SELECT * FROM Teachers";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    Teachers.Clear();
                    while (reader.Read())
                    {
                        Teachers.Add(new Teacher(reader.GetInt32(0), reader.GetString(1)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void GetScheduleListFromDB()
        {
            try
            {
                string sqlExpression = "SELECT * FROM Schedule";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    ScheduleList.Clear();
                    while (reader.Read())
                    {
                        ScheduleList.Add(new Schedule(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddSchedule(Schedule schedule)
        {
            try
            {
                string sqlExpression = $"INSERT INTO Schedule (Number_Of_Class, Number_Of_Day, Number_Of_lesson, ID_Lesson) VALUES " +
                    $"({schedule.Number_Of_Class}, {schedule.Number_Of_Day}, {schedule.Number_Of_Lesson}, {schedule.Id_Lesson})";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Added: {number}");
                    connection.Close();
                }

                GetScheduleListFromDB();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void RemoveSchedule(Schedule schedule)
        {
            ScheduleList.Remove(schedule);
            try
            {
                string sqlExpression = $"DELETE FROM Schedule " +
                    $"WHERE Number_Of_Class = {schedule.Number_Of_Class} AND Number_Of_Day = {schedule.Number_Of_Day} AND " +
                    $"Number_Of_Lesson = {schedule.Number_Of_Lesson} AND ID_Lesson = {schedule.Id_Lesson}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Removed: {number}");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void EditSchedule(Schedule oldSchedule, Schedule newSchedule)
        {
            try
            {
                string sqlExpression = $"UPDATE Schedules SET Number_Of_Class = {newSchedule.Number_Of_Class}, Number_Of_Day = {newSchedule.Number_Of_Day}, " +
                    $"Number_Of_Lesson = {newSchedule.Number_Of_Lesson}, ID_Lesson = {newSchedule.Id_Lesson} " +
                    $"WHERE Number_Of_Class = {oldSchedule.Number_Of_Class} AND Number_Of_Day = {oldSchedule.Number_Of_Day} AND " +
                    $"Number_Of_Lesson = {oldSchedule.Number_Of_Lesson} AND ID_Lesson = {oldSchedule.Id_Lesson}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Updated: {number}");
                    connection.Close();
                }

                GetScheduleListFromDB();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static Teacher GetTeacherByID(int id)
        {
            for (int i = 0; i < Teachers.Count; i++)
            {
                if (Teachers[i].Id == id)
                {
                    return Teachers[i];
                }
            }

            return new Teacher("Unknown");
        }

        public static Lesson GetLessonByID(int id)
        {
            for (int i = 0; i < Lessons.Count; i++)
            {
                if (Lessons[i].Id == id)
                {
                    return Lessons[i];
                }
            }

            return new Lesson(string.Empty, -1);
        }

        public static int CheckingSchedule(int number_Of_Class, int number_Of_Day, int number_Of_Lesson)
        {
            for (int i = 0; i < ScheduleList.Count; i++)
            {
                if (ScheduleList[i].Number_Of_Class ==  number_Of_Class && ScheduleList[i].Number_Of_Day == number_Of_Day 
                    && ScheduleList[i].Number_Of_Lesson == number_Of_Lesson)
                {
                    return ScheduleList[i].Id_Lesson;
                }
            }

            return -1;
        }





        /*//Метод сохранения списка уроков в файл
        public static void SaveLessons()
        {
            StreamWriter lessonsWriter = new StreamWriter(lessonsFileName);
            for (int i = 0; i < Lessons.Count; i++)
            {
                lessonsWriter.WriteLine($"name: {Lessons[i].Name}; teacher: {Lessons[i].Teacher.Name}");
            }

            lessonsWriter.Close();
        }

        //Метод сохранения списка классов в файлы
        public static void SaveClasses()
        {
            for (int i = 0; i < fileNamesOfClasses.Length; i++)
            {
                StreamWriter classesWriter = new StreamWriter(fileNamesOfClasses[i]);
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].Lessons.Count; currentLesson++)
                    {
                        classesWriter.WriteLine($"name: {ClassList[i].Days[k].Lessons[currentLesson].Name}; " +
                            $"teacher: {ClassList[i].Days[k].Lessons[currentLesson].Teacher.Name}");
                    }
                    classesWriter.WriteLine(separator);
                }

                classesWriter.Close();
            }
        }*/

        //Метод очистки расписания
        public static void ClearSchedule()
        {
            try
            {
                string sqlExpression = $"DELETE FROM Schedule";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        //Метод очистки списка уроков
        public static void ClearLessons()
        {
            try
            {
                string sqlExpression = $"DELETE FROM Lessons";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    connection.Close();
                }

                Initialization();
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }



        //Вспомогательные методы:

        /*//Метод поиска и замены уроков на новый
        public static void ChekingClassesForEditingLesson(Lesson checkedLesson, Lesson editedLesson)
        {
            for (int i = 0; i < ClassList.Count; i++)
            {
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].Lessons.Count; currentLesson++)
                    {
                        if (ClassList[i].Days[k].Lessons[currentLesson].Equals(checkedLesson))
                        {
                            ClassList[i].Days[k].Lessons[currentLesson] = editedLesson;
                        }
                    }
                }
            }
        }

        //Метод поиска и удаления уроков
        public static void CheckingClassesForRemovingLesson(Lesson checkedLesson)
        {
            for (int i = 0; i < ClassList.Count; i++)
            {
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].Lessons.Count; currentLesson++)
                    {
                        if (ClassList[i].Days[k].Lessons[currentLesson].Equals(checkedLesson))
                        {
                            ClassList[i].Days[k].Lessons[currentLesson] = new Lesson(string.Empty, new Teacher(string.Empty));
                        }
                    }
                }
            }
        }*/

        //Метод проверки занятости преподавателя в определённое время
        /*public static bool CheckingTeacher(Teacher teacher, out string nameOfClass, out int numberOfDay, out int numberOfLesson)
        {
            nameOfClass = string.Empty;
            numberOfDay = -1;
            numberOfLesson = -1;

            if (teacher.Name == string.Empty)
            {
                return false;
            }

            for (int i = 0; i < ClassList.Count; i++)
            {
                if (ClassList[i].Days[IndexOfSelectedDay / countOfClasses].Lessons[IndexOfSelectedLesson].Teacher.Equals(teacher))
                {
                    nameOfClass = ClassList[i].Name;
                    numberOfDay = (IndexOfSelectedDay / countOfClasses) + 1;
                    numberOfLesson = IndexOfSelectedLesson + 1;
                    return true;
                }
            }

            return false;
        }*/
    }
}
