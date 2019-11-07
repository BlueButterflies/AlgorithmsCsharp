using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Generating0._1Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] vectors = new int[n];

            Generation(0, vectors);
        }
        static void Generation(int n, int[] vectors)
        {
            if(n >= vectors.Length)
            {
                Console.WriteLine(string.Join("", vectors));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vectors[n] = i;
                    Generation(n + 1, vectors);
                }
            }
        }
    }
}
