using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors) =>
        this.sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) =>
        sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum, out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < latestSerialNum)
        {
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            serialNum = latestSerialNum;

            return false;
        }

        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        latestSerialNum = Math.Max(latestSerialNum, serialNum);
        
        return true;
    }

    public static RemoteControlCar Buy() =>
        new RemoteControlCar();
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car) =>
        this.car = car;

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        if (car.GetTelemetryData(ref serialNum, out var batteryPercentage, out var distanceDrivenInMeters) && distanceDrivenInMeters > 0)
        {
            var usagePerMeter = (100 - batteryPercentage) / distanceDrivenInMeters;
            return $"usage-per-meter={usagePerMeter}";
        }

        return "no data";
    }
}
