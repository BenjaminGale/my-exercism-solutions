using System;
using System.Linq;

static class LogLine
{
    public static string Message(string logLine) =>
        logLine
            .Substring(logLine.IndexOf(":") + 1)
            .Trim();

    public static string LogLevel(string logLine)
    {
        var startIndex = logLine.IndexOf("[") + 1;
        var numChars = logLine.IndexOf("]") - startIndex;

        return logLine.Substring(startIndex, numChars).ToLower();
    }

    public static string Reformat(string logLine) =>
        $"{Message(logLine)} ({LogLevel(logLine)})";
}
