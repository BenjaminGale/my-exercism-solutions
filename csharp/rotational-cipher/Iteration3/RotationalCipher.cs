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
        var offset = Char.IsLower(c) ? 'a' : 'A';

        return (char)((((code - offset) + shiftKey) % 26) + offset);
    }
}
