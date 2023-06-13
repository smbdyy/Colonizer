using Colonizer.ConsoleApp.Drawing;
using Domain.Fields;

var size = new FieldSize(30, 30);
var field = new Field(size);

var colors = new[] { ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.Red };
field.FillWithRandomColorsFromPool(colors);
field.RecalculateSpaces();

var drawer = new FieldDrawer();
Console.Clear();
Console.SetWindowSize(size.Width, size.Height);
while (true)
{
    drawer.Draw(field);
    field.Mutate();
    Console.ReadKey();
}