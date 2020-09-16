using System;
using System.Collections.Generic;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
