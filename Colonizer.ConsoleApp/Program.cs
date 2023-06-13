using Colonizer.ConsoleApp.Drawing;
using Domain.Fields;

var size = new FieldSize(10, 10);
var field = new Field(size);

var colors = new[] { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red };
field.FillWithRandomColorsFromPool(colors);
field.RecalculateSpaces();

int scale = 2;
var drawer = new FieldDrawer(scale);
Console.SetWindowSize(size.Width * scale + 5, size.Height * scale + 5);

while (true)
{
    drawer.Draw(field);
    field.Mutate();
    Thread.Sleep(400);
}