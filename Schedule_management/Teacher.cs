using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "Преподаватель"
    internal class Teacher : Person
    {
        //Конструктор
        public Teacher(string name) : base(name)
        {
        }

        //Переопределение метода "Изменить имя"
        public override void ChangeName(string newName)
        {
            Name = newName;
        }

        //Переопределение метода ToString
        public override string ToString()
        {
            return Name;
        }

        //Переопределение метода Equals
        public override bool Equals(object? obj)
        {
            if (obj is not Teacher)
            {
                return false;
            }

            if (obj is null)
            {
                return false;
            }

            if (Name == ((Teacher)obj).Name)
            {
                return true;
            }

            return false;
        }

        //Переопределение метода GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
