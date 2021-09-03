using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) =>
        this.birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => birdsPerDay.Last();

    public int IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() => birdsPerDay.Any(birdCount => birdCount == 0);

    public int CountForFirstDays(int numberOfDays) => birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => birdsPerDay.Count(birdCount => birdCount >= 5);
}
