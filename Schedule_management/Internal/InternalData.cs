using System.Net.Sockets;
using System.Text;
using Schedule_management.Objects;

namespace Schedule_management.Internal
{
    internal static class InternalData
    {
        public static readonly SignInForm signInForm = new SignInForm();
        public static TcpClient? Client { get; private set; }
        public static NetworkStream? NetworkStream { get; private set; }
        public static User User { get; private set; } = new User(string.Empty, -1);

        public static readonly int countOfClasses = 11;
        public static readonly int countOfLessons = 8;
        public static bool IsConnected { get; private set; }


        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public static List<Schedule> ScheduleList { get; set; } = new List<Schedule>();

        public static int IndexOfSelectedDay { get; set; }

        public static int IndexOfSelectedLesson { get; set; }

        public static void Initialization()
        {
            GetLessonsFromServer();
            GetTeachersFromServer();
            GetScheduleListFromServer();
        }

        public static void GetUserFromServer(string login, string password, string ipAddress, string port)
        {
            User = new User(string.Empty, -1);
            try
            {
                Client = new TcpClient(ipAddress, int.Parse(port));
                NetworkStream = Client.GetStream();

                string message = $"Connect\nSELECT Name, Type_Of_User FROM Users WHERE Login = '{login}' AND Password = '{password}'";

                byte[] data = Encoding.Unicode.GetBytes(message);
                NetworkStream.Write(data, 0, data.Length);
                data = new byte[2048];
                StringBuilder response = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = NetworkStream.Read(data, 0, data.Length);
                    response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (NetworkStream.DataAvailable);

                message = response.ToString();

                User = User.GetUser(message);
                IsConnected = true;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Пользователь не найден");
                if (Client is not null && NetworkStream is not null)
                {
                    Client.Close();
                    NetworkStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetLessonsFromServer()
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = "GetLessons\nSELECT * FROM Lessons";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    Lessons.Clear();
                    if (message != "empty")
                    {
                        string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        while (i < strings.Length)
                        {
                            string lesssonString = string.Empty;
                            for (int j = 0; j < 3; j++)
                            {
                                lesssonString += strings[i + j] + "\n";
                            }

                            Lessons.Add(Lesson.GetLesson(lesssonString));
                            i += 3;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddLesson(Lesson lesson)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nINSERT INTO Lessons (Name, ID_Teacher) VALUES " +
                        $"('{lesson.Name}', {lesson.Id_Teacher})";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetLessonsFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add lesson: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveLesson(Lesson lesson)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nDELETE FROM Lessons WHERE ID_Lesson = {lesson.Id}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        Initialization();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to remove lesson: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EditLesson(Lesson oldLesson, Lesson newLesson)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nUPDATE Lessons SET Name = '{newLesson.Name}', ID_Teacher = {newLesson.Id_Teacher} " +
                        $"WHERE ID_Lesson = {oldLesson.Id}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        Initialization();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to edit lesson: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetTeachersFromServer()
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = "GetTeachers\nSELECT * FROM Teachers";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    Teachers.Clear();
                    if (message != "empty")
                    {
                        string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        while (i < strings.Length)
                        {
                            string teachersString = string.Empty;
                            for (int j = 0; j < 6; j++)
                            {
                                teachersString += strings[i + j] + "\n";
                            }

                            Teachers.Add(Teacher.GetTeacher(teachersString));
                            i += 6;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddTeacher(Teacher teacher)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nINSERT INTO Teachers (Full_Name, Gender, Experience, Skill, Education) VALUES " +
                        $"('{teacher.Name}', '{teacher.Gender}', {teacher.Experience}, {teacher.Skill}, {teacher.Education})";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetTeachersFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add teacher: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveTeacher(Teacher teacher)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nDELETE FROM Teachers " +
                        $"WHERE ID_Teacher = {teacher.Id}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        Initialization();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to remove teacher: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EditTeacher(Teacher oldTeacher, Teacher newTeacher)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nUPDATE Teachers SET Full_Name = '{newTeacher.Name}', Gender = '{newTeacher.Gender}', " +
                        $"Experience = {newTeacher.Experience}, Skill = {newTeacher.Skill}, Education = {newTeacher.Education} " +
                        $"WHERE ID_Teacher = {oldTeacher.Id}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetTeachersFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to edit teacher: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetScheduleListFromServer()
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = "GetSchedule\nSELECT * FROM Schedule";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    ScheduleList.Clear();
                    if (message != "empty")
                    {
                        string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        while (i < strings.Length)
                        {
                            string scheduleString = string.Empty;
                            for (int j = 0; j < 4; j++)
                            {
                                scheduleString += strings[i + j] + "\n";
                            }

                            ScheduleList.Add(Schedule.GetSchedule(scheduleString));
                            i += 4;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddSchedule(Schedule schedule)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nINSERT INTO Schedule (Number_Of_Class, Number_Of_Day, Number_Of_lesson, ID_Lesson) VALUES " +
                        $"({schedule.Number_Of_Class}, {schedule.Number_Of_Day}, {schedule.Number_Of_Lesson}, {schedule.Id_Lesson})";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetScheduleListFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add schedule: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveSchedule(Schedule schedule)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nDELETE FROM Schedule " +
                        $"WHERE Number_Of_Class = {schedule.Number_Of_Class} AND Number_Of_Day = {schedule.Number_Of_Day} AND " +
                        $"Number_Of_Lesson = {schedule.Number_Of_Lesson} AND ID_Lesson = {schedule.Id_Lesson}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetScheduleListFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to remove schedule: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EditSchedule(Schedule oldSchedule, Schedule newSchedule)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nUPDATE Schedule SET Number_Of_Class = {newSchedule.Number_Of_Class}, Number_Of_Day = {newSchedule.Number_Of_Day}, " +
                        $"Number_Of_Lesson = {newSchedule.Number_Of_Lesson}, ID_Lesson = {newSchedule.Id_Lesson} " +
                        $"WHERE Number_Of_Class = {oldSchedule.Number_Of_Class} AND Number_Of_Day = {oldSchedule.Number_Of_Day} AND " +
                        $"Number_Of_Lesson = {oldSchedule.Number_Of_Lesson} AND ID_Lesson = {oldSchedule.Id_Lesson}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetScheduleListFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to edit schedule: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ClearSchedule()
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nDELETE FROM Schedule";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        Initialization();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete schedule: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ClearLessons()
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nDELETE FROM Lessons";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        Initialization();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete lessons: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DisconnectFromServer()
        {
            try
            {
                if (NetworkStream is not null && Client is not null)
                {
                    if (IsConnected)
                    {
                        string message = $"Disconnect";
                        byte[] data = Encoding.Unicode.GetBytes(message);
                        NetworkStream.Write(data, 0, data.Length);
                    }

                    NetworkStream.Close();
                    Client.Close();
                    IsConnected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void TestingConnection()
        {
            try
            {
                if (signInForm.IPEndPoint is null || NetworkStream is null)
                {
                    IsConnected = false;
                }
                else
                {
                    string message = $"Test";

                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                }
            }
            catch
            {
                IsConnected = false;
                if (NetworkStream is not null && Client is not null)
                {
                    NetworkStream.Close();
                    Client.Close();
                }
            }
        }

        public static void ReconnectToServer()
        {
            try
            {
                if (Client is not null && signInForm.IPEndPoint is not null)
                {
                    Client = new TcpClient(signInForm.IPEndPoint.Address.ToString(), signInForm.IPEndPoint.Port);
                    NetworkStream = Client.GetStream();

                    string message = $"Reconnect\n{User.Name}\n{User.TypeOfUser}";

                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    IsConnected = true;
                }
            }
            catch
            {
                IsConnected = false;
            }
        }

        //Вспомогательные методы:

        public static string GetWorkload(Teacher teacher)
        {
            string result = string.Empty;
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"GetWorkload\n{teacher.Id}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    result = message;
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

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
                for (int i = 0; i < lessons.Count; i++)
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
                if (ScheduleList[i].Number_Of_Day == IndexOfSelectedDay / countOfClasses + 1 &&
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

        public static Teacher GetTeacherByID(int id)
        {
            for (int i = 0; i < Teachers.Count; i++)
            {
                if (Teachers[i].Id == id)
                {
                    return Teachers[i];
                }
            }

            return new Teacher(string.Empty, string.Empty, -1, -1, -1);
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
                if (ScheduleList[i].Number_Of_Class == number_Of_Class && ScheduleList[i].Number_Of_Day == number_Of_Day
                    && ScheduleList[i].Number_Of_Lesson == number_Of_Lesson)
                {
                    return ScheduleList[i].Id_Lesson;
                }
            }

            return -1;
        }
    }
}
