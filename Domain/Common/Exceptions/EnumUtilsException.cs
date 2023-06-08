namespace Domain.Common.Exceptions;

public class EnumUtilsException : ColonizerDomainException
{
    public EnumUtilsException(string? message)
        : base(message) { }

    public static EnumUtilsException NoValues(Type enumType)
        => new($"enum '{enumType.FullName}' has no values");
}