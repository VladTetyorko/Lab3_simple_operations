namespace Task1.NumberReverser;

using Exceptions;
using Validation;

public sealed class NumberReverseService
{
    private const char MinusSign = '-';
    private const char ZeroDigit = '0';
    private const string Zero = "0";
    private const string EmptyText = "";
    private const int LastIndexOffset = 1;

    public string ReverseNumber(string number)
    {
        if (!NumberValidator.IfInputIsValidNumber(number))
        {
            throw new InvalidNumberException("Input must be an optional minus sign followed by digits.");
        }

        var charset = number.ToCharArray();
        var isNegative = charset[0] == MinusSign;
        var firstDigitIndex = 0;

        if (isNegative) firstDigitIndex = 0 + 1;

        var reversedDigits = EmptyText;

        for (var index = charset.Length - LastIndexOffset; index >= firstDigitIndex; index--)
            reversedDigits += charset[index];

        var significantDigits = RemoveLeadingZeros(reversedDigits);

        if (significantDigits == Zero) return Zero;

        if (isNegative) return MinusSign + significantDigits;

        return significantDigits;
    }

    private static string RemoveLeadingZeros(string digits)
    {
        var charset = digits.ToCharArray();
        var firstSignificantIndex = 0;

        while (firstSignificantIndex < charset.Length - LastIndexOffset
               && charset[firstSignificantIndex] == ZeroDigit)
            firstSignificantIndex++;

        return digits.Substring(firstSignificantIndex);
    }
}