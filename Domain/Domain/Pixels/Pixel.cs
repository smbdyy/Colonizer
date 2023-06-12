using Domain.Utils;

namespace Domain.Pixels;

public class Pixel
{
    public Pixel(ConsoleColor color)
    {
        Color = color;
    }

    public Pixel() : this(ConsoleColor.Black) { }

    public ConsoleColor Color { get; set; }

    public void SetRandomColor()
    {
        Color = EnumUtils.GetRandomEnumValue<ConsoleColor>();
    }

    public void SetRandomColorFromPool(ConsoleColor[] colors)
    {
        Color = colors[Random.Shared.Next(colors.Length)];
    }
}