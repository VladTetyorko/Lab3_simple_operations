using System.Globalization;

namespace Lab.Tests;

public static class Assertions
{
    private const double Tolerance = 1e-9;
    private const string ExpectedLabel = "expected \"";
    private const string ActualLabel = "\" but was \"";
    private const string ClosingLabel = "\"";
    private const string TrueConditionLabel = "expected true: ";
    private const string FalseConditionLabel = "expected false: ";

    public static void AreEqual(string expected, string actual)
    {
        if (expected != actual)
        {
            throw new AssertionException(ExpectedLabel + expected + ActualLabel + actual + ClosingLabel);
        }
    }

    public static void AreEqual(double expected, double actual)
    {
        if (Math.Abs(expected - actual) > Tolerance)
        {
            throw new AssertionException(ExpectedLabel
                                         + expected.ToString(CultureInfo.InvariantCulture)
                                         + ActualLabel
                                         + actual.ToString(CultureInfo.InvariantCulture)
                                         + ClosingLabel);
        }
    }

    public static void AreEqual(int expected, int actual)
    {
        if (expected != actual)
        {
            throw new AssertionException(ExpectedLabel
                                         + expected.ToString(CultureInfo.InvariantCulture)
                                         + ActualLabel
                                         + actual.ToString(CultureInfo.InvariantCulture)
                                         + ClosingLabel);
        }
    }

    public static void IsTrue(bool condition, string description)
    {
        if (!condition)
        {
            throw new AssertionException(TrueConditionLabel + description);
        }
    }

    public static void IsFalse(bool condition, string description)
    {
        if (condition)
        {
            throw new AssertionException(FalseConditionLabel + description);
        }
    }
}
