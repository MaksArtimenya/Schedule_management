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
        private static readonly string[] fileNamesOfClasses =
        {
            "class1.txt",
            "class2.txt",
            "class3.txt",
            "class4.txt",
            "class5.txt",
            "class6.txt",
            "class7.txt",
            "class8.txt",
            "class9.txt",
            "class10.txt",
            "class11.txt"
        };
        private static readonly string[] namesOfClasses =
        {
            "1 класс",
            "2 класс",
            "3 класс",
            "4 класс",
            "5 класс",
            "6 класс",
            "7 класс",
            "8 класс",
            "9 класс",
            "10 класс",
            "11 класс"
        };


        public static List<Class> ClassList { get; set; } = new List<Class>();

        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static void Initialization()
        {
            //Reading and creating Leason classes from files
            try
            {
                StreamReader lessonsReader = new StreamReader(lessonsFileName);
                string? line;
                while ((line = lessonsReader.ReadLine()) != null)
                {
                    Lessons.Add(new Lesson(line[6..line.IndexOf(';')], line[(line.LastIndexOf("teacher: ") + 9) ..]));
                }

                lessonsReader.Close();
            }
            catch (FileNotFoundException)
            {
                File.Create(lessonsFileName).Close();
            }

            //Reading and creating Class classes from files
            for (int i = 0; i < fileNamesOfClasses.Length; i++)
            {
                ClassList.Add(new Class(namesOfClasses[i]));
                try
                {
                    StreamReader classesReader = new StreamReader(fileNamesOfClasses[i]);
                    string? line;
                    int k = 0;
                    while ((line = classesReader.ReadLine()) != null)
                    {
                        if (line != ".......")
                        {
                            ClassList[i].Days[k].AddLesson(new Lesson(line[6..line.IndexOf(';')], line[(line.LastIndexOf("teacher: ") + 9)..]));
                        }
                        else
                        {
                            k++;
                        }
                    }

                    classesReader.Close();
                }
                catch (FileNotFoundException)
                {
                    File.Create(fileNamesOfClasses[i]).Close();
                }
            }
        }

        public static void SaveLessons()
        {
            StreamWriter lessonsWriter = new StreamWriter(lessonsFileName);
            for (int i = 0; i < Lessons.Count; i++)
            {
                lessonsWriter.WriteLine($"name: {Lessons[i].Name}; teacher: {Lessons[i].Teacher}");
            }

            lessonsWriter.Close();
        }
    }
}
