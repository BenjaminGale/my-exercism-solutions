using System;

class RemoteControlCar
{
    private int _distanceDriven;
    private int _batteryPercentage = 100;
    
    public static RemoteControlCar Buy() =>
        new RemoteControlCar();

    public string DistanceDisplay() =>
        $"Driven {_distanceDriven} meters";

    public string BatteryDisplay() =>
        BatteryEmpty ? "Battery empty" : $"Battery at {_batteryPercentage}%";

    public void Drive()
    {
        if (!BatteryEmpty)
        {
            _distanceDriven += 20;
            _batteryPercentage -= 1;
        }
    }

    private bool BatteryEmpty => _batteryPercentage <= 0;
}
