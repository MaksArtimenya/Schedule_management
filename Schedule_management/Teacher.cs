using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class Teacher
    {
        public int Id { get; private set; } = -1;

        public string Name { get; set; }


        public Teacher(string name)
        {
            Name = name;
        }
        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public override string ToString()
        {
            return Name;
        }

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

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
