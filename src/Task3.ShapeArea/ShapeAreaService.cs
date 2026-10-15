namespace Task3.ShapeArea;

using Exceptions;

public sealed class ShapeAreaService
{
    private const double Pi = 3.141592653589793;
    private const double MinimumDimension = 0;
    private const double TriangleFactor = 0.5;
    private const string NonPositiveDimensionMessage = "Every dimension must be greater than zero.";

    public double SquareArea(double side)
    {
        RequirePositive(side);

        return side * side;
    }

    public double CircleArea(double radius)
    {
        RequirePositive(radius);

        return Pi * radius * radius;
    }

    public double RectangleArea(double width, double height)
    {
        RequirePositive(width);
        RequirePositive(height);

        return width * height;
    }

    public double TriangleArea(double baseLength, double height)
    {
        RequirePositive(baseLength);
        RequirePositive(height);

        return baseLength * height * TriangleFactor;
    }

    private static void RequirePositive(double dimension)
    {
        if (dimension <= MinimumDimension)
        {
            throw new InvalidDimensionException(NonPositiveDimensionMessage);
        }
    }
}
