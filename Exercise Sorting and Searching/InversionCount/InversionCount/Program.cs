using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InversionCount
{
    class Program
    {
        static int MergeSort(int[] arr)
        {
            int[] temp = new int[arr.Length];

            return Sort(arr, temp, 0, arr.Length - 1);
        }

        static int Sort(int[] arr, int[] temp, int left, int right)
        {
            int mid, InversionCounter = 0;

            if (right > left)
            {
                mid = (right + left) / 2;

                InversionCounter = Sort(arr, temp, left, mid);

                InversionCounter += Sort(arr, temp, mid + 1, right);

                InversionCounter += Merge(arr, temp, left, mid + 1, right);
            }
            return InversionCounter;
        }

        static int Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i, j, k;
            int InversionCounter = 0;

            i = left;
            j = mid;
            k = left;
            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];

                    InversionCounter = InversionCounter + (mid - i);
                }
            }

            while (i <= mid - 1)
            {
                temp[k++] = arr[i++];
            }

            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            for (i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }

            return InversionCounter;
        }
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.Write(MergeSort(arr));
        }
    }
}
