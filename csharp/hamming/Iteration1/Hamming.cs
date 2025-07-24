using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException();
        
        return firstStrand
            .Zip(secondStrand, (first, second) => (first, second))
            .Select(pair => pair.Item1 == pair.Item2 ? 0 : 1)
            .Sum();
    }
}