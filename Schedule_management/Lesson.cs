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
            if (Name != string.Empty)
            {
                return Name; //+ $" ({Teacher})";
            }
            else
            {
                return "-";
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Lesson)
            {
                return false;
            }

            if (obj == null)
            {
                return false;
            }

            if (this.Name == ((Lesson)obj).Name && this.Teacher == ((Lesson)obj).Teacher)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
