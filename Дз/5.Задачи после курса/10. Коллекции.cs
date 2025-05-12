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
            HashSet<A> @set = new HashSet<A>();
            var el1 = new A { Value = 1 };
            var el2 = new A { Value = 1 };
            @set.Add(el1);
            Console.WriteLine(@set.Contains(el2)); //забыл оставить коммит, ранее выводилось false, потому что
                                                   //значение обьектов одно а ссылки разные и сравнивались именно ссылки
                                                   //теперь true
                                                   //после исправлениея в class A
                                                   // а именно переопределение метода Equals
        }

        class A
        {
            public int Value { get; set; }

            public override int GetHashCode()
            {
                Console.WriteLine("GetHashCode");
                return Value;
            }

            public override bool Equals(object obj) //еще есть вариант смены class A на struct A
                                                    //в этом случае у нас меняется ссылочный тип данных на значимый
            {
                Console.WriteLine("Equals");
                return obj is A a && a.Value == Value;
            }
        }
    }
}
