using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "День"
    internal class Day
    {
        //Константа "Кол-во уроков"
        private const int countOfLessons = 8;

        //Свойтсво "Уроки"
        public List<Lesson> lessons { get; set; } = new List<Lesson>();

        //Конструктор
        public Day()
        {
            for (int i = 0; i < countOfLessons; i++)
            {
                lessons.Add(new Lesson(string.Empty, string.Empty));
            }
        }

        //Метод добавления урока в список
        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }
    }
}
