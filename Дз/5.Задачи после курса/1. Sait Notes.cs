using System;
using System.IO; //пространство имен
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Обучение_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public class Notes
        {
            public string NoteName { get; set; } //private set наставил я а не нейронка по двум причинам 
                                                 //1. По видосу Сакутина
                                                 //2. Как ты сам сказал для инкапсуляции
                                                 //Да этого не было в задании но я подумал что этот момент нужен будет, в плане корректной задачи
                                                 //полей видимости данных
            public DateTime DateCreation { get; set; }
            public bool Сompleted { get; set; }
            public string description { get; set; };
            DateTime dateCreation = DateTime.Now;
            public User user { get; set; }
            //private string _holder; // это и был владелец заметки приват я уже не могу вспомнить почему)

        }

        public class User
        {
            public string userName { get; set; }; //приват я ставил чтобы имя пользователя мог было изменять только пользователь(или внутри класса пользователь)
            DateTime DateRegistration = DateTime.Now;
            //private Dictionary<string, DateTime> _notesDictionary; //Логика в том чтобы создать создать словарь в котором хранятся заметки
                                                                     // и дата их создания, я просто не знаю как сделать чтобы в ключ и значение
                                                                     // передавались название заметки и дата создания из класса Notes поэтому оставил как есть
            public List<Notes> listNotes = new List<Notes>();
        }
    }
}
