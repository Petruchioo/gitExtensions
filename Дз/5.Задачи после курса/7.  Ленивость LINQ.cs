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

            List<Person> FilterPersons(
                List<Person> all,
                string firstName = null,
                string lastName = null,int?
                age = null)
            {
                IEnumerable<Person> query = all;
                if (firstName != null) { query = query.Where(filter => filter.FirstName == firstName); }
                if (lastName != null) { query = query.Where(filter => filter.LastName == lastName); }
                if (age != null) { query = query.Where(filter => filter.Age == age); }

                return query.ToList();
            }

            var resultFilter = FilterPersons(persons, firstName: "Юрий");

            foreach (var person in resultFilter) Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

        }
    }
}
