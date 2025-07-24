using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word
            .Replace("-", string.Empty)
            .Replace(" ", string.Empty);

        var uniqueCharacterCount = word
            .ToLower()
            .ToCharArray()
            .Distinct()
            .Count();
        
        return uniqueCharacterCount == word.Length;
    }
}
