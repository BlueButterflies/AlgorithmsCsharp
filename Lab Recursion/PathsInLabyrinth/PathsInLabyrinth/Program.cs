using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PathsInLabyrinth
{
    class Program
    {
        static char[,] labyrinth;
        static List<char> path= new List<char>();

        static void ReadLabyrinth()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            labyrinth = new char[row, col];

            for (int rows = 0; rows < row; rows++)
            {
                string currentInput = Console.ReadLine();

                for (int cols = 0; cols < col; cols++)
                {
                    labyrinth[rows, cols] = currentInput[cols];
                }
            }
        }
        static void Solve(int row, int col, char direction)
        {
            if(OutSideLybirinth(row, col))
            {
                return;
            }

            path.Add(direction);

            if(IsExit(row, col))
            {
                PrintSolution();
            }
            else if(IsPassable(row, col))
            {
                labyrinth[row, col] = 'x';

                Solve(row + 1, col, 'D'); //Down
                Solve(row - 1, col, 'U');//up
                Solve(row, col + 1, 'R');//right
                Solve(row, col - 1, 'L');//left

                labyrinth[row, col] = '-';
            }
            path.RemoveAt(path.Count - 1);
        }

        private static bool IsPassable(int row, int col)
        {
            //visited
            if(labyrinth[row, col] == 'x')
            {
                return false;
            }
            //wall
            if(labyrinth[row, col] == '*')
            {
                return false;
            }

            return true;
        }

        private static void PrintSolution()
        {
            Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool OutSideLybirinth(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0))
            {
                return true;
            }

            if(col < 0 || col >= labyrinth.GetLength(1))
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            ReadLabyrinth();
            Solve(0, 0, 'S');
        }
    }
}
