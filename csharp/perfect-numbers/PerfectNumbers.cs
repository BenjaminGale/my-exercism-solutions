using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();
        
        var aliquot = number
            .Factors()
            .Where(n => n != number)
            .Sum();

        if (number == aliquot) return Classification.Perfect;
        if (number < aliquot) return Classification.Abundant;
        return Classification.Deficient;
    }

    public static IEnumerable<int> Factors(this int number) =>
        Enumerable
            .Range(1, (int)Math.Sqrt(number))
            .Where(n => number % n == 0)
            .Select(n => new[] { n, (number / n) })
            .SelectMany(n => n)
            .Distinct();
}
