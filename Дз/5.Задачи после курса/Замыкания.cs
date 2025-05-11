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
            var list = new List<int>();
            var i = 10;
            var query = list.Where(x => x == i).Where(x => x < 20);
            list.Add(10);
            list.Add(15);
            list.Add(20);
            i = 15;
            var result = query.ToList();
            list.Clear();
            Console.WriteLine(result.Count); // 1 (так как result = [15]) это разные листы
            Console.WriteLine(result.FirstOrDefault()); // 15 возваращает первый элемент

            Console.WriteLine(new String('-', 10) + "Разделение заданий" + new String('-', 10));

            //var funcs = new List<Func<int, int>>();
            //for (int j = 0; j < 10; j++)
            //{
            //    funcs.Add(x => x + j);
            //    foreach (var func in funcs)
            //    {
            //        Console.WriteLine(func(1)); // 
            //        break;
            //    }
            //}

            var funcs = new List<Func<int, int>>();
            for (int j = 0; j < 10; j++)
            {
                int temp = j;
                funcs.Add(x => x + temp);
            }

            foreach (var func in funcs)
                Console.WriteLine(func(1)); // 1, 2, 3, ..., 10
        }
    }
}
