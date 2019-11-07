using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sum = Sum(numbers, 0);

            Console.WriteLine(sum);
        }
        static int Sum(int[] arrNumbers, int index)
        {
            if(index == arrNumbers.Length)
            {
                return 0;
            }
            return arrNumbers[index] + Sum(arrNumbers, index + 1);
        }
    }
}
