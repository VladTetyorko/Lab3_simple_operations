using Task3.ShapeArea;
using Task3.ShapeArea.Exceptions;
using Task3.ShapeArea.Formatting;
using Task3.ShapeArea.Parsing;

namespace Lab.Tests.Task3.ShapeArea;

public sealed class ShapeAreaServiceTests
{
    public void ShouldReturnSquareAreaWhenSideIsTwoAndAHalf()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.SquareArea(2.5);

        Assertions.AreEqual(6.25, area);
    }

    public void ShouldReturnCircleAreaWhenRadiusIsThree()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.CircleArea(3);

        Assertions.AreEqual(28.2743, AreaAsPrinted(area));
    }

    public void ShouldReturnRectangleAreaWhenSidesAreThreeAndFourAndAHalf()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.RectangleArea(3, 4.5);

        Assertions.AreEqual(13.5, area);
    }

    public void ShouldReturnTriangleAreaWhenBaseIsSixAndHeightIsTwoAndOneTenth()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.TriangleArea(6, 2.1);

        Assertions.AreEqual(6.3, area);
    }

    public void ShouldMatchLibraryPowerWhenSquareSideIsGiven()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.SquareArea(2.5);

        Assertions.AreEqual(Math.Pow(2.5, 2), area);
    }

    public void ShouldMatchLibraryCircleFormulaWhenRadiusIsGiven()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.CircleArea(3);

        Assertions.AreEqual(Math.PI * Math.Pow(3, 2), area);
    }

    public void ShouldReturnTheSameRectangleAreaWhenSidesAreSwapped()
    {
        ShapeAreaService service = new ShapeAreaService();

        double area = service.RectangleArea(3, 4.5);
        double swappedArea = service.RectangleArea(4.5, 3);

        Assertions.AreEqual(swappedArea, area);
    }

    public void ShouldReturnHalfTheRectangleAreaWhenTriangleSharesItsBaseAndHeight()
    {
        ShapeAreaService service = new ShapeAreaService();

        double doubledTriangleArea = service.TriangleArea(6, 2.1) * 2;

        Assertions.AreEqual(service.RectangleArea(6, 2.1), doubledTriangleArea);
    }

    public void ShouldThrowInvalidDimensionExceptionWhenSquareSideIsZero()
    {
        ShapeAreaService service = new ShapeAreaService();
        bool wasThrown = false;

        try
        {
            service.SquareArea(0);
        }
        catch (InvalidDimensionException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "a square side of zero throws InvalidDimensionException");
    }

    public void ShouldThrowInvalidDimensionExceptionWhenCircleRadiusIsNegative()
    {
        ShapeAreaService service = new ShapeAreaService();
        bool wasThrown = false;

        try
        {
            service.CircleArea(-3);
        }
        catch (InvalidDimensionException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "a negative radius throws InvalidDimensionException");
    }

    public void ShouldThrowInvalidDimensionExceptionWhenRectangleHeightIsZero()
    {
        ShapeAreaService service = new ShapeAreaService();
        bool wasThrown = false;

        try
        {
            service.RectangleArea(3, 0);
        }
        catch (InvalidDimensionException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "a rectangle height of zero throws InvalidDimensionException");
    }

    public void ShouldThrowInvalidDimensionExceptionWhenTriangleBaseIsNegative()
    {
        ShapeAreaService service = new ShapeAreaService();
        bool wasThrown = false;

        try
        {
            service.TriangleArea(-6, 2.1);
        }
        catch (InvalidDimensionException)
        {
            wasThrown = true;
        }

        Assertions.IsTrue(wasThrown, "a negative triangle base throws InvalidDimensionException");
    }

    private static double AreaAsPrinted(double area)
    {
        return DecimalReader.Read(AreaFormatter.Format(area));
    }
}
