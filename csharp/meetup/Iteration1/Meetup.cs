using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
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

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var days = GetAllDates().Where(date => date.DayOfWeek == dayOfWeek);

        switch (schedule)
        {
            case Schedule.First:
                return days.First();
            case Schedule.Second:
                return days.Skip(1).First();
            case Schedule.Third:
                return days.Skip(2).First();
            case Schedule.Fourth:
                return days.Skip(3).First();
            case Schedule.Teenth:
                return days.First(date => date.Day >= 13 && date.Day <= 19);
            case Schedule.Last:
                return days.Last();
            default:
                return days.First();
        }
    }

    private IEnumerable<DateTime> GetAllDates() =>
        Enumerable
            .Range(1, DateTime.DaysInMonth(_year, _month))
            .Select(day => new DateTime(_year, _month, day));
}