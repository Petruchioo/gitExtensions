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
using MyNewLogger;

namespace Обучение_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consoleLogger = new ConsoleLogger();
            var fileLogger = new FileLogger("calculator_log.txt");
            var compositeLogger = new CompositeLogger(consoleLogger, fileLogger);

            // Создаем калькулятор
            var calculator = new Calculator(compositeLogger);
            calculator.Calculat();
        }

        public class Calculator
        {
            private readonly Ilogger _logger;

            public Calculator(Ilogger logger)
            {
                _logger = logger;
            }

            public double operand1;
            public double operand2;
            public string operation;

            public bool workСalculator = true;

            public void Calculat()
            {
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

                        Console.WriteLine(OperationSelection(operand1, operation, operand2, _logger));
                    }
                }

            }
            void Instruction()
            { Console.WriteLine("Hi, there is the instruction…"); }

            public static double OperationSelection(double operand1, string operation, double operand2, Ilogger logger)
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        logger.LogInformation("Сложение\n");
                        result = Sum(operand1, operand2);
                        break;
                    case "*":
                        logger.LogInformation("Умержение\n");
                        result = (Multiplication(operand1, operand2));
                        break;
                    case "-":
                        logger.LogInformation("Вычитание\n");
                        result = (Subtraction(operand1, operand2));
                        break;
                    case "/":
                        logger.LogInformation("Деление\n");
                        var exception = new DivideByZeroException();
                        if (operand2 == 0) logger.LogError(exception, "Долбаеб на ноль делить нельзя");
                        result = (Divide(operand1, operand2));
                        break;
                    case "%":
                        logger.LogInformation("Остаток\n");
                        result = (Modulo(operand1, operand2));
                        break;
                    case "^":
                        logger.LogInformation("Степень\n");
                        result = (RaisingPower(operand1, operand2));
                        break;
                }
                return result;
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
}
