using System;

namespace StringCalculatorKata;

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        return Convert.ToInt32(numbers);
    }
}