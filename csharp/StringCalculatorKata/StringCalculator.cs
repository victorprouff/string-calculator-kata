using System;
using System.Collections.Generic;
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
        var exeptedValue = new List<int>();
        var result = 0;
        foreach (var numberString in completeString.Split(separators))
        {
            var number = Convert.ToInt32(numberString);

            if (number < 0)
            {
                exeptedValue.Add(number);
            }

            result += number;
        }

        if (exeptedValue.Any())
        {
            throw new Exception($"negatives not allowed: {string.Join(", ", exeptedValue)}");
        }

        return result;
    }
}