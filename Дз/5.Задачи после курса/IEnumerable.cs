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
            var arr = new[] { 1, 2, 3, 4, 5, 6 };

            var query = arr.Select(el =>
                {
                    Console.WriteLine(el);
                    return el;
                })
                .Where(el => el > 4)
                .Select(el =>
                {
                    var res = el * 2;
                    Console.WriteLine(res);
                    return res;
                });

            Console.WriteLine("Output");
            _ = query.ToArray(); //Как я понял авыполнения запроса query откладывается до момента его вызова в этой строке
        }
    }
}
