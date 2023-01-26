using Var21.DBStructure;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;

namespace Var21
{
    class Program
    {
        /// <summary>
        /// Sorts list of Info by selection sort and prints time of sorting
        /// </summary>
        /// <returns>
        /// Returns sorted data
        /// </returns>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        public static List<Info> SelectionSort(List<Info> input)
        {
            Info[] result = new Info[input.Count];
            input.CopyTo(result);

            DateTime start = DateTime.Now;

            int lenght = input.Count;

            for (int i = 0; i < lenght; i++)
            {
                int min = i;


                for (int j = i; j < lenght; j++)
                {
                    if (result[j] < result[min])
                        min = j;
                }

                Info x = result[i];
                result[i] = result[min];
                result[min] = x;
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Select sort, {input.Count} elements, {(end - start).TotalMilliseconds} ms");

            return result.ToList();
        }

        /// <summary>
        /// Sorts list of Info by bubble sort and prints time of sorting
        /// </summary>
        /// <returns>
        /// Returns sorted data
        /// </returns>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        public static List<Info> BubbleSort(List<Info> input)
        {
            Info[] result = new Info[input.Count];
            input.CopyTo(result);

            DateTime start = DateTime.Now;

            int lenght = input.Count;

            for (int i = 0; i < lenght; i++)
            {
                for (int j = lenght-1; j > i; j--)
                {
                    if (result[j] < result[j - 1])
                    {
                        Info x = result[j];
                        result[j] = result[j - 1];
                        result[j - 1] = x;
                    }
                }
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Bubble sort, {input.Count} elements, {(end - start).TotalMilliseconds} ms");

            return result.ToList();
        }

        /// <summary>
        /// Sorts list of Info by insert sort and prints time of sorting
        /// </summary>
        /// <returns>
        /// Returns sorted data
        /// </returns>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        public static List<Info> InsertSort(List<Info> input)
        {
            Info[] result = new Info[input.Count];
            input.CopyTo(result);

            DateTime start = DateTime.Now;

            int lenght = input.Count;

            for (int i = 0; i < lenght; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (result[j] > result[j + 1])
                    {
                        Info x = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = x;
                    }
                    else
                        break;
                }
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Insert sort, {input.Count} elements, {(end - start).TotalMilliseconds} ms");

            return result.ToList();
        }

        /// <summary>
        /// Sorts list of Info by shaker sort and prints time of sorting
        /// </summary>
        /// <returns>
        /// Returns sorted data
        /// </returns>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        public static List<Info> ShakerSort(List<Info> input)
        {
            Info[] result = new Info[input.Count];
            input.CopyTo(result);

            DateTime start = DateTime.Now;

            int k = input.Count - 1;
            int lb = 0, rb = k;

            bool hasSwap = true;

            while(hasSwap && lb < rb)
            {
                hasSwap = false;
                k = rb;

                for(int j = rb; j > lb; j--)
                {
                    if(result[j] < result[j - 1])
                    {
                        Info x = result[j];
                        result[j] = result[j - 1];
                        result[j - 1] = x;
                        k = j;
                        hasSwap = true;
                    }
                }
                lb = k + 1;

                k = lb;

                for(int j = lb; j < rb; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        Info x = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = x;
                        k = j;
                        hasSwap = true;
                    }
                }

                rb = k - 1;
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Shaker sort, {input.Count} elements, {(end - start).TotalMilliseconds} ms");

            return result.ToList();
        }

        /// <summary>
        /// Controls sorting of list of Info by quick sort and outputs sorting time
        /// </summary>
        /// <returns>
        /// Returns sorted data
        /// </returns>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        public static List<Info> QuickSortStart(List<Info> input)
        {
            Info[] result = new Info[input.Count];
            input.CopyTo(result);

            List<Info> res = result.ToList();

            DateTime start = DateTime.Now;

            QuickSort(res, 0, res.Count - 1);

            DateTime end = DateTime.Now;

            Console.WriteLine($"Quick sort, {input.Count} elements, {(end - start).TotalMilliseconds} ms");

            return res;
        }

        /// <summary>
        /// Sorts list of Info by quick sort
        /// </summary>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        /// /// <param name="start">
        /// Start of sortable range
        /// </param>
        /// /// <param name="end">
        /// End of sortable range
        /// </param>
        public static void QuickSort(List<Info> input, int start, int end)
        {
            if (start == end)
                return;

            if (end - start == 1)
            {
                if (input[end] < input[start])
                {
                    Info x = input[start];
                    input[start] = input[end];
                    input[end] = x;
                }
                return;
            }

            int med = start;

            if (input[start] > input[end])
            {
                if (input[(start + end) / 2] > input[start])
                    med = start;
                else if (input[end] > input[(start + end) / 2])
                    med = end;
                else
                    med = (start + end) / 2;
            }
            else if (input[(start + end) / 2] > input[end])
                med = end;
            else if (input[start] > input[(start + end) / 2])
                med = start;
            else
                med = (start + end) / 2;

            int i = start, j = end;

            while (i < j)
            {
                while (input[i] < input[med]) i++;
                while (input[j] > input[med]) j--;

                if (i < j)
                {
                    Info x = input[i];
                    input[i] = input[j];
                    input[j] = x;

                    i++;
                    j--;
                }
            }

            if (j > start)
                QuickSort(input, start, j);
            if (i < end)
                QuickSort(input, i, end);

            return;
        }

        /// <summary>
        /// Controls sorting of list of Info by merge sort and outputs sorting time
        /// </summary>
        /// <returns>
        /// Returns sorted data
        /// </returns>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        public static List<Info> MergeSortStart(List<Info> input)
        {
            Info[] result = new Info[input.Count];
            input.CopyTo(result);

            List<Info> res = result.ToList();

            DateTime start = DateTime.Now;

            MergeSort(res, 0, input.Count - 1);

            DateTime end = DateTime.Now;

            Console.WriteLine($"Merge sort, {input.Count} elements, {(end - start).TotalMilliseconds} ms");

            return res;

        }

        /// <summary>
        /// Sorts list of Info by merge sort
        /// </summary>
        /// <param name="input">
        /// Input list of Info with unsorted data
        /// </param>
        /// /// <param name="start">
        /// Start of sortable range
        /// </param>
        /// /// <param name="end">
        /// End of sortable range
        /// </param>
        public static void MergeSort(List<Info> input, int start, int end)
        {
            if (start == end)
                return;

            MergeSort(input, start, (start + end) / 2);
            MergeSort(input, (start + end) / 2 + 1, end);

            Merge(input, start, end, (start + end) / 2 + 1);
        }

        /// <summary>
        /// Merge two sorted lists of Info into one
        /// </summary>
        /// <param name="input">
        /// Input list of Info with data
        /// </param>
        /// /// <param name="start">
        /// Start of the first merging range
        /// </param>
        /// /// <param name="end">
        /// End of the second merging range
        /// </param>
        /// /// /// <param name="mid">
        /// End of the first merging range and the previous element to the start of the second merging range
        /// </param>
        public static void Merge(List<Info> input, int start, int end, int mid)
        {
            int left = start, right = mid;

            List<Info> temp = new List<Info>();

            while(left < mid && right <= end)
            {
                if (input[left] <= input[right])
                {
                    temp.Add(input[left]);
                    left++;
                }
                else
                {
                    temp.Add(input[right]);
                    right++;
                }

                while(left < mid)
                {
                    temp.Add(input[left]);
                    left++;
                }

                while (right <= end)
                {
                    temp.Add(input[right]);
                    right++;
                }
            }

            for (int i = 0; i < end - start + 1; i++)
                input[i + start] = temp[i];
        }

        static void Main(string[] args)
        {
            using (var db = new DataContext100())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext1000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext10000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext20000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext40000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext60000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext80000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };

            using (var db = new DataContext100000())
            {
                List<Info> infos = db.Info.ToList();
                SelectionSort(infos);
                BubbleSort(infos);
                InsertSort(infos);
                ShakerSort(infos);
                QuickSortStart(infos);
                MergeSortStart(infos);
            };
        }
    }
}