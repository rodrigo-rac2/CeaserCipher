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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        k = k % 26;
        List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
        List<char> rotatedAlphabet = rotateAlphabet(alphabet, k);
        List<char> cipher = new List<char>();

        foreach (char ch in s)
        {
            try
            {
                bool isUpper = char.IsUpper(ch);
                int index = alphabet.IndexOf(char.ToLower(ch));
                cipher.Add(isUpper ? char.ToUpper(rotatedAlphabet[index]) : rotatedAlphabet[index]);
            } catch (ArgumentOutOfRangeException ex)
            {
                cipher.Add(ch);
            }
            
        }

        return new string(cipher.ToArray());
    }

    public static List<char> rotateAlphabet(List<char> alphabet, int k)
    {
        List<char> rotatedAlphabet = new List<char>();
        int alphabetCounter = k;
        while (alphabetCounter < alphabet.Count)
        {
            rotatedAlphabet.Add(alphabet[alphabetCounter]);
            alphabetCounter++;
        }
        int i = 0;
        while (i < k)
        {
            rotatedAlphabet.Add(alphabet[i]);
            i++;
        }
        return rotatedAlphabet;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        Console.WriteLine(result);
    }
}
