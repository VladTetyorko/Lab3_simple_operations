namespace Task2.WordRemover.Exceptions;

public sealed class InvalidWordCountException : Exception
{
    public InvalidWordCountException(string message) : base(message)
    {
    }
}
