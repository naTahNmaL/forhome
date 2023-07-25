namespace Common.Exceptions;

public class NullException : Exception
{
    public NullException(string message) : base(message)
    {
    }

    public NullException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
