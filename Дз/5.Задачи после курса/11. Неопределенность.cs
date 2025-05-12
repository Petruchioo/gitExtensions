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
            Dictionary<B, string> map = new Dictionary<B, string>();
            var el1 = new B();
            var el2 = new B();
            map[el1] = "12";
            map[el2] = "14";
            Console.WriteLine(map[el1]); // выдет 12
        }

        class B
        {
            private static readonly Random _rnd = new Random(Guid.NewGuid().GetHashCode());
            private readonly int _id = _rnd.Next();
            public override int GetHashCode() => _id;  // получаем случайный хэш код только один раз а не при кадом вызове GetHashCode

            public override bool Equals(object obj) //не может всегда быть true тк нарушает логику сравнения
            {
                return obj is B b && b._id == _id;
            }
        }

        //изначальный код
        //static void Main(string[] args)
        //{
        //    Dictionary<B, string> map = new Dictionary<B, string>();
        //    var el1 = new B();
        //    var el2 = new B();
        //    map[el1] = "12";
        //    map[el2] = "14";
        //    Console.WriteLine(map[el1]); // выдает ошибку отсутсвия ключа в словаре
        //}

        //class B
        //{
        //    private readonly Random _random = new Random();       
        //    public override int GetHashCode() => _random.Next(); //не может быть рандомным тк нарушает базовый контрат(для каждого элемента должен быть один постоянный хэш)
                                                                   // получаем новый рандомный хэш для элемента при каждом вызове GetHashCode
                                                                   // из за чего словарь не может найти необходимый элемент
        //    public override bool Equals(object obj) => true;     //не может всегда быть true тк нарушает логику сравнения
        //}
    }
}
