using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Day
    {
        private readonly List<Lesson> lessons = new List<Lesson>();

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }
    }
}
