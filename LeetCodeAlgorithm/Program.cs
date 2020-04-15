using System;
using System.Collections.Generic;
using System.Linq;
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
            //MoveZeroes(new[] { 0, 1, 0, 3, 12 });

            //Console.WriteLine(CountElements(new[] { 1, 1, 3, 3, 5, 5, 7, 7 }));

            //GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });

            Console.WriteLine(StringShift("abc", new[] {new[] {0, 1}, new[] {1, 2}}));

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
            var listOfPastResults = new List<int> { n };

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


        //LeetCode Counting Elements
        public static int CountElements(int[] arr)
        {
            var hashArr = arr.ToHashSet();

            return arr.Count(i => hashArr.Contains(i + 1));
        }

        //LeetCode #49. Group Anagrams
        //https://leetcode.com/problems/group-anagrams/
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                var charArray = str.ToCharArray();

                Array.Sort(charArray);
                var keyString = new string(charArray);

                if (dict.ContainsKey(keyString))
                {
                    dict[keyString].Add(str);
                }
                else
                {
                    dict.Add(keyString, new List<string> { str });
                }
            }

            return dict.Values.ToList();
        }


        //876. Middle of the Linked List
        //https://leetcode.com/problems/middle-of-the-linked-list/
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode MiddleNode(ListNode head)
        {
            var counter = 0;
            var currentNode = head;
            var dict = new Dictionary<int, ListNode>();

            while (currentNode != null)
            {
                dict.Add(counter++, currentNode);
                currentNode = currentNode.next;
            }

            return dict[counter / 2];
        }



        //  Perform String Shifts


        public static string StringShift(string s, int[][] shift)
        {
            if (string.IsNullOrEmpty(s)) return s;

            var leftShift = 0;
            var rightShift = 0;

            foreach (var i in shift)
            {
                if (i[0] == 0)
                    leftShift += i[1];
                else
                    rightShift += i[1];
            }

            if (leftShift >= rightShift)
                return s.Substring((leftShift - rightShift) % s.Length) +
                       s.Substring(0, (leftShift - rightShift) % s.Length);
         
            return s.Substring(s.Length - (rightShift - leftShift) % s.Length) +
                       s.Substring(0, s.Length - (rightShift - leftShift) % s.Length);
        }
    }
}
