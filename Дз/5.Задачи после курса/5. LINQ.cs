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

            //Console.WriteLine($"Второй и третий человек в списке: {names.ElementAt(1)} и {names.ElementAt(2)}");
            //Console.WriteLine(new String('-', 40));

            //Console.WriteLine("Второй и третий человек в списке:");
            //foreach (var name in names.Where((name, index) => index == 1 || index == 2))
            //    Console.WriteLine(name);
            //Console.WriteLine(new String('-', 40));
            var scndThrdName = names.Where((name, index) => index == 1 || index == 2).ToList();
            Console.WriteLine("Второй и третий человек в списке:");
            foreach (var name in scndThrdName)
                Console.WriteLine(name);
            Console.WriteLine(new String('-', 40));

            Console.WriteLine($"Человек с именем на <М>: {names.FirstOrDefault(nameM => nameM.StartsWith("М"))}");
            Console.WriteLine(new String('-', 40));

            //foreach (var name in names.Where(name => name.Contains('я')))
            //    Console.WriteLine($"Человек с именем содержащее <я>: {name}");
            //Console.WriteLine($"Таких людей {names.Count(nameContains => nameContains.Contains('я'))}");
            //Console.WriteLine(new String('-', 40)); // Это и так работает)
            var nameWith_Я = names.Where(name => name.Contains('я')).ToList();
            Console.WriteLine("Человек с именем содержащее <я>:");
            foreach (var name in nameWith_Я) Console.WriteLine(name);
            Console.WriteLine($"Таких людей {nameWith_Я.Count()}");
            Console.WriteLine(new String('-', 40));

            bool nameBool = names.Contains("Петя");

            if (nameBool) Console.WriteLine("Человек с именем  Петя есть");

            Console.WriteLine($"Наличие человека с именем <Петя>: {names.Any(namePetya => namePetya == "Петя")}");
            Console.WriteLine(new String('-', 40)); //да здест дублирование два разных способа сделал(для практики)

            //names.Sort(); //Опять же дублирование разными способами + проверка правильности сортировки
            // удолять не хотел тк практика и к этому если что можно вернуться посмотеть
            // стоило закоментить 

            //foreach (var name in names)
            //    Console.WriteLine(name);
            //Console.WriteLine(new String('-', 40));

            //names.Insert(2, "Андрей");
            //foreach (var name in names)
            //    Console.WriteLine(name);
            //Console.WriteLine();

            var sortedNames = names.OrderBy(name => name);
            foreach (var name in sortedNames)
                Console.WriteLine(name);
            Console.WriteLine(new String('-', 40));
        }
    }
}
