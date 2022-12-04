using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Абстрактный класс "Человек"
    abstract class Person
    {
        //Свойство "Имя"
        public string Name { get; set; }

        //Конструктор
        protected Person(string name)
        {
            Name = name;
        }

        //Абстрактный метод "Изменить имя"
        abstract public void ChangeName(string newName);
    }
}
