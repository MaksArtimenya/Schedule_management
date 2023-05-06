using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "День"
    internal class Day : ILessonManagement
    {
        //Константа "Кол-во уроков"
        private const int countOfLessons = 8;

        //Свойтсво "Уроки"
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        //Конструктор
        public Day()
        {
            for (int i = 0; i < countOfLessons; i++)
            {
                //Lessons.Add(new Lesson(string.Empty, new Teacher(string.Empty)));
            }
        }

        //Определение метода добавления урока в список
        public void AddLesson(Lesson lesson)
        {
            Lessons.Add(lesson);
        }
    }
}
