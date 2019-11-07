using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Snakes
{
    class Program
    {
        static char[] currentSnake;
        static HashSet<string> visitedCell = new HashSet<string>();
        static HashSet<string> result = new HashSet<string>();
        static HashSet<string> allPossibleSnakes = new HashSet<string>();

        static void GenerateSnake(
            int index, int row, int col, char direction)
        {
            if(index >= currentSnake.Length)
            {
                MarkSnake();
            }
            else
            {
                var cell = $"{row} {col}";

                if(!visitedCell.Contains(cell))
                {
                    currentSnake[index] = direction;

                    visitedCell.Add(cell);

                    GenerateSnake(index + 1, row, col + 1, 'R');
                    GenerateSnake(index + 1, row + 1, col, 'D');
                    GenerateSnake(index + 1, row, col - 1, 'L');
                    GenerateSnake(index + 1, row - 1, col, 'U');

                    visitedCell.Remove(cell);
                }
            }
        }

        private static void MarkSnake()
        {
            var normalSnake = new string(currentSnake);

            if(allPossibleSnakes.Contains(normalSnake))
            {
                return;
            }

            result.Add(normalSnake);

            var flippedSnake = Flip(normalSnake);
            var reversedSnake = Reverse(normalSnake);
            var reversecFlippedSnake = Flip(reversedSnake);

            for (int i = 0; i < 4; i++)
            {
                allPossibleSnakes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                allPossibleSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                allPossibleSnakes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                allPossibleSnakes.Add(reversecFlippedSnake);
                reversecFlippedSnake = Rotate(reversecFlippedSnake);
            }
        }

        static string Rotate(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R':
                        newSnake[i] = 'D';
                        break;
                    case 'D':
                        newSnake[i] = 'L';
                        break;
                    case 'L':
                        newSnake[i] = 'U';
                        break;
                    case 'U':
                        newSnake[i] = 'R';
                        break;
                    default:
                        newSnake[i] = snake[i];
                        break;
                }
            }

            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }
            return new string(newSnake);
        }

        private static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U':
                        newSnake[i] = 'D';
                        break;
                    case 'D':
                        newSnake[i] = 'U';
                        break;
                    default:
                        newSnake[i] = snake[i];
                        break;
                }
            }

            return new string(newSnake);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            currentSnake = new char[n];

            GenerateSnake(0, 0, 0, 'S');

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Snakes count = {result.Count}");
        }
    }
}
