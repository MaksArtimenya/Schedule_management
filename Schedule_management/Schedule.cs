using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Schedule
    {
        public int Number_Of_Class { get; private set; }

        public int Number_Of_Day { get; private set; }

        public int Number_Of_Lesson { get; private set; }

        public int Id_Lesson { get; set; }

        public Schedule(int number_Of_Class, int number_Of_Day, int number_Of_Lesson, int id_Lesson)
        {
            Number_Of_Class = number_Of_Class;
            Number_Of_Day = number_Of_Day;
            Number_Of_Lesson = number_Of_Lesson;
            Id_Lesson = id_Lesson;
        }

        public static Schedule GetSchedule(string scheduleString)
        {
            string[] strings = scheduleString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new Schedule(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), int.Parse(strings[3]));
        }
    }
}
