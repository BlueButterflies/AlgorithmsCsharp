using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NestedLoops
{
    class Program
    {
        static int number;
        static int[] arrNumber;

        static void ReadNumber()
        {
            number = int.Parse(Console.ReadLine());
        }

        static void Recursion(int currentNumber)
        {
            if(currentNumber == number)
            {
                PrintNumber();
                return;
            }

            for (int i = 1; i <= number; i++)
            {
                arrNumber[currentNumber] = i;

                Recursion(currentNumber + 1);
            }
        }

        static void PrintNumber ()
        {
           Console.WriteLine(string.Join(" ", arrNumber));
        }

        static void Main(string[] args)
        {
            ReadNumber();

            arrNumber = new int[number];

            Recursion(0);
        }
    }
}
