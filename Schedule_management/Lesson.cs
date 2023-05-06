using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "Урок"
    public class Lesson
    {
        public int Id { get; private set; } = -1;

        //Свойство "Имя"
        public string Name { get; set; }

        //Свойство "Преподаватель"
        public int Id_Teacher { get; set; }

        //Конструктор
        public Lesson(string name, int id_teacher)
        {
            Name = name;
            Id_Teacher = id_teacher;
        }

        public Lesson(int id, string name, int id_teacher)
        {
            Id = id;
            Name = name;
            Id_Teacher = id_teacher;
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

            if (Id == ((Lesson)obj).Id)
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
            return base.GetHashCode();
        }
    }
}
