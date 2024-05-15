namespace Schedule_management.Objects
{
    internal class Teacher
    {
        public int Id { get; private set; } = -1;
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }
        public int Skill { get; set; }
        public int Education { get; set; }

        public Teacher(int id, string name, string gender, int experience, int skill, int education)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Experience = experience;
            Skill = skill;
            Education = education;
        }

        public Teacher(string name, string gender, int experience, int skill, int education)
        {
            Name = name;
            Gender = gender;
            Experience = experience;
            Skill = skill;
            Education = education;
        }

        public static Teacher GetTeacher(string teacherString)
        {
            string[] strings = teacherString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new Teacher(int.Parse(strings[0]), strings[1], strings[2], int.Parse(strings[3]), int.Parse(strings[4]), int.Parse(strings[5]));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
