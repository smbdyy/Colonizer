using Domain.Fields;

namespace Domain.Spaces;

public static class SpacesFinder
{
    public static readonly Coordinate[] Shifts = {
        new(1, 0),
        new(0, 1),
        new(-1, 0),
        new(0, -1)
    };

    public static SpacesInfo FindSpaces(Field field)
    {
        var context = new SpacesFinderContext(field);

        for (int i = 0; i < field.Size.Height; i++)
        {
            for (int j = 0; j < field.Size.Width; j++)
            {
                if (context.Visited[i, j]) continue;

                ExecuteBfs(new Coordinate(i, j), context);
                context.SpacesCount++;
            }
        }

        return new SpacesInfo(context.Mask, context.SpacesCount);
    }

    private static void ExecuteBfs(Coordinate start, SpacesFinderContext context)
    {
        context.Queue.Enqueue(start);
        context.Visited[start.I, start.J] = true;
        context.Mask[start.I, start.J] = context.SpacesCount;

        while (context.Queue.Count > 0)
        {
            Coordinate current = context.Queue.Peek();
            context.Queue.Dequeue();
            CheckNeighbors(current, context);
        }
    }

    private static void CheckNeighbors(Coordinate current, SpacesFinderContext context)
    {
        var spaceColor = context.Field.PixelAt(current.I, current.J).Color;
        foreach (Coordinate shift in Shifts)
        {
            Coordinate neighbor = current.ShiftedTo(shift);
            int i = neighbor.I;
            int j = neighbor.J;

            if (!context.Field.IsInBounds(i, j) || context.Visited[i, j] ||
                context.Field.PixelAt(i, j).Color != spaceColor)
            {
                continue;
            }

            context.Visited[i, j] = true;
            context.Queue.Enqueue(neighbor);
            context.Mask[i, j] = context.SpacesCount;
        }
    }
}