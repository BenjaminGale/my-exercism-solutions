using System;
using System.Collections.Generic;

public static class Pangram
{
    private static readonly HashSet<char> AllAlphabetCharacters =
        new HashSet<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
    
    public static bool IsPangram(string input)
    {
        var sentence = new HashSet<char>(input.ToUpper().ToCharArray());
        return AllAlphabetCharacters.IsSubsetOf(sentence);
    }
}
