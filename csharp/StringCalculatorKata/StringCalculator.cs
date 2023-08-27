using System;
using System.Linq;

namespace StringCalculatorKata;

public static class StringCalculator
{
    public static int Add(string completeString)
    {
        if (string.IsNullOrWhiteSpace(completeString))
        {
            return 0;
        }

        if (completeString.StartsWith("//"))
        {
            var separator = Convert.ToChar(completeString.Substring(2, 1));

            var numbers = completeString.Substring(4);
            var result = 0;
            foreach (var number in numbers.Split(',', '\n', separator))
            {
                result += Convert.ToInt32(number);
            }

            return result;
        }

        return completeString.Split(',', '\n').Sum(number => Convert.ToInt32(number));
    }
}