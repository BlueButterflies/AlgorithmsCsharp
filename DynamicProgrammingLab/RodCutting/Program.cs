using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace RodCutting
{
    class Program
    {
        static int[] price;
        static int[] bestPrice;
        static int[] bestCombination;

        static int CutRod(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int cureentBest = bestPrice[i];

                for (int j = 1; j <= i; j++)
                {
                    cureentBest = Math.Max(bestPrice[i], price[j] + bestPrice[i - j]);

                    if (cureentBest > bestPrice[i])
                    {
                        bestPrice[i] = cureentBest;
                        bestCombination[i] = j;
                    }
                }
            }

            return bestPrice[n];
        }

        static void ReconstructSolution(int n)
        {
            int totaBest = CutRod(n);

            List<int> result = new List<int>();

            while (n > 0)
            {
               int nextComb = bestCombination[n];

                result.Add(nextComb);

                n -= nextComb;
            }

            Console.WriteLine($"{totaBest}\n{string.Join(" ",result)}");
        }

        static void Main(string[] args)
        {
            price = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bestPrice = new int[price.Length];
            bestCombination = new int[price.Length];

            int n = int.Parse(Console.ReadLine());

            ReconstructSolution(n);
        }
    }
}
