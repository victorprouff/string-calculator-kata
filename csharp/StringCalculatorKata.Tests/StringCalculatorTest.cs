using FluentAssertions;
using Xunit;

namespace StringCalculatorKata.Tests;

public class StringCalculatorTest
{
    [Fact]
    public void Return0WhenStringEmpty()
    {
        var result = StringCalculator.Add("");

        result.Should().Be(0);
    }
}