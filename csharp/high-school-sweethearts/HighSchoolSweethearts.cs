using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) =>
        $"{studentA, 29} ♡ {studentB, -29}";

    public static string DisplayBanner(string studentA, string studentB) =>
        $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
** {studentA.Trim(),9}  +  {studentB.Trim(),-9} **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";

    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
    {
        return string.Format(
            new CultureInfo("de-DE"),
            "{0} and {1} have been dating since {2:d} - that's {3:n2} hours",
            studentA, studentB, start, hours
        );
    }
}
