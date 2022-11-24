using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Lesson
    {
        public string Name { get; set; }

        public string Teacher { get; set; }

        public Lesson(string name, string teacher)
        {
            Name = name;
            Teacher = teacher;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
