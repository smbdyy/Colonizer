using Domain.Pixels;
using Domain.Spaces;

namespace Domain.Fields;

public class Field
{
    private Pixel[,] _pixels;

    public Field(FieldSize initialSize)
    {
        _pixels = new Pixel[initialSize.Height, initialSize.Width];
        Size = initialSize;
    }

    public FieldSize Size { get; private set; }
    public SpacesInfo? SpaceInfo { get; private set; }

    public Pixel PixelAt(int i, int j)
    {
        if (!IsInBounds(i, j))
        {
            throw new NotImplementedException();
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