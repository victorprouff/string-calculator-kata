using System;
using System.Linq;

namespace StringCalculatorKata;

public static class StringCalculator
{
    private const int HeadSize = 4;

    public static int Add(string completeString)
    {
        if (string.IsNullOrWhiteSpace(completeString))
        {
            return 0;
        }

        if (completeString.StartsWith("//"))
        {
            var separator = Convert.ToChar(completeString.Substring(2, 1));

            return Sum(completeString.Substring(HeadSize), new[] { separator });
        }

        return Sum(completeString, new[] { ',', '\n' });
    }

    private static int Sum(string completeString, char[] separators)
    {
        return completeString.Split(separators).Sum(number => Convert.ToInt32(number));
    }
}