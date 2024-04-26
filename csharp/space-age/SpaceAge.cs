using System;

public class SpaceAge
{
    private const double EarthSecondsInYear = 31557600;
    
    private const double EarthYearsOnMercury = 0.2408467;
    private const double EarthYearsOnVenus = 0.61519726;
    private const double EarthYearsOnMars = 1.8808158;
    private const double EarthYearsOnJupiter = 11.862615;
    private const double EarthYearsOnSaturn = 29.447498;
    private const double EarthYearsOnUranus = 84.016846;
    private const double EarthYearsOnNeptune = 164.79132;
    
    private readonly double _ageInSeconds;
    
    public SpaceAge(int ageInSeconds) =>
        _ageInSeconds = ageInSeconds;

    public double OnEarth() =>
        _ageInSeconds / EarthSecondsInYear;

    public double OnMercury() =>
        OnEarth() / EarthYearsOnMercury;

    public double OnVenus() =>
        OnEarth() / EarthYearsOnVenus;

    public double OnMars() =>
        OnEarth() / EarthYearsOnMars;

    public double OnJupiter() =>
        OnEarth() / EarthYearsOnJupiter;

    public double OnSaturn() =>
        OnEarth() / EarthYearsOnSaturn;

    public double OnUranus() =>
        OnEarth() / EarthYearsOnUranus;

    public double OnNeptune() =>
        OnEarth() / EarthYearsOnNeptune;
}