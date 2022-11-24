using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Class
    {
        public string Name { get; }

        public List<Day> Days { get; set; } = new List<Day>();

        public Class(string name)
        {
            Name = name;
        }

        public void AddDay(Day day)
        {
            Days.Add(day);
        }
    }
}
