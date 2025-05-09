﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // видимрость курсора

            char[,] map = ReadMAp("map.txt");
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            Task.Run(() =>  //аааа нууу ии хуета
            {
                while (true)
                    pressedKey = Console.ReadKey();
            });

            int pacmanX = 1, pacmanY = 1;
            int score = 0;

            while (true)
            {
                Console.Clear();

                HandleInput(pressedKey, ref pacmanX, ref pacmanY, map, ref score);

                Console.ForegroundColor = ConsoleColor.Blue;
                DrawMap(map);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(pacmanX, pacmanY);
                Console.Write('@');

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(35, 0);
                Console.Write($"Score: {score}");

                Thread.Sleep(1000);

            }
        }

        private static char[,] ReadMAp(string path) //статический метод
        {

            string[] file = File.ReadAllLines("map.txt");  // File. статический класс |  File.ReadAllLines выдает файл массивом строчек

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length]; //в качестве ширины массива мы берем ширинц максимальной строчки

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        private static void DrawMap(char[,] map) //функция для отрисовки карты
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = pacmanX + direction[0];
            int nextPacmanPositionY = pacmanY + direction[1];

            char nextCell = map[nextPacmanPositionX, nextPacmanPositionY];

            if (nextCell != '#' || nextCell == '*')
            {
                pacmanX = nextPacmanPositionX;
                pacmanY = nextPacmanPositionY;

                if (nextCell == '*')
                {
                    score++;
                    map[nextPacmanPositionX, nextPacmanPositionY] = ' ';
                }
            }

        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                direction[1] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                direction[1] = 1;
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                direction[0] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                direction[0] = 1;
            }

            return direction;
        }
        private static int GetMaxLengthOfLine(string[] lines) //выдай длину линии
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;

        }

    }
}
