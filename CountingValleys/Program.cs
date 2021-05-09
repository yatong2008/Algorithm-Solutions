using System;
using System.IO;

namespace CountingValleys
{
    class Result
    {

        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */

        public static int countingValleys(int steps, string path)
        {
            var seaLevel = 0;
            var pathActions = path.ToCharArray();
            var valleys = 0;

            for (int i = 0; i < pathActions.Length; i++)
            {
                seaLevel += path[i] == 'U' ? 1 : -1;
                valleys += path[i] == 'U' && seaLevel == 0 ? 1 : 0;
            }

            return valleys;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            int result = Result.countingValleys(steps, path);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
