using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> codonToProteinMap =
        Protein
            .AllProteins
            .Where(protein => protein != Protein.Stop)
            .SelectMany(protein => protein.Mappings)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    
    public static string[] Proteins(string strand)
    {
        return Enumerable
            .Range(0, strand.Length / 3)
            .Select(i => strand.Substring(i * 3, 3))
            .TakeWhile(codon => !Protein.Stop.Codons.Contains(codon))
            .Select(codon => codonToProteinMap[codon])
            .ToArray();
    }
}

public sealed class Protein
{
    public static readonly Protein Stop = Protein.Of("STOP", new[] { "UAA", "UAG", "UGA" });

    public static readonly List<Protein> AllProteins = new()
    {
        Protein.Of("Methionine", new[] { "AUG" }),
        Protein.Of("Phenylalanine", new[] { "UUU", "UUC" }),
        Protein.Of("Leucine", new[] { "UUA", "UUG" }),
        Protein.Of("Serine", new[] { "UCU", "UCC", "UCA", "UCG" }),
        Protein.Of("Tyrosine", new[] { "UAU", "UAC" }),
        Protein.Of("Cysteine", new[] { "UGU", "UGC" }),
        Protein.Of("Tryptophan", new[] { "UGG" }),
        Protein.Stop
    };
    
    public string Name { get; }
    public IEnumerable<string> Codons { get; }

    private Protein(string name, IEnumerable<string> codons)
    {
        Name = name;
        Codons = codons;
    }
    
    public static Protein Of(string name, IEnumerable<string> codons) =>
        new Protein(name, codons);

    public IEnumerable<KeyValuePair<string, string>> Mappings =>
        Codons.Select(codon => new KeyValuePair<string, string>(codon, Name));

    public override bool Equals(object other)
    {
        if (other is null) return false;
        if (object.ReferenceEquals(this, other)) return true;

        var otherProtein = other as Protein;

        if (otherProtein is null) return false;

        return this.Name == otherProtein.Name
            && this.Codons.SequenceEqual(otherProtein.Codons);
    }
}