using Task2.WordRemover.Parsing;

namespace Lab.Tests.Task2.WordRemover;

public sealed class IntegerReaderTests
{
    public void ShouldReadZeroWhenInputIsZero()
    {
        int value = IntegerReader.Read("0");

        Assertions.AreEqual(0, value);
    }

    public void ShouldReadSingleDigitWhenInputIsOneCharacter()
    {
        int value = IntegerReader.Read("7");

        Assertions.AreEqual(7, value);
    }

    public void ShouldReadEveryDigitWhenInputHasSeveralCharacters()
    {
        int value = IntegerReader.Read("1204");

        Assertions.AreEqual(1204, value);
    }

    public void ShouldReadNegativeValueWhenMinusLeadsTheDigits()
    {
        int value = IntegerReader.Read("-38");

        Assertions.AreEqual(-38, value);
    }

    public void ShouldIgnoreLeadingZerosWhenInputIsPadded()
    {
        int value = IntegerReader.Read("00042");

        Assertions.AreEqual(42, value);
    }

    public void ShouldMatchLibraryParsingWhenInputIsPositive()
    {
        int value = IntegerReader.Read("987654");

        Assertions.AreEqual(int.Parse("987654"), value);
    }

    public void ShouldMatchLibraryParsingWhenInputIsNegative()
    {
        int value = IntegerReader.Read("-987654");

        Assertions.AreEqual(int.Parse("-987654"), value);
    }
}
