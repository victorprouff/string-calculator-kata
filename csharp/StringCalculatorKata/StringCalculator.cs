using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata;

public static class StringCalculator
{
    private const int HeadSize = 4;
    private static readonly char[] DefaultSeparators = { ',', '\n' };

    public static int Add(string completeString)
    {
        if (string.IsNullOrWhiteSpace(completeString))
        {
            return 0;
        }

        if (completeString.StartsWith("//"))
        {
            return Sum(RemoveHeader(completeString), new[] { GetSpecialDelimitor(completeString) });
        }

        return Sum(completeString, DefaultSeparators);
    }

    private static string RemoveHeader(string numbers) => numbers.Substring(HeadSize);

    private static char GetSpecialDelimitor(string numbers) => Convert.ToChar(numbers.Substring(2, 1));

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

            if (number > 1000)
            {
                continue;
            }

            result += number;
        }

        ThrowIfNegativeValueDetected(exeptedValue);

        return result;
    }

    private static void ThrowIfNegativeValueDetected(IReadOnlyCollection<int> exeptedValue)
    {
        if (exeptedValue.Any())
        {
            throw new Exception($"negatives not allowed: {string.Join(", ", exeptedValue)}");
        }
    }
}