using System;
using System.Collections.Generic;
using System.Linq;

public interface IRemoteControlCar
{
    void Drive();
    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive() =>
        DistanceTravelled += 10;

    public int CompareTo(ProductionRemoteControlCar car) =>
        DistanceTravelled.CompareTo(car.DistanceTravelled);
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive() =>
        DistanceTravelled += 20;
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1, ProductionRemoteControlCar prc2)
    {
        return new[] { prc1, prc2 }.OrderBy(p => p.NumberOfVictories).ToList();
    }
}
