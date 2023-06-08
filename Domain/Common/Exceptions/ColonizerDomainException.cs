namespace Domain.Common.Exceptions;

public class ColonizerDomainException : Exception
{
    public ColonizerDomainException(string? message)
        : base(message) { }
}