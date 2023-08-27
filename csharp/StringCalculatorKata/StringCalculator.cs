using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata;

public class StringCalculator
{
    private readonly Ilogger _logger;

    public StringCalculator(Ilogger logger)
    {
        _logger = logger;
    }

    private const int HeadSize = 4;
    private const int MaximumValue = 1000;
    private static readonly char[] DefaultSeparators = { ',', '\n' };

    public int Add(string completeString)
    {
        if (string.IsNullOrWhiteSpace(completeString))
        {
            return LogResultBeforeToReturn(0);
        }

        if (completeString.StartsWith("//"))
        {
            return LogResultBeforeToReturn(
                Sum(
                    RemoveHeader(completeString),
                    GetSpecialDelimitor(completeString)));
        }

        return LogResultBeforeToReturn(Sum(completeString, DefaultSeparators));
    }

    private int LogResultBeforeToReturn(int result)
    {
        _logger.Write(result.ToString());
        return result;
    }

    private static string RemoveHeader(string numbers) => numbers.Substring(HeadSize);

    private static char[] GetSpecialDelimitor(string numbers) => new[] { Convert.ToChar(numbers.Substring(2, 1)) };

    private static int Sum(string completeString, char[] separators)
    {
        var numbers = ConvertToIntList(completeString, separators).ToArray();
        var negativeValue = GetNegativeValues(numbers);

        ThrowIfNegativeValueDetected(negativeValue);

        return numbers.Sum();
    }

    private static IEnumerable<int> GetNegativeValues(IEnumerable<int> numbers) =>numbers.Where(v => v < 0);

    private static IEnumerable<int> ConvertToIntList(string completeString, char[] separators) =>
        completeString.Split(separators)
            .Select(v => Convert.ToInt32(v))
            .Where(v => v <= MaximumValue);

    private static void ThrowIfNegativeValueDetected(IEnumerable<int> negativeValue)
    {
        if (negativeValue.Any())
        {
            throw new Exception($"negatives not allowed: {string.Join(", ", negativeValue)}");
        }
    }
}