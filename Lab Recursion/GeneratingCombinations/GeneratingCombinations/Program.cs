using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GeneratingCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int index = int.Parse(Console.ReadLine());

            int[] vectors = new int[index];
            

            GetGenerating(setNumber, vectors, 0, 0);
        }
        static void GetGenerating(int[] setNumber, int[] vectors,int index, int border)
        {
            if(index >= vectors.Length)
            {
                Console.WriteLine(string.Join(" ", vectors));
            }
            else
            {
                for (int i = border; i < setNumber.Length; i++)
                {
                    vectors[index] = setNumber[i];

                    GetGenerating(setNumber, vectors, index + 1, i + 1);
                }
            }
        }
    }
}
