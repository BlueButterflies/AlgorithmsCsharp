using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace _0_1Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            List<Item> items = GetAllItems();

            int[,] prices = new int[items.Count + 1, maxCapacity + 1];
            bool[,] itemsIncluded = new bool[items.Count + 1, maxCapacity + 1];

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var item = items[itemIndex];
                var rowIndex = itemIndex + 1;

                for (int capacity = 0; capacity <= maxCapacity; capacity++)
                {
                    if (item.Weight > capacity)
                    {
                        continue;
                    }

                    var excluding = prices[rowIndex - 1, capacity];
                    var including = item.Price + prices[rowIndex - 1, capacity - item.Weight];

                    if (including > excluding)
                    {
                        prices[rowIndex, capacity] = including;
                        itemsIncluded[rowIndex, capacity] = true;
                    }
                    else
                    {
                        prices[rowIndex, capacity] = excluding;
                    }
                }
            }

            var currentCapacity = maxCapacity;

            List<Item> result = new List<Item>();

            for (int itemsIndex = items.Count - 1; itemsIndex >= 0; itemsIndex--)
            {
                if (itemsIncluded[itemsIndex + 1, currentCapacity])
                {
                    var currentItem = items[itemsIndex];

                    result.Add(currentItem);

                    currentCapacity -= currentItem.Weight;
                }
            }

            Console.WriteLine($"Total Weight: {result.Sum(i => i.Weight)}");
            Console.WriteLine($"Total Value: {prices[items.Count, maxCapacity]}");

            foreach (var item in result.OrderBy(x => x.Name))
            {
                Console.WriteLine(item.Name);
            }
        }

        private static List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] parts = line.Split(' ');
                var newItem = new Item()
                {
                    Name = parts[0],
                    Weight = int.Parse(parts[1]),
                    Price = int.Parse(parts[2])
                };

                items.Add(newItem);

                line = Console.ReadLine();
            }

            items = items.OrderBy(n => n.Name).ToList();

            return items;
        }
    }
}
