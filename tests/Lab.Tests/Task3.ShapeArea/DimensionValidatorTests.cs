using Task3.ShapeArea.Validation;

namespace Lab.Tests.Task3.ShapeArea;

public sealed class DimensionValidatorTests
{
    public void ShouldAcceptWholeNumberWhenInputHasNoSeparator()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("3");

        Assertions.IsTrue(isValid, "\"3\" is a valid dimension");
    }

    public void ShouldAcceptDotSeparatorWhenInputIsDecimal()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("2.5");

        Assertions.IsTrue(isValid, "\"2.5\" is a valid dimension");
    }

    public void ShouldAcceptCommaSeparatorWhenInputIsDecimal()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("2,5");

        Assertions.IsTrue(isValid, "\"2,5\" is a valid dimension");
    }

    public void ShouldAcceptNegativeNumberWhenMinusLeadsTheDigits()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("-4.5");

        Assertions.IsTrue(isValid, "\"-4.5\" is well formed and is rejected later by the service");
    }

    public void ShouldRejectNullWhenNothingWasRead()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension(null);

        Assertions.IsFalse(isValid, "null is not a valid dimension");
    }

    public void ShouldRejectEmptyInputWhenNothingWasTyped()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("");

        Assertions.IsFalse(isValid, "an empty string is not a valid dimension");
    }

    public void ShouldRejectLetterWhenInputIsAWord()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("2.5a");

        Assertions.IsFalse(isValid, "\"2.5a\" is not a valid dimension");
    }

    public void ShouldRejectSecondSeparatorWhenInputHasTwo()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("2.5.1");

        Assertions.IsFalse(isValid, "\"2.5.1\" is not a valid dimension");
    }

    public void ShouldRejectSeparatorOnlyWhenNoDigitIsPresent()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension(".");

        Assertions.IsFalse(isValid, "\".\" is not a valid dimension");
    }

    public void ShouldRejectLoneMinusWhenNoDigitsFollowIt()
    {
        bool isValid = DimensionValidator.IfInputIsValidDimension("-");

        Assertions.IsFalse(isValid, "\"-\" is not a valid dimension");
    }
}
