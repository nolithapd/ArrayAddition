using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 4, 6, 230, 10, 1, 3 };
            string arrayAdditionResults = ArrayAddition(testArray);
            Console.WriteLine(arrayAdditionResults);
        }
        /**
        * Have the function arrayAdditionI(arr) take the array of numbers stored in arr
        * and return the string true if any combination of numbers in the array
        * (excluding the largest number) can be added up to equal the largest number in
        * the array, otherwise return the string false. For example: if arr contains
        * [4, 6, 23, 10, 1, 3] the output should return true because 4 + 6 + 10 + 3 =
        * 23. The array will not be empty, will not contain all the same elements, and
        * may contain negative numbers.
        */
        public static string ArrayAddition(int[] arr)
        {
            Array.Sort(arr);
            int n = arr.Length;
            int target = arr[n - 1];
            int MAX = arr[0] >= 0 ? target + 1 : target + 1 + Math.Abs(arr[0]);
            int ZERO = arr[0] >= 0 ? 0 : -arr[0];
            bool[,] D = new bool[n,MAX];

            D[0,0] = true;
            for (int i = 0; i < n; i++) D[i,0] = true;
            D[0,ZERO] = true;
            for (int i = 0; i < n; i++) D[i,ZERO] = true;

            for (int i = 1; i <= n - 1; i++)
            {
                if (arr[i - 1] >= 0)
                {
                    for (int j = 1; j <= MAX - 1; j++)
                    {
                        D[i,j] = D[i - 1,j];
                        if (j - arr[i - 1] >= 0)
                        {
                            D[i,j] |= D[i - 1,j - arr[i - 1]];
                        }
                    }
                }
                else
                {
                    for (int j = MAX - 1 + arr[i - 1]; j >= 1; j--)
                    {
                        D[i,j] = D[i - 1,j];
                        if (j - arr[i - 1] >= 0)
                        {
                            D[i,j] |= D[i - 1,j - arr[i - 1]];
                        }
                    }
                }
            }
            return D[n - 1,MAX - 1] ? "true" : "false";
        }
     

    }
}
