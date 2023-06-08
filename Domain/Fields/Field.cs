using Domain.Pixels;

namespace Domain.Fields;

public class Field
{
    private FieldRow[] _rows;

    public Field(FieldSize initialSize)
    {
        _rows = new FieldRow[initialSize.Height];
        for (int i = 0; i < initialSize.Height; i++)
        {
            _rows[i] = new FieldRow(initialSize.Width);
        }
    }

    public IReadOnlyCollection<FieldRow> Rows => _rows;

    public void Resize(FieldSize newSize)
    {
        _rows = new FieldRow[newSize.Height];
        for (int i = 0; i < newSize.Height; i++)
        {
            _rows[i] = new FieldRow(newSize.Width);
        }
    }

    public void FillWithRandomColors()
    {
        foreach (var row in _rows)
        {
            row.FillWithRandomColors();
        }
    }
}