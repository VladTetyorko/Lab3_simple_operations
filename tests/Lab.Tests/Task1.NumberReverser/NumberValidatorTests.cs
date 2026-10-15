using Task1.NumberReverser.Validation;

namespace Lab.Tests.Task1.NumberReverser;

public sealed class NumberValidatorTests
{
    public void ShouldAcceptDigitsWhenInputHasNoSign()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("123");

        Assertions.IsTrue(isValid, "\"123\" is a valid number");
    }

    public void ShouldAcceptSingleZeroWhenInputIsZero()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("0");

        Assertions.IsTrue(isValid, "\"0\" is a valid number");
    }

    public void ShouldAcceptTrailingZerosWhenInputEndsWithZeros()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("1000");

        Assertions.IsTrue(isValid, "\"1000\" is a valid number");
    }

    public void ShouldAcceptNegativeNumberWhenMinusLeadsTheDigits()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("-453");

        Assertions.IsTrue(isValid, "\"-453\" is a valid number");
    }

    public void ShouldAcceptSignedZerosWhenEveryDigitIsZero()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("-000");

        Assertions.IsTrue(isValid, "\"-000\" is a valid number");
    }

    public void ShouldAcceptLongInputWhenItExceedsTheLongRange()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("123456789012345678901234567891");

        Assertions.IsTrue(isValid, "a thirty digit number is a valid number");
    }

    public void ShouldRejectNullWhenNothingWasRead()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber(null);

        Assertions.IsFalse(isValid, "null is not a valid number");
    }

    public void ShouldRejectEmptyInputWhenNothingWasTyped()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("");

        Assertions.IsFalse(isValid, "an empty string is not a valid number");
    }

    public void ShouldRejectWhitespaceWhenOnlySpacesWereTyped()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("   ");

        Assertions.IsFalse(isValid, "\"   \" is not a valid number");
    }

    public void ShouldRejectLetterWhenInputMixesDigitsAndLetters()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("12a");

        Assertions.IsFalse(isValid, "\"12a\" is not a valid number");
    }

    public void ShouldRejectLoneMinusWhenNoDigitsFollowIt()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("-");

        Assertions.IsFalse(isValid, "\"-\" is not a valid number");
    }

    public void ShouldRejectRepeatedMinusWhenSignIsDoubled()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("--5");

        Assertions.IsFalse(isValid, "\"--5\" is not a valid number");
    }

    public void ShouldRejectTrailingMinusWhenSignFollowsTheDigits()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("5-");

        Assertions.IsFalse(isValid, "\"5-\" is not a valid number");
    }

    public void ShouldRejectInnerSpaceWhenDigitsAreSeparated()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("1 2");

        Assertions.IsFalse(isValid, "\"1 2\" is not a valid number");
    }

    public void ShouldRejectTrailingSpaceWhenInputEndsWithBlank()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("12 ");

        Assertions.IsFalse(isValid, "\"12 \" is not a valid number");
    }

    public void ShouldRejectPlusSignWhenInputIsExplicitlyPositive()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("+12");

        Assertions.IsFalse(isValid, "\"+12\" is not a valid number");
    }

    public void ShouldRejectDecimalPointWhenInputIsNotAnInteger()
    {
        bool isValid = NumberValidator.IfInputIsValidNumber("1.5");

        Assertions.IsFalse(isValid, "\"1.5\" is not a valid number");
    }
}
