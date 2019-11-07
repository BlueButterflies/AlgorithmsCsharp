using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PermutationsWithoutRepetition
{
    class Program
    {
        static string[] letters;

        static void Generates(int index)
        {
            if (index >= letters.Length)
            {
                Console.WriteLine(string.Join(" ", letters));
            }
            else
            {
                Generates(index + 1);

                for (int i = index + 1; i < letters.Length; i++)
                {
                    Swap(index, i);
                    Generates(index + 1);
                    Swap(index, i);
                }
            }
        }
        static void Swap(int index, int i)
        {
            var temp = letters[index];
            letters[index] = letters[i];
            letters[i] = temp;
        }

        static void Main(string[] args)
        {
            letters = Console.ReadLine().Split();

            Generates(0);
        }
    }
}
