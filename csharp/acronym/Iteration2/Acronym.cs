using System;
using System.Linq;

public static class Acronym
{
    private static readonly char[] Tokens = {' ', '-', '_'};

    public static string Abbreviate(string phrase) =>
        new string(
            phrase
                .Split(Tokens, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word[..1].ToUpper())
                .SelectMany(word => word)
                .ToArray()
        );
}
