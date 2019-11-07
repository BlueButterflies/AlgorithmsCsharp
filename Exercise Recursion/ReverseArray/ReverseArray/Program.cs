using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ReverseArray
{
    class Program
    {
        static void Print(int[] number)
        {
            Console.WriteLine(string.Join(" ", number.Reverse()));
        }
        static void Main()
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Print(number);
        }
    }
}
