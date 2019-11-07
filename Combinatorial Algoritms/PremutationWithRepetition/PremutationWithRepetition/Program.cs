using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PermutationsWithoutRepetition
{
    class Program
    {
        static char[] letters;

        static void Generates(int index)
        {
            if (index >= letters.Length)
            {
                Console.WriteLine(string.Join(" ", letters));
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();

                for (int i = index; i < letters.Length; i++)
                {
                    if(!swapped.Contains(letters[i]))
                    {
                        Swap(index, i);
                        Generates(index + 1);
                        Swap(index, i);
                        swapped.Add(letters[i]);
                    }
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
            letters = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            Generates(0);
        }
    }
}
