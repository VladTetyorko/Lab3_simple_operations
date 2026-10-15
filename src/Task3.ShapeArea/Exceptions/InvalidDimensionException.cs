namespace Task3.ShapeArea.Exceptions;

public sealed class InvalidDimensionException : Exception
{
    public InvalidDimensionException(string message) : base(message)
    {
    }
}
