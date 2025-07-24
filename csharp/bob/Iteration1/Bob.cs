using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (IsSilent(statement)) return "Fine. Be that way!";

        var isShouting = IsShouting(statement);
        var isQuestion = IsQuestion(statement);
        
        if (isQuestion && isShouting) return "Calm down, I know what I'm doing!";
        if (isQuestion) return "Sure.";
        if (isShouting) return "Whoa, chill out!";

        return "Whatever.";
    }

    private static bool IsQuestion(string statement) =>
        statement.Length > 0 && statement.Trim()[^1] == '?';

    private static bool IsShouting(string statement) =>
        statement.Any(c => Char.IsLetter(c)) && statement.Where(c => Char.IsLetter(c)).All(c => Char.IsUpper(c));

    private static bool IsSilent(string statement) =>
        string.IsNullOrWhiteSpace(statement) || statement.All(c => Char.IsControl(c));
}
