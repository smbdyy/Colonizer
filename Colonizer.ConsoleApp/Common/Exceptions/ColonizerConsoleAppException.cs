namespace Colonizer.ConsoleApp.Common.Exceptions;

public class ColonizerConsoleAppException : Exception
{
    public ColonizerConsoleAppException(string? message)
        : base(message) { }
}