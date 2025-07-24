using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) =>
        new string(text.Select(c => Rotate(c, shiftKey)).ToArray());

    public static char Rotate(char c, int shiftKey)
    {
        if (!Char.IsLetter(c)) return c;
        
        var code = (int)c;
        
        if (code >= 65 && code <= 90)
            return (char)((((code - (int)'A') + shiftKey) % 26) + (int)'A');

        if (code >= 97 && code <= 122)
            return (char)((((code - (int)'a') + shiftKey) % 26) + (int)'a');

        return c;
    }
}
