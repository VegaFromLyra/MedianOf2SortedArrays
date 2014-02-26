using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianOf2SortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = {1, 3, 5, 7, 9};

            int[] arr2 = {2, 20, 25, 58, 60 };

            Console.WriteLine("Test case 1");
            Console.WriteLine("Expected median is 8, Actual is {0}", getMedian(arr1, arr2));

            Console.WriteLine("Test case 2");
            Console.WriteLine("Expected median is 8, Actual is {0}", 
                              getMedianFaster(arr1, arr2));

            int[] arr3 = { 1, 3, 5, 7};
            int[] arr4 = { 2, 20, 25, 58};

            Console.WriteLine("Test case 3");
            Console.WriteLine("Expected median is 6, Actual is {0}", getMedian(arr3, arr4));

            Console.WriteLine("Test case 4");
            Console.WriteLine("Expected median is 6, Actual is {0}",
                              getMedianFaster(arr3, arr4));

        }



        // Time complexity - O(n)
        // Merges the values from arr1 and arr2
        // and when the value reaches index n
        // gets the average of result[n - 1] and result[n] and returns it
        static int getMedian(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new Exception("Invalid input");
            }

            int n = arr1.Length;

            int[] result = new int[n * 2];

            int i = 0, j = 0, k = 0;

            int median = 0;

            for (k = 0; k < result.Length; k++)
            {
                if (arr1[i] < arr2[j])
                {
                    result[k] = arr1[i];
                    i++;
                }
                else
                {
                    result[k] = arr2[j];
                    j++;
                }

                if (k == n)
                {
                    median = (result[n - 1] + result[n]) / 2;
                    break;
                }
            }

            return median;
        }

        // Gets m1 and m2
        // if m1 == m2, returns either
        // if m1 < m2, gets second half of arr1 and first half
        // of arr2 and repeats
        // else gets first half of arr1 and second half of arr2 
        // and repeats
        static int getMedianFaster(int[] arr1, int[] arr2)
        {
            if (arr1.Length == 0 || arr2.Length == 0)
            {
                throw new Exception("Error");
            }

            int n1 = arr1.Length;
            int n2 = arr2.Length;

            if (n1 != n2)
            {
                throw new Exception("Error - unequal array length");
            }

            int n = n1;

            if (n == 1)
            {
                return (arr1[0] + arr2[0]) / 2;
            }

            if (n == 2)
            {
                int max = Math.Max(arr1[0], arr2[0]);
                int min = Math.Min(arr1[1], arr2[1]);

                return (max + min) / 2;
            }

            int m1 = getMedian(arr1);

            int m2 = getMedian(arr2);

            if (m1 == m2)
            {
                return m1;
            }

            int start1 = 0;
            int end1 = arr1.Length - 1;

            int start2 = 0;
            int end2 = arr2.Length - 1;

            int[] newArr1 = null;
            int[] newArr2 = null;

            if (m1 < m2)
            {
                // get second half of m1 and first half of m2
                if (n % 2 == 0)
                {
                    start1 = n / 2;
                    end2 = (n / 2) - 1;
                }
                else
                {
                    start1 = n / 2;
                    end2 = n / 2;
                }
            }
            else
            {
                // get first half of m1 and second half of m2 
                if (n % 2 == 0)
                {
                    end1 = (n / 2) - 1;
                    start2 = n / 2;
                }
                else
                {
                    end1 = n / 2;
                    start2 = n / 2;
                }
            }

            newArr1 = new int[end1 - start1 + 1];
            for (int i = start1, j = 0; i <= end1; i++, j++)
            {
                newArr1[j] = arr1[i];
            }

            newArr2 = new int[end2 - start2 + 1];
            for (int i = start2, j = 0; i <= end2; i++, j++)
            {
                newArr2[j] = arr2[i];
            }

            return getMedianFaster(newArr1, newArr2);
        }

        // input should be sorted
        static int getMedian(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr[0];
            }

            int n = arr.Length;

            int mid = n / 2;

            if (n % 2 == 0)
            {
                return ((arr[mid - 1] + arr[mid]) / 2);
            }

            return arr[mid];
        }
    }
}
