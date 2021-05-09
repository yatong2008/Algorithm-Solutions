using System;
using System.IO;
using System.Linq;

class Result
{

    /*
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */

    public static long repeatedString(string s, long n)
    {
        if (!s.Contains('a'))
        {
            return 0;
        }

        var repeatedTimes = n / s.Length;
        var singleRepeatedCount = s.Count(x => x == 'a');

        var sub = s.Substring(0, (int) (n - repeatedTimes * s.Length));

        var result = repeatedTimes * singleRepeatedCount + sub.Count(x => x == 'a');

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}