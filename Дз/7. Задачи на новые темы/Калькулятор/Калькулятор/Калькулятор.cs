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
            double operand1;
            double operand2;
            string operation;

            bool workСalculator = true;

            
            
            while (workСalculator)
            {
                Instruction();

                string input = Console.ReadLine();
                
                if (input == "Exit")
                {
                    workСalculator = false;
                    break;
                }

                if (input == "Help")
                {
                    Instruction();
                }
                else
                {
                    var nonEmptyInput = input.Split(' ').Where(i => !string.IsNullOrEmpty(input)).ToArray();
                    operand1 = double.Parse(nonEmptyInput[0]);
                    operand2 = double.Parse(nonEmptyInput[2]);
                    operation = nonEmptyInput[1];

                    switch (operation)
                    {
                        case "+":
                            Console.WriteLine(Sum(operand1, operand2));
                            break;
                        case "*":
                            Console.WriteLine(Multiplication(operand1, operand2));
                            break;
                        case "-":
                            Console.WriteLine(Subtraction(operand1, operand2));
                            break;
                        case "/":
                            Console.WriteLine(Divide(operand1, operand2));
                            break;
                        case "%":
                            Console.WriteLine(Modulo(operand1, operand2));
                            break;
                        case "^":
                            Console.WriteLine(RaisingPower(operand1, operand2));
                            break;
                    }
                }
            }
            
            void Instruction() 
                {  Console.WriteLine("Hi, there is the instruction…"); }



            double Sum(double term1, double term2) // функция сложения
            {
                operand1 = term1;
                operand2 = term2;

                return term1 + term2;
            }

            double Multiplication(double multiplier1, double multiplier2) //функция умножения
            {
                operand1 = multiplier1;
                operand2 = multiplier2;
                return multiplier1 * multiplier2;
            }

            double Subtraction(double minuend, double subtrahend) // функция вычитания
            {
                operand1 = minuend;
                operand2 = subtrahend;
                return minuend - subtrahend;
            }

            double Divide(double dividend, double divider) //функция деления
            {
                operand1 = dividend;
                operand2 = divider;
                return dividend / divider;
            }

            double Modulo(double dividend, double divider) //функция остатка от деления
            {
                operand1 = dividend;
                operand2 = divider;
                return dividend % divider;
            }

            double RaisingPower(double operand, double power) //функция возведения в степень
            {
                operand1 = operand;
                operand2 = power;
                return Math.Pow(operand, power);
            } 
        }
    }
}
