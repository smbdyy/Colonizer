using Domain.Pixels;

namespace Domain.Fields;

public class FieldRow
{
    private readonly Pixel[] _pixels;

    public FieldRow(int size)
    {
        if (size <= 0)
        {
            throw new NotImplementedException();
        }

        _pixels = new Pixel[size];
    }

    public IReadOnlyCollection<Pixel> Pixels => _pixels;

    public void FillWithRandomColors()
    {
        foreach (var pixel in Pixels)
        {
            pixel.SetRandomColor();
        }
    }
}