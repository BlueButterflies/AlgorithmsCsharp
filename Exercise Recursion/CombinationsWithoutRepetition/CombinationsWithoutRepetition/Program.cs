using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        static int elemntsOne;
        static int elemntsTwo;
        static int[] arrElements;

        static void ReadInput()
        {
            elemntsOne = int.Parse(Console.ReadLine());
            elemntsTwo = int.Parse(Console.ReadLine());

            arrElements = new int[elemntsTwo];
        }

        static void CombinationElements(int num, int index, int elements = 1)
        {
            if (index >= arrElements.Length)
            {
                PrintResult();
                return;
            }

            for (int i = elements; i <= num; i++)
            {
                arrElements[index] = i;

                CombinationElements(num, index + 1, i + 1);
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", arrElements));
        }

        static void Main(string[] args)
        {
            ReadInput();

            CombinationElements(elemntsOne, 0);
        }
    }
}
