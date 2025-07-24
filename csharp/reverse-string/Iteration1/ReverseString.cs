using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var reversedChars = new char[input.Length];
        
        for (int i = 0; i < input.Length; i++)
            reversedChars[i] = input[input.Length - 1 - i];

        return new string(reversedChars);
    }
}
