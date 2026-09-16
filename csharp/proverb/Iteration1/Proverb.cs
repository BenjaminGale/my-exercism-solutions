public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0) return [];
        
        var results = new List<string>();
        var cursor = 0;

        while (cursor < subjects.Length - 1)
        {
            results.Add($"For want of a {subjects[cursor]} the {subjects[cursor + 1]} was lost.");
            cursor ++;
        }

        results.Add($"And all for the want of a {subjects[0]}.");

        return results.ToArray();
    }
}
