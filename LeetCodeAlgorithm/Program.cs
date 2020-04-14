using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LeetCodeAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SingleNumber(new []{ 4, 1, 2, 1, 2 }));

            //Console.WriteLine(IsHappy(19));

            //Console.WriteLine(MaxSubArray(new[] { 1, 2, -1, -2, 2, 1, -2, 1, 4, -5, 4 }));
            MoveZeroes(new[] { 0, 1, 0, 3, 12 });
        }

        //LeetCode #136. Single Number
        //https://leetcode.com/problems/single-number/
        public static int SingleNumber(int[] nums)
        {
            if (nums.Length % 2 != 1)
            {
                return -1;
            }

            var result = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                result ^= nums[i];
            }

            return result;
        }


        //LeetCode #202. Happy Number
        //https://leetcode.com/problems/happy-number/
        public static bool IsHappy(int n)
        {
            var listOfPastResults = new List<int> {n};

            return IsReallyHappy(n, listOfPastResults);

        }

        public static bool IsReallyHappy(int n, List<int> listOfPastResults)
        {

            List<int> listOfDigits = new List<int>();
            while (n > 0)
            {
                listOfDigits.Add(n % 10);
                n /= 10;
            }

            var result = 0;
            foreach (var i in listOfDigits)
            {
                result += (int)Math.Pow(i, 2);
            }


            if (result == 1)
            {
                return true;
            }

            if (result == n || listOfPastResults.Contains(result))
            {
                return false;
            }

            listOfPastResults.Add(result);

            return IsReallyHappy(result, listOfPastResults);
        }

        //LeetCode #53. Maximum Subarray
        //https://leetcode.com/problems/maximum-subarray/
        public static int MaxSubArray(int[] nums)
        {
            var globalMax = nums[0];
            var currentMax = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                currentMax = Math.Max(currentMax + nums[i], nums[i]);
                globalMax = Math.Max(currentMax, globalMax);
            }

            return globalMax;
        }

        //LeetCode #283. Move Zeroes
        //https://leetcode.com/problems/move-zeroes/
        public static void MoveZeroes(int[] nums)
        {
            var clearedIndex = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[clearedIndex] = nums[i];
                    clearedIndex++;
                }
                
            }

            for (var i = clearedIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }
    }
}
