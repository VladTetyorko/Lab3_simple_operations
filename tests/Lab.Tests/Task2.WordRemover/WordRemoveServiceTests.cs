using Task2.WordRemover;
using Task2.WordRemover.Exceptions;

namespace Lab.Tests.Task2.WordRemover;

public sealed class WordRemoveServiceTests
{
    public void ShouldRemoveTwoWordsWhenSentenceHasThree()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Hello big world", 2);

        Assertions.AreEqual("world", remainder);
    }

    public void ShouldRemoveFourWordsWhenSentenceHasSix()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Nice red car and green eyes", 4);

        Assertions.AreEqual("green eyes", remainder);
    }

    public void ShouldReturnTheWholeTextWhenCountIsZero()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Hello big world", 0);

        Assertions.AreEqual("Hello big world", remainder);
    }

    public void ShouldReturnEmptyTextWhenCountExceedsTheWordNumber()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Hello big world", 5);

        Assertions.AreEqual("", remainder);
    }

    public void ShouldReturnEmptyTextWhenEveryWordIsRemoved()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Hello big world", 3);

        Assertions.AreEqual("", remainder);
    }

    public void ShouldKeepInnerSpacingWhenRemainderIsPadded()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Hello   big     world", 1);

        Assertions.AreEqual("big     world", remainder);
    }

    public void ShouldSkipLeadingSpacesWhenTextStartsWithBlanks()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("   Hello big world", 1);

        Assertions.AreEqual("big world", remainder);
    }

    public void ShouldReturnTheSameRemainderWhenRemovalIsSplitInTwoSteps()
    {
        WordRemoveService service = new WordRemoveService();

        string twoSteps = service.RemoveFirstWords(service.RemoveFirstWords("Nice red car and green eyes", 2), 2);
        string oneStep = service.RemoveFirstWords("Nice red car and green eyes", 4);

        Assertions.AreEqual(oneStep, twoSteps);
    }

    public void ShouldShortenTheTextWhenWordsAreRemoved()
    {
        WordRemoveService service = new WordRemoveService();

        string remainder = service.RemoveFirstWords("Nice red car and green eyes", 2);

        Assertions.IsTrue(remainder.Length < "Nice red car and green eyes".Length,
            "removing words never makes the text longer");
    }

    public void ShouldThrowInvalidWordCountExceptionWhenCountIsNegative()
    {
        WordRemoveService service = new WordRemoveService();
        bool wasThrown = false;

        try
        {
            service.RemoveFirstWords("Hello big world", -1);
        }
        catch (InvalidWordCountException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "a negative count throws InvalidWordCountException");
    }
}
