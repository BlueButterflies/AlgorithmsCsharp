using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintResult(n);
        }
        static void PrintResult(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));

            PrintResult(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
