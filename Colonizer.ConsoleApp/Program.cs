using Colonizer.ConsoleApp.Drawing;
using Domain.Fields;

var size = new FieldSize(30, 30);
var field = new Field(size);

var colors = new[] { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red };
field.FillWithRandomColorsFromPool(colors);
field.RecalculateSpaces();

var drawer = new FieldDrawer();
Console.SetWindowSize(size.Width + 5, size.Height + 5);

while (true)
{
    drawer.Draw(field);
    field.Mutate();
    Thread.Sleep(400);
}