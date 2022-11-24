using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Day
    {
        public List<Lesson> lessons { get; set; } = new List<Lesson>();

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }
    }
}
