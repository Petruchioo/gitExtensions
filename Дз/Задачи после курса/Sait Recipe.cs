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
            private string _nameRecipe;
            private string _descriptionRecipe;
            private string _ingredients;
            private string _algorithm;
            private Сreator _nameCreator;
            private RecipeRang _recipeRang;
            private Dictionary<string, int> Category; // ключь название рецепта, значение категория
            public enum RecipeRang
            {
                One = 1,
                Two = 2,
                Three = 3,
                Four = 4,
                Five = 5,
                Six = 6,
                Seven = 7,
                Eight = 8,
                Nine = 9,
                Ten = 10
            }

            public Recipe(string nameRecipe, string ingredients, string algorithm, RecipeRang recipeRang)
            {
                _nameRecipe = nameRecipe;
                _ingredients = ingredients;
                _algorithm = algorithm;
                _recipeRang = recipeRang;
            }
        }

        class Сreator
        {
            private string _nameCreator;
            private DateTime _dateNewRecipe;
            private Recipe _nameRecipe;
            private Dictionary<string, int> listRecipes; // ключь название рецептка, значение ранг
            private int _averageRecipeRang;
            public Сreator(string nameCreator)
            {
                nameCreator = _nameCreator;
            }
        }
    }
}
