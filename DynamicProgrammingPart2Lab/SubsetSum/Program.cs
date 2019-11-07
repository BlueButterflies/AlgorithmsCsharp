using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace SubsetSum
{
    class Program
    {
        /*First Solution With No Repeats
        static Dictionary<int, int> CalculatedSums(int[] numbers)
        {
            var result = new Dictionary<int, int>();

            result.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                foreach (var number in result.Keys.ToList())
                {
                    var newSum = number + currentNumber;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            var numbers = new int[] { 3, 5, 1, 4, 2 };

            var sums = CalculatedSums(numbers);

            var targetSum = 9;

            if (sums.ContainsKey(targetSum))
            {
                Console.WriteLine("Yes");

                while (targetSum != 0)
                {
                    var number = sums[targetSum];

                    Console.Write(number + " ");

                    targetSum -= number;
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }*/

        /*Second Solution With Repeats*/
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 5, 2, 3, 1, 5 };
            var targetSum = 17;

            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        var newSum = sum + numbers[i];
                        
                        if(newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                    }
                }
            }

            while (targetSum != 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var sum = targetSum - numbers[i];

                    if (sum >= 0 && possibleSums[sum])
                    {
                        Console.Write($"{numbers[i]} ");

                        targetSum = sum;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(possibleSums[targetSum]);

        }
    }
}
