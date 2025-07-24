using System;
using System.Linq;

public static class Acronym
{
    private static readonly char[] Tokens = {' ', '-', '_'};

    public static string Abbreviate(string phrase)
    {
        var letters = phrase
            .Split(Tokens, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => word[..1].ToUpper());

        return string.Join(string.Empty, letters);
    }
}