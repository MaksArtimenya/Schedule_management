using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_management
{
    //Интерфейс "Управление уроками"
    internal interface ILessonManagement
    {
        //Метод добавления урока в список
        public void AddLesson(Lesson lesson);
    }
}
