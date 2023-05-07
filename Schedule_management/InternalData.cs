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
        public static User User { get; private set; } = new User(string.Empty, -1);

        public static readonly int countOfClasses = 11;
        public static readonly int countOfLessons = 8;


        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public static List<Schedule> ScheduleList { get; set; } = new List<Schedule>();

        public static int IndexOfSelectedDay { get; set; }

        public static int IndexOfSelectedLesson { get; set; }

        public static void Initialization()
        {
            GetLessonsFromDB();
            GetTeachersFromDB();
            GetScheduleListFromDB();
        }

        public static void GetUserFromDB(string login, string password)
        {
            User = new User(string.Empty, -1);
            try
            {
                string sqlExpression = $"SELECT Name, Type_Of_User FROM Users WHERE Login = '{login}' AND Password = '{password}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    string userName = string.Empty;
                    int typeOfUser = -1;
                    while (reader.Read())
                    {
                        userName = reader.GetString(0);
                        typeOfUser = reader.GetInt32(1);
                    }

                    User = new User(userName, typeOfUser);

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
            try
            {
                string sqlExpression = $"DELETE FROM Lessons WHERE ID_Lesson = {lesson.Id}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
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

        public static void EditLesson(Lesson oldLesson, Lesson newLesson)
        {
            try
            {
                string sqlExpression = $"UPDATE Lessons SET Name = '{newLesson.Name}', ID_Teacher = {newLesson.Id_Teacher} " +
                    $"WHERE ID_Lesson = {oldLesson.Id}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
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

        public static void EditSchedule(Schedule oldSchedule, Schedule newSchedule)
        {
            try
            {
                string sqlExpression = $"UPDATE Schedule SET Number_Of_Class = {newSchedule.Number_Of_Class}, Number_Of_Day = {newSchedule.Number_Of_Day}, " +
                    $"Number_Of_Lesson = {newSchedule.Number_Of_Lesson}, ID_Lesson = {newSchedule.Id_Lesson} " +
                    $"WHERE Number_Of_Class = {oldSchedule.Number_Of_Class} AND Number_Of_Day = {oldSchedule.Number_Of_Day} AND " +
                    $"Number_Of_Lesson = {oldSchedule.Number_Of_Lesson} AND ID_Lesson = {oldSchedule.Id_Lesson}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
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

            return new Teacher(string.Empty);
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

        public static List<Lesson> GetLessonsByTeacher(Teacher teacher)
        {
            List<Lesson> result = new List<Lesson>();
            for (int i = 0; i < Lessons.Count; i++)
            {
                if (Lessons[i].Id_Teacher == teacher.Id)
                {
                    result.Add(Lessons[i]);
                }
            }

            return result;
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

        //Метод проверки занятости преподавателя в определённое время
        public static bool CheckingTeacher(Teacher teacher, out int nameOfClass, out int numberOfDay, out int numberOfLesson)
        {
            nameOfClass = -1;
            numberOfDay = -1;
            numberOfLesson = -1;

            if (teacher.Name == string.Empty)
            {
                return false;
            }

            List<Lesson> lessons = new List<Lesson>();
            for (int i = 0; i < Lessons.Count; i++)
            {
                if (Lessons[i].Id_Teacher == teacher.Id)
                {
                    lessons.Add(Lessons[i]);
                }
            }

            bool CheckingIdLesson(int id)
            {
                for (int i = 0; i < lessons.Count;i++)
                {
                    if (lessons[i].Id == id)
                    {
                        return true;
                    }
                }

                return false;
            }

            for (int i = 0; i < ScheduleList.Count; i++)
            {
                if (ScheduleList[i].Number_Of_Day == (IndexOfSelectedDay / countOfClasses) + 1 &&
                    ScheduleList[i].Number_Of_Lesson == IndexOfSelectedLesson + 1 &&
                    CheckingIdLesson(ScheduleList[i].Id_Lesson))
                {
                    nameOfClass = ScheduleList[i].Number_Of_Class;
                    numberOfDay = ScheduleList[i].Number_Of_Day;
                    numberOfLesson = ScheduleList[i].Number_Of_Lesson;
                    return true;
                }
            }

            return false;
        }
    }
}
