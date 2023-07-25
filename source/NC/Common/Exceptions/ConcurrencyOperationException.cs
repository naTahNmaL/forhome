namespace Common.Exceptions;

public class ConcurrencyOperationException : Exception
{
    public ConcurrencyOperationException(string message) : base(message)
    {
    }

    public ConcurrencyOperationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
