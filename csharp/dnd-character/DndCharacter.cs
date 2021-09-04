using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    private DndCharacter() { }
    
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    
    public int Hitpoints => 10 + Modifier(Constitution);

    public static int Modifier(int score) =>
        (int)Math.Floor((score - 10) / 2.0);
    
    public static int Ability() =>
        SixSidedDie
            .GetDiceRolls(4)
            .OrderByDescending(score => score)
            .Take(3)
            .Sum();

    public static DndCharacter Generate() =>
        new DndCharacter()
        {
            Strength = Ability(),
            Dexterity = Ability(),
            Constitution = Ability(),
            Intelligence = Ability(),
            Wisdom = Ability(),
            Charisma = Ability()
        };
}

public static class SixSidedDie
{
    private static Random _random = new Random();
    
    public static IEnumerable<int> GetDiceRolls(int number) =>
        GetDiceRolls().Take(number);
    
    public static IEnumerable<int> GetDiceRolls()
    {
        while (true)
            yield return Roll();
    }

    public static int Roll() => _random.Next(1, 7);
}
