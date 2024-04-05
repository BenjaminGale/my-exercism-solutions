using System;

public class WeighingMachine
{
    private double _weight;
    
    public WeighingMachine(double precision) =>
        Precision = precision;
    
    public double Precision { get; }

    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();

            _weight = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            var formatString = $"{{0:F{Precision}}} kg";
            var adjustedWeight = Weight - TareAdjustment;
        
            return string.Format(formatString, adjustedWeight);
        }
    }

    public double TareAdjustment { get; set; } = 5.0;
}
