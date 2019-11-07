using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Words
{
    class Program
    {
        private static char[] elements;
        private static int counter;

        static void Gen(int index)
        { 
            if(index >= elements.Length)
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    if(elements[i] == elements[i - 1])
                    {
                        return;
                    }
                }
                counter++;
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();

                for (int i = index; i < elements.Length; i++)
                {
                    if(!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Gen(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }
        static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            elements = input.ToCharArray();

            var allUnique = input.Distinct().Count() == input.Length;

            if(allUnique)
            {
                counter = 1;

                for (int i = 1; i <= input.Length; i++)
                {
                    counter *= i;
                }
            }
            else
            {
                Gen(0);
            }

            Console.WriteLine(counter);
        }
    }
}
