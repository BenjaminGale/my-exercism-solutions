using System;

public static class Leap
{
    public static bool IsLeapYear(int year) =>
        year.IsDivisibleBy(4) && !year.IsDivisibleBy(100) || year.IsDivisibleBy(400);
}

public static class LeapExtensions
{
    public static bool IsDivisibleBy(this int year, int divisor) =>
        year % divisor == 0;
}