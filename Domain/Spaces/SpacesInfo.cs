namespace Domain.Spaces;

public class SpacesInfo
{
    private readonly int[,] _mask;

    public SpacesInfo(int[,] mask, int count)
    {
        _mask = mask;
        Count = count;
    }

    public int Count { get; }

    public int SpaceNumberAt(int i, int j)
    {
        if (i < 0 || j < 0 || i >= _mask.GetLength(0) || j >= _mask.GetLength(1))
        {
            throw new NotImplementedException();
        }

        return _mask[i, j];
    }
}