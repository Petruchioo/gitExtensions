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

namespace Обучение_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            animals.Add(new Rabbit());
            animals.Add(new Wolf());
            animals.Add(new Fox());

            foreach (var animal in animals)
            {
                animal.Run();
                Console.WriteLine(new String('-', 15) + "выебываюсь" + new String('-', 15));
            }
        }

        abstract class Animal
        {
            public virtual void Run()
            {
                Console.WriteLine("I am animal and I am running for my life!");
            }
        }

        class Rabbit : Animal 
        {
            public override void Run()
            {
                Console.WriteLine("I am running from predators");
            }
        }
        
        class Wolf : Animal 
        {
            
        }

        class Fox : Animal
        {
            public override void Run()
            {
                Console.WriteLine(" I am running for tasty rabbit ;)"); // это смайлик в конце)
            }
        }
    }
}
