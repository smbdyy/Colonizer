using Domain.Common.Exceptions;

namespace Domain.MutationProbabilityCalculators;

public struct Fraction
{
    public Fraction(float value)
    {
        if (value is < 0 or > 1)
        {
            throw IncorrectValueException.Fraction(value);
        }

        Value = value;
    }

    public float Value { get; }

    public static implicit operator Fraction(float value) => new(value);
    public static implicit operator float(Fraction f) => f.Value;
}