using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    First,
    Second,
    Third,
    Fourth,
    Last,
    Teenth,
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;
    
    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule) =>
        GetAllDates().First(date => date.IsScheduledDay(dayOfWeek, schedule));

    private IEnumerable<DateTime> GetAllDates() =>
        Enumerable
            .Range(1, DateTime.DaysInMonth(_year, _month))
            .Select(day => new DateTime(_year, _month, day));
}

public static class DateTimeExtensions
{
    public static bool IsScheduledDay(this DateTime dateTime, DayOfWeek dayOfWeek, Schedule schedule) =>
        dateTime.DayOfWeek == dayOfWeek && dateTime.IsScheduledDay(schedule);
    
    private static bool IsScheduledDay(this DateTime dateTime, Schedule schedule) =>
        schedule switch
        {
                Schedule.First   => dateTime.Day <= 7,
                Schedule.Second  => dateTime.Day > 7 && dateTime.Day <= 14,
                Schedule.Third   => dateTime.Day > 14 && dateTime.Day <= 21,
                Schedule.Fourth  => dateTime.Day > 21 && dateTime.Day <= 28,
                Schedule.Teenth  => dateTime.Day >= 13 && dateTime.Day <= 19,
                Schedule.Last    => dateTime.AddDays(7).Month != dateTime.Month,
                _                => throw new ArgumentOutOfRangeException(nameof(schedule)),
        };
}
