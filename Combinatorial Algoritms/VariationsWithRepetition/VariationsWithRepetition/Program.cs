using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VariationsWithRepetition
{
    class Program
    {
        static char[] elements;
        static char[] variations;
        static bool[] used;

        static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variations(index + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();
            int elementsK = int.Parse(Console.ReadLine());

            variations = new char[elementsK];
            used = new bool[elements.Length];

            Variations(0);
        }
    }
}
