using System;
using System.Linq;

namespace StringCalculatorKata;

public static class StringCalculator
{
    public static int Add(string numbersString)
    {
        if (string.IsNullOrWhiteSpace(numbersString))
        {
            return 0;
        }

        return numbersString.Split(',')
            .Sum(number => Convert.ToInt32(number));
    }
}