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

        }

        class Recipe
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<string> ingredients = new List<string>();
            public string Algorithm { get; set; }
            public Сreator NameCreator { get; set; }
            //public Dictionary<string, int> Category; // тут чистый брэйнлаг)
            public Category category;
            public enum Category
            {
                Перое,
                Второе,
                Компот
            }
            public RecipeRang recipeRang;
            public enum RecipeRang //начинается с 1 потому что по заданию нужен рэйтинг рецептов 
                                   // и тут я как раз и ввел этот рэйтинг по десятибальной шкале
                                   // где 1 худший 10 лучший
            {
                One_1,
                Two_2,
                Three_3,
                Four_4,
                Five_5,
                Six_6,
                Seven_7,
                Eight_8,
                Nine_9,
                Ten_10
            }

            public Recipe(string name, string algorithm)
            {
                Name = name;
                Algorithm = algorithm;
            }
        }

        class Сreator
        {
            public string Name { get; set; }
            public DateTime dateNewRecipe = DateTime.Now;
            public List<string> recipe = new List<string>();
            public double AverageRecipeRang { get; set; }
            //public Сreator(string name) // я вообще сам уже не помню зачем я его создал
            //{
            //    Name = name;
            //}

            // А по поводу что такое констркутор, у меня даже в лекции есть классная прметка "хуй знает")
            // и да я не доконцп понимаю что это и с чем едят
        }
    }
}
