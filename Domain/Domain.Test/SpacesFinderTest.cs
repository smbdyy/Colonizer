using System;
using System.Collections.Generic;
using Domain.Fields;
using Xunit;

namespace Domain.Test;

public class SpacesFinderTest
{
    private const ConsoleColor A = ConsoleColor.Black;
    private const ConsoleColor B = ConsoleColor.Red;
    private const ConsoleColor C = ConsoleColor.Blue;
    private const ConsoleColor D = ConsoleColor.Yellow;
    private const ConsoleColor E = ConsoleColor.Magenta;
    private const ConsoleColor F = ConsoleColor.Green;
    private const ConsoleColor G = ConsoleColor.Cyan;
    private const ConsoleColor H = ConsoleColor.Gray;
    private const ConsoleColor I = ConsoleColor.White;


    [Theory]
    [MemberData(nameof(SpacesData))]
    public void ShouldFindSpacesCorrectly(ConsoleColor[,] colorsMatrix, int[,] spaces, int spacesCount)
    {
        var size = new FieldSize(colorsMatrix.GetLength(0), colorsMatrix.GetLength(1));
        var field = new Field(size);

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                field.PixelAt(i, j).Color = colorsMatrix[i, j];
            }
        }

        field.RecalculateSpaces();
        Assert.Equal(spacesCount, field.SpacesCount);

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                Assert.Equal(spaces[i, j], field.SpaceNumberAt(i, j));
            }
        }
    }

    public static IEnumerable<object> SpacesData()
    {
        var matrix = new[,]
        {
            { A, A, A },
            { A, A, A },
            { A, A, A }
        };
        var spaces = new[,]
        {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

        yield return new object[] { matrix, spaces, 1 };

        matrix = new[,]
        {
            { A, A, B, B },
            { A, A, B, B },
            { C, C, D, D }
        };
        spaces = new[,]
        {
            { 0, 0, 1, 1 },
            { 0, 0, 1, 1 },
            { 2, 2, 3, 3 }
        };

        yield return new object[] { matrix, spaces, 4 };

        matrix = new[,]
        {
            { A, B, C },
            { D, E, F },
            { G, H, I }
        };
        spaces = new[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };

        yield return new object[] { matrix, spaces, 9 };

        matrix = new[,]
        {
            { A, A, B, B, B, C, C, D, D, D },
            { A, A, B, B, B, C, C, D, D, D },
            { E, E, F, F, F, G, G, H, H, H },
            { E, E, F, F, F, G, G, A, A, H }
        };

        spaces = new[,]
        {
            { 0, 0, 1, 1, 1, 2, 2, 3, 3, 3 },
            { 0, 0, 1, 1, 1, 2, 2, 3, 3, 3 },
            { 4, 4, 5, 5, 5, 6, 6, 7, 7, 7 },
            { 4, 4, 5, 5, 5, 6, 6, 8, 8, 7 }
        };

        yield return new object[] { matrix, spaces, 9 };
    }
}