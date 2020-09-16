using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Benchmarking
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = 0;
            Stopwatch sw = new Stopwatch();
            Random rand = new Random();

            n = 100;

            int[] arr = new int[n];
            List<int> list = new List<int>();

            sw.Start();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next();
            }
            sw.Stop();
            double arrMs = sw.Elapsed.TotalMilliseconds;
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                list.Add(rand.Next(1,100));
            }
            sw.Stop();
            double listMs = sw.Elapsed.TotalMilliseconds;
            sw.Restart();
            Array.Sort(arr);
            sw.Stop();
            double arrSortMs = sw.Elapsed.TotalMilliseconds;
            sw.Restart();
            list = list.OrderBy(i => i).ToList(); //Eftersom det är en fucking IEnumerable... Lazy Loading. Listan existerar inte förrän den behöver göra det...

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        
        static void BubbleSort(List<int> l)
        {

            for (int i = 0; i < l.Count - 1; i++) //Se nedan. 
            {
                for (int j = 0; j < l.Count - i - 1; j++) //Så att den inte går igenom redan sorterade nummer. Går marginellt snabbare här.
                {

                    if (l[j] > l[j + 1])
                    {
                        int temp = l[j];
                        l[j] = l[j + 1];
                        l[j + 1] = temp;
                    }
                }
            }

        }
        static void SelectionSort(List<int> l)
        {
            for (int i = 0; i < l.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[j] < l[min])
                        min = j;

                    if (min != i)
                    {
                        int temp = l[i];
                        l[i] = l[min];
                        l[min] = temp;
                    }
                }

            }
        }
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
    }
}
