using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColor
{
    private static readonly List<string> _colors = new()
    {
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue", 
        "violet",
        "grey",
        "white"
    };
    
    public static int ColorCode(string color) =>
        _colors.IndexOf(color);

    public static string[] Colors() =>
        _colors.ToArray();
}