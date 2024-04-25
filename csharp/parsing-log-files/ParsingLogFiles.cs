using System;
using System.Linq;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) =>
        Regex.IsMatch(text, "^\\[(TRC|DBG|INF|WRN|ERR|FTL)\\]");

    public string[] SplitLogLine(string text) =>
        Regex.Split(text, "<[-^*=]+>");

    public int CountQuotedPasswords(string lines) =>
        Regex
            .Matches(lines, "(?i)\\\"[a-zA-Z ]*password[a-zA-Z ]*\\\"", RegexOptions.Multiline)
            .Count;
        
    public string RemoveEndOfLineText(string line) =>
        Regex.Replace(line, "end-of-line[\\d]*", "");

    public string[] ListLinesWithPasswords(string[] lines) =>
        lines
            .Select(ProcessPasswordLine)
            .ToArray();

    private string ProcessPasswordLine(string line)
    {
        var match = Regex.Match(line, "password\\w+", RegexOptions.IgnoreCase);
        return match == Match.Empty
            ? $"--------: {line}"
            : $"{match.Value}: {line}";
    }
}
