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
            public string NotesName { get; private set; }
            public DateTime DateCreation { get; private set; }
            public bool Сompleted {  get; private set; }

            private string _holder;

            public void Description(string notesName, string holder, DateTime dateCreation)
            {
                NotesName = notesName;
                DateCreation = dateCreation;
                _holder = holder;
                Сompleted = false;
                string description;
            }

        }

        public class User
        {
            private string _userName;
            DateTime DateКegistration = new DateTime();
            private Dictionary<string, DateTime> _notesDictionary;
        }
    }
}
