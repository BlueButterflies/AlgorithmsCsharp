﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _8QueensPuzzle
{
    class Program
    {
        private const int Size = 8;

        static int[,] board = new int[Size, Size];

        static HashSet<int> attackedRow = new HashSet<int>();
        static HashSet<int> attackedCol = new HashSet<int>();

        static void Solve(int row)
        {
            if(row == Size)
            {
                PrintSolution();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedFields(row, col);
                        Solve(row + 1);
                        UnmarkAttackedFields(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if(board[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void UnmarkAttackedFields(int row, int col)
        {
            board[row, col] = 0;
            attackedRow.Remove(row);
            attackedCol.Remove(col);
        }

        private static void MarkAttackedFields(int row, int col)
        {
            board[row, col] = 1;
            attackedRow.Add(row);
            attackedCol.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if(attackedRow.Contains(row))
            {
                return false;
            }

            if(attackedCol.Contains(col))
            {
                return false;
            }
             // left-up
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col - i;

                if(currentRow < 0 || currentRow >= Size
                    || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                //queen here
                if(board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            //right - up
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col + i;

                if (currentRow < 0 || currentRow >= Size
                    || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                //queen here
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            //left- down
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col - i;

                if (currentRow < 0 || currentRow >= Size
                    || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                //queen here
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            //right- down
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col + i;

                if (currentRow < 0 || currentRow >= Size
                    || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                //queen here
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Solve(0);
        }
    }
}
