using System;
using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    private static readonly Dictionary<int, string> Factors = new()
    {
        {3, "Pling"},
        {5, "Plang"},
        {7, "Plong"}
    };

    public static string Convert(int number)
    {
        return string.Join("",
            Factors
                .Where(p => number % p.Key == 0)
                .Select(p => p.Value)
                .DefaultIfEmpty(number.ToString())
        );
    }
}