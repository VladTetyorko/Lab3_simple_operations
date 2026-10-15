namespace Task1.NumberReverser.Validation;

public static class NumberValidator
{
    private const char MinusSign = '-';
    private const char MinDigit = '0';
    private const char MaxDigit = '9';
    private const int FirstIndex = 0;

    public static bool IfInputIsValidNumber(string? stringToCheck)
    {
        if (stringToCheck == null)
        {
            return false;
        }

        return IsNotEmpty(stringToCheck) && IsCorrectNumber(stringToCheck);
    }

    private static bool IsNotEmpty(string stringToCheck)
    {
        return stringToCheck.Length > 0;
    }

    private static bool IsCorrectNumber(string stringToCheck)
    {
        var charsetFromStringToCheck = stringToCheck.ToCharArray();
        var firstDigitIndex = FirstIndex;

        if (charsetFromStringToCheck[FirstIndex] == MinusSign) firstDigitIndex = FirstIndex + 1;

        if (charsetFromStringToCheck.Length == firstDigitIndex) return false;

        for (var index = firstDigitIndex; index < charsetFromStringToCheck.Length; index++)
        {
            var currentChar = charsetFromStringToCheck[index];

            if (currentChar < MinDigit || currentChar > MaxDigit) return false;
        }

        return true;
    }
}