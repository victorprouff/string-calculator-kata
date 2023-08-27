using System.Collections.Generic;

namespace StringCalculatorKata;

public class Logger : Ilogger
{
    private static readonly IList<string> Messages = new List<string>();

    public void Write(string message)
    {
    }

    public IList<string> GetMessages()
    {
        return new List<string>();
    }
}