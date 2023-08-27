using System;

namespace StringCalculatorKata;

public static class StringCalculator
{
    public static int Add(string numbersString)
    {
        if (string.IsNullOrWhiteSpace(numbersString))
        {
            return 0;
        }

        var response = 0;
        foreach (var number in numbersString.Split(','))
        {
            response += Convert.ToInt32(number);
        }

        return response;
    }
}