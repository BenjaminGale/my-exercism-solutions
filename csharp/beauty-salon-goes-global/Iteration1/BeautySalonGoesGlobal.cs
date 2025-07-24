using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) =>
        dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var timeZoneId = location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
        };

        return TimeZoneInfo.ConvertTimeToUtc(
            DateTime.Parse(appointmentDateDescription),
            TimeZoneInfo.FindSystemTimeZoneById(timeZoneId)
        );
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30)
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var sevenDaysAgo = dt.AddDays(-7);

        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var timeZoneId = location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
        };

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(sevenDaysAgo);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var cultureCode = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentOutOfRangeException(),
        };
    
        var culture = CultureInfo.GetCultureInfo(cultureCode);
        
        return DateTime.TryParse(dtStr, culture, out var dateTime) ? dateTime : new DateTime(1, 1, 1);
    }
}
