namespace Domain.Common.Exceptions;

public class OutOfBoundsException : ColonizerDomainException
{
    public OutOfBoundsException(string? message)
        : base(message) { }

    public static OutOfBoundsException TwoDimIndex(int i, int j)
        => new($"index [{i}, {j}] is out of field's bounds");
}