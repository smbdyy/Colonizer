using Domain.Fields;

namespace Colonizer.ConsoleApp.Drawing;

public class FieldDrawer
{
    private ConsoleColor[,]? prevMap;

    public void Draw(Field field)
    {
        var backgroundColor = Console.BackgroundColor;
        if (prevMap == null || field.Size.Height != prevMap.GetLength(0) || field.Size.Width != prevMap.GetLength(1))
        {
            DrawFully(field);
        }
        else
        {
            DrawIncremental(field);
        }

        Console.BackgroundColor = backgroundColor;
        Console.SetCursorPosition(0, field.Size.Height);
    }

    private void DrawFully(Field field)
    {
        var size = field.Size;
        prevMap = new ConsoleColor[size.Height, size.Width];

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                var color = field.PixelAt(i, j).Color;
                prevMap[i, j] = color;
                Console.BackgroundColor = color;
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }

    private void DrawIncremental(Field field)
    {
        for (int i = 0; i < field.Size.Height; i++)
        {
            for (int j = 0; j < field.Size.Width; j++)
            {
                var color = field.PixelAt(i, j).Color;
                if (prevMap![i, j] == color) continue;

                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = color;
                Console.Write(' ');
                prevMap[i, j] = color;
            }
        }
    }
}