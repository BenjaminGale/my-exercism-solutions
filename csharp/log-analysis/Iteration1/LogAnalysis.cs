using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string input, string delimiter) =>
        input.Substring(input.IndexOf(delimiter) + delimiter.Length);

    public static string SubstringBetween(this string input, string startDelimiter, string endDelimiter)
    {
        var start = input.IndexOf(startDelimiter) + startDelimiter.Length;
        var numChars = input.IndexOf(endDelimiter) - start;

        return input.Substring(start, numChars);
    }

    public static string Message(this string input) =>
        input.SubstringAfter(": ");

    public static string LogLevel(this string input) =>
        input.SubstringBetween("[", "]");
}