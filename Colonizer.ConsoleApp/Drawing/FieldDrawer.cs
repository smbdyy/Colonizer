using Colonizer.ConsoleApp.Common.Exceptions;
using Domain.Fields;

namespace Colonizer.ConsoleApp.Drawing;

public class FieldDrawer
{
    private ConsoleColor[,]? _prevMap;
    private readonly int _scale;

    public FieldDrawer(int scale = 1)
    {
        if (scale < 1)
        {
            throw new ColonizerConsoleAppException($"scale value must be >= 1, {scale} is given");
        }

        _scale = scale;
    }

    public void Draw(Field field)
    {
        var backgroundColor = Console.BackgroundColor;
        if (_prevMap == null || field.Size.Height != _prevMap.GetLength(0) || field.Size.Width != _prevMap.GetLength(1))
        {
            DrawFully(field);
        }
        else
        {
            DrawIncremental(field);
        }

        Console.BackgroundColor = backgroundColor;
        Console.SetCursorPosition(0, field.Size.Height * _scale);
    }

    private void DrawFully(Field field)
    {
        Console.Clear();
        var size = field.Size;
        _prevMap = new ConsoleColor[size.Height, size.Width];

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                var color = field.PixelAt(i, j).Color;
                _prevMap[i, j] = color;
                Console.BackgroundColor = color;
                DrawPixelAt(j * _scale, _scale * (i + 1));
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
                if (_prevMap![i, j] == color) continue;

                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = color;
                DrawPixelAt(j * _scale, _scale * (i + 1));
                _prevMap[i, j] = color;
            }
        }
    }

    private void DrawPixelAt(int left, int top)
    {
        for (int i = 0; i < _scale; i++)
        {
            Console.SetCursorPosition(left, top + i);
            for (int j = 0; j < _scale; j++)
            {
                Console.Write(' ');
            }
        }
    }
}