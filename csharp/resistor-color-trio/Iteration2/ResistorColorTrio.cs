using System;

public static class ResistorColorTrio
{
    public static string Label(string[] colors)
    {
        long value = (Value(colors[0]) * 10) + Value(colors[1]);
        var numZeros = Value(colors[2]);

        for (int i = 0; i < numZeros; i++)
            value *= 10;
        
        return value switch
        {
            >= 1_000_000_000 => $"{value / 1_000_000_000} gigaohms",
            >= 1_000_000     => $"{value / 1_000_000} megaohms",
            >= 1_000         => $"{value / 1_000} kiloohms",
            _                => $"{value} ohms"
        };
    }

    private static int Value(string color) =>
        color switch
        {
            "black" => 0,
            "brown" => 1,
            "red" => 2,
            "orange" => 3,
            "yellow" => 4,
            "green" => 5,
            "blue" => 6,
            "violet" => 7,
            "grey" => 8,
            "white" => 9
        };
}
