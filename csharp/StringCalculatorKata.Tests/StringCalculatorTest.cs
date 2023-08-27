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

    [Fact]
    public void Return5WhenStringValue5()
    {
        var result = StringCalculator.Add("5");

        result.Should().Be(5);
    }

    [Fact]
    public void ReturnSumWhenStringContain2Value()
    {
        var result = StringCalculator.Add("5,2");

        result.Should().Be(7);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4", 10)]
    [InlineData("10,1,2,3,4,14", 34)]
    public void ReturnSumWhenStringContainUnknownAmountOfNumbers(string numbers, int expectedResult)
    {
        var result = StringCalculator.Add(numbers);

        result.Should().Be(expectedResult);
    }

    [Fact]
    public void ReturnSumWhenStringContainValuesWithLnSeparator()
    {
        var result = StringCalculator.Add("1\n2,3");

        result.Should().Be(6);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//:\n4:2:5", 11)]
    [InlineData("//$\n4$9$7$2", 22)]
    public void ReturnSumWhenStringContainDifferentDelimiters(string numbers, int expectedResult)
    {
        var result = StringCalculator.Add(numbers);

        result.Should().Be(expectedResult);
    }
}