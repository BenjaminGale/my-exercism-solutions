using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;
    private readonly IEnumerable<char> _orderedBaseWordChars;
    
    public Anagram(string baseWord)
    {
        _baseWord = baseWord.ToLower();
        _orderedBaseWordChars = _baseWord.OrderBy(s => s).ToArray();
    }

    public string[] FindAnagrams(string[] potentialMatches) =>
        potentialMatches
            .Where(match => match.Length == _baseWord.Length)
            .Where(match => IsAnagram(match.ToLower()))
            .ToArray();
    
    private bool IsAnagram(string potentialMatch) =>
        potentialMatch != _baseWord &&
        potentialMatch.OrderBy(s => s).SequenceEqual(_orderedBaseWordChars);
}