using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Sorting
{
    class Program
    {
        static void SortNumber()
        {
            List<int> number = Console.ReadLine().Split().Select(int.Parse).ToList();

            number.Sort();

            Console.WriteLine(string.Join(" ", number));
        }

        static void Main(string[] args)
        {
            SortNumber();
        }
    }
}
