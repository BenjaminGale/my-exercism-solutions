using System;
using System.Collections.Generic;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category) =>
        category switch
        {
             YachtCategory.Ones           => dice.Tally(1),
             YachtCategory.Twos           => dice.Tally(2),
             YachtCategory.Threes         => dice.Tally(3),
             YachtCategory.Fours          => dice.Tally(4),
             YachtCategory.Fives          => dice.Tally(5),
             YachtCategory.Sixes          => dice.Tally(6),
             YachtCategory.FullHouse      => dice.FullHouse(),
             YachtCategory.FourOfAKind    => dice.FourOfAKind(),
             YachtCategory.LittleStraight => dice.LittleStraight(),
             YachtCategory.BigStraight    => dice.BigStraight(),
             YachtCategory.Choice         => dice.Choice(),
             YachtCategory.Yacht          => dice.Yacht(),
             _                            => 0
        };
}

public static class YachtGameExtensions
{
    public static int Tally(this IEnumerable<int> dice, int number) =>
        dice
            .Where(die => die == number)
            .Sum();

    public static int FullHouse(this IEnumerable<int> dice)
    {
        var groups = dice.GroupBy(die => die);
        var hasTwoOfAKind = groups.Any(g => g.Count() == 2);
        var hasThreeOfAKind = groups.Any(g => g.Count() == 3);

        if (hasTwoOfAKind && hasThreeOfAKind) return dice.Sum();
        return 0;
    }

    public static int Yacht(this IEnumerable<int> dice) =>
        dice
            .GroupBy(die => die)
            .Where(g => g.Count() == 5)
            .Select(g => 50)
            .DefaultIfEmpty(0)
            .First();

    public static int Choice(this IEnumerable<int> dice) =>
        dice.Sum();

    public static int FourOfAKind(this IEnumerable<int> dice) =>
        dice
            .GroupBy(die => die)
            .Where(g => g.Count() >= 4)
            .SelectMany(g => g)
            .Take(4)
            .Sum();

    public static int LittleStraight(this IEnumerable<int> dice) {
        if (dice.OrderBy(die => die).ToList() is [1, 2, 3, 4, 5]) return 30;
        return 0;
    }

    public static int BigStraight(this IEnumerable<int> dice) {
        if (dice.OrderBy(die => die).ToList() is [2, 3, 4, 5, 6]) return 30;
        return 0;
    }
}