using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        var successPercentage = speed switch
        {
            0 => 0.0,
            >= 1 and <= 4 => 100.0,
            >= 5 and <= 8 => 90.0,
            9 => 80.0,
            _ => 77.0
        };

        return 0.01 * successPercentage;
    }
    
    public static double ProductionRatePerHour(int speed) =>
         CarsPerHour(speed) * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) =>
        (int)ProductionRatePerHour(speed) / 60;

    private static double CarsPerHour(int speed) =>
        221 * speed;
}
