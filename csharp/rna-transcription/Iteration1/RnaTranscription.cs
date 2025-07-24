using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static Dictionary<char, char> dnaToRnaMap = new()
    {
        { 'G', 'C' },
        { 'C', 'G' },
        { 'T', 'A' },
        { 'A', 'U' }
    };
    
    public static string ToRna(string nucleotide) =>
        string.Concat(nucleotide.Select(dna => dnaToRnaMap[dna]));
}