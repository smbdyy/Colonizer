using Domain.Common.Exceptions;
using Domain.Pixels;
using Domain.Spaces;

namespace Domain.Fields;

public class Field
{
    private Pixel[,] _pixels;
    private SpacesInfo _spacesInfo;

    public Field(FieldSize initialSize)
    {
        Size = initialSize;
        _pixels = new Pixel[Size.Height, Size.Width];
        var spacesMask = new int[Size.Height, Size.Width];
        _spacesInfo = new SpacesInfo(spacesMask, 1);
    }

    public FieldSize Size { get; private set; }

    public int SpacesCount => _spacesInfo.Count;

    public int SpaceNumberAt(int i, int j)
    {
        if (!IsInBounds(i, j))
        {
            throw OutOfBoundsException.TwoDimIndex(i, j);
        }

        return _spacesInfo.Mask[i, j];
    }

    public void RecalculateSpaces()
    {
        _spacesInfo = SpacesFinder.FindSpaces(this);
    }

    public Pixel PixelAt(int i, int j)
    {
        if (!IsInBounds(i, j))
        {
            throw OutOfBoundsException.TwoDimIndex(i, j);
        }

        return _pixels[i, j];
    }

    public void Resize(FieldSize newSize)
    {
        _pixels = new Pixel[newSize.Height, newSize.Width];
        Size = newSize;
    }

    public void FillWithRandomColors()
    {
        for (int i = 0; i < Size.Height; i++)
        {
            for (int j = 0; j < Size.Width; j++)
            {
                _pixels[i, j].SetRandomColor();
            }
        }
    }

    public bool IsInBounds(int i, int j)
    {
        return i >= 0 && j >= 0 && i < Size.Height && j < Size.Width;
    }
}