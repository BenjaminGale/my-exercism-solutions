public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0) return [];
        
        var results = new string[subjects.Length];

        for (var i = 0; i < subjects.Length - 1; i++)
            results[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";

        results[^1] = $"And all for the want of a {subjects[0]}.";

        return results;
    }
}
