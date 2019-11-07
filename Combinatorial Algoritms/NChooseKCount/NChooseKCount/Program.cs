using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace NChooseKCount
{
    class Program
    {
        static BigInteger Factorial(int number)
        {
            BigInteger facturials = 1;

            for (int i = 2; i <= number; i++)
            {
                facturials *= i;
            }

            return facturials;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger result = Factorial(n) / (Factorial(n - k) * Factorial(k));

            Console.WriteLine(result);
        }
    }
}
