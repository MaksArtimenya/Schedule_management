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
        private static readonly string separator = ".......";
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
        public static readonly int countOfClasses = 11;



        public static List<Class> ClassList { get; set; } = new List<Class>();

        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static int IndexOfSelectedDay { get; set; }

        public static int IndexOfSelectedLesson { get; set; }

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
                    int currentLesson = 0;
                    while ((line = classesReader.ReadLine()) != null)
                    {
                        if (line != separator)
                        {
                            try
                            {
                                ClassList[i].Days[k].lessons[currentLesson] = new Lesson(line[6..line.IndexOf(';')], line[(line.LastIndexOf("teacher: ") + 9)..]);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                ClassList[i].Days[k].AddLesson(new Lesson(line[6..line.IndexOf(';')], line[(line.LastIndexOf("teacher: ") + 9)..]));
                            }

                            currentLesson++;
                        }
                        else
                        {
                            k++;
                            currentLesson = 0;
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

        //Save lessons into file
        public static void SaveLessons()
        {
            StreamWriter lessonsWriter = new StreamWriter(lessonsFileName);
            for (int i = 0; i < Lessons.Count; i++)
            {
                lessonsWriter.WriteLine($"name: {Lessons[i].Name}; teacher: {Lessons[i].Teacher}");
            }

            lessonsWriter.Close();
        }

        //Save classes into files
        public static void SaveClasses()
        {
            for (int i = 0; i < fileNamesOfClasses.Length; i++)
            {
                StreamWriter classesWriter = new StreamWriter(fileNamesOfClasses[i]);
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].lessons.Count; currentLesson++)
                    {
                        classesWriter.WriteLine($"name: {ClassList[i].Days[k].lessons[currentLesson].Name}; " +
                            $"teacher: {ClassList[i].Days[k].lessons[currentLesson].Teacher}");
                    }
                    classesWriter.WriteLine(separator);
                }

                classesWriter.Close();
            }
        }

        public static void ChekingClassesForEditingLesson(Lesson checkedLesson, Lesson editedLesson)
        {
            for (int i = 0; i < ClassList.Count; i++)
            {
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].lessons.Count; currentLesson++)
                    {
                        if (ClassList[i].Days[k].lessons[currentLesson].Equals(checkedLesson))//(Equals(ClassList[i].Days[k].lessons[currentLesson], checkedLesson))
                        {
                            ClassList[i].Days[k].lessons[currentLesson] = editedLesson;
                        }
                    }
                }
            }
        }

        public static void CheckingClassesForRemovingLesson(Lesson checkedLesson)
        {
            for (int i = 0; i < ClassList.Count; i++)
            {
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].lessons.Count; currentLesson++)
                    {
                        if (ClassList[i].Days[k].lessons[currentLesson].Equals(checkedLesson))//(Equals(ClassList[i].Days[k].lessons[currentLesson], checkedLesson))
                        {
                            ClassList[i].Days[k].lessons[currentLesson] = new Lesson(string.Empty, string.Empty);
                        }
                    }
                }
            }
        }

        public static void ClearSchedule()
        {
            for (int i = 0; i < fileNamesOfClasses.Length; i++)
            {
                File.Delete(fileNamesOfClasses[i]);
            }

            ClassList = new List<Class>();
            Lessons = new List<Lesson>();
            Initialization();
        }

        public static void ClearLessons()
        {
            File.Delete(lessonsFileName);
            Lessons = new List<Lesson>();
        }
    }
}
