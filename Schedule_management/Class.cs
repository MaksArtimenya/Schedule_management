using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Class
    {
        private const int numberOfDays = 5;

        public string Name { get; }

        public List<Day> Days { get; set; } = new List<Day>();

        public Class(string name)
        {
            Name = name;
            for (int i = 0; i < numberOfDays; i++)
            {
                Days.Add(new Day());
            }
        }
    }
}
