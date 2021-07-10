using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'makeAnagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING a
     *  2. STRING b
     */

    public static int makeAnagram(string a, string b)
    {
        var charInFirstString = new int[26];
        var charInSecondString = new int[26];
        foreach (var ch in a)
        {
            charInFirstString[ch - 'a']++;
        }

        foreach (var ch in b)
        {
            charInSecondString[ch - 'a']++;
        }

        var counter = 0;

        for (var i = 0; i < 26; i++)
        {
            counter += Math.Abs(charInFirstString[i] - charInSecondString[i]);
        }

        return counter;
    }

}

class Program
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = Result.makeAnagram(a, b);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}