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
        InitializePixels();

        var spacesMask = new int[Size.Height, Size.Width];
        _spacesInfo = new SpacesInfo(spacesMask, 1);
    }

    private void InitializePixels()
    {
        for (int i = 0; i < Size.Height; i++)
        {
            for (int j = 0; j < Size.Width; j++)
            {
                _pixels[i, j] = new Pixel();
            }
        }
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

    public void Mutate()
    {
        ConsoleColor[] spaceColors = MapSpacesToColors();
        var candidates = GetColorChangeCandidates().ToArray();

        for (int i = 0; i < SpacesCount; i++)
        {
            var candidatesForCurrentSpace = candidates[i].ToArray();
            int randomPixelNumber = Random.Shared.Next(candidatesForCurrentSpace.Length);
            Coordinate pixel = candidatesForCurrentSpace[randomPixelNumber];

            _pixels[pixel.I, pixel.J].Color = spaceColors[i];
        }

        RecalculateSpaces();
    }

    private ConsoleColor[] MapSpacesToColors()
    {
        var colors = new ConsoleColor[SpacesCount];
        for (int i = 0; i < Size.Height; i++)
        {
            for (int j = 0; j < Size.Width; j++)
            {
                colors[SpaceNumberAt(i, j)] = _pixels[i, j].Color;
            }
        }

        return colors;
    }

    private IEnumerable<IEnumerable<Coordinate>> GetColorChangeCandidates()
    {
        var colorChangeCandidates = new List<Coordinate>[SpacesCount];
        Array.Fill(colorChangeCandidates, new List<Coordinate>());
        for (int i = 0; i < Size.Height; i++)
        {
            for (int j = 0; j < Size.Width; j++)
            {
                var currentCoordinate = new Coordinate(i, j);
                AddNeighborsFromDifferentSpaces(currentCoordinate, colorChangeCandidates);
            }
        }

        return colorChangeCandidates;
    }

    private void AddNeighborsFromDifferentSpaces(
        Coordinate currentCoordinate, IReadOnlyList<List<Coordinate>> candidates)
    {
        var currentCoordinateSpace = SpaceNumberAt(currentCoordinate.I, currentCoordinate.J);
        foreach (Coordinate shift in SpacesFinder.Shifts)
        {
            var neighbor = currentCoordinate.ShiftedTo(shift);
            int i = neighbor.I;
            int j = neighbor.J;
            if (IsInBounds(i, j) && SpaceNumberAt(i, j) != currentCoordinateSpace)
            {
                candidates[currentCoordinateSpace].Add(neighbor);
            }
        }
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

    public void FillWithRandomColorsFromPool(ConsoleColor[] colors)
    {
        for (int i = 0; i < Size.Height; i++)
        {
            for (int j = 0; j < Size.Width; j++)
            {
                _pixels[i, j].SetRandomColorFromPool(colors);
            }
        }
    }

    public bool IsInBounds(int i, int j)
    {
        return i >= 0 && j >= 0 && i < Size.Height && j < Size.Width;
    }
}