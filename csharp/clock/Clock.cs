using System;

public class Clock
{
    private const int MinutesPerDay = 24 * 60;
    
    private readonly int _hours;
    private readonly int _minutes;
    
    public Clock(int hours, int minutes)
    {
        var totalMinutes = (hours * 60) + minutes;
        
        totalMinutes = (totalMinutes % (MinutesPerDay) + (MinutesPerDay)) % (MinutesPerDay);
        
        _hours = totalMinutes / 60;
        _minutes = totalMinutes % 60;
    }

    public Clock Add(int minutesToAdd) =>
        new Clock(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) =>
        new Clock(_hours, _minutes - minutesToSubtract);

    public override string ToString() =>
        $"{_hours:00}:{_minutes:00}";

    public override bool Equals(object obj)
    {
        var other = obj as Clock;
        
        if (other is null) return false;

        return this._hours == other._hours
            && this._minutes == other._minutes;
    }
}
