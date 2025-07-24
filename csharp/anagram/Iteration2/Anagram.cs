using System;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;
    
    public Anagram(string baseWord) =>
        _baseWord = baseWord;

    public string[] FindAnagrams(string[] potentialMatches) =>
        potentialMatches
            .Where(match => match.Length == _baseWord.Length)
            .Where(match => IsAnagram(match.ToLower(), _baseWord.ToLower()))
            .ToArray();

    private bool IsAnagram(string left, string right) =>
        left != right &&
        left.OrderBy(s => s).SequenceEqual(right.OrderBy(s => s));
}