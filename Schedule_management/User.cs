using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal class User
    {
        public string Name { get; }

        public int TypeOfUser { get; }

        public User(string name, int typeOfUser)
        {
            Name = name;
            TypeOfUser = typeOfUser;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not User)
            {
                return false;
            }

            if (obj is null)
            {
                return false;
            }

            if (Name == ((User)obj).Name && TypeOfUser == ((User)obj).TypeOfUser)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
