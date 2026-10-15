namespace Task3.ShapeArea.Formatting;

public static class AreaFormatter
{
    private const double ScaleFactor = 10000;
    private const double RoundingOffset = 0.5;
    private const long ScaleDivisor = 10000;
    private const int FractionDigits = 4;
    private const char ZeroDigit = '0';
    private const char DotSeparator = '.';
    private const string EmptyText = "";
    private const int FirstIndex = 0;
    private const int LastIndexOffset = 1;

    public static string Format(double area)
    {
        long scaledArea = (long)(area * ScaleFactor + RoundingOffset);
        long wholePart = scaledArea / ScaleDivisor;
        long fractionPart = scaledArea % ScaleDivisor;

        string fractionText = TrimTrailingZeros(PadFraction(fractionPart));

        if (fractionText == EmptyText)
        {
            return wholePart.ToString();
        }

        return wholePart.ToString() + DotSeparator + fractionText;
    }

    private static string PadFraction(long fractionPart)
    {
        string digits = fractionPart.ToString();

        while (digits.Length < FractionDigits)
        {
            digits = ZeroDigit + digits;
        }

        return digits;
    }

    private static string TrimTrailingZeros(string digits)
    {
        char[] charsetFromDigits = digits.ToCharArray();
        int lengthWithoutZeros = charsetFromDigits.Length;

        while (lengthWithoutZeros > FirstIndex && charsetFromDigits[lengthWithoutZeros - LastIndexOffset] == ZeroDigit)
        {
            lengthWithoutZeros--;
        }

        return digits.Substring(FirstIndex, lengthWithoutZeros);
    }
}
