using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var result = new StringBuilder();
        var skip = false;
        
        for (var i = 0; i < identifier.Length; i++)
        {
            if (skip)
            {
                skip = false;
                continue;
            }
            
            var c = identifier[i];

            if (c == ' ')
            {
                result.Append('_');
            }
            else if (c == '-')
            {
                result.Append(Char.ToUpper(identifier[i+1]));
                skip = true;
            }
            else if (Char.IsControl(c))
            {
                result.Append("CTRL");
            }
            else if (!skip && Char.IsLetter(c) && !IsGreek(c))
            {    
                result.Append(c);
            }
        }

        return result.ToString();
    }

    private static bool IsGreek(char c) =>
        c >= 'α' && c <= 'ω';
}
