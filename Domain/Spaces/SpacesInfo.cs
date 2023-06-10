using Domain.Common.Exceptions;

namespace Domain.Spaces;

public class SpacesInfo
{
    private readonly int[,] _mask;

    public SpacesInfo(int[,] mask, int count)
    {
        if (Count <= 0)
        {
            throw IncorrectValueException.MustBePositive(count);
        }

        _mask = mask;
        Count = count;
    }

    public int Count { get; }

    public int SpaceNumberAt(int i, int j)
    {
        if (i < 0 || j < 0 || i >= _mask.GetLength(0) || j >= _mask.GetLength(1))
        {
            throw OutOfBoundsException.TwoDimIndex(i, j);
        }

        return _mask[i, j];
    }
}