using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace FractionalKnapsackProblem
{
    class Program
    {
        static double capacity;

        static void Main(string[] args)
        {
            capacity = double.Parse(Console.ReadLine()
                .Split(' ')
                [1]);

            var item = double.Parse(Console.ReadLine()
                .Split(' ')
                [1]);

            var totalItem = new List<Items>();

            for (int i = 0; i < item; i++)
            {
                var currentItem = Console.ReadLine()
                    .Split(' ');

                totalItem.Add(new Items
                {
                    Weight = double.Parse(currentItem[2]),
                    Price = double.Parse(currentItem[0])
                });
            }

            totalItem = totalItem
                .OrderByDescending(i => i.Price / i.Weight)
                .ToList();

            var index = 0;
            double totalPrice = 0;

            while (capacity > 0 && index < totalItem.Count)
            {
                var currentItems = totalItem[index];

                var quantity = Math.Min(capacity, currentItems.Weight);

                var percent = quantity / currentItems.Weight;

                totalPrice += percent * currentItems.Price;
                capacity -= quantity;

                index++;

                var percentStr = percent == 1 ? "100" : $"{percent * 100:f2}";

                Console.WriteLine($"Take {percentStr}% of item with price {currentItems.Price:f2} and weight {currentItems.Weight:f2}");
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
