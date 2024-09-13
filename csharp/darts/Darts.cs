using System;

public static class Darts
{
    private static double Distance(double x, double y) =>
        Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    
    public static int Score(double x, double y) =>
        Distance(x, y) switch
        {
            > 10 => 0,
            > 5 => 1,
            > 1 => 5,
            >= 0 => 10
        };
}
