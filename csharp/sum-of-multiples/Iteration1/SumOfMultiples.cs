using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) =>
        multiples
            .Where(m => m != 0)
            .Select(m => Enumerable.Range(1, max - 1).Where(n => n % m == 0))
            .SelectMany(ms => ms)
            .Distinct()
            .Sum();
}
