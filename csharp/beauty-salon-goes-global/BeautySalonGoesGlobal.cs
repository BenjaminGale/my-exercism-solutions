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
        var (timeZoneId, _) = GetTimeInfo(location);
        
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

        var (timeZoneId, _) = GetTimeInfo(location);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(sevenDaysAgo);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var (_, cultureCode) = GetTimeInfo(location);
        var culture = CultureInfo.GetCultureInfo(cultureCode);
        
        return DateTime.TryParse(dtStr, culture, out var dateTime) ? dateTime : new DateTime(1, 1, 1);
    }

    private static (string TimeZoneId, string CultureCode) GetTimeInfo(Location location)
    {
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        return location switch
        {
            Location.NewYork => (isWindows ? "Eastern Standard Time" : "America/New_York", "en-US"),
            Location.London => (isWindows ? "GMT Standard Time" : "Europe/London", "en-GB"),
            Location.Paris => (isWindows ? "W. Europe Standard Time" : "Europe/Paris", "fr-FR")
        };
    }
}
