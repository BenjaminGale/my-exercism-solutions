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
        int offset = Char.IsLower(c) ? (int)'a' : (int)'A';

        return (char)((((code - offset) + shiftKey) % 26) + offset);
    }
}
