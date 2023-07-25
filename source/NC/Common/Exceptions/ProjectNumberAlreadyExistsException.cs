namespace Common.Exceptions;

public class ProjectNumberAlreadyExistsException : Exception
{
    public ProjectNumberAlreadyExistsException(string message) : base(message)
    {
    }

    public ProjectNumberAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
