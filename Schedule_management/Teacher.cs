using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "Преподаватель"
    internal class Teacher
    {
        public int Id { get; private set; } = -1;

        //Свойство "Имя"
        public string Name { get; set; }


        //Конструктор
        public Teacher(string name)
        {
            Name = name;
        }
        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //Переопределение метода "Изменить имя"
        public void ChangeName(string newName)
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

            if (Id == ((Teacher)obj).Id)
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
