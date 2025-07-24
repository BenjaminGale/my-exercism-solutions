using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    private static readonly char[] _allowedCharacters = new[] { 'A', 'C', 'G', 'T' };
    
    public static IDictionary<char, int> Count(string sequence) =>
        string.Concat(sequence + "ACGT")
            .Where(IsAllowedCharacter)
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Skip(1).Count());

    private static bool IsAllowedCharacter(char c)
    {
        if (!_allowedCharacters.Contains(c))
            throw new ArgumentException();

        return true;
    }
        
}