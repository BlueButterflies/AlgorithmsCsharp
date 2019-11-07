using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        static char[] set;
        static char[] combinations;

        static void Combination(int index, int start)
        {
            if(index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    combinations[index] = set[i];
                    Combination(index + 1, i + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            set = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());

            combinations = new char[k];

            Combination(0, 0);
        }
    }
}
