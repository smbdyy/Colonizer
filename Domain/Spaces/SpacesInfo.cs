using Domain.Common.Exceptions;

namespace Domain.Spaces;

public class SpacesInfo
{
    public SpacesInfo(int[,] mask, int count)
    {
        if (Count <= 0)
        {
            throw IncorrectValueException.MustBePositive(count);
        }

        Mask = mask;
        Count = count;
    }

    public int Count { get; }
    public int[,] Mask { get; }
}