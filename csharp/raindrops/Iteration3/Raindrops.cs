using System;
using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    private static readonly List<(int Factor, string Sound)> _raindrops = new()
    {
        (Factor: 3, Sound: "Pling"),
        (Factor: 5, Sound: "Plang"),
        (Factor: 7, Sound: "Plong")  
    };

    public static string Convert(int number) =>
        string.Concat(
            _raindrops
                .Where(raindrop => number % raindrop.Factor == 0)
                .Select(raindrop => raindrop.Sound)
                .DefaultIfEmpty(number.ToString())
        );
}