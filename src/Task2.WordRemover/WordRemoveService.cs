namespace Task2.WordRemover;

using Exceptions;

public sealed class WordRemoveService
{
    private const char Space = ' ';
    private const char Tab = '\t';
    private const string EmptyText = "";
    private const int FirstIndex = 0;
    private const int MinimumCount = 0;
    private const string NegativeCountMessage = "The number of words to remove must not be negative.";

    public string RemoveFirstWords(string text, int count)
    {
        if (count < MinimumCount)
        {
            throw new InvalidWordCountException(NegativeCountMessage);
        }

        char[] charsetFromText = text.ToCharArray();
        int index = FirstIndex;

        for (int removedWords = FirstIndex; removedWords < count; removedWords++)
        {
            index = SkipWhitespace(charsetFromText, index);
            index = SkipWord(charsetFromText, index);

            if (index == charsetFromText.Length)
            {
                return EmptyText;
            }
        }

        index = SkipWhitespace(charsetFromText, index);

        return text.Substring(index);
    }

    private static int SkipWhitespace(char[] charsetFromText, int startIndex)
    {
        int index = startIndex;

        while (index < charsetFromText.Length && IsWhitespace(charsetFromText[index]))
        {
            index++;
        }

        return index;
    }

    private static int SkipWord(char[] charsetFromText, int startIndex)
    {
        int index = startIndex;

        while (index < charsetFromText.Length && !IsWhitespace(charsetFromText[index]))
        {
            index++;
        }

        return index;
    }

    private static bool IsWhitespace(char currentChar)
    {
        return currentChar == Space || currentChar == Tab;
    }
}
