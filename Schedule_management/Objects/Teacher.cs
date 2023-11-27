namespace Schedule_management.Objects
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

        public static Teacher GetTeacher(string teacherString)
        {
            string[] strings = teacherString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new Teacher(int.Parse(strings[0]), strings[1]);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
