using Domain.Common.Exceptions;

namespace Domain.Fields;

public struct FieldSize
{
    public FieldSize(int width, int height)
    {
        Width = ValidatePositive(width);
        Height = ValidatePositive(height);
    }

    public int Width { get; }
    public int Height { get; }

    private static int ValidatePositive(int value)
    {
        if (value <= 0) throw IncorrectValueException.MustBePositive(value);
        return value;
    }
}