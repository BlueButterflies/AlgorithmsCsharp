using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;
using System.Threading.Tasks;

namespace Blocks
{
    class Program
    {
        public const int LettersToChoose = 4;
        public static readonly HashSet<string> Combinations = new HashSet<string>();
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> result = FindBlocks(n);

            Print(result);

        }

        private static void FillLetters(int n, char[] letters)
        {
            for (int i = 0; i < n; i++)
            {
                letters[i] = (char)('A' + i);
            }
        }

        private static HashSet<string> FindBlocks(int n)
        {
            char[] letters = new char[n];

            FillLetters(n, letters);

           bool[] used = new bool[n];
           char[]currentComb = new char[LettersToChoose];

            HashSet<string> result = new HashSet<string>();

            GenerateVariantions(letters,currentComb, used, result);

            return result;
        }

        private static void GenerateVariantions(char[] letters,  char[] currentComb, bool[] used, HashSet<string> result, int index =  0)
        {
            if (index >= currentComb.Length)
            {
                Results(currentComb, result);
            }
            else
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentComb[index] = letters[i];
                        GenerateVariantions(letters, currentComb, used, result, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Results(char[] currentComb, HashSet<string> result)
        {
            string currentCombination = new string(currentComb);

            if (!Combinations.Contains(currentCombination))
            {
                result.Add(currentCombination);

                Combinations.Add(currentCombination);
                Combinations.Add(new string(new[] { currentComb[3], currentComb[0], currentComb[2], currentComb[1] }));
                Combinations.Add(new string(new[] { currentComb[2], currentComb[3], currentComb[1], currentComb[0] }));
                Combinations.Add(new string(new[] { currentComb[1], currentComb[2], currentComb[0], currentComb[3] }));
            }
        }

        private static void Print(HashSet<string> result)
        {
            Console.WriteLine($"Number of blocks: {result.Count}");

            foreach (var comb in result)
            {
                Console.WriteLine(comb);
            }
        }

    }
}
