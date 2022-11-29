using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "Класс"
    internal class Class
    {
        //Константа "Кол-во дней"
        private const int numberOfDays = 5;

        //Свойство "Имя"
        public string Name { get; }

        //Свойтво "Дни"
        public List<Day> Days { get; set; } = new List<Day>();

        //Конструктор
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
