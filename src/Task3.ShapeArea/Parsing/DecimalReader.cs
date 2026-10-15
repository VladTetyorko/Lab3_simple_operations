namespace Task3.ShapeArea.Parsing;

public static class DecimalReader
{
    private const char MinusSign = '-';
    private const char MinDigit = '0';
    private const char MaxDigit = '9';
    private const char DotSeparator = '.';
    private const char CommaSeparator = ',';
    private const int FirstIndex = 0;
    private const int SignLength = 1;
    private const double DecimalBase = 10;
    private const double Zero = 0;
    private const double NoScale = 1;

    public static double Read(string number)
    {
        char[] charsetFromNumber = number.ToCharArray();
        bool isNegative = charsetFromNumber[FirstIndex] == MinusSign;
        int index = FirstIndex;

        if (isNegative)
        {
            index = FirstIndex + SignLength;
        }

        double wholePart = Zero;

        while (index < charsetFromNumber.Length && IsDigit(charsetFromNumber[index]))
        {
            wholePart = wholePart * DecimalBase + (charsetFromNumber[index] - MinDigit);
            index++;
        }

        double fractionPart = Zero;
        double fractionScale = NoScale;

        if (index < charsetFromNumber.Length && IsSeparator(charsetFromNumber[index]))
        {
            index++;

            while (index < charsetFromNumber.Length && IsDigit(charsetFromNumber[index]))
            {
                fractionPart = fractionPart * DecimalBase + (charsetFromNumber[index] - MinDigit);
                fractionScale = fractionScale * DecimalBase;
                index++;
            }
        }

        double value = wholePart + fractionPart / fractionScale;

        if (isNegative)
        {
            return -value;
        }

        return value;
    }

    private static bool IsDigit(char currentChar)
    {
        return currentChar >= MinDigit && currentChar <= MaxDigit;
    }

    private static bool IsSeparator(char currentChar)
    {
        return currentChar == DotSeparator || currentChar == CommaSeparator;
    }
}
