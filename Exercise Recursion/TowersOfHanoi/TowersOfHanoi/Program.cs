using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TowersOfHanoi
{
    class Program
    {
        static Stack<int> source;
        static Stack<int> destination = new Stack<int>();
        static Stack<int> spare = new Stack<int>();
        static int takenStep = 0;
        static int disksNumber;

        static void ReadDisks()
        {
            disksNumber = int.Parse(Console.ReadLine());

            source = new Stack<int>(Enumerable.Range(1, disksNumber).Reverse());
        }

        static void MoveDisk(int bottom, Stack<int> source, Stack<int> destination,Stack<int> spare)
        {
            if(bottom == 1)
            {
                takenStep++;

                destination.Push(source.Pop());

                Console.WriteLine($"Step #{takenStep}: Moved disk");

                PrintRods();
            }
            else
            {
                 MoveDisk(bottom - 1, source, spare, destination);

                takenStep++;

                destination.Push(source.Pop());

                Console.WriteLine($"Step #{takenStep}: Moved disk");

                PrintRods();

                MoveDisk(bottom - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ReadDisks();
            
            PrintRods();

            MoveDisk(disksNumber, source, destination, spare);
        }
    }
}
