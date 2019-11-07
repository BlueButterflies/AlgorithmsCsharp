using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Needles
{
    class Program
    {
        static List<int> result = new List<int>();
        static string input;
        static List<int> stack;
        static List<int> needles;

        static void ReadInput()
        {
            input = Console.ReadLine();

            stack = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            needles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
        }

        static void Index(List<int> nums, int i)
        {
            while (i >= 0)
            {
                if (nums[i] != 0)
                {
                    result.Add(i + 1);

                    return;
                }

                i--;
            }

            result.Add(0);
        }

        static void Main(string[] args)
        {
            ReadInput();

            foreach (var needle in needles)
            {
                bool match = false;

                for (int i = 0; i < stack.Count; i++)
                {
                    if (stack[i] >= needle)
                    {
                        match = true;

                        Index(stack, i - 1);

                        break;
                    }
                }

                if (!match)
                {
                    Index(stack, stack.Count - 1);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
