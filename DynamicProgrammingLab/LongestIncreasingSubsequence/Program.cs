using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            long[] sequences = new long[numbers.Length];
            long[] prevSolution = new long[numbers.Length];

            long maxSequence = 0;
            long maxSequnceIndex = 0;

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                long sequence = 1;
                long prevIndex = -1;

                long currentNumber = numbers[currentIndex];

                for (int sequnceIndex = 0; sequnceIndex < currentIndex; sequnceIndex++)
                {
                    long previusNumber = numbers[sequnceIndex];
                    long previusSequence = sequences[sequnceIndex];

                    if (currentNumber > previusNumber && sequence <= previusSequence )
                    {
                        sequence = previusSequence + 1;
                        prevIndex = sequnceIndex;
                    }
                }
                sequences[currentIndex] = sequence;
                prevSolution[currentIndex] = prevIndex;

                if (sequence > maxSequence)
                {
                    maxSequence = sequence;
                    maxSequnceIndex = currentIndex;
                }
            }

            long index = maxSequnceIndex;

            List<long> result = new List<long>();

            while (index != -1)
            {
                long currentNum = numbers[index];
                result.Add(currentNum);
                index = prevSolution[index];
            }
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
