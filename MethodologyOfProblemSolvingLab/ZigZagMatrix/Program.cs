using System;
using System.Linq;
using System.Collections.Generic;

namespace ZigZagMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[][] jaggetMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggetMatrix[i] = Console.ReadLine()
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();
            }

            int[,] maxPaths = new int[rows, cols];
            int[,] previousRowIndex = new int[rows, cols];

            for (int row = 1; row < rows; row++)
            {
                maxPaths[row, 0] = jaggetMatrix[row][0];
            }

            for (int col = 1; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int previousMax = 0;

                    if (col % 2 != 0)
                    {
                        for (int i = row + 1; i < rows; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previousRowIndex[row, col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < row; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previousRowIndex[row, col] = i;
                            }
                        }
                    }

                    maxPaths[row, col] = previousMax + jaggetMatrix[row][col];
                }
            }

            var rowIndex = GetLAstRowIndexOfPath(maxPaths, cols);

            var path = RecoverMaxPath(cols, jaggetMatrix, rowIndex, previousRowIndex);

            Console.WriteLine($"{path.Sum()} = {String.Join(" + ", path)}");

        }

        private static List<int> RecoverMaxPath(int cols, int[][] jaggetMatrix, int rowIndex, int[,] previousRowIndex)
        {
            List<int> path = new List<int>();
            int columnIndex = cols - 1;

            while (columnIndex >= 0)
            {
                path.Add(jaggetMatrix[rowIndex][columnIndex]);
                rowIndex = previousRowIndex[rowIndex, columnIndex];

                columnIndex--;
            }

            path.Reverse();

            return path;
        }

        private static int GetLAstRowIndexOfPath(int[,] maxPaths, int cols)
        {
            int rowIndex = -1;
            int globalMax = 0;
            for (int row = 0; row < maxPaths.GetLength(0); row++)
            {
                if (maxPaths[row, cols - 1] > globalMax)
                {
                    globalMax = maxPaths[row, cols - 1];
                    rowIndex = row;
                }
            }

            return rowIndex;
        }
    }
}
