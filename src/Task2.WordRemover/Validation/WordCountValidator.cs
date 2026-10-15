namespace Task2.WordRemover.Validation;

public static class WordCountValidator
{
    private const char MinusSign = '-';
    private const char MinDigit = '0';
    private const char MaxDigit = '9';
    private const int FirstIndex = 0;
    private const int SignLength = 1;
    private const int EmptyLength = 0;

    public static bool IfInputIsValidCount(string? stringToCheck)
    {
        if (stringToCheck == null)
        {
            return false;
        }

        if (stringToCheck.Length == EmptyLength)
        {
            return false;
        }

        char[] charsetFromStringToCheck = stringToCheck.ToCharArray();
        int firstDigitIndex = FirstIndex;

        if (charsetFromStringToCheck[FirstIndex] == MinusSign)
        {
            firstDigitIndex = FirstIndex + SignLength;
        }

        if (charsetFromStringToCheck.Length == firstDigitIndex)
        {
            return false;
        }

        for (int index = firstDigitIndex; index < charsetFromStringToCheck.Length; index++)
        {
            char currentChar = charsetFromStringToCheck[index];

            if (currentChar < MinDigit || currentChar > MaxDigit)
            {
                return false;
            }
        }

        return true;
    }
}
