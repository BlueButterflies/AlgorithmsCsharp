using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace MoveDownRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrixNum = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrixNum[row, col] = numbers[col];
                }
            }

            int[,] sum = new int[rows, cols];

            sum[0, 0] = matrixNum[0, 0];

            for (int row = 1; row < rows; row++)
            {
                sum[row, 0] = sum[row - 1, 0] + matrixNum[row, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                sum[0, col] = sum[0, col - 1] + matrixNum[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < rows; col++)
                {
                    sum[row, col] = Math.Max(sum[row - 1, col],
                       sum[row, col - 1]) + matrixNum[row, col];
                }
            }

            List<string> result = new List<string>();

            result.Add($"[{rows - 1}, {cols - 1}]");

            int currentRow = rows - 1;
            int currentCol = cols - 1;

            while (currentRow != 0 || currentCol != 0)
            {
                int top = -1;

                if (currentRow - 1 >= 0)
                {
                    top = sum[currentRow - 1, currentCol];
                }

                int left = -1;

                if (currentCol - 1 >= 0)
                {
                    left = sum[currentRow, currentCol - 1];
                }

                if (top > left)
                {
                    result.Add($"[{currentRow - 1}, {currentCol}]");

                    currentRow -= 1;

                    if (currentRow < 0)
                    {
                        currentRow = 0;
                    }
                }
                else
                {
                    result.Add($"[{currentRow}, {currentCol - 1}]");

                    currentCol -= 1;

                    if (currentCol < 0)
                    {
                        currentCol = 0;
                    }
                }
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}