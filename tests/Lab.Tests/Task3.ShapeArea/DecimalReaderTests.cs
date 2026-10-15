using System.Globalization;
using Task3.ShapeArea.Parsing;

namespace Lab.Tests.Task3.ShapeArea;

public sealed class DecimalReaderTests
{
    public void ShouldReadWholeNumberWhenInputHasNoSeparator()
    {
        double value = DecimalReader.Read("3");

        Assertions.AreEqual(3, value);
    }

    public void ShouldReadDecimalWhenSeparatorIsADot()
    {
        double value = DecimalReader.Read("2.5");

        Assertions.AreEqual(2.5, value);
    }

    public void ShouldReadTheSameValueWhenSeparatorIsAComma()
    {
        double dotValue = DecimalReader.Read("2.5");
        double commaValue = DecimalReader.Read("2,5");

        Assertions.AreEqual(dotValue, commaValue);
    }

    public void ShouldReadSeveralFractionDigitsWhenInputIsPrecise()
    {
        double value = DecimalReader.Read("4.125");

        Assertions.AreEqual(4.125, value);
    }

    public void ShouldReadNegativeValueWhenMinusLeadsTheDigits()
    {
        double value = DecimalReader.Read("-2.5");

        Assertions.AreEqual(-2.5, value);
    }

    public void ShouldTreatMissingFractionAsZeroWhenSeparatorEndsTheInput()
    {
        double value = DecimalReader.Read("7.");

        Assertions.AreEqual(7, value);
    }

    public void ShouldMatchLibraryParsingWhenInputIsDecimal()
    {
        double value = DecimalReader.Read("13.5");

        Assertions.AreEqual(double.Parse("13.5", CultureInfo.InvariantCulture), value);
    }

    public void ShouldMatchLibraryParsingWhenInputHasManyFractionDigits()
    {
        double value = DecimalReader.Read("0.0625");

        Assertions.AreEqual(double.Parse("0.0625", CultureInfo.InvariantCulture), value);
    }
}
