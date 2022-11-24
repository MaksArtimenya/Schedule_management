using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    internal static class InternalData
    {
        private static readonly string lessonsFileName = "lessons.txt";

        public static List<Class> ClassList { get; set; } = new List<Class>();

        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static void Initialization()
        {
            try
            {
                StreamReader lessonsReader = new StreamReader(lessonsFileName);
                string? line;
                while ((line = lessonsReader.ReadLine()) != null)
                {
                    Lessons.Add(new Lesson(line[6..line.IndexOf(';')], line[line.LastIndexOf("teacher: ")..]));
                }

                lessonsReader.Close();
            }
            catch (FileNotFoundException)
            {
                File.Create(lessonsFileName).Close();
            }
        }
    }
}
