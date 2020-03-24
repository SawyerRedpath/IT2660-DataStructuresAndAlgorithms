using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;

namespace RecursiveMergeSort
{
    public static class MergeSortAlgo
    {
        private static readonly int[] Numbers = new int[100];
        private static readonly int[] Helper = new int[Numbers.Length];

        public static void Main(string[] args)
        {
            Console.WriteLine("Random numbers, unsorted array");
            GenerateAndPrintRandomNumbersArray();
            
            MergeSort(0, Numbers.Length - 1);
            
            Console.WriteLine("Random numbers, merge sorted array");
            foreach (var t in Numbers)
            {
                Console.WriteLine(t);
            }
            
            
        }

        private static void GenerateAndPrintRandomNumbersArray()
        {
            var r = new Random();
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = r.Next(0, 100);
                Console.WriteLine(Numbers[i]);
            }
        }


        private static void MergeSort(int low, int high)
        {
            // Check if low is less than high, if no then array = sorted
            if (low < high)
            {
                // Get the middle index
                int middle = low + (high - low) / 2;
                
                // Sort left side array
                MergeSort(low, middle);
                
                // Sort right side array
                MergeSort(middle + 1, high);
                
                // Combine both
                Merge(low, middle, high);


            }
        }

        private static void Merge(int low, int middle, int high)
        {
            // Copy both sides into helper array
            int i;
            for (i = low; i <= high; i++)
            {
                Helper[i] = Numbers[i];
            }

            i = low;
            var j = middle + 1;
            var k = low;
            
            // Copy smallest value from either left or right array to original
            while (i <= middle && j <= high)
            {
                if (Helper[i] <= Helper[j])
                {
                    Numbers[k] = Helper[i];
                    i++;
                }

                else
                {
                    Numbers[k] = Helper[j];
                    j++;
                }
                k++;
            }
            
            // Copy the rest of left side of array 
            while (i <= middle)
            {
                Numbers[k] = Helper[i];
                k++;
                i++;
            }
        }
    }
}