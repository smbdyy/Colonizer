using Domain.Common.Exceptions;

namespace Domain.Fields;

public struct FieldSize
{
    public FieldSize(int height, int width)
    {
        Height = ValidatePositive(height);
        Width = ValidatePositive(width);
    }

    public int Width { get; }
    public int Height { get; }

    private static int ValidatePositive(int value)
    {
        if (value <= 0) throw IncorrectValueException.MustBePositive(value);
        return value;
    }
}