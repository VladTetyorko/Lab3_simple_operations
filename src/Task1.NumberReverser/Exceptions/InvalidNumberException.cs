namespace Task1.NumberReverser.Exceptions;

public sealed class InvalidNumberException : Exception
{
    public InvalidNumberException(string message) : base(message)
    {
    }
}