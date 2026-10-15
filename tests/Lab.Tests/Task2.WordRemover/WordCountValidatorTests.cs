using Task2.WordRemover.Validation;

namespace Lab.Tests.Task2.WordRemover;

public sealed class WordCountValidatorTests
{
    public void ShouldAcceptZeroWhenNothingHasToBeRemoved()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("0");

        Assertions.IsTrue(isValid, "\"0\" is a valid count");
    }

    public void ShouldAcceptPositiveCountWhenInputIsDigitsOnly()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("4");

        Assertions.IsTrue(isValid, "\"4\" is a valid count");
    }

    public void ShouldAcceptNegativeCountWhenMinusLeadsTheDigits()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("-2");

        Assertions.IsTrue(isValid, "\"-2\" is well formed and is rejected later by the service");
    }

    public void ShouldRejectNullWhenNothingWasRead()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount(null);

        Assertions.IsFalse(isValid, "null is not a valid count");
    }

    public void ShouldRejectEmptyInputWhenNothingWasTyped()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("");

        Assertions.IsFalse(isValid, "an empty string is not a valid count");
    }

    public void ShouldRejectLetterWhenInputIsAWord()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("two");

        Assertions.IsFalse(isValid, "\"two\" is not a valid count");
    }

    public void ShouldRejectLoneMinusWhenNoDigitsFollowIt()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("-");

        Assertions.IsFalse(isValid, "\"-\" is not a valid count");
    }

    public void ShouldRejectDecimalPointWhenCountIsNotAnInteger()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount("2.5");

        Assertions.IsFalse(isValid, "\"2.5\" is not a valid count");
    }

    public void ShouldRejectSurroundingSpacesWhenInputIsPadded()
    {
        bool isValid = WordCountValidator.IfInputIsValidCount(" 2");

        Assertions.IsFalse(isValid, "\" 2\" is not a valid count");
    }
}
