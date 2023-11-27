namespace Schedule_management.Objects
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

        public static User GetUser(string userString)
        {
            string[] strings = userString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new User(strings[0], int.Parse(strings[1]));
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
