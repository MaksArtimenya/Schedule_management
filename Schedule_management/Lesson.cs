﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    public class Lesson
    {
        public int Id { get; private set; } = -1;

        public string Name { get; set; }

        public int Id_Teacher { get; set; }

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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
