using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace StringCalculatorKata.Tests;

public class StringCalculatorTest
{
    [Fact]
    public void Return0WhenStringEmpty()
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add("");

        result.Should().Be(0);
        logger.Verify(e => e.Write("0"), Times.Once);
    }

    [Fact]
    public void Return5WhenStringValue5()
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add("5");

        result.Should().Be(5);
        logger.Verify(e => e.Write("5"), Times.Once);
    }

    [Fact]
    public void ReturnSumWhenStringContain2Value()
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add("5,2");

        result.Should().Be(7);
        logger.Verify(e => e.Write("7"), Times.Once);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4", 10)]
    [InlineData("10,1,2,3,4,14", 34)]
    public void ReturnSumWhenStringContainUnknownAmountOfNumbers(string numbers, int expectedResult)
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add(numbers);

        result.Should().Be(expectedResult);
        logger.Verify(e => e.Write(expectedResult.ToString()), Times.Once);
    }

    [Fact]
    public void ReturnSumWhenStringContainValuesWithLnSeparator()
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add("1\n2,3");

        result.Should().Be(6);
        logger.Verify(e => e.Write("6"), Times.Once);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//:\n4:2:5", 11)]
    [InlineData("//$\n4$9$7$2", 22)]
    public void ReturnSumWhenStringContainDifferentDelimiters(string numbers, int expectedResult)
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add(numbers);

        result.Should().Be(expectedResult);
        logger.Verify(e => e.Write(expectedResult.ToString()), Times.Once);
    }

    [Theory]
    [InlineData("//;\n1;-2", "negatives not allowed: -2")]
    [InlineData("//:\n-4:2:-5", "negatives not allowed: -4, -5")]
    [InlineData("//$\n4$-9$7$-2", "negatives not allowed: -9, -2")]
    public void ThrowExeptionWhenNegativeValueDetected(string numbers, string expectedMessageException)
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var exception = ()  => stringCalculator.Add(numbers);

        exception.Should().Throw<Exception>().WithMessage(expectedMessageException);
    }

    [Theory]
    [InlineData("1001,2", 2)]
    [InlineData("//:\n4000:2:5", 7)]
    [InlineData("10,1001,2,3,4,1400", 19)]
    public void ReturnSumButIgnoreNumbersBiggerThan1000(string numbers, int expectedResult)
    {
        var logger = new Mock<Ilogger>();
        var stringCalculator = new StringCalculator(logger.Object);

        var result = stringCalculator.Add(numbers);

        result.Should().Be(expectedResult);
        logger.Verify(e => e.Write(expectedResult.ToString()), Times.Once);
    }
}