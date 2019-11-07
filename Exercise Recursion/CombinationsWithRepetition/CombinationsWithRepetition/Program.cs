using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CombinationsWithRepetition
{
    class Program
    {
        static int num;
        static int combination;
        static int[] arrCombination;

        static void ReadArrK()
        {
            num = int.Parse(Console.ReadLine());
            combination = int.Parse(Console.ReadLine());
        }

        static void Combinations(int num, int index, int elements = 1)
        {
            if(index >= arrCombination.Length)
            {
                PrintResult();
                return;
            }

            for (int i = elements; i <= num; i++)
            {
                arrCombination[index] = i;

                Combinations(num, index + 1, i);
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", arrCombination));
        }

        static void Main(string[] args)
        {
            ReadArrK();

            arrCombination = new int[combination];

            Combinations(num, 0);
        }
    }
}
