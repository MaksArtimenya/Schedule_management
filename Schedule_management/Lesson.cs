using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "Урок"
    internal class Lesson
    {
        //Свойство "Имя"
        public string Name { get; set; }

        //Свойство "Преподаватель"
        public Teacher Teacher { get; set; }

        //Конструктор
        public Lesson(string name, Teacher teacher)
        {
            Name = name;
            Teacher = teacher;
        }

        //Переопределение метода ToString
        public override string ToString()
        {
            if (Name != string.Empty)
            {
                return Name;
            }
            else
            {
                return "-";
            }
        }

        //Переопределение метода Equals
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

            if (Name == ((Lesson)obj).Name && Teacher.Name == ((Lesson)obj).Teacher.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Переопределение метода GetHashCode
        public override int GetHashCode()
        {
            return (Name + Teacher.ToString()).GetHashCode();
        }
    }
}
