using System;
using System.Linq;
using System.Collections.Generic;

public static class Languages
{
    public static List<string> NewList() =>
        new List<string>();

    public static List<string> GetExistingLanguages() =>
        new List<string> { "C#", "Clojure", "Elm" };

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) =>
        languages.Count;

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages) =>
        languages.FirstOrDefault() == "C#" || languages.Contains("C#") && languages.Count == 2 || languages.Count == 3;

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages) =>
        languages.Count == languages.Distinct().Count();
}
