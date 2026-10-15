using Task1.NumberReverser;
using Task1.NumberReverser.Exceptions;

namespace Lab.Tests.Task1.NumberReverser;

public sealed class NumberReverseServiceTests
{
    private const string MinusSign = "-";
    private const int FirstIndex = 0;
    private const int SignLength = 1;

    public void ShouldReverseDigitsWhenInputIsPositive()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("123");

        Assertions.AreEqual("321", reversed);
    }

    public void ShouldDropLeadingZerosWhenInputEndsWithZeros()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("1000");

        Assertions.AreEqual("1", reversed);
    }

    public void ShouldKeepMinusWhenInputIsNegative()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("-453");

        Assertions.AreEqual("-354", reversed);
    }

    public void ShouldDropLeadingZerosAndKeepMinusWhenInputIsNegative()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("-1200");

        Assertions.AreEqual("-21", reversed);
    }

    public void ShouldReturnZeroWhenInputIsZero()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("0");

        Assertions.AreEqual("0", reversed);
    }

    public void ShouldReturnUnsignedZeroWhenEveryDigitIsZero()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("-000");

        Assertions.AreEqual("0", reversed);
    }

    public void ShouldReverseEveryDigitWhenInputExceedsTheLongRange()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("123456789012345678901234567891");

        Assertions.AreEqual("198765432109876543210987654321", reversed);
    }

    public void ShouldReturnTheOriginalWhenReversedTwice()
    {
        NumberReverseService service = new NumberReverseService();

        string reversedTwice = service.ReverseNumber(service.ReverseNumber("1234"));

        Assertions.AreEqual("1234", reversedTwice);
    }

    public void ShouldReturnNegativeResultWhenInputIsNegative()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("-1234");

        Assertions.IsTrue(reversed.Substring(FirstIndex, SignLength) == MinusSign,
            "reversing a negative number keeps the minus sign");
    }

    public void ShouldReturnPositiveResultWhenInputIsPositive()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("1234");

        Assertions.IsFalse(reversed.Substring(FirstIndex, SignLength) == MinusSign,
            "reversing a positive number introduces no minus sign");
    }

    public void ShouldPreserveDigitCountWhenNoZerosAreStripped()
    {
        NumberReverseService service = new NumberReverseService();

        string reversed = service.ReverseNumber("94321");

        Assertions.AreEqual("94321".Length, reversed.Length);
    }

    public void ShouldThrowInvalidNumberExceptionWhenInputContainsLetter()
    {
        NumberReverseService service = new NumberReverseService();
        bool wasThrown = false;

        try
        {
            service.ReverseNumber("12a");
        }
        catch (InvalidNumberException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "\"12a\" throws InvalidNumberException");
    }

    public void ShouldThrowInvalidNumberExceptionWhenInputIsLoneMinus()
    {
        NumberReverseService service = new NumberReverseService();
        bool wasThrown = false;

        try
        {
            service.ReverseNumber(MinusSign);
        }
        catch (InvalidNumberException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "\"-\" throws InvalidNumberException");
    }

    public void ShouldThrowInvalidNumberExceptionWhenInputIsEmpty()
    {
        NumberReverseService service = new NumberReverseService();
        bool wasThrown = false;

        try
        {
            service.ReverseNumber("");
        }
        catch (InvalidNumberException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "an empty string throws InvalidNumberException");
    }

    public void ShouldThrowInvalidNumberExceptionWhenInputIsWhitespace()
    {
        NumberReverseService service = new NumberReverseService();
        bool wasThrown = false;

        try
        {
            service.ReverseNumber("   ");
        }
        catch (InvalidNumberException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "\"   \" throws InvalidNumberException");
    }
}
