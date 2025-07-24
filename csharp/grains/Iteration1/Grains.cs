using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64) throw new ArgumentOutOfRangeException();
        
        return (ulong)Math.Pow(2, n-1);
    }

    public static ulong Total() =>
        (ulong)Enumerable
            .Range(1, 64)
            .Select(n => (int)Square(n))
            .Sum();
}
