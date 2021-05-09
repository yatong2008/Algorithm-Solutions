using System;
using System.IO;

namespace HackerRank_MaxArraySum
{
    class Solution
    {

        // Complete the maxSubsetSum function below.
        static int maxSubsetSum(int[] arr)
        {
            var maxGlobal = Math.Max(arr[0], 0);
            var maxEndHere = Math.Max(arr[0], 0);
            var maxBeforeLast = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                var maxForLastElement = maxEndHere;
                maxEndHere = maxBeforeLast + arr[i];
                maxGlobal = Math.Max(maxGlobal, maxEndHere);
                maxBeforeLast = Math.Max(maxBeforeLast, maxForLastElement);
            }

            return maxGlobal;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine());

            //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            //    ;
            //int res = maxSubsetSum(arr);

            //textWriter.WriteLine(res);

            //textWriter.Flush();
            //textWriter.Close();

            Console.WriteLine(maxSubsetSum(new []{ 3, 5, -7, 8, 10 }));
        }
    }
}
