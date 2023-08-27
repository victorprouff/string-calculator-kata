using System;
using System.Linq;

namespace StringCalculatorKata;

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        return numbers.Split(',')
            .Sum(number => Convert.ToInt32(number));
    }
}