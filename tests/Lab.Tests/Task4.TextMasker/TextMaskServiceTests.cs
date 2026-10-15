using Task4.TextMasker;

namespace Lab.Tests.Task4.TextMasker;

public sealed class TextMaskServiceTests
{
    private const int LetterInterval = 3;
    private const int DigitInterval = 5;
    private const int FirstIndex = 0;
    private const int FirstPosition = 1;
    private const int NoRemainder = 0;

    public void ShouldMaskTheSampleSentenceWhenEveryRuleApplies()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("Hello nice red car and green eyes");

        Assertions.AreEqual("HeXl9XniX9 Xed?caX 9Xd X9eXn ?yeX", masked);
    }

    public void ShouldReturnEmptyTextWhenInputIsEmpty()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("");

        Assertions.AreEqual("", masked);
    }

    public void ShouldLeaveTheFirstTwoCharactersWhenNoRuleApplies()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("ab");

        Assertions.AreEqual("ab", masked);
    }

    public void ShouldMaskTheThirdCharacterWhenPositionIsAMultipleOfThree()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("abc");

        Assertions.AreEqual("abX", masked);
    }

    public void ShouldMaskTheFifthCharacterWhenPositionIsAMultipleOfFive()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("abcde");

        Assertions.AreEqual("abXd9", masked);
    }

    public void ShouldMaskTheFifteenthCharacterWhenPositionIsAMultipleOfFifteen()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("abcdefghijklmno");

        Assertions.AreEqual("abXd9XghX9kXmn?", masked);
    }

    public void ShouldReplaceSpacesWhenTheyFallOnAMaskedPosition()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("a b c d e");

        Assertions.AreEqual("a X 9Xd X", masked);
    }

    public void ShouldKeepTheLengthWhenTextIsMasked()
    {
        TextMaskService service = new TextMaskService();

        string masked = service.Mask("Hello nice red car and green eyes");

        Assertions.AreEqual("Hello nice red car and green eyes".Length, masked.Length);
    }

    public void ShouldLeaveEveryUnmaskedPositionUntouchedWhenTextIsMasked()
    {
        TextMaskService service = new TextMaskService();
        string original = "Hello nice red car and green eyes";

        string masked = service.Mask(original);

        Assertions.IsTrue(UnmaskedPositionsMatch(original, masked),
            "positions that are multiples of neither three nor five keep their character");
    }

    private static bool UnmaskedPositionsMatch(string original, string masked)
    {
        char[] originalCharset = original.ToCharArray();
        char[] maskedCharset = masked.ToCharArray();

        for (int index = FirstIndex; index < originalCharset.Length; index++)
        {
            int position = index + FirstPosition;

            if (position % LetterInterval != NoRemainder
                && position % DigitInterval != NoRemainder
                && originalCharset[index] != maskedCharset[index])
            {
                return false;
            }
        }

        return true;
    }
}
