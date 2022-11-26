using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Day
    {
        private const int countOfLessons = 8;

        public List<Lesson> lessons { get; set; } = new List<Lesson>();

        public Day()
        {
            for (int i = 0; i < countOfLessons; i++)
            {
                lessons.Add(new Lesson(string.Empty, string.Empty));
            }
        }

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }
    }
}
