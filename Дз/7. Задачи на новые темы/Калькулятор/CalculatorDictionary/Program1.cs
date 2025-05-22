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
using System.Collections;


namespace Обучение_.Net
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            double operand1;
            double operand2;
            string operation;
            bool workСalculator = true;


            Instruction();

            while (workСalculator)
            {

                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    workСalculator = false;
                    break;
                }

                if (input.ToLower() == "help")
                {
                    Instruction();
                }
                else
                {
                    var nonEmptyInput = NonEmptyInput(input);
                    operand1 = double.Parse(nonEmptyInput[0]);
                    operand2 = double.Parse(nonEmptyInput[2]);
                    operation = nonEmptyInput[1];

                    var DictionaryOperations = new Dictionary<string, object>
                    {
                        ["+"] = Sum(operand1, operand2),
                        ["*"] = Multiplication(operand1, operand2),
                        ["-"] = Subtraction(operand1, operand2),
                        ["/"] = Divide(operand1, operand2),
                        ["%"] = Modulo(operand1, operand2),
                        ["^"] = RaisingPower(operand1, operand2),

                    };

                    Console.WriteLine(DictionaryOperations[operation]);
                }
            }

            void Instruction()
            { Console.WriteLine("Hi, there is the instruction…"); }
        }
        public static string[] NonEmptyInput(string input)
        {
            var nonEmptyInput = input.Split(' ').Where(i => !string.IsNullOrEmpty(input)).ToArray();
            return nonEmptyInput;
        }

        public static double Sum(double term1, double term2) // функция сложения
        {
            return term1 + term2;
        }

        public static double Multiplication(double multiplier1, double multiplier2) //функция умножения
        {
            return multiplier1 * multiplier2;
        }

        public static double Subtraction(double minuend, double subtrahend) // функция вычитания
        {
            return minuend - subtrahend;
        }

        public static double Divide(double dividend, double divider) //функция деления
        {
            return dividend / divider;
        }

        public static double Modulo(double dividend, double divider) //функция остатка от деления
        {
            return dividend % divider;
        }

        public static double RaisingPower(double operand, double power) //функция возведения в степень
        {
            return Math.Pow(operand, power);
        }
    }
}
