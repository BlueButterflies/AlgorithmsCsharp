using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace Fibonacci
{
    class Program
    {
        /* With Recursive Solution, but this method not a big number solution
        static int Fibonacci(long n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(string[] args)
        {
          long n = long.Parse(Console.ReadLine());

           Console.WriteLine(Fibonacci(n));
        } */


        //With Dynamic Programming method.This method is faster.
        static long[] numbers;
        static long Fibonacci(long n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            numbers[n] = Fibonacci(n - 1) + Fibonacci(n - 2);

            return numbers[n];
        }

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            numbers = new long[n + 1];

            Console.WriteLine(Fibonacci(n));
        }

    }
}
