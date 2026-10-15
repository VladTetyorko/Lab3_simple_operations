namespace Task4.TextMasker;

public sealed class TextMaskService
{
    private const int QuestionInterval = 15;
    private const int LetterInterval = 3;
    private const int DigitInterval = 5;
    private const char QuestionMask = '?';
    private const char LetterMask = 'X';
    private const char DigitMask = '9';
    private const string EmptyText = "";
    private const int FirstIndex = 0;
    private const int FirstPosition = 1;
    private const int NoRemainder = 0;

    public string Mask(string text)
    {
        char[] charsetFromText = text.ToCharArray();
        string maskedText = EmptyText;

        for (int index = FirstIndex; index < charsetFromText.Length; index++)
        {
            maskedText += MaskAtPosition(charsetFromText[index], index + FirstPosition);
        }

        return maskedText;
    }

    private static char MaskAtPosition(char currentChar, int position)
    {
        if (position % QuestionInterval == NoRemainder)
        {
            return QuestionMask;
        }

        if (position % LetterInterval == NoRemainder)
        {
            return LetterMask;
        }

        if (position % DigitInterval == NoRemainder)
        {
            return DigitMask;
        }

        return currentChar;
    }
}
