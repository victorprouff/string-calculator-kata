using System.Collections.Generic;

namespace StringCalculatorKata;

public interface Ilogger
{
    public void Write(string message);

    public IList<string> GetMessages();
}