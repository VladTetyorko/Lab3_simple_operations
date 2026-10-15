namespace Task2.WordRemover.Parsing;

public static class IntegerReader
{
    private const char MinusSign = '-';
    private const char MinDigit = '0';
    private const int DecimalBase = 10;
    
    public static int Read(string digits)
    {
        char[] charsetFromDigits = digits.ToCharArray();
        bool isNegative = charsetFromDigits[0] == MinusSign;
        int firstDigitIndex = 0;

        if (isNegative)
        {
            firstDigitIndex = 0 + 1;
        }

        int value = 0;

        for (int index = firstDigitIndex; index < charsetFromDigits.Length; index++)
        {
            value = value * DecimalBase + (charsetFromDigits[index] - MinDigit);
        }

        if (isNegative)
        {
            return -value;
        }

        return value;
    }
}
