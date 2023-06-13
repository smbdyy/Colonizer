namespace Domain.Common.Exceptions;

public class IncorrectValueException : ColonizerDomainException
{
    public IncorrectValueException(string? message)
        : base(message) { }

    public static IncorrectValueException MustBePositive(int value)
        => new($"value must be positive, {value} is given");

    public static IncorrectValueException Fraction(float value)
        => new($"probability value must be >= 0 and <= 1, {value} is given");
}