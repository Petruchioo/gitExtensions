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
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace Обучение_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
                {
                    new Person { FirstName = "Виталий", LastName = "Цаль", Age = 33 },
                    new Person { FirstName = "Куджо", LastName = "Джотаро", Age = 40 },
                    new Person { FirstName = "Юрий", LastName = "Хованский", Age = 34 },
                    new Person { FirstName = "Михаил", LastName = "Петров", Age = 15 },
                    new Person { FirstName = "Виталий", LastName = "Гачиев", Age = 40 },
                    new Person { FirstName = "Юрий", LastName = "Гагарин", Age = 34 },
                };


            Console.WriteLine($"Людей с именем Юрий: {persons.Count(name => name.FirstName.Contains("Юрий"))}\n");

            var fullName = persons.Select(player => $"{player.FirstName} {player.LastName}").ToList();
            Console.WriteLine($"Имя фамилия \n{string.Join("\n", fullName)}\n");

            Console.WriteLine($"Средний возраст людей: {persons.Average(person => person.Age)} \n");

            var agefilter = persons.GroupBy(person => person.Age);
            foreach (var age in agefilter)
            {
                Console.WriteLine($"Возростная групаа {age.Key}\n");
                foreach (var person in age)
                    Console.WriteLine($"- {person.FirstName} {person.LastName}");
                Console.WriteLine();
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

        }
    }
}
