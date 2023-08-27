using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata;

public class StringCalculator
{
    private readonly Ilogger _logger;
    private readonly IWebservice _webservice;

    public StringCalculator(Ilogger logger, IWebservice webservice)
    {
        _logger = logger;
        _webservice = webservice;
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

    private int Sum(string completeString, char[] separators)
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

    private void ThrowIfNegativeValueDetected(IEnumerable<int> negativeValue)
    {
        if (negativeValue.Any())
        {
            var message = $"negatives not allowed: {string.Join(", ", negativeValue)}";
            _webservice.Notify(message);

            throw new Exception(message);
        }
    }
}