using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Класс "внутренние данные"
    internal static class InternalData
    {
        private static readonly string lessonsFileName = "lessons.txt";   //Переменная имени файла, содержащего список уроков
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
        };   //Массив имён файлов, содержащих классы
        private static readonly string separator = ".......";   //Переменная "разделитель" (используется в файлах для разделения информации)
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
        };   //Массив имён классов
        public static readonly int countOfClasses = 11;   //Переменная "Кол-во классов"


        //Свойство "Список классов"
        public static List<Class> ClassList { get; set; } = new List<Class>();

        //Свойство "Уроки"
        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();

        //Свойтсво "Индекс выбранного дня"
        public static int IndexOfSelectedDay { get; set; }

        //Свойство "Индекс выбранного урока"
        public static int IndexOfSelectedLesson { get; set; }

        //Метод "Инициализация"
        public static void Initialization()
        {
            //Чтение файла и заполнение списка уроков
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

            //Чтение файлов и заполнение списка классов
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
                                ClassList[i].Days[k].Lessons[currentLesson] = new Lesson(line[6..line.IndexOf(';')], line[(line.LastIndexOf("teacher: ") + 9)..]);
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

        //Метод сохранения списка уроков в файл
        public static void SaveLessons()
        {
            StreamWriter lessonsWriter = new StreamWriter(lessonsFileName);
            for (int i = 0; i < Lessons.Count; i++)
            {
                lessonsWriter.WriteLine($"name: {Lessons[i].Name}; teacher: {Lessons[i].Teacher}");
            }

            lessonsWriter.Close();
        }

        //Метод сохранения списка классов в файлы
        public static void SaveClasses()
        {
            for (int i = 0; i < fileNamesOfClasses.Length; i++)
            {
                StreamWriter classesWriter = new StreamWriter(fileNamesOfClasses[i]);
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].Lessons.Count; currentLesson++)
                    {
                        classesWriter.WriteLine($"name: {ClassList[i].Days[k].Lessons[currentLesson].Name}; " +
                            $"teacher: {ClassList[i].Days[k].Lessons[currentLesson].Teacher}");
                    }
                    classesWriter.WriteLine(separator);
                }

                classesWriter.Close();
            }
        }

        //Метод очистки расписания
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

        //Метод очистки списка уроков
        public static void ClearLessons()
        {
            File.Delete(lessonsFileName);
            Lessons = new List<Lesson>();
        }



        //Вспомогательные методы:

        //Метод поиска и замены уроков на новый
        public static void ChekingClassesForEditingLesson(Lesson checkedLesson, Lesson editedLesson)
        {
            for (int i = 0; i < ClassList.Count; i++)
            {
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].Lessons.Count; currentLesson++)
                    {
                        if (ClassList[i].Days[k].Lessons[currentLesson].Equals(checkedLesson))
                        {
                            ClassList[i].Days[k].Lessons[currentLesson] = editedLesson;
                        }
                    }
                }
            }
        }

        //Метод поиска и удаления уроков
        public static void CheckingClassesForRemovingLesson(Lesson checkedLesson)
        {
            for (int i = 0; i < ClassList.Count; i++)
            {
                for (int k = 0; k < ClassList[i].Days.Count; k++)
                {
                    for (int currentLesson = 0; currentLesson < ClassList[i].Days[k].Lessons.Count; currentLesson++)
                    {
                        if (ClassList[i].Days[k].Lessons[currentLesson].Equals(checkedLesson))
                        {
                            ClassList[i].Days[k].Lessons[currentLesson] = new Lesson(string.Empty, string.Empty);
                        }
                    }
                }
            }
        }

        //Метод проверки занятости преподавателя в определённое время
        public static bool CheckingTeacher(string teacher, out string nameOfClass, out int numberOfDay, out int numberOfLesson)
        {
            nameOfClass = string.Empty;
            numberOfDay = -1;
            numberOfLesson = -1;

            if (teacher == string.Empty)
            {
                return false;
            }

            for (int i = 0; i < ClassList.Count; i++)
            {
                if (ClassList[i].Days[IndexOfSelectedDay / countOfClasses].Lessons[IndexOfSelectedLesson].Teacher == teacher)
                {
                    nameOfClass = ClassList[i].Name;
                    numberOfDay = (IndexOfSelectedDay / countOfClasses) + 1;
                    numberOfLesson = IndexOfSelectedLesson + 1;
                    return true;
                }
            }

            return false;
        }
    }
}
