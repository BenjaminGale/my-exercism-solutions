using System;
using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var matches = new List<char>();
        
        foreach (var c in input)
        {
            if (c.IsOpenBracket())
            {
                matches.Add(c);
                continue;
            }
            
            if (c.IsCloseBracket())
            {
                var openBracket = c.GetOpenBracket();
                
                if (matches.Count == 0) return false;
                if (matches[matches.Count - 1] != openBracket) return false;
                    
                matches.RemoveAt(matches.Count - 1);
            }
        }

        return matches.Count == 0;
    }   
}

public static class Extensions
{
    public static char GetOpenBracket(this char c) =>
        c switch
        {
            ']' => '[',
            '}' => '{',
            ')' => '(',
            _ => throw new InvalidOperationException(),
        };
    
    public static bool IsOpenBracket(this char c) =>
        c is '[' or '{' or '(';

    public static bool IsCloseBracket(this char c) =>
        c is ']' or '}' or ')';
}
