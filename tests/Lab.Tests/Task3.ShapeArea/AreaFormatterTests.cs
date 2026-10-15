using System.Globalization;
using Task3.ShapeArea.Formatting;

namespace Lab.Tests.Task3.ShapeArea;

public sealed class AreaFormatterTests
{
    public void ShouldPrintTwoFractionDigitsWhenAreaIsASquareOfTwoAndAHalf()
    {
        string formatted = AreaFormatter.Format(6.25);

        Assertions.AreEqual("6.25", formatted);
    }

    public void ShouldPrintFourFractionDigitsWhenAreaIsACircleOfRadiusThree()
    {
        string formatted = AreaFormatter.Format(28.274333882308138);

        Assertions.AreEqual("28.2743", formatted);
    }

    public void ShouldPrintOneFractionDigitWhenTrailingZerosAreDropped()
    {
        string formatted = AreaFormatter.Format(13.5);

        Assertions.AreEqual("13.5", formatted);
    }

    public void ShouldPrintOneFractionDigitWhenValueCarriesFloatingPointNoise()
    {
        string formatted = AreaFormatter.Format(6.300000000000001);

        Assertions.AreEqual("6.3", formatted);
    }

    public void ShouldPrintNoSeparatorWhenAreaIsAWholeNumber()
    {
        string formatted = AreaFormatter.Format(4);

        Assertions.AreEqual("4", formatted);
    }

    public void ShouldKeepLeadingFractionZerosWhenAreaIsSmall()
    {
        string formatted = AreaFormatter.Format(0.0625);

        Assertions.AreEqual("0.0625", formatted);
    }

    public void ShouldRoundToFourDigitsWhenAreaIsMorePrecise()
    {
        string formatted = AreaFormatter.Format(1.234567);

        Assertions.AreEqual("1.2346", formatted);
    }

    public void ShouldMatchLibraryFormattingWhenAreaIsACircleOfRadiusThree()
    {
        double area = Math.PI * Math.Pow(3, 2);

        string formatted = AreaFormatter.Format(area);

        Assertions.AreEqual(area.ToString("0.####", CultureInfo.InvariantCulture), formatted);
    }
}
