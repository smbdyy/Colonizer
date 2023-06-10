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
        var field = context.Field;
        var spaceColor = field.PixelAt(start.I, start.J).Color;
        var spacesCount = context.SpacesCount;
        var queue = context.Queue;
        var visited = context.Visited;
        var mask = context.Mask;

        queue.Enqueue(start);
        visited[start.I, start.J] = true;
        mask[start.I, start.J] = spacesCount;

        while (queue.Count > 0)
        {
            Coordinate current = queue.Peek();
            queue.Dequeue();

            foreach (Coordinate shift in Shifts)
            {
                var next = current.ShiftedTo(shift);
                int i = next.I;
                int j = next.J;
                if (!field.IsInBounds(i, j) || visited[i, j] || field.PixelAt(i, j).Color != spaceColor)
                {
                    continue;
                }

                visited[i, j] = true;
                queue.Enqueue(next);
                mask[i, j] = spacesCount;
            }
        }
    }
}