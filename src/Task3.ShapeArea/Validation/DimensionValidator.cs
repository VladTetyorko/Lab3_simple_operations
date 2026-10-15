namespace Task3.ShapeArea.Validation;

public static class DimensionValidator
{
    private const char MinusSign = '-';
    private const char MinDigit = '0';
    private const char MaxDigit = '9';
    private const char DotSeparator = '.';
    private const char CommaSeparator = ',';
    private const int FirstIndex = 0;
    private const int SignLength = 1;
    private const int EmptyLength = 0;
    private const int NoDigits = 0;
    private const int SingleSeparator = 1;

    public static bool IfInputIsValidDimension(string? stringToCheck)
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

        int digitCount = NoDigits;
        int separatorCount = NoDigits;

        for (int index = firstDigitIndex; index < charsetFromStringToCheck.Length; index++)
        {
            char currentChar = charsetFromStringToCheck[index];

            if (currentChar >= MinDigit && currentChar <= MaxDigit)
            {
                digitCount++;
            }
            else if (currentChar == DotSeparator || currentChar == CommaSeparator)
            {
                separatorCount++;
            }
            else
            {
                return false;
            }
        }

        return digitCount > NoDigits && separatorCount <= SingleSeparator;
    }
}
