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

namespace Обучение_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "Миша",
                "Вася",
                "Петя",
                "Гриша"
            };

            Console.WriteLine($"Первый человек списка: {names.First()}");
            Console.WriteLine(new String('-', 40));

            Console.WriteLine($"Второй и третий человек в списке: {names.ElementAt(1)} и {names.ElementAt(2)}");
            Console.WriteLine(new String('-', 40));

            Console.WriteLine($"Человек с именем на <М>: {names.FirstOrDefault(nameM => nameM.StartsWith("М"))}");
            Console.WriteLine(new String('-', 40));

            foreach ( string name in names.Where(name => name.Contains('я'))) 
                Console.WriteLine($"Человек с именем содержащее <я>: {name}");
            Console.WriteLine($"Таких людей {names.Count(nameContains => nameContains.Contains('я'))}");
            Console.WriteLine(new String('-', 40));

            bool nameBoll = names.Contains("Петя");

            if (nameBoll) Console.WriteLine("Человек с именем  Петя есть");

            Console.WriteLine($"Наличие человека с именем <Петя>: {names.Any(namePetya => namePetya == "Петя")}");
            Console.WriteLine(new String('-', 40));

            names.Sort();

            foreach (var name in names)
                Console.WriteLine(name);
            Console.WriteLine(new String('-', 40));

            names.Insert(2, "Андрей");
            foreach (var name in names)
                Console.WriteLine(name);
            Console.WriteLine();

            var sortedNames = names.OrderBy(name => name);
            foreach (var name in sortedNames)
                Console.WriteLine(name);
            Console.WriteLine(new String('-', 40));
        }
    }
}
