using Domain.Fields;
using Domain.Utils;

namespace Domain.Spaces;

public class SpacesFinderContext
{
    public SpacesFinderContext(Field field)
    {
        Field = field;
        Visited = new bool[field.Size.Height, field.Size.Width];
        Mask = new int[field.Size.Height, field.Size.Width];
        Queue = new Queue<Coordinate>();
        SpacesCount = 0;

        ArrayUtils.FillTwoDimArray(Mask, -1);
        ArrayUtils.FillTwoDimArray(Visited, false);
    }

    public Field Field { get; }
    public bool[,] Visited { get; }
    public int[,] Mask { get; }
    public int SpacesCount { get; set; }
    public Queue<Coordinate> Queue { get; }
}