﻿using System;
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
            var constantReader = new ConstantReader();
            var consoleReader = new ConsoleReader();

            var integerParser = new IntegerParser(constantReader).Parse();
            Console.WriteLine(integerParser);
            var integerParser2 = new IntegerParser(consoleReader).Parse();
            Console.WriteLine(integerParser2);
        }

        interface IInputReader
        {
            string ReaderFromSource();
        }

        class ConstantReader : IInputReader
        {
            public string ReaderFromSource()
            {
                return "5";
            }
        }

        class ConsoleReader : IInputReader
        {
            public string ReaderFromSource()
            {
                return Console.ReadLine(); //андрей говорил лишнюю логику не добавлять (в первых двух задачах я этим пренебрег)
            }
        }

        class IntegerParser
        {
            private IInputReader _reader;

            public IntegerParser(IInputReader reader) //нейронка не до конца понимаю: создается констркутор котрый принимает интерфейс и переменную, переменная обьявляется, а дальше затуп
            {
                _reader = reader;
            }

            public int Parse()
            {
                var inputedValue = _reader.ReaderFromSource();
                return int.Parse(inputedValue);
            }
        }
    }
}
