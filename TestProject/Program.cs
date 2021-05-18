using System;
using System.Collections.Generic;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

        int counter = int.Parse(Console.ReadLine() ?? string.Empty);

        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        for (int i = 0; i < counter; i++)
        {
            var input = Console.ReadLine()?.Split(' ');
            if (input != null && input.Length == 2)
            {
                dictionary.Add(input[0], input[1]);
            }
        }

        bool moreInput = true;

        while (moreInput)
        {
            var key = Console.ReadLine();

            if (string.IsNullOrEmpty(key))
            {
                moreInput = false;
                continue;
            }

            var found = dictionary.TryGetValue(key, out var value);

            if (found)
            {
                Console.WriteLine("{0}={1}", key, value);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}